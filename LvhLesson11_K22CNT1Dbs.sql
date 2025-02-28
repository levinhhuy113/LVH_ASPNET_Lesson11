USE [LvhLesson11Db]
GO
/****** Object:  Table [dbo].[LvhTaiKhoan]    Script Date: 7/1/2024 8:45:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LvhTaiKhoan](
	[LvhId] [int] NULL,
	[LvhUserName] [nvarchar](50) NULL,
	[LvhPassword] [nvarchar](50) NULL,
	[LvhFullName] [nvarchar](50) NULL,
	[LvhAge] [int] NULL,
	[LvhEmail] [nvarchar](50) NULL,
	[LvhPhone] [nvarchar](50) NULL,
	[LvhStatus] [bit] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[LvhTaiKhoan] ([LvhId], [LvhUserName], [LvhPassword], [LvhFullName], [LvhAge], [LvhEmail], [LvhPhone], [LvhStatus]) VALUES (1, N'LeVinhHuy', N'123456a@', N'Lê Vinh Huy', 20, N'levinhhuy113@gmail.com', N'113', 1)
