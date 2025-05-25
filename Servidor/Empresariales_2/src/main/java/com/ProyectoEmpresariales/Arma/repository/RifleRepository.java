package com.ProyectoEmpresariales.Arma.repository;

import com.ProyectoEmpresariales.Arma.model.Municion;
import com.ProyectoEmpresariales.Arma.model.Rifle;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface RifleRepository extends JpaRepository<Rifle, Long> {

    // Buscar rifles activos por tipo de munición
    List<Rifle> findByTipoMunicionAndActivoTrue(Municion tipoMunicion);

    // Buscar rifles activos por velocidad mínima
    List<Rifle> findByVelocidadGreaterThanEqualAndActivoTrue(double velocidadMinima);

    // Listar todos los rifles activos
    List<Rifle> findByActivoTrue();

    // Buscar rifle activo por ID
    Optional<Rifle> findByIdAndActivoTrue(Long id);

    // Buscar rifles activos por nombre
    Optional<Rifle> findByNombreAndActivoTrue(String nombre);

    // Buscar rifles activos que usan municiones activas
    @Query("SELECT r FROM Rifle r WHERE r.activo = true AND r.tipoMunicion.activo = true")
    List<Rifle> findActiveRiflesWithActiveMunicion();

    // Buscar rifles activos por tipo de munición (solo municiones activas)
    @Query("SELECT r FROM Rifle r WHERE r.activo = true AND r.tipoMunicion.activo = true AND r.tipoMunicion = :municion")
    List<Rifle> findByActiveTrueAndTipoMunicionActiveTrueAndTipoMunicion(@Param("municion") Municion municion);

    // Contar rifles activos
    long countByActivoTrue();

    // Contar rifles inactivos
    long countByActivoFalse();

    // Métodos para rifles inactivos (por si se necesitan)
    List<Rifle> findByActivoFalse();
    Optional<Rifle> findByIdAndActivoFalse(Long id);
}