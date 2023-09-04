USE [TripAdvisor]
GO
/****** Object:  Table [dbo].[DistrictTemperatures]    Script Date: 9/5/2023 2:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistrictTemperatures](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[District] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Time] [varchar](10) NOT NULL,
	[Temperature] [float] NOT NULL,
	[Unit] [varchar](5) NOT NULL,
 CONSTRAINT [PK_DistrictTemperatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
