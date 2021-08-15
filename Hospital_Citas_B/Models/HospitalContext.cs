using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hospital_Citas_B.Models
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Cita { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Secretaria> Secretaria { get; set; }
        public virtual DbSet<WvcitasCancelar> WvcitasCancelars { get; set; }
        public virtual DbSet<WvcitasF> WvcitasFs { get; set; }
        public virtual DbSet<WvcitasSin> WvcitasSins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QILN7PV;Initial Catalog=Hospital; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.Idcita)
                    .HasName("PK__Cita__36D350AB4B66BBAF");

                entity.Property(e => e.Idcita).HasColumnName("IDCita");

                entity.Property(e => e.CitaCompletada)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Cita_Completada");

                entity.Property(e => e.DuracionDeLaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Duracion_de_la_Cita");

                entity.Property(e => e.EstadoDeLaCita)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Estado_de_la_Cita");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSecretaria");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Iddoctor)
                    .HasConstraintName("FK__Cita__IDDoctor__46E78A0C");

                entity.HasOne(d => d.IdpacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Idpaciente)
                    .HasConstraintName("FK__Cita__IDPaciente__44FF419A");

                entity.HasOne(d => d.IdsecretariaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Idsecretaria)
                    .HasConstraintName("FK__Cita__IDSecretar__45F365D3");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Iddoctor)
                    .HasName("PK__Doctor__A4F7F9EC9807027C");

                entity.ToTable("Doctor");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Idpaciente)
                    .HasName("PK__Paciente__94DF170F35A6B8C8");

                entity.ToTable("Paciente");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeLaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_de_la_Cita");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Secretaria>(entity =>
            {
                entity.HasKey(e => e.Idsecretaria)
                    .HasName("PK__Secretar__B42B8E64F3F9D2F4");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSecretaria");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WvcitasCancelar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WVCitasCancelar");

                entity.Property(e => e.CitaCompletada)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Cita_Completada");

                entity.Property(e => e.DuracionDeLaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Duracion_de_la_Cita");

                entity.Property(e => e.EstadoDeLaCita)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Estado_de_la_Cita");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSecretaria");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WvcitasF>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WVCitasF");

                entity.Property(e => e.CitaCompletada)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Cita_Completada");

                entity.Property(e => e.DuracionDeLaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Duracion_de_la_Cita");

                entity.Property(e => e.EstadoDeLaCita)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Estado_de_la_Cita");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSecretaria");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WvcitasSin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WVCitasSin");

                entity.Property(e => e.CitaCompletada)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Cita_Completada");

                entity.Property(e => e.DuracionDeLaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Duracion_de_la_Cita");

                entity.Property(e => e.EstadoDeLaCita)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Estado_de_la_Cita");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSecretaria");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
