USE [DiamondCircle_db]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 15/07/2014 10:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[CustomerId] [numeric](18, 0) NOT NULL,
	[Currency] [nchar](3) NOT NULL,
	[Balance] [decimal](20, 9) NOT NULL,
 CONSTRAINT [PrimaryKey_11f2fe3e-540f-4e57-88bf-28290f7db112] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 15/07/2014 10:13:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[CustomerId] [numeric](18, 0) NOT NULL,
	[AddressType] [nchar](1) NULL,
	[AddressLine1] [nvarchar](50) NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[Suburb] [nvarchar](50) NULL,
	[Postcode] [nvarchar](6) NULL,
	[CountryId] [int] NULL,
	[LandLine] [nvarchar](15) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_YourTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/07/2014 10:13:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/07/2014 10:13:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Key] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/07/2014 10:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserManagement]    Script Date: 15/07/2014 10:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserManagement](
	[UserId] [nvarchar](128) NOT NULL,
	[DisableSignIn] [bit] NOT NULL,
	[LastSignInTimeUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserManagement] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/07/2014 10:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/07/2014 10:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AspNetUserSecrets]    Script Date: 15/07/2014 10:13:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserSecrets](
	[UserName] [nvarchar](128) NOT NULL,
	[Secret] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserSecrets] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[BPay]    Script Date: 15/07/2014 10:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BPay](
	[Id] [int] NOT NULL,
	[BillerCode] [int] NOT NULL,
	[Reference] [varchar](50) NOT NULL,
	[Email] [varchar](256) NULL,
	[Created] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CardCurrency]    Script Date: 15/07/2014 10:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CardCurrency](
	[CardCurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [nchar](16) NOT NULL,
	[FiatCurrencyId] [int] NOT NULL,
	[Balance] [decimal](18, 8) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[LastModifiedUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CardCurrency] PRIMARY KEY CLUSTERED 
(
	[CardCurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CardCurrencyHistory]    Script Date: 15/07/2014 10:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CardCurrencyHistory](
	[FiatHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[CardCurrencyId] [int] NOT NULL,
	[CreditAmount] [decimal](18, 8) NULL,
	[DebitAmount] [decimal](18, 8) NULL,
	[DateActioned] [datetime] NULL,
	[DateConfirmed] [datetime] NULL,
	[Reference] [varchar](50) NULL,
	[TransactionDetails] [varchar](100) NULL,
	[CreateUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CardCurrencyHistory] PRIMARY KEY CLUSTERED 
(
	[FiatHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 15/07/2014 10:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CustomerID] [numeric](18, 0) NULL,
	[DateIssued] [datetime] NOT NULL,
	[CardId] [nchar](16) NOT NULL,
	[Password] [nchar](256) NULL,
	[PublicKey] [nchar](34) NULL,
	[Pin] [nchar](6) NULL,
	[Status] [nchar](10) NULL,
	[TempPublicKey] [nchar](34) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[ColdStorage]    Script Date: 15/07/2014 10:13:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColdStorage](
	[Id] [int] NOT NULL,
	[BitcoinAddress] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[CommissionCharge]    Script Date: 15/07/2014 10:13:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommissionCharge](
	[CommissionChargeId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerRoleId] [int] NOT NULL,
	[CommissionTypeId] [int] NOT NULL,
	[TransactionId] [numeric](18, 0) NOT NULL,
	[TransationPercent] [decimal](2, 2) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[DatePaid] [datetime] NULL,
 CONSTRAINT [PK_CommissionCharge] PRIMARY KEY CLUSTERED 
(
	[CommissionChargeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[CommissionType]    Script Date: 15/07/2014 10:13:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CommissionType](
	[CommissionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[SituationId] [int] NOT NULL,
	[Percentage] [decimal](2, 2) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NOT NULL,
	[ModfiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CommissionType] PRIMARY KEY CLUSTERED 
(
	[CommissionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[countries]    Script Date: 15/07/2014 10:13:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[Id] [int] NOT NULL,
	[name] [nchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[CreditCardCharge]    Script Date: 15/07/2014 10:13:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCardCharge](
	[CreditCardChargeId] [int] IDENTITY(1,1) NOT NULL,
	[PercentageCharged] [decimal](18, 0) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[TransactionId] [numeric](18, 0) NOT NULL,
	[CreditCardChargeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_CreditCardCharge] PRIMARY KEY CLUSTERED 
(
	[CreditCardChargeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[CreditCardChargeType]    Script Date: 15/07/2014 10:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditCardChargeType](
	[CreditCardChargeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CreditCardTypeId] [int] NOT NULL,
	[Percentage] [decimal](18, 0) NOT NULL,
	[FinancialRegionId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CreditCardChargeType] PRIMARY KEY CLUSTERED 
(
	[CreditCardChargeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CreditCardType]    Script Date: 15/07/2014 10:13:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditCardType](
	[CreditCardTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Abbreviation] [varchar](5) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CreditCardType] PRIMARY KEY CLUSTERED 
(
	[CreditCardTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 15/07/2014 10:13:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyAbbrev] [nchar](3) NOT NULL,
	[CurrencyDescription] [nchar](30) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[LastModifiedUser] [nchar](30) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/07/2014 10:13:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[Identified] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[CustomerBanks]    Script Date: 15/07/2014 10:13:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBanks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](18, 0) NOT NULL,
	[BSB] [nchar](6) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[PayPal] [nvarchar](60) NULL,
	[SWIFT] [nvarchar](50) NULL,
	[IBAN] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[FiatBalance]    Script Date: 15/07/2014 10:13:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FiatBalance](
	[BalanceId] [int] NOT NULL,
	[CardId] [nchar](16) NOT NULL,
	[FiatCurrencyId] [int] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[LastModifiedUser] [varchar](50) NOT NULL,
	[Balance] [decimal](18, 8) NOT NULL,
 CONSTRAINT [PK_FiatBalance] PRIMARY KEY CLUSTERED 
(
	[BalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FinancialRegion]    Script Date: 15/07/2014 10:13:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FinancialRegion](
	[FinancialRegionId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Abbreviation] [varchar](5) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NOT NULL,
	[ModfiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FinancialRegion] PRIMARY KEY CLUSTERED 
(
	[FinancialRegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 15/07/2014 10:13:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] NOT NULL,
	[ColdStorageId] [int] NOT NULL,
	[BTCAmount] [decimal](18, 6) NOT NULL,
	[FiatAmount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [varchar](50) NOT NULL,
	[Confirmations] [int] NOT NULL,
	[TxId] [varchar](256) NULL,
	[Created] [datetime2](7) NOT NULL,
	[Expires] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Margins]    Script Date: 15/07/2014 10:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Margins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TerminalId] [varchar](1) NOT NULL,
	[FiatCurrency] [nchar](3) NOT NULL,
	[FiatAmount] [money] NOT NULL,
	[FiatFee] [money] NULL,
	[Rate] [decimal](20, 9) NULL,
 CONSTRAINT [PK_Margins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpenOrders]    Script Date: 15/07/2014 10:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenOrders](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CustomerID] [numeric](18, 0) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[OrderType] [nchar](3) NOT NULL,
	[ValidTill] [datetime] NULL,
	[Amount] [decimal](20, 9) NOT NULL,
	[Price] [decimal](20, 9) NOT NULL,
	[NumuratorCurrency] [nchar](3) NOT NULL,
	[DeominatorCurrency] [nchar](3) NOT NULL,
 CONSTRAINT [PK_OpenOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[send]    Script Date: 15/07/2014 10:13:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[send](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](18, 0) NOT NULL,
	[Sender] [varchar](40) NOT NULL,
	[Receiver] [varchar](40) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[BTCAmount] [decimal](18, 8) NOT NULL,
	[Amount] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_send] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 15/07/2014 10:13:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[CustomerId] [numeric](18, 0) NOT NULL,
	[DefaultFiatCurrency] [nchar](3) NULL,
	[DefaultCryptoCurrency] [nchar](10) NULL
)

GO
/****** Object:  Table [dbo].[Situation]    Script Date: 15/07/2014 10:13:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Situation](
	[SituationId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Situation] PRIMARY KEY CLUSTERED 
(
	[SituationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Terminals]    Script Date: 15/07/2014 10:13:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Terminals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[Longitude] [decimal](18, 9) NULL,
	[Latitude] [decimal](18, 9) NULL,
	[Description] [text] NULL,
	[Enabled] [bit] NOT NULL,
	[Version] [varchar](50) NULL,
	[Created] [datetime2](7) NOT NULL,
	[SerialNumber] [varchar](50) NULL,
	[DefaultFiatCurrency] [nchar](3) NOT NULL,
	[DefaultCryptoCurrency] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Terminals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 15/07/2014 10:13:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokens](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[TokenKey] [varchar](128) NULL,
	[TokenValue] [varchar](128) NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TradingHistory]    Script Date: 15/07/2014 10:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TradingHistory](
	[Id] [numeric](18, 0) NOT NULL,
	[CustomerId] [numeric](18, 0) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[OrderType] [nchar](3) NOT NULL,
	[Amount] [decimal](20, 9) NOT NULL,
	[Price] [decimal](29, 9) NOT NULL,
	[NumuratorCurrency] [nchar](3) NOT NULL,
	[DeominatorCurrency] [nchar](3) NOT NULL,
 CONSTRAINT [PK_TradingHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 15/07/2014 10:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[CardId] [nchar](16) NULL,
	[TransType] [nchar](3) NOT NULL,
	[TerminalId] [nchar](10) NULL,
	[NumuratorCurrency] [nchar](3) NOT NULL,
	[DeominatorCurrency] [nchar](3) NOT NULL,
	[Amount] [numeric](20, 9) NOT NULL,
	[Price] [numeric](20, 9) NOT NULL,
	[Reference] [nvarchar](100) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[UploadFiles]    Script Date: 15/07/2014 10:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[FileRealName] [nchar](50) NOT NULL,
	[Createdate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 15/07/2014 10:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserId] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 15/07/2014 10:14:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 15/07/2014 10:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 15/07/2014 10:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 15/07/2014 10:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 15/07/2014 10:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_AddressType]  DEFAULT ('H') FOR [AddressType]
GO
ALTER TABLE [dbo].[Cards] ADD  CONSTRAINT [DF_Cards_DateIssued]  DEFAULT (getdate()) FOR [DateIssued]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Identified]  DEFAULT ((0)) FOR [Identified]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0)) FOR [Confirmations]
GO
ALTER TABLE [dbo].[OpenOrders] ADD  CONSTRAINT [DF_OpenOrders_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Terminals] ADD  DEFAULT ((0)) FOR [Enabled]
GO
ALTER TABLE [dbo].[TradingHistory] ADD  CONSTRAINT [DF_TradingHistory_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_0] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_0]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[countries] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Countries]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Customer]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserManagement]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserManagement] CHECK CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CardCurrency]  WITH CHECK ADD  CONSTRAINT [FK_CardCurrency_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([CardId])
GO
ALTER TABLE [dbo].[CardCurrency] CHECK CONSTRAINT [FK_CardCurrency_Cards]
GO
ALTER TABLE [dbo].[CardCurrency]  WITH CHECK ADD  CONSTRAINT [FK_CardCurrency_Currency] FOREIGN KEY([FiatCurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[CardCurrency] CHECK CONSTRAINT [FK_CardCurrency_Currency]
GO
ALTER TABLE [dbo].[CardCurrencyHistory]  WITH CHECK ADD  CONSTRAINT [FK_CardCurrencyHistory_CardCurrency] FOREIGN KEY([CardCurrencyId])
REFERENCES [dbo].[CardCurrency] ([CardCurrencyId])
GO
ALTER TABLE [dbo].[CardCurrencyHistory] CHECK CONSTRAINT [FK_CardCurrencyHistory_CardCurrency]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Customer]
GO
ALTER TABLE [dbo].[CommissionCharge]  WITH CHECK ADD  CONSTRAINT [FK_CommissionCharge_CommissionType] FOREIGN KEY([CommissionTypeId])
REFERENCES [dbo].[CommissionType] ([CommissionTypeId])
GO
ALTER TABLE [dbo].[CommissionCharge] CHECK CONSTRAINT [FK_CommissionCharge_CommissionType]
GO
ALTER TABLE [dbo].[CommissionCharge]  WITH CHECK ADD  CONSTRAINT [FK_CommissionCharge_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[CommissionCharge] CHECK CONSTRAINT [FK_CommissionCharge_Currency]
GO
ALTER TABLE [dbo].[CommissionCharge]  WITH CHECK ADD  CONSTRAINT [FK_CommissionCharge_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[CommissionCharge] CHECK CONSTRAINT [FK_CommissionCharge_Transaction]
GO
ALTER TABLE [dbo].[CommissionType]  WITH CHECK ADD  CONSTRAINT [FK_CommissionType_Situation] FOREIGN KEY([SituationId])
REFERENCES [dbo].[Situation] ([SituationId])
GO
ALTER TABLE [dbo].[CommissionType] CHECK CONSTRAINT [FK_CommissionType_Situation]
GO
ALTER TABLE [dbo].[CommissionType]  WITH CHECK ADD  CONSTRAINT [FK_CommissionType_webpages_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[CommissionType] CHECK CONSTRAINT [FK_CommissionType_webpages_Roles]
GO
ALTER TABLE [dbo].[CreditCardCharge]  WITH CHECK ADD  CONSTRAINT [FK_CreditCardCharge_CreditCardChargeType] FOREIGN KEY([CreditCardChargeTypeId])
REFERENCES [dbo].[CreditCardChargeType] ([CreditCardChargeTypeId])
GO
ALTER TABLE [dbo].[CreditCardCharge] CHECK CONSTRAINT [FK_CreditCardCharge_CreditCardChargeType]
GO
ALTER TABLE [dbo].[CreditCardCharge]  WITH CHECK ADD  CONSTRAINT [FK_CreditCardCharge_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[CreditCardCharge] CHECK CONSTRAINT [FK_CreditCardCharge_Currency]
GO
ALTER TABLE [dbo].[CreditCardCharge]  WITH CHECK ADD  CONSTRAINT [FK_CreditCardCharge_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[CreditCardCharge] CHECK CONSTRAINT [FK_CreditCardCharge_Transaction]
GO
ALTER TABLE [dbo].[CreditCardChargeType]  WITH CHECK ADD  CONSTRAINT [FK_CreditCardChargeType_CreditCardType] FOREIGN KEY([CreditCardTypeId])
REFERENCES [dbo].[CreditCardType] ([CreditCardTypeId])
GO
ALTER TABLE [dbo].[CreditCardChargeType] CHECK CONSTRAINT [FK_CreditCardChargeType_CreditCardType]
GO
ALTER TABLE [dbo].[CreditCardChargeType]  WITH CHECK ADD  CONSTRAINT [FK_CreditCardChargeType_FinancialRegion] FOREIGN KEY([FinancialRegionId])
REFERENCES [dbo].[FinancialRegion] ([FinancialRegionId])
GO
ALTER TABLE [dbo].[CreditCardChargeType] CHECK CONSTRAINT [FK_CreditCardChargeType_FinancialRegion]
GO
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[countries] ([Id])
GO
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_countries]
GO
ALTER TABLE [dbo].[CustomerBanks]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBanks_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerBanks] CHECK CONSTRAINT [FK_CustomerBanks_Customer]
GO
ALTER TABLE [dbo].[FiatBalance]  WITH CHECK ADD  CONSTRAINT [FK_FiatBalance_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([CardId])
GO
ALTER TABLE [dbo].[FiatBalance] CHECK CONSTRAINT [FK_FiatBalance_Cards]
GO
ALTER TABLE [dbo].[FiatBalance]  WITH CHECK ADD  CONSTRAINT [FK_FiatBalance_Currency] FOREIGN KEY([FiatCurrencyId])
REFERENCES [dbo].[Currency] ([CurrencyId])
GO
ALTER TABLE [dbo].[FiatBalance] CHECK CONSTRAINT [FK_FiatBalance_Currency]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_ColdStorage] FOREIGN KEY([ColdStorageId])
REFERENCES [dbo].[ColdStorage] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_ColdStorage]
GO
ALTER TABLE [dbo].[OpenOrders]  WITH CHECK ADD  CONSTRAINT [FK_OpenOrders_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[OpenOrders] CHECK CONSTRAINT [FK_OpenOrders_Customer]
GO
ALTER TABLE [dbo].[send]  WITH CHECK ADD  CONSTRAINT [FK_send_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[send] CHECK CONSTRAINT [FK_send_Customer]
GO
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_Customer]
GO
ALTER TABLE [dbo].[TradingHistory]  WITH CHECK ADD  CONSTRAINT [FK_TradingHistory_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[TradingHistory] CHECK CONSTRAINT [FK_TradingHistory_Customer]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([CardId])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Cards]
GO
ALTER TABLE [dbo].[UploadFiles]  WITH CHECK ADD  CONSTRAINT [FK_UploadFiles_user] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UploadFiles] CHECK CONSTRAINT [FK_UploadFiles_user]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
