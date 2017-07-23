USE [Beeant]
GO
/****** Object:  Table [dbo].[t_Account_Account]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Account_Account](
	[Id] [bigint] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Payword] [nvarchar](500) NULL,
	[RealName] [nvarchar](20) NULL,
	[Balance] [decimal](18, 2) NULL,
	[Mobile] [nvarchar](30) NULL,
	[Email] [nvarchar](120) NULL,
	[IsActiveEmail] [bit] NOT NULL,
	[IsActiveMobile] [bit] NOT NULL,
	[IsReality] [bit] NULL,
	[IsUsed] [bit] NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Finance_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Account_AccountCard]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Account_AccountCard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Account_AccountCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Account_AccountIdentity]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Account_AccountIdentity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Account_AccountIdentity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Account_AccountItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Account_AccountItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Status] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Remark] [nvarchar](100) NULL,
	[DataId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_AccountItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Account_AccountNumber]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Account_AccountNumber](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[Tag] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Account_AccountNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Agent_Agent]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Agent_Agent](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[Setting] [nvarchar](4000) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Agent_Agent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Api_Protocol]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Api_Protocol](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Nickname] [nvarchar](100) NULL,
	[Detail] [nvarchar](4000) NULL,
	[IsVerify] [bit] NULL,
	[IsStart] [bit] NULL,
	[SecondCount] [int] NULL,
	[DayCount] [int] NULL,
	[IsLog] [bit] NULL,
	[IsSign] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Api_Protocol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Api_Voucher]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Api_Voucher](
	[Id] [bigint] IDENTITY(10000,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Token] [nvarchar](100) NULL,
	[Type] [int] NULL,
	[Url] [varchar](500) NULL,
	[Ips] [varchar](2000) NULL,
	[IsLog] [bit] NULL,
	[IsSign] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Api_Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Api_VoucherProtocol]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Api_VoucherProtocol](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherId] [bigint] NULL,
	[ProtocolId] [bigint] NULL,
	[IsForbid] [bit] NULL,
	[SecondCount] [int] NULL,
	[DayCount] [int] NULL,
	[Args] [nvarchar](1000) NULL,
	[IsLog] [bit] NULL,
	[IsSign] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Api_VoucherProtocol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Ability]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Ability](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuId] [bigint] NULL,
	[Name] [nvarchar](20) NULL,
	[IsVerify] [bit] NULL,
	[IsLog] [bit] NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Authority_Ability] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Menu]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[SubsystemId] [bigint] NULL,
	[Name] [nvarchar](20) NULL,
	[IsBlank] [bit] NULL,
	[IsShow] [bit] NULL,
	[Remark] [nvarchar](100) NULL,
	[Sequence] [int] NULL,
	[Url] [nvarchar](150) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Authority_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Owner]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Owner](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](200) NULL,
	[Nickname] [nvarchar](20) NULL,
	[SubmitCode] [nvarchar](5) NULL,
	[ReadCodes] [nvarchar](200) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Authority_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_OwnerAccount]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_OwnerAccount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OwnerId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Authority_OwnerAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Resource]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Resource](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AbilityId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[URL] [nvarchar](150) NULL,
	[IsValidateParamter] [bit] NULL,
	[IsRegexValidate] [bit] NULL,
	[Controls] [varchar](500) NULL,
	[IsExcude] [bit] NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Authority_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Role]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Remark] [nvarchar](100) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Authority_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_RoleAbility]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_RoleAbility](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NULL,
	[AbilityId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Authority_RoleAbility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_RoleAccount]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_RoleAccount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Authority_RoleAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Authority_Subsystem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authority_Subsystem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Url] [nvarchar](150) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Authority_MenuType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Album]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Album](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[FrontFileName] [varchar](120) NULL,
	[BackFileName] [varchar](120) NULL,
	[AboutFileName] [varchar](120) NULL,
	[Tag] [nvarchar](50) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Path] [varchar](100) NULL,
	[PageSize] [int] NULL,
	[MusicUrl] [nvarchar](500) NULL,
	[Detail] [nvarchar](3000) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Brand]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[EnglishName] [nvarchar](120) NULL,
	[Tag] [nvarchar](100) NULL,
	[Initial] [nvarchar](30) NOT NULL,
	[FileName] [nvarchar](120) NULL,
	[IsUsed] [bit] NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Scm_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_City]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Country]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Currency]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Currency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Code] [varchar](5) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Basedata_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Delivery]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Delivery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[LimitCount] [int] NULL,
	[Remark] [nvarchar](100) NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Basedata_Delivery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_District]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_District](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[Pinyin] [varchar](100) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Freight]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Freight](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[FullFreePrice] [decimal](18, 2) NULL,
	[DefaultCount] [int] NULL,
	[DefaultPrice] [decimal](11, 2) NULL,
	[ContinueCount] [int] NULL,
	[ContinuePrice] [decimal](11, 2) NULL,
	[Description] [nvarchar](200) NULL,
	[Region] [nvarchar](max) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Basedata_Freight] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_PayType]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_PayType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[Url] [nvarchar](500) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_PayMode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Style]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Style](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Type] [int] NULL,
	[Path] [nvarchar](120) NULL,
	[IsShow] [bit] NULL,
	[Sequence] [int] NULL,
	[Detail] [nvarchar](4000) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Basedata_Style] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Tag]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[FileName] [nvarchar](120) NULL,
	[Value] [nvarchar](100) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Basedata_Unit]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Basedata_Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Sequence] [int] NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Basedata_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cart_Attention]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cart_Attention](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Price] [decimal](11, 2) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cart_Attention] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cart_Shopcart]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cart_Shopcart](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Count] [int] NULL,
	[Price] [decimal](11, 2) NULL,
	[Tag] [nvarchar](60) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cart_Shopcart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cart_ShopcartTag]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cart_ShopcartTag](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cart_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cms_Class]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cms_Class](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[Tag] [nvarchar](100) NULL,
	[Name] [nvarchar](20) NULL,
	[Sequence] [int] NULL,
	[IsPublish] [bit] NULL,
	[IsPublic] [bit] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Infomation_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cms_Cms]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cms_Cms](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[IsUsed] [bit] NULL,
	[Setting] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cms_Cms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cms_Content]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cms_Content](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClassId] [bigint] NULL,
	[Title] [nvarchar](80) NULL,
	[FileName] [varchar](120) NULL,
	[Tag] [varchar](500) NULL,
	[Url] [varchar](500) NULL,
	[Sequence] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[Detail] [nvarchar](max) NULL,
	[IsShow] [bit] NULL,
	[AttachmentName] [varchar](120) NULL,
	[UserId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Infomation_Content] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cms_Notice]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cms_Notice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CmsId] [bigint] NULL,
	[Tag] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Url] [nvarchar](500) NULL,
	[Detail] [nvarchar](max) NULL,
	[Sequence] [int] NULL,
	[IsShow] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cms_Notice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Cms_Postcard]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cms_Postcard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FileName] [varchar](120) NULL,
	[Detail] [nvarchar](max) NULL,
	[IsShow] [bit] NULL,
	[CmsId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Cms_Postcard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_Contract]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_Contract](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CrmId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[Content] [nvarchar](4000) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_Crm]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_Crm](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[ExpireDate] [datetime] NULL,
	[Setting] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_Crm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_Customer]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CrmId] [bigint] NULL,
	[TypeId] [bigint] NULL,
	[StaffId] [bigint] NULL,
	[ChannelId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[RemindNoteDate] [datetime] NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[Weixin] [nvarchar](50) NULL,
	[Qq] [nvarchar](30) NULL,
	[Linkman] [nvarchar](20) NULL,
	[Mobile] [nvarchar](30) NOT NULL,
	[Telephone] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[Address] [nvarchar](120) NULL,
	[Remark] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_Customer_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_CustomerChannel]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_CustomerChannel](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CrmId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_CustomerChannel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_CustomerNote]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_CustomerNote](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CrmId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Content] [nvarchar](120) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_CustomerNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Crm_CustomerType]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Crm_CustomerType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CrmId] [bigint] NULL,
	[Name] [nvarchar](80) NOT NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Crm_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Datacube_Trace]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Datacube_Trace](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Tag] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[Value] [nvarchar](200) NULL,
	[Source] [nvarchar](500) NULL,
	[Token] [varchar](50) NULL,
	[Ip] [varchar](500) NULL,
	[Device] [varchar](500) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Datacube_Trace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Editor_Flash]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Editor_Flash](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FolderId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[FileName] [varchar](120) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Editor_Flash] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Editor_Folder]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Editor_Folder](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Type] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Editor_Folder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Editor_Image]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Editor_Image](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FolderId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[FileName] [varchar](120) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Editor_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Editor_Template]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Editor_Template](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FolderId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](max) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Editor_Template] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Bank]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Bank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Number] [nvarchar](60) NOT NULL,
	[Holder] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](100) NOT NULL,
	[Linkman] [nvarchar](30) NOT NULL,
	[Telephone] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](120) NULL,
	[IsAuthentication] [bit] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Finance_Bank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Integral]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Integral](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[AccountId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[SubmitId] [bigint] NULL,
	[Status] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Level] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_IntegralItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Invoicein]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Invoicein](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelType] [int] NULL,
	[Type] [int] NULL,
	[GeneralType] [smallint] NULL,
	[InvoiceNumber] [nvarchar](60) NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Content] [nvarchar](150) NULL,
	[Remark] [nvarchar](100) NULL,
	[IsFlush] [bit] NULL,
	[Recipient] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Address] [nvarchar](150) NULL,
	[ExpressName] [nvarchar](100) NULL,
	[ExpressNumber] [nvarchar](100) NULL,
	[AccountId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[SubmitId] [bigint] NULL,
	[Status] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Level] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_Invoicein] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_InvoiceinItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_InvoiceinItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceinId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_InvoiceinItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Invoiceout]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Invoiceout](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelType] [int] NULL,
	[Type] [int] NULL,
	[GeneralType] [smallint] NULL,
	[InvoiceNumber] [nvarchar](60) NULL,
	[AccountId] [bigint] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Content] [nvarchar](150) NULL,
	[Recipient] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Address] [nvarchar](150) NULL,
	[ExpressName] [nvarchar](100) NULL,
	[ExpressNumber] [nvarchar](100) NULL,
	[Remark] [nvarchar](100) NULL,
	[IsFlush] [bit] NULL,
	[UserId] [bigint] NULL,
	[SubmitId] [bigint] NULL,
	[Status] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Level] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_Invoiceout] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_InvoiceoutItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_InvoiceoutItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceinId] [bigint] NULL,
	[PurchaseId] [bigint] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_InvoiceoutItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Payin]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Payin](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelType] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[IsFlush] [bit] NULL,
	[AccountId] [bigint] NULL,
	[Currency] [nvarchar](20) NULL,
	[PayTime] [datetime] NULL,
	[PayType] [varchar](20) NULL,
	[SourceAmount] [decimal](9, 2) NOT NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Amountinwords] [nvarchar](50) NULL,
	[OriginalNumber] [nvarchar](50) NULL,
	[BankName] [nvarchar](60) NULL,
	[BankNumber] [nvarchar](30) NULL,
	[BankHolder] [nvarchar](30) NULL,
	[Remark] [nvarchar](300) NULL,
	[UserId] [bigint] NULL,
	[SubmitId] [bigint] NULL,
	[Status] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Level] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_Payin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_PayinItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_PayinItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PayinId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_PayinItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Payline]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Payline](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelType] [int] NULL,
	[Type] [int] NULL,
	[Number] [varchar](32) NULL,
	[AccountId] [bigint] NULL,
	[OutNumber] [nvarchar](100) NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[Status] [int] NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_Payline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_PaylineItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_PaylineItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaylineId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_PaylineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_Payout]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_Payout](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChannelType] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[IsFlush] [bit] NULL,
	[AccountId] [bigint] NULL,
	[Currency] [nvarchar](20) NULL,
	[PayTime] [datetime] NULL,
	[PayType] [varchar](20) NULL,
	[SourceAmount] [decimal](10, 2) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Amountinwords] [nvarchar](50) NULL,
	[OriginalNumber] [nvarchar](50) NULL,
	[BankName] [nvarchar](60) NULL,
	[BankNumber] [nvarchar](30) NULL,
	[BankHolder] [nvarchar](30) NULL,
	[Remark] [nvarchar](300) NULL,
	[UserId] [bigint] NULL,
	[SubmitId] [bigint] NULL,
	[Status] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Level] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_Payout] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Finance_PayoutItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Finance_PayoutItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PayoutId] [bigint] NULL,
	[PurchaseId] [bigint] NULL,
	[Amount] [decimal](9, 2) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Finance_PayoutItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Gis_Address]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Gis_Address](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Point] [varchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[Type] [varchar](50) NULL,
	[IsStartWith] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Gis_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Gis_Area]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Gis_Area](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Color] [varchar](100) NULL,
	[Value] [nvarchar](50) NULL,
	[Path] [varchar](max) NULL,
	[Origin] [nvarchar](max) NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Gis_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Hr_Family]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Hr_Family](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HrId] [bigint] NULL,
	[StaffId] [bigint] NULL,
	[Relation] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](20) NULL,
	[IdCardNumber] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[MedicalHistory] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Hr_Family] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Hr_Hr]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Hr_Hr](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Setting] [nvarchar](1000) NULL,
	[AccountId] [bigint] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Hr_Hr] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Hr_Organization]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Hr_Organization](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HrId] [bigint] NULL,
	[Name] [nvarchar](20) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Hr_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Hr_Staff]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Hr_Staff](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HrId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](80) NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[Birthday] [datetime] NULL,
	[IdCardNumber] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Organization] [nvarchar](200) NULL,
	[Position] [nvarchar](50) NULL,
	[Kind] [nvarchar](50) NULL,
	[Grade] [nvarchar](50) NULL,
	[WorkAddress] [nvarchar](80) NULL,
	[StartWorkDate] [datetime] NULL,
	[EnrollmentDate] [datetime] NULL,
	[SocialSecurity] [nvarchar](80) NULL,
	[MedicalHistory] [nvarchar](200) NULL,
	[Company] [nvarchar](80) NULL,
	[Classify] [nvarchar](80) NULL,
	[Remark1] [nvarchar](80) NULL,
	[Remark2] [nvarchar](80) NULL,
	[Remark3] [nvarchar](80) NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Hr_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_ApiTrace]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_ApiTrace](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Method] [nvarchar](150) NULL,
	[Request] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[Ip] [varchar](500) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_ApiTrace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Echo]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Echo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](500) NULL,
	[Request] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[Key] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_Echo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Error]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Error](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](4000) NULL,
	[Detail] [nvarchar](max) NULL,
	[Address] [varchar](500) NULL,
	[Ip] [varchar](500) NULL,
	[Device] [varchar](500) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_Error] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Login]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Login](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Device] [varchar](500) NULL,
	[Ip] [varchar](500) NULL,
	[Message] [varchar](200) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Message]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Content] [nvarchar](4000) NULL,
	[FromAddress] [nvarchar](1000) NULL,
	[ToAddress] [nvarchar](2000) NULL,
	[Status] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Operation]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Operation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Control] [nvarchar](50) NULL,
	[Detail] [nvarchar](max) NULL,
	[Address] [varchar](500) NULL,
	[Ip] [varchar](500) NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Log_Operation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Log_Recycler]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Log_Recycler](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](150) NULL,
	[FileName] [varchar](500) NULL,
 CONSTRAINT [PK_t_Log_Recycler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Management_ListSearch]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Management_ListSearch](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](500) NULL,
	[AccountId] [bigint] NULL,
	[Website] [nvarchar](50) NULL,
	[Detail] [nvarchar](4000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Management_ListSearch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Management_User]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Management_User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[AccountId] [bigint] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Management_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Market_Market]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Market_Market](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](50) NULL,
	[Name] [nvarchar](20) NULL,
	[FileName] [varchar](120) NULL,
	[Sequence] [int] NULL,
	[Description] [nvarchar](20) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Market_Market] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Market_Vender]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Market_Vender](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Description] [nvarchar](200) NULL,
	[MarketId] [bigint] NULL,
	[Url] [varchar](500) NULL,
	[Sequence] [int] NULL,
	[IsShow] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Market_Vender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Address]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Address](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[County] [nvarchar](50) NULL,
	[Recipient] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Address] [nvarchar](150) NULL,
	[Tag] [nvarchar](30) NULL,
	[Email] [nvarchar](80) NULL,
	[Telephone] [nvarchar](30) NULL,
	[Company] [nvarchar](80) NULL,
	[IsDefault] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Browse]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Browse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Browse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Coupon]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Coupon](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[CouponerId] [bigint] NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Amount] [decimal](11, 2) NULL,
	[EndDate] [datetime] NULL,
	[UsedTime] [datetime] NULL,
	[CollectTime] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[OrderIds] [varchar](1000) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Coupon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Invoice]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Invoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Type] [smallint] NULL,
	[GeneralType] [smallint] NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [nvarchar](150) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Recipient] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Postcode] [nvarchar](10) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Member]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Member](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[AgentId] [bigint] NULL,
	[Nickname] [nvarchar](30) NULL,
	[HeadUrl] [varchar](500) NULL,
	[IdCardNumber] [nvarchar](20) NULL,
	[Gender] [nvarchar](2) NULL,
	[Telephone] [nvarchar](30) NULL,
	[Address] [nvarchar](120) NULL,
	[Postal] [varchar](20) NULL,
	[Birthday] [datetime] NULL,
	[Remark] [nvarchar](200) NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Member_Message]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Member_Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Title] [nvarchar](200) NULL,
	[Detail] [nvarchar](1000) NULL,
	[IsRead] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Member_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Merchant_Catalogue]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Merchant_Catalogue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[ParentId] [bigint] NULL,
	[Name] [nvarchar](20) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Merchant_Catalogue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Merchant_CatalogueGoods]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Merchant_CatalogueGoods](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CatalogueId] [bigint] NULL,
	[GoodsId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Merchant_CatalogueGoods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Merchant_MerchantOrder]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Merchant_MerchantOrder](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Merchant_MerchantOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Merchant_Partner]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Merchant_Partner](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[AccountId] [bigint] NULL,
	[Postcode] [nvarchar](20) NULL,
	[Linkman] [nvarchar](30) NULL,
	[Msn] [nvarchar](120) NULL,
	[Mobile] [nvarchar](30) NULL,
	[Telephone] [nvarchar](30) NULL,
	[Fax] [nvarchar](30) NULL,
	[Area] [nvarchar](30) NULL,
	[Country] [nvarchar](30) NULL,
	[Province] [nvarchar](30) NULL,
	[City] [nvarchar](30) NULL,
	[Gender] [nvarchar](1) NULL,
	[Address] [nvarchar](120) NULL,
	[Qq] [nvarchar](50) NULL,
	[FileName] [varchar](120) NULL,
	[Tag] [varchar](1000) NULL,
	[Domain] [nvarchar](200) NULL,
	[Remark] [nvarchar](100) NULL,
	[WebsiteStyleId] [bigint] NULL,
	[MobileStyleId] [bigint] NULL,
	[ServiceId] [bigint] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Merchant_Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_Order]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[Type] [int] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[TotalPayAmount] [decimal](18, 2) NULL,
	[TotalInvoiceAmount] [decimal](18, 2) NULL,
	[PayAmount] [decimal](18, 2) NULL,
	[InvoiceAmount] [decimal](18, 2) NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[Deposit] [decimal](11, 2) NULL,
	[ChannelType] [int] NULL,
	[AccountId] [bigint] NULL,
	[SettleType] [int] NULL,
	[PayTypes] [nvarchar](500) NULL,
	[Variables] [nvarchar](2000) NULL,
	[RouteId] [varchar](100) NULL,
	[Status] [int] NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderAttachment]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderAttachment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Tag] [nvarchar](100) NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](80) NOT NULL,
	[FileName] [nvarchar](120) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderAttachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderCard]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderCard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderComplaint]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderComplaint](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](50) NULL,
	[ParentId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Question] [nvarchar](200) NULL,
	[Answer] [nvarchar](1000) NULL,
	[AnswerTime] [datetime] NULL,
	[Type] [int] NULL,
	[IsReply] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderComplaint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderExpress]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderExpress](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Key] [varchar](50) NULL,
	[DeliveryDate] [datetime] NULL,
	[Amount] [decimal](11, 2) NULL,
	[Cost] [decimal](11, 2) NULL,
	[Name] [nvarchar](100) NULL,
	[Number] [nvarchar](100) NULL,
	[Recipient] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Address] [nvarchar](150) NULL,
	[Remark] [nvarchar](100) NULL,
	[Email] [nvarchar](80) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderExpress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderInsurance]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderInsurance](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Key] [varchar](50) NULL,
	[Relation] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Gender] [nvarchar](1) NULL,
	[IdCardNumber] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[MedicalHistory] [nvarchar](200) NULL,
	[EffectiveDate] [datetime] NULL,
	[ExpireDate] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderInsurance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderInvoice]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderInvoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](150) NULL,
	[Number] [nvarchar](50) NULL,
	[Amount] [decimal](11, 2) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderInvoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[Tag] [nvarchar](100) NULL,
	[Price] [decimal](11, 2) NOT NULL,
	[Cost] [decimal](11, 2) NULL,
	[Count] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CostAmount] [decimal](11, 2) NULL,
	[InvoiceAmount] [decimal](11, 2) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderLinkman]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderLinkman](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Mobile] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderLinkman] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderNote]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderNote](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Key] [varchar](50) NULL,
	[AccountId] [bigint] NOT NULL,
	[Content] [nvarchar](120) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderNumber]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderNumber](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [nvarchar](50) NULL,
	[Number] [nvarchar](100) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderPay]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderPay](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[Key] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Tag] [nvarchar](50) NULL,
	[Amount] [decimal](11, 2) NULL,
	[Number] [nvarchar](50) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderPay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Order_OrderProduct]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order_OrderProduct](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](50) NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Price] [decimal](11, 2) NOT NULL,
	[Cost] [decimal](11, 2) NULL,
	[Count] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[PromotionId] [bigint] NULL,
	[IsInvoice] [bit] NULL,
	[IsCount] [bit] NULL,
	[Number] [nvarchar](50) NULL,
	[FileName] [varchar](150) NULL,
	[IsAppraisement] [bit] NULL,
	[IsReturn] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Order_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Category]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Category](
	[Id] [bigint] IDENTITY(1000,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[Name] [nvarchar](80) NULL,
	[Pinyin] [varchar](500) NULL,
	[Initial] [varchar](80) NULL,
	[IsPublish] [bit] NULL,
	[IsShow] [bit] NULL,
	[Url] [varchar](500) NULL,
	[ImageCount] [int] NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Comment]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Comment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Detail] [nvarchar](200) NULL,
	[Type] [int] NULL,
	[IsShow] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Goods]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Goods](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NULL,
	[Name] [nvarchar](120) NULL,
	[FileName] [nvarchar](150) NULL,
	[IsSales] [bit] NULL,
	[AccountId] [bigint] NULL,
	[FreightId] [bigint] NULL,
	[Sequence] [int] NULL,
	[UnusedStatus] [varchar](200) NULL,
	[Tag] [varchar](100) NULL,
	[DataId] [nvarchar](100) NULL,
	[Price] [decimal](11, 2) NULL,
	[Cost] [decimal](11, 2) NULL,
	[PayTypes] [nvarchar](500) NULL,
	[Count] [int] NULL,
	[OrderMinCount] [int] NULL,
	[OrderStepCount] [int] NULL,
	[DepositRate] [decimal](11, 2) NULL,
	[IsCustom] [bit] NULL,
	[IsReturn] [bit] NULL,
	[VisitCount] [int] NULL,
	[AttentionCount] [int] NULL,
	[SalesCount] [int] NULL,
	[PublishTime] [datetime] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Goods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_GoodsDetail]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_GoodsDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GoodsId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Attachment] [varbinary](150) NULL,
	[Detail] [nvarchar](max) NULL,
	[ProductId] [bigint] NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_GoodsDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_GoodsImage]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_GoodsImage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GoodsId] [bigint] NULL,
	[FileName] [nvarchar](150) NULL,
	[Sequence] [int] NULL,
	[ProductId] [bigint] NULL,
	[Sku] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_GoodsImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_GoodsProperty]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_GoodsProperty](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GoodsId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[PropertyId] [bigint] NULL,
	[Value] [nvarchar](500) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_GoodsProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Inquery]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Inquery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[GoodsId] [bigint] NULL,
	[Tag] [nvarchar](50) NULL,
	[Question] [nvarchar](200) NULL,
	[Answer] [nvarchar](1000) NULL,
	[AnswerTime] [datetime] NULL,
	[IsReply] [bit] NULL,
	[IsShow] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Productr_Inquery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Message]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[PromotionItemId] [bigint] NULL,
	[Name] [nvarchar](80) NULL,
	[Mobile] [nvarchar](11) NULL,
	[Email] [nvarchar](80) NULL,
	[MessageType] [int] NULL,
	[CreatedTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Platform]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Platform](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[GoodsId] [bigint] NULL,
	[DataId] [nvarchar](100) NULL,
	[SynchTime] [datetime] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Platform] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Product]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GoodsId] [bigint] NULL,
	[Name] [nvarchar](120) NULL,
	[Price] [decimal](11, 2) NULL,
	[Cost] [decimal](11, 2) NULL,
	[Count] [int] NULL,
	[OrderMinCount] [int] NULL,
	[OrderStepCount] [int] NULL,
	[FileName] [varchar](120) NULL,
	[Sku] [nvarchar](1000) NULL,
	[IsSales] [bit] NULL,
	[DataId] [varchar](100) NULL,
	[DepositRate] [decimal](11, 2) NULL,
	[VisitCount] [int] NULL,
	[AttentionCount] [int] NULL,
	[SalesCount] [int] NULL,
	[IsCustom] [bit] NULL,
	[IsReturn] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Property]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Property](
	[Id] [bigint] IDENTITY(10000,1) NOT NULL,
	[CategoryId] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[SearchType] [int] NULL,
	[Message] [nvarchar](50) NULL,
	[CustomCount] [int] NULL,
	[IsUsed] [bit] NULL,
	[IsAllowEdit] [bit] NULL,
	[Tag] [nvarchar](100) NULL,
	[Sequence] [int] NULL,
	[Value] [nvarchar](3000) NULL,
	[SearchValue] [nvarchar](3000) NULL,
	[IsSku] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_PropertyRule]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_PropertyRule](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PropertyId] [bigint] NULL,
	[RuleId] [bigint] NULL,
	[Type] [int] NULL,
	[IsMultiline] [bit] NULL,
	[IsIgnoreCase] [bit] NULL,
	[Message] [nvarchar](50) NULL,
	[Paramter] [varchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_PropertyRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Product_Rule]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Product_Rule](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NULL,
	[Pattern] [nvarchar](2000) NULL,
	[Sequence] [int] NULL,
	[IsRange] [bit] NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Product_Rule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Promotion_Couponer]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Promotion_Couponer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Amount] [decimal](11, 2) NULL,
	[EndDate] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[IsShow] [bit] NULL,
	[Count] [int] NULL,
	[CollectCount] [int] NULL,
	[CollectEndDate] [datetime] NOT NULL,
	[IsCode] [bit] NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Promotion_Couponer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Promotion_Promotion]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Promotion_Promotion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[BeginTime] [nvarchar](50) NULL,
	[EndTime] [nvarchar](50) NULL,
	[Weeks] [varchar](120) NULL,
	[Months] [varchar](100) NULL,
	[PayTypes] [nvarchar](500) NULL,
	[Cities] [nvarchar](500) NULL,
	[ProductId] [bigint] NULL,
	[Price] [decimal](9, 2) NULL,
	[OrderLimitCount] [int] NULL,
	[IsUsed] [bit] NULL,
	[Tag] [nvarchar](100) NULL,
	[Remark] [nvarchar](150) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Promotion_Promotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_Purchase]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_Purchase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[AccountId] [bigint] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[PayAmount] [decimal](18, 2) NULL,
	[InvoiceAmount] [decimal](18, 2) NOT NULL,
	[OpenAmount] [decimal](18, 2) NULL,
	[PurchaseDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[FollowId] [bigint] NOT NULL,
	[Type] [int] NULL,
	[Remark] [nvarchar](100) NULL,
	[OriginalPurchaseId] [bigint] NULL,
	[UserId] [bigint] NOT NULL,
	[SubmitId] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[StatusTime] [datetime] NOT NULL,
	[Level] [nvarchar](20) NOT NULL,
	[StorehouseId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_PurchaseAttachment]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_PurchaseAttachment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[FileName] [nvarchar](120) NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_PurchaseAttachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_PurchaseExpress]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_PurchaseExpress](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NOT NULL,
	[Amount] [decimal](11, 2) NULL,
	[Name] [nvarchar](100) NULL,
	[Number] [nvarchar](100) NULL,
	[Recipient] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Postcode] [nvarchar](10) NULL,
	[Address] [nvarchar](150) NULL,
	[Remark] [nvarchar](100) NULL,
	[UserId] [bigint] NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_PurchaseExpress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_PurchaseInvoice]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_PurchaseInvoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NULL,
	[Number] [nvarchar](50) NULL,
	[Amount] [decimal](11, 2) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_PurchaseInvoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_PurchaseItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_PurchaseItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[IsOpen] [bit] NULL,
	[Type] [int] NULL,
	[Name] [nvarchar](120) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Count] [int] NULL,
	[Price] [decimal](11, 2) NULL,
	[Remark] [nvarchar](100) NULL,
	[UserId] [bigint] NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_PurchaseItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Purchase_PurchasePay]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Purchase_PurchasePay](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Amount] [decimal](11, 2) NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Purchase_PurchasePay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Search_Key]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Search_Key](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](50) NULL,
	[Ip] [nvarchar](120) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Search_Key] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Search_RelateKey]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Search_RelateKey](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KeyName] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Source] [nvarchar](50) NULL,
	[Ip] [nvarchar](120) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Search_RelateKey_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Search_Similar]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Search_Similar](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[WordId] [bigint] NULL,
	[Weight] [float] NULL,
	[Count] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Search_Similar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Search_Word]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Search_Word](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Pinyin] [nvarchar](800) NULL,
	[Original] [nvarchar](100) NULL,
	[IsForbid] [bit] NULL,
	[Count] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Search_Word] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Security_Code]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Security_Code](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Tag] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Value] [nvarchar](50) NULL,
	[EffectiveTime] [datetime] NULL,
	[ToAddress] [nvarchar](200) NULL,
	[SendStep] [int] NULL,
	[Subject] [nvarchar](500) NULL,
	[Body] [nvarchar](3000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Security_Code] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Security_Locker]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Security_Locker](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[Name] [nvarchar](20) NOT NULL,
	[LockTime] [datetime] NULL,
	[ErrorCount] [int] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Security_Locker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Security_Temporary]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Security_Temporary](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[Name] [nvarchar](20) NOT NULL,
	[EffectiveTime] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Security——Temporary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Banner]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Banner](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NULL,
	[FileName] [nvarchar](150) NULL,
	[Url] [nvarchar](50) NULL,
	[IsShow] [bit] NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Book]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Book](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NULL,
	[IsUsed] [bit] NULL,
	[FileName] [nvarchar](150) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Site_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Catalog]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Catalog](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Name] [nvarchar](120) NULL,
	[FileName] [nvarchar](150) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Certificate]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Certificate](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NULL,
	[FileName] [nvarchar](150) NULL,
	[Sequence] [int] NULL,
	[IsShow] [bit] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Certificate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Commodity]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Commodity](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NULL,
	[CatalogId] [bigint] NULL,
	[Password] [nvarchar](6) NULL,
	[Sequence] [int] NULL,
	[Name] [nvarchar](120) NULL,
	[FileName] [nvarchar](150) NULL,
	[Cost] [decimal](11, 2) NULL,
	[Price] [decimal](11, 2) NULL,
	[IsShowPrice] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[VenderName] [nvarchar](50) NULL,
	[VenderLinkman] [nvarchar](50) NULL,
	[VenderMobile] [nvarchar](50) NULL,
	[VenderAddress] [nvarchar](50) NULL,
	[AlbumFileName] [varchar](120) NULL,
	[IsCreateAlbum] [bit] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_CommodityImage]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_CommodityImage](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[CommodityId] [bigint] NULL,
	[Sequence] [int] NULL,
	[FileName] [nvarchar](150) NULL,
	[SiteId] [bigint] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Site_CommodityImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_CommodityTag]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_CommodityTag](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[CommodityId] [bigint] NULL,
	[TagId] [bigint] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_CommodityTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Company]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Company](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SiteId] [bigint] NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](80) NULL,
	[Linkman] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
	[Qq] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Detail] [nvarchar](2000) NULL,
	[WeixinQrCodeFileName] [nvarchar](500) NULL,
	[RecordNumber] [nvarchar](100) NULL,
	[AlbumId] [bigint] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Inquery]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Inquery](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NULL,
	[Content] [nvarchar](200) NULL,
	[Linkman] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Inquery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Message]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Message](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Type] [nvarchar](30) NULL,
	[Name] [nvarchar](30) NULL,
	[Content] [nvarchar](500) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Site_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_News]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_News](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[IsShow] [bit] NULL,
	[Content] [nvarchar](2000) NULL,
	[SiteId] [bigint] NOT NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Site]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Site](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Domain] [nvarchar](100) NULL,
	[AccountId] [bigint] NOT NULL,
	[ExpireDate] [datetime] NULL,
	[LogoFileName] [varchar](150) NULL,
	[FaviconFileName] [varchar](150) NULL,
	[Setting] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Site_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Site_Tag]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Site_Tag](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Name] [nvarchar](120) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Site_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Supplier_Certification]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Supplier_Certification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Certification] [nvarchar](120) NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_SupplierCertification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Supplier_Contract]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Supplier_Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[SettlementType] [nvarchar](100) NOT NULL,
	[PaymentType] [smallint] NOT NULL,
	[DispatchType] [smallint] NOT NULL,
	[BillType] [smallint] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Rebate] [nvarchar](200) NULL,
	[Attachment] [nvarchar](120) NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_SupplierContract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Supplier_Qualification]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Supplier_Qualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[AgencyLicense] [nvarchar](120) NOT NULL,
	[BusinessLicense] [nvarchar](120) NOT NULL,
	[BankLicense] [nvarchar](120) NOT NULL,
	[TaxLicense] [nvarchar](120) NOT NULL,
	[TrademarkLicense] [nvarchar](120) NOT NULL,
	[BrandAuthorization] [smallint] NOT NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_SupplierQualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Supplier_Supplier]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Supplier_Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[Postcode] [nvarchar](10) NULL,
	[Province] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[County] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](120) NOT NULL,
	[WebUrl] [nvarchar](120) NULL,
	[BusinessRange] [nvarchar](200) NOT NULL,
	[BusinessBrand] [nvarchar](200) NOT NULL,
	[SalesRange] [nvarchar](200) NOT NULL,
	[Linkman] [nvarchar](30) NOT NULL,
	[Telephone] [nvarchar](30) NOT NULL,
	[Fax] [nvarchar](30) NOT NULL,
	[Mobile] [nvarchar](30) NULL,
	[Email] [nvarchar](120) NULL,
	[Qq] [nvarchar](30) NULL,
	[ServiceTelephone] [nvarchar](30) NOT NULL,
	[ServiceAddress] [nvarchar](120) NOT NULL,
	[Receiver] [nvarchar](30) NOT NULL,
	[ReceiverTelephone] [nvarchar](30) NOT NULL,
	[Status] [smallint] NOT NULL,
	[ServiceId] [bigint] NULL,
	[InsertTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[DeleteTime] [datetime] NOT NULL,
	[Mark] [tinyint] NOT NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_t_Supplier_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Sys_Event]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Sys_Event](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](200) NULL,
	[Name] [nvarchar](20) NULL,
	[Url] [varchar](150) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Sys_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Sys_Language]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Sys_Language](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[Key] [nvarchar](100) NULL,
	[Type] [nvarchar](20) NULL,
	[Name] [nvarchar](20) NULL,
	[Value] [nvarchar](4000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Sys_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Sys_Parameter]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Sys_Parameter](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Value] [nvarchar](150) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Sys_Parameter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Sys_Queue]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Sys_Queue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Value] [nvarchar](4000) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Sys_Queue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Sys_Task]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Sys_Task](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[ClassName] [varchar](150) NULL,
	[BeginTime] [datetime] NULL,
	[Recycle] [int] NULL,
	[Args] [nvarchar](500) NULL,
	[Months] [varchar](120) NULL,
	[Weeks] [varchar](15) NULL,
	[Remark] [nvarchar](100) NULL,
	[IsStart] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Sys_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_Inventory]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_Inventory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[StorehouseId] [bigint] NULL,
	[Count] [int] NULL,
	[LockCount] [int] NULL,
	[WarningCount] [int] NULL,
	[TransitCount] [int] NULL,
	[Recycle] [int] NULL,
	[Cities] [nvarchar](500) NULL,
	[BeginTime] [datetime] NULL,
	[Weeks] [varchar](15) NULL,
	[Months] [varchar](120) NULL,
	[Type] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Storage_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_Shelf]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_Shelf](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[StorehouseId] [bigint] NULL,
	[Count] [int] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Storage_Shelf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_Shift]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_Shift](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ShelfId] [bigint] NULL,
	[Count] [int] NULL,
	[Remark] [nvarchar](200) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Storage_Shift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_Stock]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_Stock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[PurchaseId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Remark] [nvarchar](100) NULL,
	[IsFlush] [bit] NULL,
	[UserId] [bigint] NOT NULL,
	[SubmitId] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[StatusTime] [datetime] NOT NULL,
	[Level] [nvarchar](20) NOT NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Storage_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_StockItem]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_StockItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StockId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[StorehouseId] [bigint] NULL,
	[Name] [nvarchar](120) NULL,
	[Count] [int] NULL,
	[Remark] [nvarchar](100) NULL,
	[IsCount] [bit] NULL,
	[IsLockCount] [bit] NULL,
	[UserId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Storage_StockItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Wms_Storehouse]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Wms_Storehouse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](100) NULL,
	[Sequence] [int] NULL,
	[IsUsed] [bit] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [pk_t_Storage_Storehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Auditor]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Auditor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Auditor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_AuditorAccount]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_AuditorAccount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AuditorId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_AuditorAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Condition]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Condition](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NodeId] [bigint] NULL,
	[InspectExp] [nvarchar](300) NULL,
	[SelectExp] [nvarchar](200) NULL,
	[Argument] [varchar](800) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Condition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Flow]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Flow](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[Name] [varchar](30) NULL,
	[ClassName] [varchar](300) NULL,
	[Url] [varchar](150) NULL,
	[EmailUrl] [varchar](150) NULL,
	[MobileUrl] [varchar](150) NULL,
	[DefaultUrl] [varchar](150) NULL,
	[Remark] [nvarchar](100) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Flow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Group]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Group](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Key] [nvarchar](50) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_GroupFlow]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_GroupFlow](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FlowId] [bigint] NULL,
	[GroupId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_GroupFlow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Level]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Level](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Color] [varchar](10) NULL,
	[Sequence] [int] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Level] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Message]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FlowId] [bigint] NULL,
	[Title] [nvarchar](100) NULL,
	[LevelId] [bigint] NULL,
	[DataId] [bigint] NULL,
	[IsRead] [bit] NULL,
	[NodeId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[TaskId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Node]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Node](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FlowId] [bigint] NULL,
	[AuditorId] [bigint] NULL,
	[IsGroup] [bit] NULL,
	[Name] [nvarchar](50) NULL,
	[Nickname] [nvarchar](20) NULL,
	[NodeType] [int] NULL,
	[PassName] [nvarchar](50) NULL,
	[RejectName] [nvarchar](50) NULL,
	[AssignType] [int] NULL,
	[ConditionType] [int] NULL,
	[Timeout] [int] NULL,
	[MessageType] [int] NULL,
	[MessageTitle] [nvarchar](100) NULL,
	[DefaultMessage] [nvarchar](500) NULL,
	[EmailMessage] [nvarchar](500) NULL,
	[MobileMessage] [nvarchar](500) NULL,
	[ConditionMethod] [nvarchar](200) NULL,
	[BeforeMethod] [nvarchar](200) NULL,
	[AfterMethod] [nvarchar](200) NULL,
	[StatusName] [nvarchar](50) NULL,
	[StatusValue] [nvarchar](50) NULL,
	[Sequence] [int] NULL,
	[RecordProperties] [nvarchar](500) NULL,
	[Remark] [nvarchar](100) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Node] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Property]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Property](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NodeId] [bigint] NULL,
	[Name] [varchar](50) NULL,
	[Nickname] [varchar](30) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Workflow_Task]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Workflow_Task](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FlowId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[NodeId] [bigint] NULL,
	[DataId] [bigint] NULL,
	[LevelId] [bigint] NULL,
	[OverTime] [datetime] NULL,
	[DataInfo] [nvarchar](4000) NULL,
	[HandleTime] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Worklflow_GroupAccount]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Worklflow_GroupAccount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [bigint] NULL,
	[GroupId] [bigint] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[DeleteTime] [datetime] NULL,
	[Mark] [tinyint] NULL,
	[Version] [bigint] NULL,
 CONSTRAINT [PK_t_Workflow_GroupAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_IsActiveEmail]  DEFAULT ((0)) FOR [IsActiveEmail]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_IsActiveMobile]  DEFAULT ((0)) FOR [IsActiveMobile]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_IsUsed]  DEFAULT ((1)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Account_Account] ADD  CONSTRAINT [DF_t_Finance_Account_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Agent_Agent] ADD  CONSTRAINT [DF_t_Agent_Agent_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Agent_Agent] ADD  CONSTRAINT [DF_t_Agent_Agent_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Agent_Agent] ADD  CONSTRAINT [DF_t_Agent_Agent_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Agent_Agent] ADD  CONSTRAINT [DF_t_Agent_Agent_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Agent_Agent] ADD  CONSTRAINT [DF_t_Agent_Agent_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_Status]  DEFAULT ((1)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Basedata_Brand] ADD  CONSTRAINT [DF_t_Scm_Brand_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_IsUsed]  DEFAULT ((1)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Basedata_District] ADD  CONSTRAINT [DF_t_Basedata_District_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Basedata_PayType] ADD  CONSTRAINT [DF_t_Basedata_PayMode_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Basedata_PayType] ADD  CONSTRAINT [DF_t_Basedata_PayMode_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Basedata_PayType] ADD  CONSTRAINT [DF_t_Basedata_PayMode_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Basedata_PayType] ADD  CONSTRAINT [DF_t_Basedata_PayMode_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Basedata_PayType] ADD  CONSTRAINT [DF_t_Basedata_PayMode_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Basedata_Tag] ADD  CONSTRAINT [DF_t_Basedata_Tag_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Basedata_Tag] ADD  CONSTRAINT [DF_t_Basedata_Tag_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Basedata_Tag] ADD  CONSTRAINT [DF_t_Basedata_Tag_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Basedata_Tag] ADD  CONSTRAINT [DF_t_Basedata_Tag_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Basedata_Tag] ADD  CONSTRAINT [DF_t_Basedata_Tag_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF__t_Basedat__seque__06A2E7C5]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF_t_Basedata_Unit_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF_t_Basedata_Unit_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF_t_Basedata_Unit_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF_t_Basedata_Unit_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Basedata_Unit] ADD  CONSTRAINT [DF_t_Basedata_Unit_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Editor_Folder] ADD  CONSTRAINT [DF_t_Editor_Folder_Sequence]  DEFAULT ((1)) FOR [Sequence]
GO
ALTER TABLE [dbo].[t_Finance_Bank] ADD  CONSTRAINT [DF_t_Finance_Bank_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Finance_Bank] ADD  CONSTRAINT [DF_t_Finance_Bank_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Finance_Bank] ADD  CONSTRAINT [DF_t_Finance_Bank_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Finance_Bank] ADD  CONSTRAINT [DF_t_Finance_Bank_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Finance_Bank] ADD  CONSTRAINT [DF_t_Finance_Bank_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Product_Goods] ADD  CONSTRAINT [DF_t_Product_Goods_Count]  DEFAULT ((0)) FOR [Count]
GO
ALTER TABLE [dbo].[t_Product_Goods] ADD  CONSTRAINT [DF_t_Product_Goods_OrderMinCount_1]  DEFAULT ((0)) FOR [OrderMinCount]
GO
ALTER TABLE [dbo].[t_Product_Goods] ADD  CONSTRAINT [DF_t_Product_Goods_OrderStepCount_1]  DEFAULT ((0)) FOR [OrderStepCount]
GO
ALTER TABLE [dbo].[t_Product_GoodsProperty] ADD  CONSTRAINT [DF_t_Product_GoodsProperty_ProductId]  DEFAULT ((0)) FOR [ProductId]
GO
ALTER TABLE [dbo].[t_Product_Property] ADD  CONSTRAINT [DF_t_Product_Property_IsAllowEdit]  DEFAULT ((0)) FOR [IsAllowEdit]
GO
ALTER TABLE [dbo].[t_Purchase_Purchase] ADD  CONSTRAINT [DF_t_Purchase_Purchase_ReceiptAmount]  DEFAULT ((0)) FOR [InvoiceAmount]
GO
ALTER TABLE [dbo].[t_Search_Word] ADD  CONSTRAINT [DF_t_Search_Word_IsForbid]  DEFAULT ((0)) FOR [IsForbid]
GO
ALTER TABLE [dbo].[t_Supplier_Certification] ADD  CONSTRAINT [DF_SupplierCertification_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Supplier_Certification] ADD  CONSTRAINT [DF_SupplierCertification_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Supplier_Certification] ADD  CONSTRAINT [DF_SupplierCertification_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Supplier_Certification] ADD  CONSTRAINT [DF_SupplierCertification_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Supplier_Certification] ADD  CONSTRAINT [DF_t_Supplier_Certification_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Supplier_Contract] ADD  CONSTRAINT [DF_SupplierContract_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Supplier_Contract] ADD  CONSTRAINT [DF_SupplierContract_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Supplier_Contract] ADD  CONSTRAINT [DF_SupplierContract_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Supplier_Contract] ADD  CONSTRAINT [DF_SupplierContract_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Supplier_Contract] ADD  CONSTRAINT [DF_t_Supplier_Contract_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Supplier_Qualification] ADD  CONSTRAINT [DF_SupplierQualification_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Supplier_Qualification] ADD  CONSTRAINT [DF_SupplierQualification_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[t_Supplier_Qualification] ADD  CONSTRAINT [DF_SupplierQualification_DeleteTime]  DEFAULT (getdate()) FOR [DeleteTime]
GO
ALTER TABLE [dbo].[t_Supplier_Qualification] ADD  CONSTRAINT [DF_SupplierQualification_Mark]  DEFAULT ((1)) FOR [Mark]
GO
ALTER TABLE [dbo].[t_Supplier_Qualification] ADD  CONSTRAINT [DF_t_Supplier_Qualification_Version]  DEFAULT ((0)) FOR [Version]
GO
ALTER TABLE [dbo].[t_Supplier_Supplier] ADD  CONSTRAINT [DF_t_Supplier_Supplier_StatusFlag]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[t_Supplier_Supplier] ADD  CONSTRAINT [DF_t_Supplier_Supplier_InsertTime]  DEFAULT (getdate()) FOR [InsertTime]
GO
ALTER TABLE [dbo].[t_Supplier_Supplier] ADD  CONSTRAINT [DF_t_Supplier_Supplier_Mark]  DEFAULT ((1)) FOR [Mark]
GO
/****** Object:  StoredProcedure [dbo].[ImportRecycler]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ImportRecycler]
 
AS
BEGIN
 declare @day int
 set @day=-30
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Banner',FileName from t_Site_Banner where FileName<>'' and FileName is not null and DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Catalog',FileName from t_Site_Catalog where FileName<>'' and FileName is not null and DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Certificate',FileName from t_Site_Certificate where FileName<>'' and FileName is not null and DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Commodity',FileName from t_Site_Commodity where FileName<>'' and FileName is not null and  DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_CommodityImage',FileName from t_Site_CommodityImage where FileName<>'' and FileName is not null and  DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Site',LogoFileName from t_Site_Site where LogoFileName<>'' and LogoFileName is not null and  DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 insert into [dbo].[t_Log_Recycler] (TableName,FileName) select 't_Site_Site',FaviconFileName from t_Site_Site where FaviconFileName<>'' and FaviconFileName is not null and  DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Banner where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Catalog where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Certificate where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Commodity where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_CommodityImage where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_CommodityTag where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Company where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Inquery where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
 delete from t_Site_Message where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
  delete from t_Site_News where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
  delete from t_Site_Site where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
  delete from t_Site_Tag where DeleteTime<DATEADD(DAY,@day,GETDATE()) and Mark=0
END
 
GO
/****** Object:  StoredProcedure [dbo].[LookLock]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LookLock]
AS
BEGIN
Select * from sysprocesses where blocked<>0
--找到SPID  
exec sp_lock
--根据SPID找到OBJID
select object_name(1467152272)
END



GO
/****** Object:  StoredProcedure [dbo].[PrssLog]    Script Date: 2017/7/20 22:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrssLog]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DBCC SHRINKFILE (N'Solution_log' ,1, TRUNCATEONLY)
END



GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Account_Account', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Account_Account', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Account_Account', @level2type=N'COLUMN',@level2name=N'Payword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Account_Account', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Account_Account', @level2type=N'COLUMN',@level2name=N'Balance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'EnglishName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌拼音首字母大写：  如"爱普华顿"，则为 "A" 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'Initial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态： 默认为 1 启用， 0 - 暂停 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'IsUsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记：默认值为 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Basedata_Brand', @level2type=N'COLUMN',@level2name=N'Mark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商银行信息标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商账号标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开户银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开户账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Holder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税务账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人：  财务联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Linkman'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话： 财务联系人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系邮箱：  财务联系人邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记：默认值为 1 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Finance_Bank', @level2type=N'COLUMN',@level2name=N'Mark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Order_Order', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Purchase_Purchase', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购明细标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Purchase_PurchaseItem', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商其他证书标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'SupplierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他证书:  存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'Certification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记： 默认值为 1 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'Mark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值为 0 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Certification', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商合同标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'SupplierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算方式：1 - 货到且票7天到结算， 2- 货到且票15天到结算， 4 - 货到且票30天到结算， 8 - 货到且票60天到结算， 16 - 预付款， 32 - 代销30天结算， 64 - 代销60天结算， 128 - 代销90天结算 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'SettlementType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付方式： 1 - 现金， 2 - 支票， 4 - 转账， 8 - 汇票 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'PaymentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配送方式：1 - 入仓， 2 - 直送 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'DispatchType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'票据类型： 1 - 增值税票， 2 - 普票，4 - 服务性发票 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'BillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同开始日期：2015-05-15' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返利条件说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'Rebate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同附件：  存放附件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'Attachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记： 默认值为 1 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'Mark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值为 0 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Contract', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商资质标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'SupplierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构代码：存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'AgencyLicense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营业执照： 存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'BusinessLicense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行开户许可证： 存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'BankLicense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税务登记证： 存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'TaxLicense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商标注册证：存放路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'TrademarkLicense'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌授权： 1 - 品牌代理授权（经销代理商）， 2 - 生产许可证（厂家）。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'BrandAuthorization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值为 0 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Qualification', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号标识Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮政编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Postcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在省份（直辖市）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在地级市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在县（县级市）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'County'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'官网地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'WebUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经营范围' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'BusinessRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经营品牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'BusinessBrand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售范围： 如： 华东 - 上海，浙江，江苏 。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'SalesRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Linkman'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人邮箱地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Qq号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Qq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售后咨询电话：  -- 售后服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'ServiceTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返修地址：   --  售后服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'ServiceAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返修收货人：  -- 售后服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Receiver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返修收货人联系方式： -- 售后服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'ReceiverTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商状态： 默认 1 - 未审核， 2 - 审核中， 4 - 可用， 8 - 不可用。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_Supplier_Supplier', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
