namespace OVR.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AdminUser",
                c => new
                    {
                        AdminUserID = c.Int(nullable: false, identity: true),
                        LoginID = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 200),
                        Designation = c.String(maxLength: 200),
                        Password = c.String(),
                        LoginSessionGUID = c.String(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminUserID);
            
            CreateTable(
                "dbo.T_AdminUserInRole",
                c => new
                    {
                        AdminUserInRoleID = c.Int(nullable: false, identity: true),
                        AdminUserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminUserInRoleID)
                .ForeignKey("dbo.T_Role", t => t.RoleID)
                .ForeignKey("dbo.T_AdminUser", t => t.AdminUserID)
                .Index(t => t.AdminUserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.T_Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 200),
                        RoleDescription = c.String(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.T_ModuleInRole",
                c => new
                    {
                        ModuleInRoleID = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(),
                        RoleID = c.Int(),
                        IsReadWrite = c.Boolean(),
                        IsReadOnly = c.Boolean(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleInRoleID)
                .ForeignKey("dbo.T_Module", t => t.ModuleID)
                .ForeignKey("dbo.T_Role", t => t.RoleID)
                .Index(t => t.ModuleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.T_Module",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(maxLength: 200),
                        PageName = c.String(maxLength: 200),
                        FunctionName = c.String(maxLength: 200),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.T_Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryNameShort = c.String(maxLength: 100),
                        ISOCode2 = c.String(maxLength: 10),
                        ISOCode3 = c.String(maxLength: 10),
                        FlagImageFilePath = c.String(),
                        IconFilePath = c.String(),
                        SmallIconFilePath = c.String(),
                        RegionID = c.Int(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.T_Participant",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        AccreditationNumber = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 100),
                        FamilyName = c.String(maxLength: 100),
                        GenderID = c.Int(),
                        CountryID = c.Int(),
                        PassportNumber = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(),
                        Weight = c.Decimal(precision: 4, scale: 0),
                        Height = c.Decimal(precision: 4, scale: 0),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        GivenName = c.String(maxLength: 100),
                        IPCNo = c.String(maxLength: 100),
                        CardPhotoPath = c.String(),
                        MainCategoryId = c.Int(),
                        CardPhotoPathThumbnail = c.String(),
                        CardPhotoPathExternal = c.String(),
                    })
                .PrimaryKey(t => t.ParticipantID)
                .ForeignKey("dbo.T_Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.T_ParticipantInEvent",
                c => new
                    {
                        ParticipantInEventID = c.Int(nullable: false, identity: true),
                        ParticipantID = c.Int(),
                        EventID = c.Int(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        SportClassID = c.Int(),
                        TeamID = c.Int(),
                        PersonalBestRecord = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ParticipantInEventID)
                .ForeignKey("dbo.T_Event", t => t.EventID)
                .ForeignKey("dbo.T_Participant", t => t.ParticipantID)
                .Index(t => t.ParticipantID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.T_Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventName = c.String(maxLength: 200),
                        EventCode = c.String(maxLength: 100),
                        SportID = c.Int(nullable: false),
                        GenderID = c.Int(),
                        PlayFormatID = c.Int(),
                        EventTypeID = c.Int(),
                        ExternalEventID = c.Int(),
                        ExternalEventCode = c.String(maxLength: 100),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        EventFooterNote = c.String(),
                        IsTogleHtmlMode = c.Boolean(),
                        IsShowResult = c.Boolean(),
                        IsShowMedal = c.Boolean(),
                        IsShowAthelete = c.Boolean(),
                        IsShowReport = c.Boolean(),
                        IsShowRecord = c.Boolean(),
                        IsShowSummary = c.Boolean(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.T_Sport", t => t.SportID)
                .Index(t => t.SportID);
            
            CreateTable(
                "dbo.T_FileInEvent",
                c => new
                    {
                        EventFileID = c.Int(nullable: false, identity: true),
                        FileID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        FileGroupID = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                        IsLinkedToSport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventFileID)
                .ForeignKey("dbo.T_File", t => t.FileID)
                .ForeignKey("dbo.T_Event", t => t.EventID)
                .Index(t => t.FileID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.T_File",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FilePath = c.String(maxLength: 255),
                        IsActive = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FileID);
            
            CreateTable(
                "dbo.T_Schedule",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        ScheduleName = c.String(maxLength: 200),
                        ScheduleDateTime = c.DateTime(),
                        ExternalScheduleID = c.Int(),
                        ExternalScheduleCode = c.String(maxLength: 100),
                        RoundName = c.String(maxLength: 200),
                        Venue = c.String(),
                        MatchNumber = c.Int(),
                        CompetitionStage = c.Int(),
                        TotalParticipant = c.Int(),
                        PlayFormatID = c.Int(),
                        GroupCode = c.String(maxLength: 100),
                        ScheduleFooterNote = c.String(),
                        StartListFooter = c.String(),
                        Remark = c.String(),
                        IsPublishStartList = c.Boolean(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Location = c.String(),
                        StatusCodeID = c.Int(),
                        HeadToHead = c.Boolean(),
                        IsMedalGame = c.Int(),
                        IsOfficial = c.Boolean(),
                        IsPublishSchedule = c.Boolean(),
                        IsGenerateLeagueSummary = c.Boolean(),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.T_Event", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.T_ParticipantInSchedule",
                c => new
                    {
                        ParticipantInScheduleID = c.Int(nullable: false, identity: true),
                        StatisticID = c.Int(),
                        ScheduleID = c.Int(),
                        TeamID = c.Int(),
                        ParticipantID = c.Int(),
                        SortID = c.Int(),
                        ParticipantPosition = c.String(maxLength: 200),
                        ParticipantTypeID = c.Int(),
                        StartList1 = c.String(maxLength: 100),
                        StartList2 = c.String(maxLength: 100),
                        StartList3 = c.String(maxLength: 100),
                        StartList4 = c.String(maxLength: 100),
                        StartList5 = c.String(maxLength: 100),
                        StartList6 = c.String(maxLength: 100),
                        StartList7 = c.String(maxLength: 100),
                        StartList8 = c.String(maxLength: 100),
                        StartList9 = c.String(maxLength: 100),
                        StartList10 = c.String(maxLength: 100),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipantInScheduleID)
                .ForeignKey("dbo.T_Participant", t => t.ParticipantID)
                .ForeignKey("dbo.T_Schedule", t => t.ScheduleID)
                .ForeignKey("dbo.T_Statistic", t => t.StatisticID)
                .Index(t => t.StatisticID)
                .Index(t => t.ScheduleID)
                .Index(t => t.ParticipantID);
            
            CreateTable(
                "dbo.T_Result",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                        ParticipantInScheduleID = c.Int(nullable: false),
                        BreakRecord = c.String(maxLength: 50),
                        MedalID = c.Int(),
                        ResultPosition = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ResultID)
                .ForeignKey("dbo.T_ParticipantInSchedule", t => t.ParticipantInScheduleID)
                .Index(t => t.ParticipantInScheduleID);
            
            CreateTable(
                "dbo.T_ScoreInParticipantInSchedule",
                c => new
                    {
                        ScoreInParticipantInScheduleID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        ScoreID = c.Int(nullable: false),
                        ParticipantInScheduleID = c.Int(),
                        TeamID = c.Int(),
                    })
                .PrimaryKey(t => new { t.ScoreInParticipantInScheduleID, t.ScheduleID, t.ScoreID })
                .ForeignKey("dbo.T_ParticipantInSchedule", t => t.ParticipantInScheduleID)
                .ForeignKey("dbo.T_Score", t => t.ScoreID)
                .Index(t => t.ScoreID)
                .Index(t => t.ParticipantInScheduleID);
            
            CreateTable(
                "dbo.T_Score",
                c => new
                    {
                        ScoreID = c.Int(nullable: false, identity: true),
                        Score1 = c.String(maxLength: 100),
                        Score2 = c.String(maxLength: 100),
                        Score3 = c.String(maxLength: 100),
                        Score4 = c.String(maxLength: 100),
                        Score5 = c.String(maxLength: 100),
                        Score6 = c.String(maxLength: 100),
                        Score7 = c.String(maxLength: 100),
                        Score8 = c.String(maxLength: 100),
                        Score9 = c.String(maxLength: 100),
                        Score10 = c.String(maxLength: 100),
                        Score11 = c.String(maxLength: 100),
                        Score12 = c.String(maxLength: 100),
                        Score13 = c.String(maxLength: 100),
                        Score14 = c.String(maxLength: 100),
                        Score15 = c.String(maxLength: 100),
                        Score16 = c.String(maxLength: 100),
                        Score17 = c.String(maxLength: 100),
                        Score18 = c.String(maxLength: 100),
                        Score19 = c.String(maxLength: 100),
                        Score20 = c.String(maxLength: 100),
                        ScoreFinal = c.String(maxLength: 100),
                        BreakRecord = c.String(maxLength: 50),
                        MedalID = c.Int(),
                        ResultPosition = c.Int(),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                        Remarks = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ScoreID);
            
            CreateTable(
                "dbo.T_Statistic",
                c => new
                    {
                        StatisticID = c.Int(nullable: false, identity: true),
                        Statistic1 = c.String(maxLength: 100),
                        Statistic2 = c.String(maxLength: 100),
                        Statistic3 = c.String(maxLength: 100),
                        Statistic4 = c.String(maxLength: 100),
                        Statistic5 = c.String(maxLength: 100),
                        Statistic6 = c.String(maxLength: 100),
                        Statistic7 = c.String(maxLength: 100),
                        Statistic8 = c.String(maxLength: 100),
                        Statistic9 = c.String(maxLength: 100),
                        Statistic10 = c.String(maxLength: 100),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.StatisticID);
            
            CreateTable(
                "dbo.T_Referee",
                c => new
                    {
                        RefereeID = c.Int(nullable: false, identity: true),
                        ScheduleID = c.Int(nullable: false),
                        RefereeName1 = c.String(maxLength: 200),
                        RefereeTitle1 = c.String(maxLength: 100),
                        RefereeName2 = c.String(maxLength: 200),
                        RefereeTitle2 = c.String(maxLength: 100),
                        RefereeName3 = c.String(maxLength: 200),
                        RefereeTitle3 = c.String(maxLength: 100),
                        RefereeName4 = c.String(maxLength: 200),
                        RefereeTitle4 = c.String(maxLength: 100),
                        RefereeName5 = c.String(maxLength: 200),
                        RefereeTitle5 = c.String(maxLength: 100),
                        RefereeName6 = c.String(maxLength: 200),
                        RefereeTitle6 = c.String(maxLength: 100),
                        RefereeName7 = c.String(maxLength: 200),
                        RefereeTitle7 = c.String(maxLength: 100),
                        RefereeName8 = c.String(maxLength: 200),
                        RefereeTitle8 = c.String(maxLength: 100),
                        RefereeName9 = c.String(maxLength: 200),
                        RefereeTitle9 = c.String(maxLength: 100),
                        RefereeName10 = c.String(maxLength: 200),
                        RefereeTitle10 = c.String(maxLength: 100),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.RefereeID)
                .ForeignKey("dbo.T_Schedule", t => t.ScheduleID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.T_ScoreName",
                c => new
                    {
                        ScoreNameID = c.Int(nullable: false, identity: true),
                        ScoreName1 = c.String(maxLength: 100),
                        ScoreName2 = c.String(nullable: false, maxLength: 100),
                        ScoreName3 = c.String(maxLength: 100),
                        ScoreName4 = c.String(maxLength: 100),
                        ScoreName5 = c.String(maxLength: 100),
                        ScoreName6 = c.String(maxLength: 100),
                        ScoreName7 = c.String(maxLength: 100),
                        ScoreName8 = c.String(maxLength: 100),
                        ScoreName9 = c.String(maxLength: 100),
                        ScoreName10 = c.String(maxLength: 100),
                        ScoreName11 = c.String(maxLength: 100),
                        ScoreName12 = c.String(maxLength: 100),
                        ScoreName13 = c.String(maxLength: 100),
                        ScoreName14 = c.String(maxLength: 100),
                        ScoreName15 = c.String(maxLength: 100),
                        ScoreName16 = c.String(maxLength: 100),
                        ScoreName17 = c.String(maxLength: 100),
                        ScoreName18 = c.String(maxLength: 100),
                        ScoreName19 = c.String(maxLength: 100),
                        ScoreName20 = c.String(maxLength: 100),
                        ScoreNameFinal = c.String(maxLength: 100),
                        ScheduleID = c.Int(),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsVisible1 = c.Boolean(),
                        IsVisible2 = c.Boolean(),
                        IsVisible3 = c.Boolean(),
                        IsVisible4 = c.Boolean(),
                        IsVisible5 = c.Boolean(),
                        IsVisible6 = c.Boolean(),
                        IsVisible7 = c.Boolean(),
                        IsVisible8 = c.Boolean(),
                        IsVisible9 = c.Boolean(),
                        IsVisible10 = c.Boolean(),
                        IsVisible11 = c.Boolean(),
                        IsVisible12 = c.Boolean(),
                        IsVisible13 = c.Boolean(),
                        IsVisible14 = c.Boolean(),
                        IsVisible15 = c.Boolean(),
                        IsVisible16 = c.Boolean(),
                        IsVisible17 = c.Boolean(),
                        IsVisible18 = c.Boolean(),
                        IsVisible19 = c.Boolean(),
                        IsVisible20 = c.Boolean(),
                    })
                .PrimaryKey(t => t.ScoreNameID)
                .ForeignKey("dbo.T_Schedule", t => t.ScheduleID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.T_StartListName",
                c => new
                    {
                        StartListNameID = c.Int(nullable: false, identity: true),
                        ScheduleID = c.Int(),
                        StartlistName1 = c.String(maxLength: 100),
                        StartlistName2 = c.String(maxLength: 100),
                        StartlistName3 = c.String(maxLength: 100),
                        StartlistName4 = c.String(maxLength: 100),
                        StartlistName5 = c.String(maxLength: 100),
                        StartlistName6 = c.String(maxLength: 100),
                        StartlistName7 = c.String(maxLength: 100),
                        StartlistName8 = c.String(maxLength: 100),
                        StartlistName9 = c.String(maxLength: 100),
                        StartlistName10 = c.String(maxLength: 100),
                        IsActive = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.StartListNameID)
                .ForeignKey("dbo.T_Schedule", t => t.ScheduleID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.T_StatisticName",
                c => new
                    {
                        StatisticNameID = c.Int(nullable: false, identity: true),
                        StatisticName1 = c.String(maxLength: 100),
                        StatisticName2 = c.String(maxLength: 100),
                        StatisticName3 = c.String(maxLength: 100),
                        StatisticName4 = c.String(maxLength: 100),
                        StatisticName5 = c.String(maxLength: 100),
                        StatisticName6 = c.String(maxLength: 100),
                        StatisticName7 = c.String(maxLength: 100),
                        StatisticName8 = c.String(maxLength: 100),
                        StatisticName9 = c.String(maxLength: 100),
                        StatisticName10 = c.String(maxLength: 100),
                        ScheduleID = c.Int(),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.StatisticNameID)
                .ForeignKey("dbo.T_Schedule", t => t.ScheduleID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.T_Sport",
                c => new
                    {
                        SportID = c.Int(nullable: false, identity: true),
                        ExternalSportID = c.Int(),
                        ExternalSportCode = c.String(maxLength: 100),
                        SportName = c.String(maxLength: 200),
                        SportCode = c.String(maxLength: 100),
                        ImageFilePath = c.String(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        HasRecord = c.Boolean(),
                    })
                .PrimaryKey(t => t.SportID);
            
            CreateTable(
                "dbo.T_SportClass",
                c => new
                    {
                        SportClassID = c.Int(nullable: false, identity: true),
                        SportID = c.Int(),
                        SportClassCode = c.String(maxLength: 20),
                        SportClassGroupCode = c.String(maxLength: 100),
                        ExternalSportClassID = c.Int(),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.SportClassID)
                .ForeignKey("dbo.T_Sport", t => t.SportID)
                .Index(t => t.SportID);
            
            CreateTable(
                "dbo.T_Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(maxLength: 100),
                        EventID = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.T_Event", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.T_ParticipatingCountry",
                c => new
                    {
                        ParticipatingCountryID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipatingCountryID)
                .ForeignKey("dbo.T_Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.T_DataGridColumn",
                c => new
                    {
                        DataGridColumnID = c.Int(nullable: false, identity: true),
                        DataGridName = c.String(maxLength: 200),
                        HeaderText = c.String(maxLength: 100),
                        DataField = c.String(maxLength: 100),
                        NavigateURL = c.String(),
                        NavigateURLDataField = c.String(maxLength: 200),
                        SortID = c.Int(),
                        ColumnTypeID = c.Int(),
                        EnumTypeID = c.Int(),
                        ColumnWidth = c.Int(),
                        CSSClass = c.String(maxLength: 100),
                        IsReadOnly = c.Boolean(),
                        IsAllowHTMLEncode = c.Boolean(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DataGridColumnID);
            
            CreateTable(
                "dbo.T_Email",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        EmailSubject = c.String(nullable: false, maxLength: 100),
                        ReceiverEmail = c.String(nullable: false),
                        ReceiverEmail_CC = c.String(),
                        ReceiverEmail_BCC = c.String(),
                        EmailContent = c.String(),
                        EmailStatus = c.Int(),
                        AttemptCount = c.Int(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDateTime = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmailID);
            
            CreateTable(
                "dbo.T_EmailAttachment",
                c => new
                    {
                        EmailAttachmentID = c.Int(nullable: false, identity: true),
                        EmailAttachmentLocation = c.String(),
                        EmailAttachmentType = c.Int(),
                        EmailID = c.Int(),
                        EmailAttachmentGUID = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EmailAttachmentID)
                .ForeignKey("dbo.T_Email", t => t.EmailID)
                .Index(t => t.EmailID);
            
            CreateTable(
                "dbo.T_InitialRecord",
                c => new
                    {
                        HistoryRecordID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(),
                        SportClassID = c.Int(),
                        SportClassCode = c.String(maxLength: 20),
                        FullName = c.String(maxLength: 100),
                        FamilyName = c.String(maxLength: 100),
                        GivenName = c.String(maxLength: 100),
                        ParticipantCountryID = c.Int(),
                        ParticipantCountryName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Result = c.String(maxLength: 100),
                        OffSet = c.String(maxLength: 100),
                        TimeMillisecond = c.String(maxLength: 100),
                        Record = c.String(maxLength: 100),
                        Date = c.DateTime(),
                        City = c.String(),
                        Country = c.String(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryRecordID);
            
            CreateTable(
                "dbo.T_League",
                c => new
                    {
                        LeagueID = c.Int(nullable: false, identity: true),
                        Rank = c.Int(),
                        League1 = c.String(maxLength: 100),
                        League2 = c.String(maxLength: 100),
                        League3 = c.String(maxLength: 100),
                        League4 = c.String(maxLength: 100),
                        League5 = c.String(maxLength: 100),
                        League6 = c.String(maxLength: 100),
                        League7 = c.String(maxLength: 100),
                        League8 = c.String(maxLength: 100),
                        League9 = c.String(maxLength: 100),
                        League10 = c.String(maxLength: 100),
                        League11 = c.String(maxLength: 100),
                        League12 = c.String(maxLength: 100),
                        League13 = c.String(maxLength: 100),
                        League14 = c.String(maxLength: 100),
                        League15 = c.String(maxLength: 100),
                        League16 = c.String(maxLength: 100),
                        League17 = c.String(maxLength: 100),
                        League18 = c.String(maxLength: 100),
                        League19 = c.String(maxLength: 100),
                        League20 = c.String(maxLength: 100),
                        IsActive = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Int(),
                        GroupCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.LeagueID);
            
            CreateTable(
                "dbo.T_LeagueInParticipantInEvent",
                c => new
                    {
                        LeageInParticipantInEventID = c.Int(nullable: false, identity: true),
                        LeagueID = c.Int(),
                        TeamID = c.Int(),
                        EventID = c.Int(),
                        ParticipantInEventID = c.Int(),
                        GroupCode = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.LeageInParticipantInEventID)
                .ForeignKey("dbo.T_League", t => t.LeagueID)
                .Index(t => t.LeagueID);
            
            CreateTable(
                "dbo.T_Reference",
                c => new
                    {
                        ReferenceID = c.Int(nullable: false, identity: true),
                        ReferenceInternalID = c.Int(nullable: false),
                        ReferenceCategoryID = c.Int(nullable: false),
                        ReferenceName = c.String(maxLength: 200),
                        ReferenceCode = c.String(maxLength: 100),
                        ReferenceDescription = c.String(),
                        ReferenceContent = c.String(),
                        LanguageID = c.Int(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceID)
                .ForeignKey("dbo.T_ReferenceCategory", t => t.ReferenceCategoryID)
                .Index(t => t.ReferenceCategoryID);
            
            CreateTable(
                "dbo.T_ReferenceCategory",
                c => new
                    {
                        ReferenceCategoryID = c.Int(nullable: false, identity: true),
                        ReferenceCategoryCode = c.String(maxLength: 100),
                        ReferenceCategoryDescription = c.String(),
                        IsActive = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Reference", "ReferenceCategoryID", "dbo.T_ReferenceCategory");
            DropForeignKey("dbo.T_LeagueInParticipantInEvent", "LeagueID", "dbo.T_League");
            DropForeignKey("dbo.T_EmailAttachment", "EmailID", "dbo.T_Email");
            DropForeignKey("dbo.T_ParticipatingCountry", "CountryID", "dbo.T_Country");
            DropForeignKey("dbo.T_ParticipantInEvent", "ParticipantID", "dbo.T_Participant");
            DropForeignKey("dbo.T_Team", "EventID", "dbo.T_Event");
            DropForeignKey("dbo.T_SportClass", "SportID", "dbo.T_Sport");
            DropForeignKey("dbo.T_Event", "SportID", "dbo.T_Sport");
            DropForeignKey("dbo.T_Schedule", "EventID", "dbo.T_Event");
            DropForeignKey("dbo.T_StatisticName", "ScheduleID", "dbo.T_Schedule");
            DropForeignKey("dbo.T_StartListName", "ScheduleID", "dbo.T_Schedule");
            DropForeignKey("dbo.T_ScoreName", "ScheduleID", "dbo.T_Schedule");
            DropForeignKey("dbo.T_Referee", "ScheduleID", "dbo.T_Schedule");
            DropForeignKey("dbo.T_ParticipantInSchedule", "StatisticID", "dbo.T_Statistic");
            DropForeignKey("dbo.T_ScoreInParticipantInSchedule", "ScoreID", "dbo.T_Score");
            DropForeignKey("dbo.T_ScoreInParticipantInSchedule", "ParticipantInScheduleID", "dbo.T_ParticipantInSchedule");
            DropForeignKey("dbo.T_ParticipantInSchedule", "ScheduleID", "dbo.T_Schedule");
            DropForeignKey("dbo.T_Result", "ParticipantInScheduleID", "dbo.T_ParticipantInSchedule");
            DropForeignKey("dbo.T_ParticipantInSchedule", "ParticipantID", "dbo.T_Participant");
            DropForeignKey("dbo.T_ParticipantInEvent", "EventID", "dbo.T_Event");
            DropForeignKey("dbo.T_FileInEvent", "EventID", "dbo.T_Event");
            DropForeignKey("dbo.T_FileInEvent", "FileID", "dbo.T_File");
            DropForeignKey("dbo.T_Participant", "CountryID", "dbo.T_Country");
            DropForeignKey("dbo.T_AdminUserInRole", "AdminUserID", "dbo.T_AdminUser");
            DropForeignKey("dbo.T_ModuleInRole", "RoleID", "dbo.T_Role");
            DropForeignKey("dbo.T_ModuleInRole", "ModuleID", "dbo.T_Module");
            DropForeignKey("dbo.T_AdminUserInRole", "RoleID", "dbo.T_Role");
            DropIndex("dbo.T_Reference", new[] { "ReferenceCategoryID" });
            DropIndex("dbo.T_LeagueInParticipantInEvent", new[] { "LeagueID" });
            DropIndex("dbo.T_EmailAttachment", new[] { "EmailID" });
            DropIndex("dbo.T_ParticipatingCountry", new[] { "CountryID" });
            DropIndex("dbo.T_Team", new[] { "EventID" });
            DropIndex("dbo.T_SportClass", new[] { "SportID" });
            DropIndex("dbo.T_StatisticName", new[] { "ScheduleID" });
            DropIndex("dbo.T_StartListName", new[] { "ScheduleID" });
            DropIndex("dbo.T_ScoreName", new[] { "ScheduleID" });
            DropIndex("dbo.T_Referee", new[] { "ScheduleID" });
            DropIndex("dbo.T_ScoreInParticipantInSchedule", new[] { "ParticipantInScheduleID" });
            DropIndex("dbo.T_ScoreInParticipantInSchedule", new[] { "ScoreID" });
            DropIndex("dbo.T_Result", new[] { "ParticipantInScheduleID" });
            DropIndex("dbo.T_ParticipantInSchedule", new[] { "ParticipantID" });
            DropIndex("dbo.T_ParticipantInSchedule", new[] { "ScheduleID" });
            DropIndex("dbo.T_ParticipantInSchedule", new[] { "StatisticID" });
            DropIndex("dbo.T_Schedule", new[] { "EventID" });
            DropIndex("dbo.T_FileInEvent", new[] { "EventID" });
            DropIndex("dbo.T_FileInEvent", new[] { "FileID" });
            DropIndex("dbo.T_Event", new[] { "SportID" });
            DropIndex("dbo.T_ParticipantInEvent", new[] { "EventID" });
            DropIndex("dbo.T_ParticipantInEvent", new[] { "ParticipantID" });
            DropIndex("dbo.T_Participant", new[] { "CountryID" });
            DropIndex("dbo.T_ModuleInRole", new[] { "RoleID" });
            DropIndex("dbo.T_ModuleInRole", new[] { "ModuleID" });
            DropIndex("dbo.T_AdminUserInRole", new[] { "RoleID" });
            DropIndex("dbo.T_AdminUserInRole", new[] { "AdminUserID" });
            DropTable("dbo.T_ReferenceCategory");
            DropTable("dbo.T_Reference");
            DropTable("dbo.T_LeagueInParticipantInEvent");
            DropTable("dbo.T_League");
            DropTable("dbo.T_InitialRecord");
            DropTable("dbo.T_EmailAttachment");
            DropTable("dbo.T_Email");
            DropTable("dbo.T_DataGridColumn");
            DropTable("dbo.T_ParticipatingCountry");
            DropTable("dbo.T_Team");
            DropTable("dbo.T_SportClass");
            DropTable("dbo.T_Sport");
            DropTable("dbo.T_StatisticName");
            DropTable("dbo.T_StartListName");
            DropTable("dbo.T_ScoreName");
            DropTable("dbo.T_Referee");
            DropTable("dbo.T_Statistic");
            DropTable("dbo.T_Score");
            DropTable("dbo.T_ScoreInParticipantInSchedule");
            DropTable("dbo.T_Result");
            DropTable("dbo.T_ParticipantInSchedule");
            DropTable("dbo.T_Schedule");
            DropTable("dbo.T_File");
            DropTable("dbo.T_FileInEvent");
            DropTable("dbo.T_Event");
            DropTable("dbo.T_ParticipantInEvent");
            DropTable("dbo.T_Participant");
            DropTable("dbo.T_Country");
            DropTable("dbo.T_Module");
            DropTable("dbo.T_ModuleInRole");
            DropTable("dbo.T_Role");
            DropTable("dbo.T_AdminUserInRole");
            DropTable("dbo.T_AdminUser");
        }
    }
}
