namespace OVR.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SemContext : DbContext
    {
        public SemContext()
            : base("name=SemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SemContext, Migrations.Configuration>());
        }

        public virtual DbSet<T_AdminUser> T_AdminUser { get; set; }
        public virtual DbSet<T_AdminUserInRole> T_AdminUserInRole { get; set; }
        public virtual DbSet<T_Country> T_Country { get; set; }
        public virtual DbSet<T_DataGridColumn> T_DataGridColumn { get; set; }
        public virtual DbSet<T_Email> T_Email { get; set; }
        public virtual DbSet<T_EmailAttachment> T_EmailAttachment { get; set; }
        public virtual DbSet<T_Event> T_Event { get; set; }
        public virtual DbSet<T_File> T_File { get; set; }
        public virtual DbSet<T_FileInEvent> T_FileInEvent { get; set; }
        public virtual DbSet<T_InitialRecord> T_InitialRecord { get; set; }
        public virtual DbSet<T_League> T_League { get; set; }
        public virtual DbSet<T_LeagueInParticipantInEvent> T_LeagueInParticipantInEvent { get; set; }
        public virtual DbSet<T_Module> T_Module { get; set; }
        public virtual DbSet<T_ModuleInRole> T_ModuleInRole { get; set; }
        public virtual DbSet<T_Participant> T_Participant { get; set; }
        public virtual DbSet<T_ParticipantInEvent> T_ParticipantInEvent { get; set; }
        public virtual DbSet<T_ParticipantInSchedule> T_ParticipantInSchedule { get; set; }
        public virtual DbSet<T_ParticipatingCountry> T_ParticipatingCountry { get; set; }
        public virtual DbSet<T_Referee> T_Referee { get; set; }
        public virtual DbSet<T_Reference> T_Reference { get; set; }
        public virtual DbSet<T_ReferenceCategory> T_ReferenceCategory { get; set; }
        public virtual DbSet<T_Result> T_Result { get; set; }
        public virtual DbSet<T_Role> T_Role { get; set; }
        public virtual DbSet<T_Schedule> T_Schedule { get; set; }
        public virtual DbSet<T_Score> T_Score { get; set; }
        public virtual DbSet<T_ScoreName> T_ScoreName { get; set; }
        public virtual DbSet<T_Sport> T_Sport { get; set; }
        public virtual DbSet<T_SportClass> T_SportClass { get; set; }
        public virtual DbSet<T_StartListName> T_StartListName { get; set; }
        public virtual DbSet<T_Statistic> T_Statistic { get; set; }
        public virtual DbSet<T_StatisticName> T_StatisticName { get; set; }
        public virtual DbSet<T_Team> T_Team { get; set; }
        public virtual DbSet<T_ScoreInParticipantInSchedule> T_ScoreInParticipantInSchedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_AdminUser>()
                .HasMany(e => e.T_AdminUserInRole)
                .WithRequired(e => e.T_AdminUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Event>()
                .HasMany(e => e.T_FileInEvent)
                .WithRequired(e => e.T_Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Event>()
                .HasMany(e => e.T_Schedule)
                .WithRequired(e => e.T_Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Event>()
                .HasMany(e => e.T_Team)
                .WithRequired(e => e.T_Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_File>()
                .HasMany(e => e.T_FileInEvent)
                .WithRequired(e => e.T_File)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Participant>()
                .Property(e => e.Weight)
                .HasPrecision(4, 0);

            modelBuilder.Entity<T_Participant>()
                .Property(e => e.Height)
                .HasPrecision(4, 0);

            modelBuilder.Entity<T_ParticipantInSchedule>()
                .HasMany(e => e.T_Result)
                .WithRequired(e => e.T_ParticipantInSchedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_ReferenceCategory>()
                .HasMany(e => e.T_Reference)
                .WithRequired(e => e.T_ReferenceCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Role>()
                .HasMany(e => e.T_AdminUserInRole)
                .WithRequired(e => e.T_Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Schedule>()
                .HasMany(e => e.T_Referee)
                .WithRequired(e => e.T_Schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Score>()
                .HasMany(e => e.T_ScoreInParticipantInSchedule)
                .WithRequired(e => e.T_Score)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Sport>()
                .HasMany(e => e.T_Event)
                .WithRequired(e => e.T_Sport)
                .WillCascadeOnDelete(false);
        }
    }
}
