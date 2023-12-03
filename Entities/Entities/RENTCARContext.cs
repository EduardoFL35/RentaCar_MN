using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class RENTCARContext : IdentityDbContext<ApplicationUser>
    {
        public RENTCARContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<RENTCARContext>();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public RENTCARContext(DbContextOptions<RENTCARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Automovile> Automoviles { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Mantenimiento> Mantenimientos { get; set; } = null!;
        public virtual DbSet<Sede> Sedes { get; set; } = null!;
        public virtual DbSet<Seguro> Seguros { get; set; } = null!;
        public virtual DbSet<Transaccione> Transacciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Automovile>(entity =>
            {
                entity.ToTable("automoviles");

                entity.Property(e => e.FechaActualizado)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Actualizado");

                entity.Property(e => e.IdCategorias).HasColumnName("ID_Categorias");

                entity.Property(e => e.IdDeSedes).HasColumnName("ID_De_Sedes");

                entity.Property(e => e.IdSeguros).HasColumnName("ID_Seguros");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriasNavigation)
                    .WithMany(p => p.Automoviles)
                    .HasForeignKey(d => d.IdCategorias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__automovil__ID_Ca__5441852A");

                entity.HasOne(d => d.IdDeSedesNavigation)
                    .WithMany(p => p.Automoviles)
                    .HasForeignKey(d => d.IdDeSedes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__automovil__ID_De__5535A963");

                entity.HasOne(d => d.IdSegurosNavigation)
                    .WithMany(p => p.Automoviles)
                    .HasForeignKey(d => d.IdSeguros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__automovil__ID_Se__5629CD9C");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.DescripcionCategoria)
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion_Categoria");

                entity.Property(e => e.Licencia)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_contratacion");

                entity.Property(e => e.IdSede).HasColumnName("ID_Sede");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleado__ID_Sed__4BAC3F29");
            });

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.ToTable("mantenimiento");

                entity.Property(e => e.DescripcionMantenimiento)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion_Mantenimiento");

                entity.Property(e => e.FechaActualizado)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Actualizado");

                entity.Property(e => e.FechaFinalizacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Finalizacion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.IdAutomovil).HasColumnName("ID_Automovil");

                entity.Property(e => e.TipoMantenimiento)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Mantenimiento");

                entity.HasOne(d => d.IdAutomovilNavigation)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.IdAutomovil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mantenimi__ID_Au__59063A47");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.ToTable("sedes");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSede)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Direccion_Sede");

                entity.Property(e => e.NombreUbi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Ubi");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.ToTable("seguros");

                entity.Property(e => e.CostoSeguro).HasColumnName("Costo_Seguro");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSeguro)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Seguro");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.ToTable("transacciones");

                entity.Property(e => e.CostoTotal).HasColumnName("Costo_Total");

                entity.Property(e => e.Detalles)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_devolucion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_inicio");

                entity.Property(e => e.IdAutomovil).HasColumnName("ID_Automovil");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("date")
                    .HasColumnName("Shipment_date");

                entity.HasOne(d => d.IdAutomovilNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdAutomovil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacci__ID_Au__5BE2A6F2");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacci__ID_Cl__5CD6CB2B");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transacci__ID_Em__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
