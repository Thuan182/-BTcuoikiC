USE [ThieuVanThuanDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21/06/2021 9:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [ntext] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 21/06/2021 9:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[UnitCost] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varchar](50) NOT NULL,
	[Description] [ntext] NOT NULL,
	[Status] [bit] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 21/06/2021 9:28:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[PassWord] [char](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (1, N'Quần dài', N'quần form ôm vừa vẹn, phù hợp cho mọi lứa tuổi')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (6, N'Quần Đùi', N'Thoáng mát,gọn gàng')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (7, N'Quần Short', N'Trẻ trung')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (8, N'Áo sơ mi', N'vải chất lượng cao, mềm mại, dể chịu')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (9, N'Áo thun', N'ôm sát, tôn lên vẻ đẹp rạng ngời')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (10, N'Áo khoác', N'chống nắng tuyệt vời')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (11, N'Áo phao', N'Dày, rất ấm cho mùa đông')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (1, N'Quần Ống rộng', CAST(350000 AS Decimal(18, 0)), 100, N'or.png', N'quần form ôm vừa vẹn, phù hợp cho mọi lứa tuổi', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (2, N'Quần Jean', CAST(350000 AS Decimal(18, 0)), 100, N'orr.png', N'quần form ôm vừa vẹn, phù hợp cho mọi lứa tuổi', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (4, N'Quần bơi', CAST(35000 AS Decimal(18, 0)), 100, N'ql.png', N'quần mặc rất thoãi mái', 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (5, N'Áo sơ mi học sinh', CAST(150000 AS Decimal(18, 0)), 10, N'daitay.png', N'vải chất lượng cao, mềm mại, dể chịu', 1, 8)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (6, N'Áo sơ mi nữ', CAST(350000 AS Decimal(18, 0)), 10, N'sominu.png', N'vải chất lượng cao, mềm mại, dể chịu', 1, 8)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (1, N'thuan', N'123                                               ', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (4, N'van', N'123                                               ', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (10, N'thang', N'123                                               ', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (12, N'thuan12', N'1234567                                           ', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (13, N'thuan1234567', N'1234567                                           ', 0)
INSERT [dbo].[UserAccount] ([ID], [UserName], [PassWord], [Status]) VALUES (14, N'thuan113', N'1                                                 ', 0)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
