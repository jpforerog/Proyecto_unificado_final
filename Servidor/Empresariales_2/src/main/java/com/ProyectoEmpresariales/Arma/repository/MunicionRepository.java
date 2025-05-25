package com.ProyectoEmpresariales.Arma.repository;

import com.ProyectoEmpresariales.Arma.model.Municion;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface MunicionRepository extends JpaRepository<Municion, Long> {

    // Buscar por nombre solo entre municiones activas
    Optional<Municion> findByNombreAndActivoTrue(String nombre);

    // Buscar por ID solo entre municiones activas
    Optional<Municion> findByIdAndActivoTrue(Long id);

    // Listar todas las municiones activas
    List<Municion> findByActivoTrue();

    // Buscar por cadencia mínima solo entre municiones activas
    List<Municion> findByCadenciaGreaterThanEqualAndActivoTrue(int cadenciaMinima);

    // Buscar por daño de área solo entre municiones activas
    List<Municion> findByDañoAreaAndActivoTrue(boolean dañoArea);

    // Verificar si existe una munición activa con el mismo nombre
    boolean existsByNombreAndActivoTrue(String nombre);

    // Verificar si existe una munición activa con el mismo nombre excluyendo un ID específico
    @Query("SELECT COUNT(m) > 0 FROM Municion m WHERE m.nombre = :nombre AND m.activo = true AND m.id != :id")
    boolean existsByNombreAndActivoTrueAndIdNot(@Param("nombre") String nombre, @Param("id") Long id);

    // Métodos adicionales para obtener municiones inactivas (por si se necesitan en el futuro)
    List<Municion> findByActivoFalse();

    Optional<Municion> findByIdAndActivoFalse(Long id);

    // Método para contar municiones activas
    long countByActivoTrue();

    // Método para contar municiones inactivas
    long countByActivoFalse();

    // Filtros combinados para municiones activas
    @Query("SELECT m FROM Municion m WHERE m.activo = true AND m.cadencia >= :cadenciaMinima AND m.dañoArea = :dañoArea")
    List<Municion> findByCadenciaGreaterThanEqualAndDañoAreaAndActivoTrue(
            @Param("cadenciaMinima") int cadenciaMinima,
            @Param("dañoArea") boolean dañoArea
    );
}