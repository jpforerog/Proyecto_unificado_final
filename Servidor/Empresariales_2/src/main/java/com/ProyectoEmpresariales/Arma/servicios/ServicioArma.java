package com.ProyectoEmpresariales.Arma.servicios;

import com.ProyectoEmpresariales.Arma.model.Arma;
import com.ProyectoEmpresariales.Arma.model.Rifle;
import com.ProyectoEmpresariales.Arma.repository.ArmaRepository;
import com.ProyectoEmpresariales.Arma.repository.RifleRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Service
public class ServicioArma {
    @Autowired
    private ArmaRepository armaRepository;

    @Autowired
    private RifleRepository rifleRepository;

    @Transactional
    public Arma añadirArma(Arma arma) throws Exception {
        // Verificar que no exista otra arma activa con el mismo nombre
        if (armaRepository.existsByNombreAndActivoTrue(arma.getNombre())) {
            throw new Exception("Arma activa con el mismo nombre ya existe");
        }

        // Asegurar que el arma se marque como activa
        arma.setActivo(true);

        // Guardar en la base de datos
        return armaRepository.save(arma);
    }

    @Transactional(readOnly = true)
    public List<Arma> getArmas() {
        // Solo devolver armas activas
        return armaRepository.findByActivoTrue();
    }

    @Transactional(readOnly = true)
    public List<Rifle> getRifles() {
        // Solo devolver rifles activos
        return rifleRepository.findByActivoTrue();
    }

    @Transactional
    public void eliminarArma(Arma arma) {
        // Eliminación lógica: cambiar estado activo a false
        arma.setActivo(false);
        armaRepository.save(arma);
    }

    @Transactional
    public void eliminarArmaPorId(Long id) throws Exception {
        Optional<Arma> armaOpt = armaRepository.findByIdAndActivoTrue(id);
        if (armaOpt.isPresent()) {
            eliminarArma(armaOpt.get());
        } else {
            throw new Exception("Arma no encontrada o ya está inactiva");
        }
    }

    @Transactional
    public Arma reactivarArma(Long id) throws Exception {
        // Buscar arma inactiva
        Optional<Arma> armaOpt = armaRepository.findByIdAndActivoFalse(id);
        if (armaOpt.isPresent()) {
            Arma arma = armaOpt.get();

            // Verificar que no exista otra arma activa con el mismo nombre
            if (armaRepository.existsByNombreAndActivoTrue(arma.getNombre())) {
                throw new Exception("Ya existe un arma activa con el mismo nombre");
            }

            arma.setActivo(true);
            return armaRepository.save(arma);
        } else {
            throw new Exception("Arma no encontrada o ya está activa");
        }
    }

    @Transactional
    public Arma actualizarArma(Arma oldArma, Arma newArma) throws Exception {
        // Verificar que el nuevo nombre no esté en uso por otra arma activa
        if (!oldArma.getNombre().equals(newArma.getNombre()) &&
                armaRepository.existsByNombreAndActivoTrueAndIdNot(newArma.getNombre(), oldArma.getId())) {
            throw new Exception("Otra arma activa con el mismo nombre ya existe");
        }

        // Mantener el ID del arma original y el estado activo
        newArma.setId(oldArma.getId());
        newArma.setActivo(oldArma.isActivo());

        return armaRepository.save(newArma);
    }

    @Transactional(readOnly = true)
    public Optional<Arma> findById(Long id) {
        // Solo buscar entre armas activas
        return armaRepository.findByIdAndActivoTrue(id);
    }

    @Transactional(readOnly = true)
    public Optional<Arma> findByNombre(String nombre) {
        // Solo buscar entre armas activas
        return armaRepository.findByNombreAndActivoTrue(nombre);
    }

    @Transactional(readOnly = true)
    public List<Arma> findByVidaMinima(int vidaMinima) {
        // Solo buscar entre armas activas
        return armaRepository.findByVidaGreaterThanEqualAndActivoTrue(vidaMinima);
    }

    @Transactional(readOnly = true)
    public List<Arma> findByDañoMinimo(int dañoMinimo) {
        // Solo buscar entre armas activas
        return armaRepository.findByDañoGreaterThanEqualAndActivoTrue(dañoMinimo);
    }

    @Transactional(readOnly = true)
    public List<Arma> findByTipo(String tipo) {
        if (tipo == null) {
            return List.of();
        }

        String tipoNormalizado = tipo.toLowerCase();
        switch (tipoNormalizado) {
            case "rifle":
                // Solo buscar entre armas activas
                return armaRepository.findByTipoArmaAndActivoTrue("Rifle");
            default:
                return List.of();
        }
    }

    // Métodos adicionales para gestión de armas inactivas
    @Transactional(readOnly = true)
    public List<Arma> getArmasInactivas() {
        return armaRepository.findByActivoFalse();
    }

    @Transactional(readOnly = true)
    public Optional<Arma> findByIdIncludeInactive(Long id) {
        return armaRepository.findById(id);
    }

    @Transactional(readOnly = true)
    public long countArmasActivas() {
        return armaRepository.countByActivoTrue();
    }

    @Transactional(readOnly = true)
    public long countArmasInactivas() {
        return armaRepository.countByActivoFalse();
    }
}