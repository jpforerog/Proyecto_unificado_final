package com.ProyectoEmpresariales.Arma.repository;

import com.ProyectoEmpresariales.Arma.model.Arma;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface ArmaRepository extends JpaRepository<Arma, Long> {

    // Buscar por nombre solo entre armas activas
    Optional<Arma> findByNombreAndActivoTrue(String nombre);

    // Buscar por ID solo entre armas activas
    Optional<Arma> findByIdAndActivoTrue(Long id);

    // Listar todas las armas activas
    List<Arma> findByActivoTrue();

    // Buscar por vida mínima solo entre armas activas
    List<Arma> findByVidaGreaterThanEqualAndActivoTrue(int vidaMinima);

    // Buscar por daño mínimo solo entre armas activas
    List<Arma> findByDañoGreaterThanEqualAndActivoTrue(int dañoMinimo);

    // Buscar por tipo solo entre armas activas
    List<Arma> findByTipoArmaAndActivoTrue(String tipoArma);

    // Verificar si existe un arma activa con el mismo nombre
    boolean existsByNombreAndActivoTrue(String nombre);

    // Verificar si existe un arma activa con el mismo nombre excluyendo un ID específico
    @Query("SELECT COUNT(a) > 0 FROM Arma a WHERE a.nombre = :nombre AND a.activo = true AND a.id != :id")
    boolean existsByNombreAndActivoTrueAndIdNot(@Param("nombre") String nombre, @Param("id") Long id);

    // Métodos adicionales para obtener armas inactivas
    List<Arma> findByActivoFalse();

    Optional<Arma> findByIdAndActivoFalse(Long id);

    // Método para contar armas activas
    long countByActivoTrue();

    // Método para contar armas inactivas
    long countByActivoFalse();
}