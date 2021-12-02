using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class manejoempleadosContext : DbContext
    {
        public manejoempleadosContext()
        {
        }

        public manejoempleadosContext(DbContextOptions<manejoempleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsumoEmpleado> ConsumoEmpleados { get; set; }
        public virtual DbSet<Departamentocl> Departamentocls { get; set; }
        public virtual DbSet<Departamentopuesto> Departamentopuestos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }
        public virtual DbSet<Vacacionesestado> Vacacionesestados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=mysql;database=manejoempleados", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<ConsumoEmpleado>(entity =>
            {
                entity.ToTable("consumo_empleado");

                entity.HasIndex(e => e.EmpleadoId, "FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoId).HasColumnType("int(11)");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.ConsumoEmpleados)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId");
            });

            modelBuilder.Entity<Departamentocl>(entity =>
            {
                entity.ToTable("departamentocl");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Departamentopuesto>(entity =>
            {
                entity.ToTable("departamentopuestos");

                entity.HasIndex(e => e.DepartamentoId, "FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DepartamentoId).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Departamentopuestos)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.HasIndex(e => e.DepartamentoclId, "FK_Empleado_Departamento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DepartamentoclId).HasColumnType("int(11)");

                entity.Property(e => e.FechaContratacion).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SueldoEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Departamentocl)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoclId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Departamento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vacacione>(entity =>
            {
                entity.ToTable("vacaciones");

                entity.HasIndex(e => e.EmpleadoId, "FK_Vacaciones_Empleado_EmpleadoId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EmpleadoId).HasColumnType("int(11)");

                entity.Property(e => e.HastaVacaciones).HasColumnType("date");

                entity.Property(e => e.InicioVacaciones).HasColumnType("date");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Vacaciones)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacaciones_Empleado_EmpleadoId");
            });

            modelBuilder.Entity<Vacacionesestado>(entity =>
            {
                entity.ToTable("vacacionesestado");

                entity.HasIndex(e => e.VacacionesId, "FK_VacacionesEstado_Vacaciones_VacionesId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado");

                entity.Property(e => e.VacacionesId).HasColumnType("int(11)");

                entity.HasOne(d => d.Vacaciones)
                    .WithMany(p => p.Vacacionesestados)
                    .HasForeignKey(d => d.VacacionesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacacionesEstado_Vacaciones_VacionesId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
