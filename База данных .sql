USE [master]
GO
/****** Object:  Database [AutoPartsStore]    Script Date: 16.06.2024 15:50:53 ******/
CREATE DATABASE [AutoPartsStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoPartsStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AutoPartsStore.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutoPartsStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AutoPartsStore_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AutoPartsStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoPartsStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoPartsStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoPartsStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoPartsStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoPartsStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoPartsStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoPartsStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AutoPartsStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoPartsStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoPartsStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoPartsStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoPartsStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoPartsStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoPartsStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoPartsStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoPartsStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AutoPartsStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoPartsStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoPartsStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoPartsStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoPartsStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoPartsStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoPartsStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoPartsStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AutoPartsStore] SET  MULTI_USER 
GO
ALTER DATABASE [AutoPartsStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoPartsStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoPartsStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoPartsStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AutoPartsStore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AutoPartsStore]
GO
/****** Object:  Table [dbo].[applications]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[applications](
	[id_application] [int] IDENTITY(1,1) NOT NULL,
	[fk_id_client] [int] NOT NULL,
	[fk_id_spare_part] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[brands]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brands](
	[id_brand] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](35) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categories]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categories](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cells_stocks]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cells_stocks](
	[id_cell] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[fk_id_stock] [int] NOT NULL,
	[capacity] [int] NOT NULL CONSTRAINT [DF_cells_stocks_capacity]  DEFAULT ((15))
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clients]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[fio] [varchar](120) NOT NULL,
	[phone] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[defective_goods]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[defective_goods](
	[id_defect] [int] IDENTITY(1,1) NOT NULL,
	[fk_id_supplies] [int] NOT NULL,
	[amount] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[manufacturers]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[manufacturers](
	[id_manufacturer] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[models]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[models](
	[id_model] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](35) NOT NULL,
	[fk_id_brand] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[products]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[products](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sales]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales](
	[id_sale] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[fk_id_spare_part] [int] NOT NULL,
	[fk_id_client] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[total_price] [decimal](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[spare_part_stock]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[spare_part_stock](
	[id_sp_stock] [int] IDENTITY(1,1) NOT NULL,
	[fk_id_spare_part] [int] NOT NULL,
	[fk_id_cell] [int] NOT NULL,
	[amount] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[spare_parts]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[spare_parts](
	[id_sparePart] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](20) NULL,
	[fk_id_category] [int] NOT NULL,
	[fk_id_manuf] [int] NOT NULL,
	[fk_id_model] [int] NOT NULL,
	[fk_id_product] [int] NOT NULL,
	[price] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stock]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[address] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[supplies]    Script Date: 16.06.2024 15:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplies](
	[id_supply] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[fk_id_spare_part] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[applications] ON 

INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (1, 7, 8)
INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (2, 7, 14)
INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (3, 8, 14)
INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (4, 6, 16)
INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (5, 9, 2)
INSERT [dbo].[applications] ([id_application], [fk_id_client], [fk_id_spare_part]) VALUES (6, 4, 12)
SET IDENTITY_INSERT [dbo].[applications] OFF
SET IDENTITY_INSERT [dbo].[brands] ON 

INSERT [dbo].[brands] ([id_brand], [name]) VALUES (1, N'Ford')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (2, N'Sasha')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (3, N'BMW')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (4, N'BMW1')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (5, N'Sitroen')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (6, N'BMW2')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (7, N'BMW34')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (8, N'Citroen5')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (9, N'CCC')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (10, N'GFG670')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (11, N'GFHjkk')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (12, N'MazDA')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (13, N'Toyuota')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (14, N'Kia')
INSERT [dbo].[brands] ([id_brand], [name]) VALUES (15, N'Ferrarii')
SET IDENTITY_INSERT [dbo].[brands] OFF
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id_category], [name]) VALUES (1, N'Движок')
INSERT [dbo].[categories] ([id_category], [name]) VALUES (2, N'Детали для ТО')
INSERT [dbo].[categories] ([id_category], [name]) VALUES (3, N'Топливо')
INSERT [dbo].[categories] ([id_category], [name]) VALUES (4, N'Кузов')
INSERT [dbo].[categories] ([id_category], [name]) VALUES (5, N'Деталь55')
INSERT [dbo].[categories] ([id_category], [name]) VALUES (6, N'Деталь 56')
SET IDENTITY_INSERT [dbo].[categories] OFF
SET IDENTITY_INSERT [dbo].[cells_stocks] ON 

INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (1, 1, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (2, 2, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (3, 3, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (4, 4, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (5, 5, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (6, 6, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (7, 7, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (8, 8, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (9, 9, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (10, 10, 1, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (11, 11, 2, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (12, 4, 3, 15)
INSERT [dbo].[cells_stocks] ([id_cell], [number], [fk_id_stock], [capacity]) VALUES (13, 7, 3, 15)
SET IDENTITY_INSERT [dbo].[cells_stocks] OFF
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (1, N'Исаков Савва Георгиевич', N'784598')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (2, N'Максимова Светлана Владимировна', N'254879')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (3, N'Гришина Марина Михайловна', N'154879')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (4, N'Власова Вероника Ивановна', N'456518')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (5, N'Петров Денис Константинович', N'546874')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (6, N'Дементьев Глеб Алексеевич', N'189847')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (7, N'Корнев Леонид Миронович', N'574687')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (8, N'Литвинов Павел Константинович', N'688788')
INSERT [dbo].[clients] ([id_client], [fio], [phone]) VALUES (9, N'Ильясевич', N'77777')
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[defective_goods] ON 

INSERT [dbo].[defective_goods] ([id_defect], [fk_id_supplies], [amount]) VALUES (1, 7, 1)
INSERT [dbo].[defective_goods] ([id_defect], [fk_id_supplies], [amount]) VALUES (2, 8, 2)
INSERT [dbo].[defective_goods] ([id_defect], [fk_id_supplies], [amount]) VALUES (3, 9, 1)
INSERT [dbo].[defective_goods] ([id_defect], [fk_id_supplies], [amount]) VALUES (4, 2, 3)
SET IDENTITY_INSERT [dbo].[defective_goods] OFF
SET IDENTITY_INSERT [dbo].[manufacturers] ON 

INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (1, N'Bosh')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (2, N'Valeo')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (3, N'Dfghj')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (4, N'NumberB')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (5, N'Sashaa')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (6, N'Hghkjl')
INSERT [dbo].[manufacturers] ([id_manufacturer], [name]) VALUES (7, N'uiiuuu')
SET IDENTITY_INSERT [dbo].[manufacturers] OFF
SET IDENTITY_INSERT [dbo].[models] ON 

INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (1, N'И', 1)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (2, N'BBB', 2)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (3, N'Test', 3)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (4, N'WWW', 3)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (5, N'DF', 4)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (6, N'GF', 5)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (7, N'HF', 7)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (8, N'HG', 3)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (9, N'SSS', 1)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (10, N'GFTR', 7)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (11, N'XXX', 7)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (12, N'QQ7', 13)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (13, N'QWQW', 14)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (14, N'GHK', 9)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (15, N'Mustang', 1)
INSERT [dbo].[models] ([id_model], [name], [fk_id_brand]) VALUES (16, N'Ciop', 15)
SET IDENTITY_INSERT [dbo].[models] OFF
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id_product], [name]) VALUES (1, N'Сальник коленвала')
INSERT [dbo].[products] ([id_product], [name]) VALUES (2, N'Фильтр воздушный')
INSERT [dbo].[products] ([id_product], [name]) VALUES (3, N'Фильтр салона')
INSERT [dbo].[products] ([id_product], [name]) VALUES (4, N'Колодки тормозные передние')
INSERT [dbo].[products] ([id_product], [name]) VALUES (5, N'Колодки тормозные задние')
INSERT [dbo].[products] ([id_product], [name]) VALUES (6, N'Свеча')
INSERT [dbo].[products] ([id_product], [name]) VALUES (7, N'Топливный фильтр')
SET IDENTITY_INSERT [dbo].[products] OFF
SET IDENTITY_INSERT [dbo].[sales] ON 

INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (1, CAST(N'2024-05-01 00:00:00.000' AS DateTime), 1, 1, 1, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (2, CAST(N'2024-05-02 00:00:00.000' AS DateTime), 2, 2, 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (3, CAST(N'2024-05-02 00:00:00.000' AS DateTime), 3, 3, 2, CAST(1600.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (4, CAST(N'2024-05-03 00:00:00.000' AS DateTime), 4, 4, 2, CAST(3600.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (5, CAST(N'2024-05-03 00:00:00.000' AS DateTime), 4, 8, 1, CAST(1800.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (8, CAST(N'2024-05-05 00:00:00.000' AS DateTime), 5, 6, 1, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (10, CAST(N'2024-05-05 00:00:00.000' AS DateTime), 6, 6, 1, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (11, CAST(N'2024-05-05 00:00:00.000' AS DateTime), 6, 1, 1, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[sales] ([id_sale], [date], [fk_id_spare_part], [fk_id_client], [amount], [total_price]) VALUES (12, CAST(N'2024-05-05 00:00:00.000' AS DateTime), 9, 5, 1, CAST(5444.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[sales] OFF
SET IDENTITY_INSERT [dbo].[spare_part_stock] ON 

INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (1, 2, 1, 10)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (2, 3, 2, 5)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (3, 2, 3, 5)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (4, 4, 7, 10)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (5, 5, 9, 10)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (6, 7, 10, 11)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (7, 8, 11, 10)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (8, 17, 12, 8)
INSERT [dbo].[spare_part_stock] ([id_sp_stock], [fk_id_spare_part], [fk_id_cell], [amount]) VALUES (9, 12, 13, 5)
SET IDENTITY_INSERT [dbo].[spare_part_stock] OFF
SET IDENTITY_INSERT [dbo].[spare_parts] ON 

INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (1, N'1234234', 1, 1, 1, 1, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (2, N'4315214', 2, 2, 1, 2, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (3, N'2341234', 2, 2, 10, 2, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (4, N'2352323', 1, 1, 11, 1, CAST(1800.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (5, N'2352143', 1, 1, 5, 1, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (6, N'2357978', 1, 1, 14, 3, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (7, N'4678467', 2, 2, 6, 3, CAST(550.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (8, N'6478678', 4, 4, 5, 4, CAST(2300.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (9, N'4624565', 4, 4, 7, 4, CAST(5444.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (10, N'4564563', 4, 4, 9, 4, CAST(2355.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (11, N'5675675', 4, 4, 15, 4, CAST(2450.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (12, N'3453453', 4, 4, 6, 5, CAST(3200.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (13, N'3463465', 4, 4, 12, 5, CAST(4000.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (14, N'4562464', 4, 4, 11, 5, CAST(2500.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (15, N'3452345', 2, 2, 9, 6, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (16, N'5783549', 2, 2, 9, 6, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (17, N'7537858', 2, 2, 8, 6, CAST(850.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (18, N'4', 2, 2, 2, 8, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[spare_parts] ([id_sparePart], [code], [fk_id_category], [fk_id_manuf], [fk_id_model], [fk_id_product], [price]) VALUES (19, N'3452345', 4, 3, 9, 7, CAST(344.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[spare_parts] OFF
SET IDENTITY_INSERT [dbo].[stock] ON 

INSERT [dbo].[stock] ([id_stock], [number], [address]) VALUES (1, 11, N'Адрес 1')
INSERT [dbo].[stock] ([id_stock], [number], [address]) VALUES (2, 43, N'Адрес 2')
INSERT [dbo].[stock] ([id_stock], [number], [address]) VALUES (3, 54, N'Адрес 3')
INSERT [dbo].[stock] ([id_stock], [number], [address]) VALUES (4, 32, N'Адрес 4')
INSERT [dbo].[stock] ([id_stock], [number], [address]) VALUES (5, 78, N'Адрес 5')
SET IDENTITY_INSERT [dbo].[stock] OFF
SET IDENTITY_INSERT [dbo].[supplies] ON 

INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (1, CAST(N'2024-03-10' AS Date), 11, 5, CAST(1950.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (2, CAST(N'2024-03-10' AS Date), 3, 3, CAST(450.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (3, CAST(N'2024-03-10' AS Date), 1, 3, CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (4, CAST(N'2024-03-11' AS Date), 2, 3, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (5, CAST(N'2024-03-12' AS Date), 4, 5, CAST(850.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (6, CAST(N'2024-03-13' AS Date), 5, 3, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (7, CAST(N'2024-03-13' AS Date), 13, 5, CAST(2100.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (8, CAST(N'2024-05-05' AS Date), 15, 6, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[supplies] ([id_supply], [date], [fk_id_spare_part], [amount], [price]) VALUES (9, CAST(N'2024-05-05' AS Date), 17, 4, CAST(400.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[supplies] OFF
USE [master]
GO
ALTER DATABASE [AutoPartsStore] SET  READ_WRITE 
GO
