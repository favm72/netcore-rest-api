CREATE DATABASE REALPLAZA
GO
USE [REALPLAZA]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01/11/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Username] [varchar](20) NOT NULL,
    [Password] [varchar](20) NOT NULL,
    [FullName] [varchar](300) NULL,
    [Created] [datetime] NOT NULL,
    PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/11/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](150) NOT NULL,
    [Category] [varchar](200) NOT NULL,
    [Description] [varchar](500) NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
    [Provider] [varchar](150) NULL,
    [Discount] [int] NULL,
    [Image] [varchar](max) NOT NULL,
    [Created] [datetime] NOT NULL,
    [Updated] [datetime] NULL,
    CONSTRAINT [PK__Product__3214EC0780F79B99] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 01/11/2021 20:38:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](150) NOT NULL,
    [Address] [varchar](300) NOT NULL,
    [Image] [varchar](max) NULL,
    [Created] [datetime] NOT NULL,
    [Updated] [datetime] NULL,
    CONSTRAINT [PK__Store__3214EC07641D9D5A] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON

INSERT [dbo].[Account]
    ([Id], [Username], [Password], [FullName], [Created])
VALUES
    (1, N'admin', N'1234', N'Fabio Villavicencio', CAST(N'2021-11-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON

INSERT [dbo].[Product]
    ([Id], [Name], [Category], [Description], [Price], [Provider], [Discount], [Image], [Created], [Updated])
VALUES
    (1, N'bicicleta x60', N'Deportes', N'La mejor bicicleta !!', CAST(250.00 AS Decimal(18, 2)), N'gear wheel', 10, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqYZZmOZObpYlW1vgQtZxVtkLsJUoxKdIE1w&usqp=CAU', CAST(N'2021-11-01T11:12:35.160' AS DateTime), CAST(N'2021-11-01T18:41:43.117' AS DateTime))
INSERT [dbo].[Product]
    ([Id], [Name], [Category], [Description], [Price], [Provider], [Discount], [Image], [Created], [Updated])
VALUES
    (2, N'Scooter', N'Deportes', N'El mejor scooter', CAST(800.00 AS Decimal(18, 2)), NULL, 0, N'https://m.media-amazon.com/images/I/61UpUcBCWVL._AC_SX425_.jpg', CAST(N'2021-11-01T18:00:08.890' AS DateTime), NULL)
INSERT [dbo].[Product]
    ([Id], [Name], [Category], [Description], [Price], [Provider], [Discount], [Image], [Created], [Updated])
VALUES
    (4, N'Ropero Cali 6 puertas 2 cajones Jacaranda', N'Hogar', N'Tamaño estándar, madera Cedro, madera plastificada, capacidad de 5kg por cajón', CAST(379.00 AS Decimal(18, 2)), NULL, 0, N'https://realplaza.vtexassets.com/arquivos/ids/17616566-1200-auto?v=637712692991770000&width=1200&height=auto&aspect=true', CAST(N'2021-11-01T20:28:31.350' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Store] ON

INSERT [dbo].[Store]
    ([Id], [Name], [Address], [Image], [Created], [Updated])
VALUES
    (1, N'Real Plaza Guardia Civil', N'Av. Guardia Civil Nro. 1035 (Nros. 1001 1005 1009 1025 1045). Chorrillos. Lima.', N'https://cdn.mercadonegro.pe/wp-content/uploads/2019/06/9ca467cd2cfa1a15ea46adc3e63ab39b.jpg', CAST(N'2021-11-01T19:18:01.623' AS DateTime), NULL)
INSERT [dbo].[Store]
    ([Id], [Name], [Address], [Image], [Created], [Updated])
VALUES
    (2, N'Real Plaza Primavera', N'Av Primavera San Borja', N'https://static0.tiendeo.pe/galeria/centroscomerciales/112/real%20plaza%20primavera.jpg', CAST(N'2021-11-01T19:20:00.033' AS DateTime), NULL)
INSERT [dbo].[Store]
    ([Id], [Name], [Address], [Image], [Created], [Updated])
VALUES
    (3, N'Real Plaza Salaverry', N'Av. Gral. Salaverry 2370, Jesús María 15076', N'https://www.peru-retail.com/wp-content/uploads/real-plaza-salaverry-100.jpg', CAST(N'2021-11-01T19:25:49.670' AS DateTime), NULL)
INSERT [dbo].[Store]
    ([Id], [Name], [Address], [Image], [Created], [Updated])
VALUES
    (4, N'Real Plaza Centro Cívico', N'Av. Garcilaso De La Vega Nro. 1337. Lima.', N'https://img10.naventcdn.com/avisos/11/00/50/77/05/41/1200x1200/33895627.jpg', CAST(N'2021-11-01T19:32:13.200' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Store] OFF
GO
