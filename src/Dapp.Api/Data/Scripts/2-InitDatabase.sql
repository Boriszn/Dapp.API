
/*   
   Creates the table and adds the test data
*/

USE [DeviceDb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Devices](
	[DeviceId] [uniqueidentifier] NOT NULL,
	[DeviceTitle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'689542fe-442f-45cb-a48c-12664dfa1ef1', N'AR14500000')
GO
INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'd35565c5-e9d1-4d55-9278-430870ce84a4', N'33333')
GO
INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'8b039108-86ec-422e-bed9-48adfee86842', N'AR14500000')
GO
INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'2374bbd8-596c-44bf-842b-bdde0afb3816', N'RASPBERRY-123')
GO
INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'226e9553-c1a8-43c1-9b06-c638bf7ce183', N'fssdf')
GO
INSERT [dbo].[Devices] ([DeviceId], [DeviceTitle]) VALUES (N'7cab5731-438a-46d6-88b4-ddc77ed502dc', N'X-Controller')
GO
