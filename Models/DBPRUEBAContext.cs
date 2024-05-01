using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aplicacion.Models
{
    public partial class DBPRUEBAContext : DbContext
    {
        public DBPRUEBAContext()
        {
        }

        public DBPRUEBAContext(DbContextOptions<DBPRUEBAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<HistoricoCursosAlumno> HistoricoCursosAlumnos { get; set; } = null!;
        public virtual DbSet<Tabla> Tablas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//               optionsBuilder.UseSqlServer("server=DESKTOP-H1L0P1R; database=DBPRUEBA; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Num_empleado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("num_empleado");
            });

            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.Property(e => e.Id)
                   // .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK__Asistenci__id_al__5165187F");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Asistenci__id_cu__52593CB8");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaTermino)
                    .HasColumnType("date")
                    .HasColumnName("fecha_termino");

                entity.Property(e => e.Horario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.TituloObtenido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo_obtenido");
            });

            modelBuilder.Entity<HistoricoCursosAlumno>(entity =>
            {
                entity.ToTable("Historico_Cursos_Alumnos");

                entity.Property(e => e.Id)
                    //.ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.HistoricoCursosAlumnos)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK__Historico__id_al__5535A963");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.HistoricoCursosAlumnos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Historico__id_cu__5629CD9C");
            });

            modelBuilder.Entity<Tabla>(entity =>
            {
                entity.ToTable("tabla");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__5B65BF97A4D0431C");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Clave)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
