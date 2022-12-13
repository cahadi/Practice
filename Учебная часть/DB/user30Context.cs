using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Учебная_часть.Models;

namespace Учебная_часть.DB
{
    public partial class user30Context : DbContext
    {
        public user30Context()
        {
        }

        public user30Context(DbContextOptions<user30Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DisGroupTeacher> DisGroupTeachers { get; set; } = null!;
        public virtual DbSet<Discipline> Disciplines { get; set; } = null!;
        public virtual DbSet<FailedJob> FailedJobs { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<KindOfTypeDiscipline> KindOfTypeDisciplines { get; set; } = null!;
        public virtual DbSet<Migration> Migrations { get; set; } = null!;
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TypeDiscipline> TypeDisciplines { get; set; } = null!;
        public virtual DbSet<TypeGroup> TypeGroups { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;database=user30;user=user30;password=42494");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisGroupTeacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DisGroupTeacher");

                entity.Property(e => e.DisciplineId).HasColumnName("DisciplineID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Discipline)
                    .WithMany()
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dis_gro_teach_disciplines");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dis_gro_teach_groups");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_dis_gro_teach_teacher");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(e => e.DisciplineId).HasColumnName("DisciplineID");

                entity.Property(e => e.TypeDisciplinesId).HasColumnName("TypeDisciplinesID");

                entity.HasOne(d => d.TypeDisciplines)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.TypeDisciplinesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disciplines_TypeDisciplines");
            });

            modelBuilder.Entity<FailedJob>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Connection).HasColumnName("connection");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.FailedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.Queue).HasColumnName("queue");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.TypeGroupId).HasColumnName("TypeGroupID");

                entity.HasOne(d => d.TypeGroup)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.TypeGroupId)
                    .HasConstraintName("FK_Groups_TypeGroup");
            });

            modelBuilder.Entity<KindOfTypeDiscipline>(entity =>
            {
                entity.HasKey(e => e.KindOfTypeDisciplinesId);

                entity.Property(e => e.KindOfTypeDisciplinesId).HasColumnName("KindOfTypeDisciplinesID");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .HasMaxLength(255)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email, "password_resets_email_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<PersonalAccessToken>(entity =>
            {
                entity.ToTable("personal_access_tokens");

                entity.HasIndex(e => e.Token, "personal_access_tokens_token_unique")
                    .IsUnique();

                entity.HasIndex(e => new { e.TokenableType, e.TokenableId }, "personal_access_tokens_tokenable_type_tokenable_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abilities).HasColumnName("abilities");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.LastUsedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_used_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Token)
                    .HasMaxLength(64)
                    .HasColumnName("token");

                entity.Property(e => e.TokenableId).HasColumnName("tokenable_id");

                entity.Property(e => e.TokenableType)
                    .HasMaxLength(255)
                    .HasColumnName("tokenable_type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<TypeDiscipline>(entity =>
            {
                entity.HasKey(e => e.TypeDisciplinesId);

                entity.Property(e => e.TypeDisciplinesId).HasColumnName("TypeDisciplinesID");

                entity.Property(e => e.KindOfTypeDisciplinesId).HasColumnName("KindOfTypeDisciplinesID");

                entity.HasOne(d => d.KindOfTypeDisciplines)
                    .WithMany(p => p.TypeDisciplines)
                    .HasForeignKey(d => d.KindOfTypeDisciplinesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeDisciplines_KindOfTypeDisciplines");
            });

            modelBuilder.Entity<TypeGroup>(entity =>
            {
                entity.ToTable("TypeGroup");

                entity.Property(e => e.TypeGroupId).HasColumnName("TypeGroupID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("email_verified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        static user30Context instance;
        public static user30Context GetInstance()
        {
            if(instance == null)
                instance = new user30Context();
            return instance;
        }
    }
}
