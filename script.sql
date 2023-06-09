USE [master]
GO
/****** Object:  Database [HospitalSystem]    Script Date: 30.04.2023 20:11:13 ******/
CREATE DATABASE [HospitalSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HospitalSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HospitalSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [HospitalSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HospitalSystem]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 30.04.2023 20:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentId] [bigint] NOT NULL,
	[PatientId] [bigint] NULL,
	[DoctorId] [bigint] NULL,
	[BranchName] [nvarchar](max) NULL,
	[DateTime] [date] NULL,
	[Diagnosis] [nvarchar](max) NULL,
 CONSTRAINT [PK__Appointm__A1682FC5D9E3CC40] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 30.04.2023 20:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [bigint] NOT NULL,
	[BranchName] [nvarchar](max) NULL,
 CONSTRAINT [PK__Branch__A1682FC574D2A1DB] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 30.04.2023 20:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Id] [bigint] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Branch] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 30.04.2023 20:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Id] [bigint] NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Diagnosis] [nvarchar](max) NULL,
 CONSTRAINT [PK__Patient__3214EC07F82F08A4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Secretary]    Script Date: 30.04.2023 20:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secretary](
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Id] [bigint] NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Secretary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (82, 779, 444, N'General Surgery', CAST(N'2023-03-21' AS Date), N'')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (110, 95, 111, N'Pulmonology', CAST(N'2023-04-15' AS Date), N'heartache')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (111, 723, 123, N'Urology', CAST(N'2023-05-15' AS Date), N'Böbrek üstü bezlerindeki kist alınacak.')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (120, 88612, 123, N'Urology', CAST(N'2023-07-29' AS Date), N'Unnecessary')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (200, 531, 333, N'Neurology', CAST(N'2023-03-24' AS Date), N'')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (308, 123123, 555, N'Cardiology', CAST(N'2023-05-18' AS Date), N'')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (772, 8311, 777, N'Cardiology', CAST(N'2023-06-01' AS Date), N'')
INSERT [dbo].[Appointment] ([AppointmentId], [PatientId], [DoctorId], [BranchName], [DateTime], [Diagnosis]) VALUES (971, 7123, 123, N'Urology', CAST(N'2023-05-04' AS Date), N'Plasebo')
GO
INSERT [dbo].[Branch] ([BranchId], [BranchName]) VALUES (1, N'Cardiology')
INSERT [dbo].[Branch] ([BranchId], [BranchName]) VALUES (2, N'Neurology')
INSERT [dbo].[Branch] ([BranchId], [BranchName]) VALUES (3, N'General Surgery')
INSERT [dbo].[Branch] ([BranchId], [BranchName]) VALUES (4, N'Urology')
INSERT [dbo].[Branch] ([BranchId], [BranchName]) VALUES (5, N'Pulmonology')
GO
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Deniz', N'Oral', 111, N'111', N'Pulmonology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Can', N'Çevik', 123, N'123', N'Urology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Osman', N'Doral', 222, N'222', N'Cardiology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Didem', N'Kırmızı', 333, N'333', N'Neurology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Hande', N'Erçetin', 444, N'444', N'General Surgery')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Ivana', N'Sert', 555, N'555', N'Cardiology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Buket', N'Susak', 666, N'666', N'Pulmonology')
INSERT [dbo].[Doctor] ([Name], [Surname], [Id], [Password], [Branch]) VALUES (N'Akif', N'Yolcu', 777, N'777', N'Cardiology')
GO
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Pelin', N'Su', 95, N'Kadin', N'stomach ache')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Sedef', N'Kurnaz', 531, N'Kadin', N'')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Oya', N'Bilir', 723, N'Kadin', N'baş ağrısı')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Uraz', N'Dingil', 779, N'Erkek', N'')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Tuana', N'Dokay', 7123, N'Kadin', N'')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'İsmail', N'Saymaz', 8311, N'Erkek', N'')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Duran', N'Buran', 88612, N'Erkek', N'')
INSERT [dbo].[Patient] ([Name], [Surname], [Id], [Gender], [Diagnosis]) VALUES (N'Eren', N'Ortak', 123123, N'Erkek', N'')
GO
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Ahmet', N'Tosla', 1, N'1')
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Aliye', N'Deniz', 111, N'111')
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Demet', N'Uzak', 123, N'123')
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Mine', N'Tugay', 222, N'222')
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Rıdvan', N'Dilmen', 333, N'333')
INSERT [dbo].[Secretary] ([Name], [Surname], [Id], [Password]) VALUES (N'Atiye', N'Göl', 444, N'444')
GO
/****** Object:  StoredProcedure [dbo].[AddAppointment]    Script Date: 30.04.2023 20:11:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAppointment]
    @AppointmentId BIGINT,
    @PatientId INT,
    @DoctorId INT,
    @BranchName nvarchar(max),
	@DateTime DATETIME,
	@Diagnosis NVARCHAR(max)
AS
BEGIN
    IF NOT EXISTS (SELECT Id FROM Patient WHERE Id = @PatientId)
    BEGIN
        RAISERROR( 'PatientId does not match any Id in the Patient table. Appointment cannot be added.',16,1);
        RETURN;
    END
    ELSE IF EXISTS (SELECT 1 FROM Appointment WHERE AppointmentId = @AppointmentId)
    BEGIN
        RAISERROR('An appointment with the same Id already exists!', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        INSERT INTO Appointment (PatientId,DoctorId,BranchName,AppointmentId,DateTime,Diagnosis)
		VALUES (@PatientId,@DoctorId,@BranchName,@AppointmentId,@DateTime,@Diagnosis)
        RETURN;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[CheckAppointmentId]    Script Date: 30.04.2023 20:11:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE CheckPatientId
--    @Name NVARCHAR(max),
--    @Surname NVARCHAR(max),
--    @Id BIGINT,
--    @Gender NVARCHAR(max),
--    @Diagnosis NVARCHAR(max)
--AS
--BEGIN
--    IF EXISTS (SELECT 1 FROM Patient WHERE Id = @Id)
--    BEGIN
--        RAISERROR('A patient with the same Id already exists!', 16, 1);
--        RETURN;
--    END
--    ELSE
--    BEGIN
--        INSERT INTO Patient (Name, Surname, Id, Gender, Diagnosis) 
--        VALUES (@Name, @Surname, @Id, @Gender, @Diagnosis);
--        RETURN;
--    END
--END

CREATE PROCEDURE [dbo].[CheckAppointmentId]
	@AppointmentId BIGINT,
	@PatientId INT,
	@DoctorId INT,
	@BranchName NVARCHAR(max),
	@DateTime datetime,
	@Diagnosis NVARCHAR(max)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Appointment WHERE AppointmentId = @AppointmentId)
    BEGIN
        RAISERROR('An appointment with the same Id already exists!', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        INSERT INTO Appointment (PatientId,DoctorId,BranchName,AppointmentId,DateTime,Diagnosis)
		VALUES (@PatientId,@DoctorId,@BranchName,@AppointmentId,@DateTime,@Diagnosis)
        RETURN;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[CheckPatientId]    Script Date: 30.04.2023 20:11:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckPatientId]
    @Name NVARCHAR(max),
    @Surname NVARCHAR(max),
    @Id BIGINT,
    @Gender NVARCHAR(max),
    @Diagnosis NVARCHAR(max)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Patient WHERE Id = @Id)
    BEGIN
        RAISERROR('A patient with the same Id already exists!', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        INSERT INTO Patient (Name, Surname, Id, Gender, Diagnosis) 
        VALUES (@Name, @Surname, @Id, @Gender, @Diagnosis);
        RETURN;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAppointmentId]    Script Date: 30.04.2023 20:11:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAppointmentId]
    @AppointmentId BIGINT,
	@PatientId INT,
	@DoctorId INT,
	@BranchName NVARCHAR(max),
	@DateTime datetime,
	@Diagnosis NVARCHAR(max)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Appointment WHERE AppointmentId != @AppointmentId)
    BEGIN
        RAISERROR('An appointment with the same Id does not exists!', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        Update Appointment Set DateTime=@DateTime, AppointmentId=@AppointmentId,PatientId=@PatientId,Diagnosis=@Diagnosis 
		WHERE AppointmentId=@AppointmentId
        RETURN;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatientId]    Script Date: 30.04.2023 20:11:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE CheckPatientId
--    @Name NVARCHAR(max),
--    @Surname NVARCHAR(max),
--    @Id BIGINT,
--    @Gender NVARCHAR(max),
--    @Diagnosis NVARCHAR(max)
--AS
--BEGIN
--    IF EXISTS (SELECT 1 FROM Patient WHERE Id = @Id)
--    BEGIN
--        RAISERROR('A patient with the same Id already exists!', 16, 1);
--        RETURN;
--    END
--    ELSE
--    BEGIN
--        INSERT INTO Patient (Name, Surname, Id, Gender, Diagnosis) 
--        VALUES (@Name, @Surname, @Id, @Gender, @Diagnosis);
--        RETURN;
--    END
--END

--CREATE PROCEDURE CheckAppointmentId
--    @AppointmentId BIGINT,
--	@PatientId INT,
--	@DoctorId INT,
--	@BranchName NVARCHAR(max),
--	@DateTime datetime,
--	@Diagnosis NVARCHAR(max)
--AS
--BEGIN
--    IF EXISTS (SELECT 1 FROM Appointment WHERE AppointmentId = @AppointmentId)
--    BEGIN
--        RAISERROR('A patient with the same Id already exists!', 16, 1);
--        RETURN;
--    END
--    ELSE
--    BEGIN
--        INSERT INTO Appointment (PatientId,DoctorId,BranchName,AppointmentId,DateTime,Diagnosis)
--		VALUES (@PatientId,@DoctorId,@BranchName,@AppointmentId,@DateTime,@Diagnosis)
--        RETURN;
--    END
--END

--------

--CREATE PROCEDURE UpdateAppointmentId
--    @AppointmentId BIGINT,
--	@PatientId INT,
--	@DoctorId INT,
--	@BranchName NVARCHAR(max),
--	@DateTime datetime,
--	@Diagnosis NVARCHAR(max)
--AS
--BEGIN
--    IF EXISTS (SELECT 1 FROM Appointment WHERE AppointmentId != @AppointmentId)
--    BEGIN
--        RAISERROR('An appointment with the same Id does not exists!', 16, 1);
--        RETURN;
--    END
--    ELSE
--    BEGIN
--        Update Appointment Set DateTime=@DateTime, AppointmentId=@AppointmentId,PatientId=@PatientId,Diagnosis=@Diagnosis 
--		WHERE AppointmentId=@AppointmentId
--        RETURN;
--    END
--END

CREATE PROCEDURE [dbo].[UpdatePatientId]
    @Name NVARCHAR(max),
    @Surname NVARCHAR(max),
    @Id BIGINT,
    @Gender NVARCHAR(max),
    @Diagnosis NVARCHAR(max)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Patient WHERE Id = @Id)
    BEGIN
        RAISERROR('A patient with the same Id does not exists!', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        Update Patient Set Name=@Name, Surname=@Surname, Id=@Id, Gender=@Gender, Diagnosis=@Diagnosis 
		where Id=@Id
        RETURN;
    END
END
GO
USE [master]
GO
ALTER DATABASE [HospitalSystem] SET  READ_WRITE 
GO
