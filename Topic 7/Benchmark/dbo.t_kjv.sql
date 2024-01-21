CREATE TABLE [dbo].[t_kjv] (
    [id] INT            NOT NULL,
    [b]  INT            NOT NULL,
    [c]  INT            NOT NULL,
    [v]  INT            NOT NULL,
    [t]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_t_kjv] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UC_t_kjv_b_c_v] UNIQUE NONCLUSTERED ([b] ASC, [c] ASC, [v] ASC)
);