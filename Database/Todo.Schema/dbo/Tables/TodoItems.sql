CREATE TABLE [dbo].[TodoItems] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]  TINYINT        NOT NULL,
    [Title]       NVARCHAR (30)  NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    [IsFinish]    BIT            NOT NULL,
    [DeadLineOn]  DATETIME       NULL,
    CONSTRAINT [PK_TodoItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'截止日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'DeadLineOn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否完成（True:已完成 False:尚未完成）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'IsFinish';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'詳細內容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'標題', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'分類Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'CategoryId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'流水識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TodoItems', @level2type = N'COLUMN', @level2name = N'Id';

