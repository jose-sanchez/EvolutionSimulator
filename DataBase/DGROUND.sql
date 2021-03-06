USE [DATA.MDF]
GO

/****** Object:  Table [dbo].[DGROUND]    Script Date: 11/24/2017 12:10:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DGROUND](
	[GROUND_ID] [char](32) NOT NULL,
	[PARENT] [char](32) NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
	[ABSORTION] [float] NULL,
	[DAMAGE] [int] NULL,
	[GROUNDTYPE] [char](32) NULL,
 CONSTRAINT [PK_DGROUND] PRIMARY KEY CLUSTERED 
(
	[GROUND_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


