IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_FEEDBACKS] (
    [Id] int NOT NULL IDENTITY,
    [Remetente] nvarchar(50) NOT NULL,
    [Destinatario] nvarchar(50) NOT NULL,
    [Descricao] nvarchar(450) NOT NULL,
    [Data] datetime2 NULL,
    CONSTRAINT [PK_TB_FEEDBACKS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Data', N'Descricao', N'Destinatario', N'Remetente') AND [object_id] = OBJECT_ID(N'[TB_FEEDBACKS]'))
    SET IDENTITY_INSERT [TB_FEEDBACKS] ON;
INSERT INTO [TB_FEEDBACKS] ([Id], [Data], [Descricao], [Destinatario], [Remetente])
VALUES (1, '2025-04-10T08:05:20.0000000', N'O ventilador da sala 7 foi concertado com sucesso. Favor dar baixa no chamado pelo sistema.', N'Daniela', N'Kelly'),
(2, '2025-04-15T12:50:31.0000000', N'A visita do técnico precisou ser adiada, peço que aguarde mais alguns dias até a resolução do problema no pc do lab 4.', N'Lucas', N'Marion'),
(3, '2025-04-18T07:15:44.0000000', N'A tela do pc do lab 4 foi trocada com sucesso, agradeço a paciencia. Favor dar baixa no chamado pelo sistema.', N'Lucas', N'Marion'),
(4, '2025-04-28T17:02:28.0000000', N'Os mouses defeituosos do lab 2 foram substituídos com sucesso. Favor dar baixa no chamado pelo sistema.', N'Aline', N'Luis'),
(5, '2025-05-11T13:34:12.0000000', N'Já encomendamos o vidro para a janela quebrada da sala 17 e o problema será resolvido o quanto antes.', N'Roberto', N'Flávio'),
(6, '2025-05-13T09:37:53.0000000', N'A janela da sala 17 foi concertada com sucesso. Favor dar baixa no chamado pelo sistema.', N'Roberto', N'Flávio'),
(7, '2025-05-21T14:16:49.0000000', N'O vazamento nos bebedouros do pátio foi resolvido imediatamente, agradecemos o aviso. Favor dar baixa no chamado pelo sistema.', N'Carlos', N'Amanda');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Data', N'Descricao', N'Destinatario', N'Remetente') AND [object_id] = OBJECT_ID(N'[TB_FEEDBACKS]'))
    SET IDENTITY_INSERT [TB_FEEDBACKS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250618150356_InitialCreate', N'9.0.6');

COMMIT;
GO

