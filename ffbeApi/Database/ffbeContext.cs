using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ffbeApi.Database.Entities;
using ffbeApi.Database.Views;

namespace ffbeApi.Database
{
    public partial class FFBEContext : DbContext
    {
        public FFBEContext(DbContextOptions<FFBEContext> options) : base(options)
        {
        }

        
        public virtual DbSet<Dungeons> Dungeons { get; set; }
        public virtual DbSet<Enhancements> Enhancements { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentSlots> EquipmentSlots { get; set; }
        public virtual DbSet<EquipmentTypes> EquipmentTypes { get; set; }
        public virtual DbSet<Expeditions> Expeditions { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Limitbursts> Limitbursts { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Mogking> Mogking { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Sexes> Sexes { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Subregions> Subregions { get; set; }
        public virtual DbSet<SummonBoards> SummonBoards { get; set; }
        public virtual DbSet<Summons> Summons { get; set; }
        public virtual DbSet<SysJobs> SysJobs { get; set; }
        public virtual DbSet<SysMigrations> SysMigrations { get; set; }
        public virtual DbSet<UnitEntries> UnitEntries { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        public virtual DbSet<TMRs> TMRs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dungeons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Dungeons)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("dungeons_region_id_foreign");

                entity.HasOne(d => d.Subregion)
                    .WithMany(p => p.Dungeons)
                    .HasForeignKey(d => d.SubregionId)
                    .HasConstraintName("dungeons_subregion_id_foreign");
            });

            modelBuilder.Entity<Enhancements>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equipment_slot_id_foreign");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equipment_type_id_foreign");
            });

            modelBuilder.Entity<EquipmentSlots>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<EquipmentTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Expeditions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Limitbursts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Missions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Dungeon)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.DungeonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missions_dungeon_id_foreign");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Sexes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Subregions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SummonBoards>(entity =>
            {
                entity.HasOne(d => d.Summon)
                    .WithMany(p => p.SummonBoards)
                    .HasForeignKey(d => d.SummonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("summon_boards_summon_id_foreign");
            });

            modelBuilder.Entity<Summons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SysJobs>(entity =>
            {
                entity.HasIndex(e => e.Queue)
                    .HasName("sys_jobs_queue_index");
            });

            modelBuilder.Entity<UnitEntries>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.UnitEntries)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_entries_unit_id_foreign");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("units_game_id_foreign");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("units_job_id_foreign");

                entity.HasOne(d => d.Sex)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("units_sex_id_foreign");
            });
        }
    }
}
