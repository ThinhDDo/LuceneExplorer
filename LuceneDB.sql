USE [LuceneDB]
GO
/****** Object:  Table [dbo].[FileType]    Script Date: 5/31/2020 5:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileType](
	[TENTYPE] [varchar](20) NOT NULL,
	[ISUSE] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TENTYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 5/31/2020 5:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[NAME] [varchar](255) NOT NULL,
	[FULLPATH] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'acf', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'bak', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'bc', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'bin', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'bmp', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'cache', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'cdat', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'cfs', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'check', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'class', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'classpath', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'component', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'conf', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'config', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'container', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'CopyComplete', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'cs', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'csproj', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'css', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'cur', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'dat', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'data', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'db', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'dcp', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'del', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'dll', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'doc', 1)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'docx', 1)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'driveupload', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'exe', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'gen', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'gif', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'gitattributes', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'gitignore', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'hbs', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'history', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'html', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ico', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ide', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ide-shm', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ide-wal', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'idx', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'iml', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'index', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'info', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ini', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'jar', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'java', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'jpg', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'js', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'jscsrc', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'jsdtscope', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'jshintrc', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'json', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'launch', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'lcp', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ldb', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'lifecyclemapping', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'location', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'lock', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'log', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'log_backup1', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'lst', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'manifest', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'map', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'mark', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'markers', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'md', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'MF', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'mp4', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'msi', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'mst', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'mtx', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'name', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'nupkg', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'old', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'p7s', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'pack', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'pak', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'pdb', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'pdf', 1)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'php', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'png', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ppt', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'pptx', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'prefs', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'project', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'properties', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'rar', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'resources', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'resx', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'rtf', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'sample', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'scss', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ser', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'settings', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'setup', 1)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'shm', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'sln', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'suo', 0)
GO
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'svg', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'testlog', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'tree', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'ttf', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'txt', 1)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'user', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'vdi', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'version', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'xls', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'xlsx', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'xmi', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'xml', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'xmp', 0)
INSERT [dbo].[FileType] ([TENTYPE], [ISUSE]) VALUES (N'zip', 0)
GO
ALTER TABLE [dbo].[FileType] ADD  DEFAULT ((0)) FOR [ISUSE]
GO
