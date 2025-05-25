package com.ProyectoEmpresariales.Arma.controller;

import com.ProyectoEmpresariales.Arma.model.Municion;
import com.ProyectoEmpresariales.Arma.servicios.ServicioMunicion;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

@RestController
@CrossOrigin(origins = "*")
@RequestMapping(value = "/Municion")
public class MunicionController {

    @Autowired
    private ServicioMunicion servicioMunicion;

    private final ObjectMapper objectMapper = new ObjectMapper().registerModule(new JavaTimeModule());

    @GetMapping(value = "/healthCheck")
    public String healthCheck() {
        return "service status OK!";
    }

    @GetMapping(value = "/")
    public ResponseEntity<?> getMuniciones() {
        List<Municion> municiones = servicioMunicion.getMuniciones();

        if (municiones.isEmpty()) {
            return new ResponseEntity<>("No hay municiones", HttpStatus.NOT_FOUND);
        }

        ArrayNode arrayNode = objectMapper.valueToTree(municiones);
        return new ResponseEntity<>(arrayNode, HttpStatus.OK);
    }

    @GetMapping(value = "/buscarNombre/")
    public ResponseEntity<?> getPorNombre(@RequestBody JsonNode jsonNode) {
        if (!jsonNode.has("nombre")) {
            return new ResponseEntity<>("Falta nombre", HttpStatus.BAD_REQUEST);
        }

        String nombre = jsonNode.get("nombre").asText();
        Optional<Municion> municionOpt = servicioMunicion.findByNombre(nombre);

        if (municionOpt.isPresent()) {
            return new ResponseEntity<>(municionOpt.get(), HttpStatus.OK);
        }

        return new ResponseEntity<>("Municion no encontrada", HttpStatus.NOT_FOUND);
    }

    @PostMapping(value = "/buscarNombre/")
    public ResponseEntity<?> getPorNombre1(@RequestBody JsonNode jsonNode) {
        return getPorNombre(jsonNode);
    }

    @GetMapping(value = "/buscar/")
    public ResponseEntity<?> getPorID(@RequestBody JsonNode jsonNode) {
        if (!jsonNode.has("id") || !jsonNode.get("id").isNumber()) {
            return new ResponseEntity<>("Se requiere un ID válido", HttpStatus.BAD_REQUEST);
        }

        Long id = jsonNode.get("id").asLong();
        Optional<Municion> municion = servicioMunicion.findById(id);

        if (municion.isPresent()) {
            return new ResponseEntity<>(municion.get(), HttpStatus.OK);
        }

        return new ResponseEntity<>("Municion no encontrada", HttpStatus.NOT_FOUND);
    }

    @PostMapping(value = "/buscar/")
    public ResponseEntity<?> getPorID1(@RequestBody JsonNode jsonNode) {
        return getPorID(jsonNode);
    }

    @PostMapping("/filtrarMunicion")
    public ResponseEntity<?> getMunicionFilter(@RequestBody JsonNode jsonNode) {
        boolean tieneCadenciaMinima = jsonNode.has("cadencia_minima") && jsonNode.get("cadencia_minima").isInt();
        boolean tieneDañoArea = jsonNode.has("danoArea") && jsonNode.get("danoArea").isBoolean();

        if (!tieneCadenciaMinima && !tieneDañoArea) {
            return new ResponseEntity<>("El json debe tener al menos un filtro válido (cadencia_minima o danoArea)",
                    HttpStatus.BAD_REQUEST);
        }

        List<Municion> municionesFiltradas = new ArrayList<>();

        try {
            // Aplicar filtros solo entre municiones activas
            if (tieneCadenciaMinima && tieneDañoArea) {
                // Filtrar por ambos criterios
                int cadenciaMinima = jsonNode.get("cadencia_minima").asInt();
                boolean danoArea = jsonNode.get("danoArea").asBoolean();

                // Usar método del repositorio que filtra por ambos criterios y activo = true
                List<Municion> municionesPorCadencia = servicioMunicion.findByCadenciaMinima(cadenciaMinima);
                for (Municion m : municionesPorCadencia) {
                    if (m.isDañoArea() == danoArea) {
                        municionesFiltradas.add(m);
                    }
                }
            } else if (tieneCadenciaMinima) {
                // Filtrar solo por cadencia mínima (entre municiones activas)
                int cadenciaMinima = jsonNode.get("cadencia_minima").asInt();
                municionesFiltradas = servicioMunicion.findByCadenciaMinima(cadenciaMinima);
            } else {
                // Filtrar solo por daño de área (entre municiones activas)
                boolean danoArea = jsonNode.get("danoArea").asBoolean();
                municionesFiltradas = servicioMunicion.findByDañoArea(danoArea);
            }

            if (municionesFiltradas.isEmpty()) {
                return new ResponseEntity<>("No existen municiones activas con esas características", HttpStatus.NOT_FOUND);
            }

            // Convertir a JSON incluyendo estado activo
            List<Map<String, Object>> municionesDTO = new ArrayList<>();
            for (Municion municion : municionesFiltradas) {
                Map<String, Object> dto = new HashMap<>();
                dto.put("id", municion.getId());
                dto.put("nombre", municion.getNombre());
                dto.put("cadencia", municion.getCadencia());
                dto.put("dañoArea", municion.isDañoArea());
                dto.put("activo", municion.isActivo());
                municionesDTO.add(dto);
            }

            return ResponseEntity.ok()
                    .contentType(org.springframework.http.MediaType.APPLICATION_JSON)
                    .body(municionesDTO);

        } catch (Exception e) {
            return new ResponseEntity<>("Error al filtrar municiones: " + e.getMessage(),
                    HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PostMapping(value = "/")
    public ResponseEntity<?> añadirMunicion(@RequestBody JsonNode jsonNode) {
        try {
            // Validaciones básicas
            if (!jsonNode.has("nombre") || jsonNode.get("nombre").asText().isEmpty()) {
                return new ResponseEntity<>("Munición sin nombre", HttpStatus.BAD_REQUEST);
            }

            if (!jsonNode.has("cadencia") || !jsonNode.get("cadencia").isInt()) {
                return new ResponseEntity<>("Munición sin cadencia válida", HttpStatus.BAD_REQUEST);
            }

            // Crear la munición
            Municion municion = objectMapper.treeToValue(jsonNode, Municion.class);
            Municion savedMunicion = servicioMunicion.añadirMunicion(municion);

            return new ResponseEntity<>(savedMunicion, HttpStatus.CREATED);
        } catch (Exception e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

    @DeleteMapping(value = "/")
    public ResponseEntity<?> eliminarMunicion(@RequestBody JsonNode jsonNode) {
        if (!jsonNode.has("id")) {
            return new ResponseEntity<>("Tienes que proporcionar el ID de la munición", HttpStatus.BAD_REQUEST);
        }

        if (!jsonNode.get("id").isNumber()) {
            return new ResponseEntity<>("El ID debe ser un número", HttpStatus.BAD_REQUEST);
        }

        Long id = jsonNode.get("id").asLong();

        try {
            // Buscar la munición activa
            Optional<Municion> municionOpt = servicioMunicion.findById(id);
            if (!municionOpt.isPresent()) {
                return new ResponseEntity<>("Munición no encontrada", HttpStatus.NOT_FOUND);
            }

            Municion municion = municionOpt.get();

            // Crear respuesta
            Map<String, Object> municionDTO = new HashMap<>();
            municionDTO.put("id", municion.getId());
            municionDTO.put("nombre", municion.getNombre());
            municionDTO.put("mensaje", "Munición eliminada correctamente");

            // Realizar eliminación lógica (cambia activo = false)
            servicioMunicion.eliminarMunicion(municion);

            return new ResponseEntity<>(municionDTO, HttpStatus.OK);

        } catch (Exception e) {
            return new ResponseEntity<>("Error al eliminar la munición: " + e.getMessage(),
                    HttpStatus.BAD_REQUEST);
        }
    }


    @PutMapping(value = "/")
    public ResponseEntity<?> actualizarMunicion(@RequestBody JsonNode jsonNode) {
        try {
            if (!jsonNode.has("id")) {
                return new ResponseEntity<>("Ingresa el ID de la munición", HttpStatus.BAD_REQUEST);
            }

            if (!jsonNode.has("nombre") || jsonNode.get("nombre").asText().isEmpty()) {
                return new ResponseEntity<>("Nombre de munición no válido", HttpStatus.BAD_REQUEST);
            }

            Long id = jsonNode.get("id").asLong();
            Optional<Municion> municionExistenteOpt = servicioMunicion.findById(id);

            if (!municionExistenteOpt.isPresent()) {
                return new ResponseEntity<>("Munición no encontrada", HttpStatus.NOT_FOUND);
            }

            Municion municionExistente = municionExistenteOpt.get();

            // Crear la nueva versión de la munición
            Municion nuevaMunicion = objectMapper.treeToValue(jsonNode, Municion.class);

            // Actualizar
            Municion municionActualizada = servicioMunicion.actualizarMunicion(municionExistente, nuevaMunicion);

            return new ResponseEntity<>(municionActualizada, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

    // Nuevo endpoint para reactivar municiones
    @PutMapping(value = "/reactivar")
    public ResponseEntity<?> reactivarMunicion(@RequestBody JsonNode jsonNode) {
        if (!jsonNode.has("id")) {
            return new ResponseEntity<>("Tienes que proporcionar el ID de la munición", HttpStatus.BAD_REQUEST);
        }

        if (!jsonNode.get("id").isNumber()) {
            return new ResponseEntity<>("El ID debe ser un número", HttpStatus.BAD_REQUEST);
        }

        Long id = jsonNode.get("id").asLong();

        try {
            Municion municionReactivada = servicioMunicion.reactivarMunicion(id);

            Map<String, Object> municionDTO = new HashMap<>();
            municionDTO.put("id", municionReactivada.getId());
            municionDTO.put("nombre", municionReactivada.getNombre());
            municionDTO.put("mensaje", "Munición reactivada correctamente");

            return new ResponseEntity<>(municionDTO, HttpStatus.OK);

        } catch (Exception e) {
            return new ResponseEntity<>("Error al reactivar la munición: " + e.getMessage(),
                    HttpStatus.BAD_REQUEST);
        }
    }

    // Nuevo endpoint para listar municiones inactivas
    @GetMapping(value = "/inactivas")
    public ResponseEntity<?> getMunicionesInactivas() {
        List<Municion> municionesInactivas = servicioMunicion.getMunicionesInactivas();

        if (municionesInactivas.isEmpty()) {
            return new ResponseEntity<>("No hay municiones inactivas", HttpStatus.NOT_FOUND);
        }

        // Crear lista simple
        List<Map<String, Object>> municionesDTO = new ArrayList<>();
        for (Municion municion : municionesInactivas) {
            Map<String, Object> dto = new HashMap<>();
            dto.put("id", municion.getId());
            dto.put("nombre", municion.getNombre());
            dto.put("cadencia", municion.getCadencia());
            dto.put("dañoArea", municion.isDañoArea());
            municionesDTO.add(dto);
        }

        return new ResponseEntity<>(municionesDTO, HttpStatus.OK);
    }
}