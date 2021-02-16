namespace EntityFrameworkCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Gateway](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serial] [varchar](50) NULL,
	[ipv4] [varchar](15) NULL,
 CONSTRAINT [PK_Gateway] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Gateway] ON [dbo].[Gateway]
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO");
            Sql(@"
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Peripheral](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vendor] [varchar](250) NULL,
	[creatioDate] [datetime] NULL,

	[status] [bit] NULL,
	[GatewayId] [int] NULL,
	[UID] [int] NOT NULL,
 CONSTRAINT [PK__Peripher__C5B19602E43F7B79] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Peripheral]  WITH CHECK ADD  CONSTRAINT [FK_Peripheral_Gateway] FOREIGN KEY([GatewayId])
REFERENCES [dbo].[Gateway] ([id])
GO

ALTER TABLE [dbo].[Peripheral] CHECK CONSTRAINT [FK_Peripheral_Gateway]
GO

/****** Object:  Index [NonClusteredIndex-20210214-124928]    Script Date: 2/14/2021 5:40:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20210214-124928] ON [dbo].[Peripheral]
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO");

        }
        
        public override void Down()
        {
            
        }
    }
}
