using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ManejoDeEmpleados.Models
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

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }
        public virtual DbSet<Departamentocl> Departamentocls { get; set; }
        public virtual DbSet<Departamentopuesto> Departamentopuestos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }
        public virtual DbSet<Vacacionesestado> Vacacionesestados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=Solohome;database=manejoempleados", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasMaxLength(6);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Departamentocl>(entity =>
            {
                entity.ToTable("departamentocl");

                entity.UseCollation("utf8mb4_general_ci");

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

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.DepartamentoId, "FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Departamentopuestos)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.DepartamentoPuestoId, "FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaContratacion).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.DepartamentoPuesto)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoPuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.ToTable("nomina");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.EmpleadoId, "FK_Nomina_Empleado_EmpleadoId");

                entity.Property(e => e.Afp).HasColumnName("AFP");

                entity.Property(e => e.Isr).HasColumnName("ISR");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nomina_Empleado_EmpleadoId");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.UseCollation("utf8mb4_general_ci");

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

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.EmpleadoId, "FK_Vacaciones_Empleado_EmpleadoId");

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

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.VacacionesId, "FK_VacacionesEstado_Vacaciones_VacionesId");

                entity.Property(e => e.Estado).HasColumnName("estado");

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
