package com.ProyectoEmpresariales.Arma.servicios;

import com.ProyectoEmpresariales.Arma.model.Municion;
import com.ProyectoEmpresariales.Arma.model.Rifle;
import com.ProyectoEmpresariales.Arma.repository.MunicionRepository;
import com.ProyectoEmpresariales.Arma.repository.RifleRepository;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Service
public class ServicioMunicion {

    @Autowired
    private MunicionRepository municionRepository;

    @Autowired
    private RifleRepository rifleRepository;

    @PostConstruct
    public void init() {
        // Crear munición predeterminada si no existe
        if (!municionRepository.existsByNombreAndActivoTrue("Predeterminado")) {
            Municion predeterminada = Municion.builder()
                    .nombre("Predeterminado")
                    .dañoArea(false)
                    .cadencia(10)
                    .activo(true)
                    .build();
            municionRepository.save(predeterminada);
        }
    }

    @Transactional
    public Municion añadirMunicion(Municion municion) throws Exception {
        // Validar que no exista otra munición activa con el mismo nombre
        if (municionRepository.existsByNombreAndActivoTrue(municion.getNombre())) {
            throw new Exception("Municion activa con el mismo nombre ya existe");
        }

        // Asegurar que la munición se marque como activa
        municion.setActivo(true);

        // Guardar en la base de datos
        return municionRepository.save(municion);
    }

    @Transactional(readOnly = true)
    public List<Municion> getMuniciones() {
        // Solo devolver municiones activas
        return municionRepository.findByActivoTrue();
    }

    @Transactional
    public void eliminarMunicion(Municion municion) throws Exception {
        // No permitir eliminar la munición predeterminada
        Municion predeterminada = getPredeterminada();
        if (municion.getId().equals(predeterminada.getId())) {
            throw new Exception("La munición predeterminada no se puede eliminar");
        }

        // Actualizar rifles activos que usan esta munición a la predeterminada
        List<Rifle> riflesAfectados = rifleRepository.findByTipoMunicionAndActivoTrue(municion);

        for (Rifle rifle : riflesAfectados) {
            rifle.setTipoMunicion(predeterminada);
            rifleRepository.save(rifle);
        }

        // Eliminación lógica: cambiar estado activo a false
        municion.setActivo(false);
        municionRepository.save(municion);
    }

    @Transactional
    public Municion reactivarMunicion(Long id) throws Exception {
        // Buscar munición inactiva
        Optional<Municion> municionOpt = municionRepository.findByIdAndActivoFalse(id);
        if (municionOpt.isPresent()) {
            Municion municion = municionOpt.get();

            // Verificar que no exista otra munición activa con el mismo nombre
            if (municionRepository.existsByNombreAndActivoTrue(municion.getNombre())) {
                throw new Exception("Ya existe una munición activa con el mismo nombre");
            }

            municion.setActivo(true);
            return municionRepository.save(municion);
        } else {
            throw new Exception("Munición no encontrada o ya está activa");
        }
    }

    @Transactional
    public Municion actualizarMunicion(Municion oldMunicion, Municion newMunicion) throws Exception {
        // Verificar que el nuevo nombre no esté en uso por otra munición activa
        if (!oldMunicion.getNombre().equals(newMunicion.getNombre()) &&
                municionRepository.existsByNombreAndActivoTrueAndIdNot(newMunicion.getNombre(), oldMunicion.getId())) {
            throw new Exception("Otra municion activa con el mismo nombre ya existe");
        }

        // Mantener el ID de la munición original y el estado activo
        newMunicion.setId(oldMunicion.getId());
        newMunicion.setActivo(oldMunicion.isActivo());

        return municionRepository.save(newMunicion);
    }

    @Transactional(readOnly = true)
    public Municion getPredeterminada() {
        return municionRepository.findByNombreAndActivoTrue("Predeterminado")
                .orElseThrow(() -> new RuntimeException("Munición predeterminada no encontrada"));
    }

    @Transactional(readOnly = true)
    public Optional<Municion> findByNombre(String nombre) {
        // Solo buscar entre municiones activas
        return municionRepository.findByNombreAndActivoTrue(nombre);
    }

    @Transactional(readOnly = true)
    public Optional<Municion> findById(Long id) {
        // Solo buscar entre municiones activas
        return municionRepository.findByIdAndActivoTrue(id);
    }

    @Transactional(readOnly = true)
    public List<Municion> findByCadenciaMinima(int cadenciaMinima) {
        // Solo buscar entre municiones activas
        return municionRepository.findByCadenciaGreaterThanEqualAndActivoTrue(cadenciaMinima);
    }

    @Transactional(readOnly = true)
    public List<Municion> findByDañoArea(boolean dañoArea) {
        // Solo buscar entre municiones activas
        return municionRepository.findByDañoAreaAndActivoTrue(dañoArea);
    }

    // Métodos adicionales para gestión de municiones inactivas
    @Transactional(readOnly = true)
    public List<Municion> getMunicionesInactivas() {
        return municionRepository.findByActivoFalse();
    }

    @Transactional(readOnly = true)
    public long countMunicionesActivas() {
        return municionRepository.countByActivoTrue();
    }

    @Transactional(readOnly = true)
    public long countMunicionesInactivas() {
        return municionRepository.countByActivoFalse();
    }
}