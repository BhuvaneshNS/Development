USE [master]
GO
/****** Object:  Database [FoodShopDB]    Script Date: 25-08-2022 13:40:17 ******/
CREATE DATABASE [FoodShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FoodShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FoodShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FoodShopDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodShopDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FoodShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodShopDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FoodShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodShopDB] SET RECOVERY FULL 
GO
ALTER DATABASE [FoodShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [FoodShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoodShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FoodShopDB', N'ON'
GO
ALTER DATABASE [FoodShopDB] SET QUERY_STORE = OFF
GO
USE [FoodShopDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25-08-2022 13:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodShops]    Script Date: 25-08-2022 13:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodShops](
	[FastFoodShopId] [int] IDENTITY(1,1) NOT NULL,
	[FastFoodShopName] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_FoodShops] PRIMARY KEY CLUSTERED 
(
	[FastFoodShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 25-08-2022 13:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
	[ItemType] [nvarchar](max) NOT NULL,
	[FastFoodShopId] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 25-08-2022 13:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[PersonName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[EmailId] [nvarchar](max) NOT NULL,
	[PersonCity] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25-08-2022 13:40:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825051517_Initial', N'3.1.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825054943_PersonModelModifications', N'3.1.28')
GO
SET IDENTITY_INSERT [dbo].[FoodShops] ON 

INSERT [dbo].[FoodShops] ([FastFoodShopId], [FastFoodShopName], [City], [PhoneNumber]) VALUES (1, N'string', N'string', N'string')
INSERT [dbo].[FoodShops] ([FastFoodShopId], [FastFoodShopName], [City], [PhoneNumber]) VALUES (2, N'Food Shop 1', N'Mysore', N'1234567890')
SET IDENTITY_INSERT [dbo].[FoodShops] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ItemId], [ItemName], [Price], [ItemType], [FastFoodShopId]) VALUES (1, N'string', 11, N'string', 1)
INSERT [dbo].[Items] ([ItemId], [ItemName], [Price], [ItemType], [FastFoodShopId]) VALUES (2, N'Idli', 22, N'Veg', 2)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [PersonName], [Password], [EmailId], [PersonCity], [RoleId]) VALUES (1, N'bns', N'string', N'user@example.com', N'string', 1)
INSERT [dbo].[People] ([PersonId], [PersonName], [Password], [EmailId], [PersonCity], [RoleId]) VALUES (2, N'Bhuvanesh N S', N'pass123', N'bns@mail.com', N'Coorg', 1)
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
/****** Object:  Index [IX_Items_FastFoodShopId]    Script Date: 25-08-2022 13:40:18 ******/
CREATE NONCLUSTERED INDEX [IX_Items_FastFoodShopId] ON [dbo].[Items]
(
	[FastFoodShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_People_RoleId]    Script Date: 25-08-2022 13:40:18 ******/
CREATE NONCLUSTERED INDEX [IX_People_RoleId] ON [dbo].[People]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_FoodShops_FastFoodShopId] FOREIGN KEY([FastFoodShopId])
REFERENCES [dbo].[FoodShops] ([FastFoodShopId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_FoodShops_FastFoodShopId]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [FoodShopDB] SET  READ_WRITE 
GO
