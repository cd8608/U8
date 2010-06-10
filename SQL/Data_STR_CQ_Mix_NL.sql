
---- 预置数据表 开始 ----

--/*==============================MES_CQ_DLLReflect structure =============================*/
--print 'dbo.MES_CQ_DLLReflect...'
--if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_DLLReflect') and sysstat & 0xf = 3)
--BEGIN
--CREATE TABLE dbo.MES_CQ_DLLReflect
--(
--  id int IDENTITY(1,1) not null ,
--  cvouchertype varchar(50) null ,
--  Dllpath varchar(200) null ,
--  Namespace varchar(200) null ,
--  ClassName varchar(200) null ,
--  ClassType varchar(10) null ,
--  CONSTRAINT PK_MES_CQ_DLLReflect PRIMARY KEY  CLUSTERED
--  (
--    id
--  )
--)
--END

--GO



/*==============================MES_Comm_DLLReflect structure =============================*/
print 'dbo.MES_Comm_DLLReflect...' 
if not exists (select * from sysobjects where id = object_id('dbo.MES_Comm_DLLReflect') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_Comm_DLLReflect
(
  id int IDENTITY(1,1) not null ,
  TaskType int not null,  --任务工厂  0 CQ 1 XT 2 DS
  cvouchertype varchar(50) null ,
  Dllpath varchar(200) null ,
  Namespace varchar(200) null ,
  ClassName varchar(200) null ,
  ClassType varchar(10) null ,
  CONSTRAINT PK_MES_Comm_DLLReflect PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

--事件字段转换 
print 'dbo.MES_FIELDCMP'   
IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE id = object_id(N'[dbo].[MES_FIELDCMP]'))
BEGIN
	CREATE TABLE [MES_FIELDCMP]
	( 
	  autoid int IDENTITY(1,1) not null ,
	  itype nvarchar(30) null ,
	  cname nvarchar(30) null ,
	  ctable nvarchar(30) not null ,
	  cfield nvarchar(30) not null ,
	  cdefult nvarchar(30) null ,
	  bfixed nvarchar(30) null ,
	  ctabledesc nvarchar(60) null ,
	  cfielddesc nvarchar(60) null ,
	  cfieldtype nvarchar(30) null ,
	  cfieldlength int  null ,
	  bvisible int  null ,
	  cversion nvarchar(30) null ,
	  [igetvaluetype] [int] NOT NULL default 1,  --取值方式 :0 取自dom,1取自dataset,2固定值,3函数 
	  [igetvalue] [nvarchar](100)      --取值表达式
	  CONSTRAINT PK_AAA_MES_FIELDCMP PRIMARY KEY  CLUSTERED
	  (
		ctable,cfield
	  )  
	)
END 
GO
 



--单据字段转换
print 'dbo.MES_CQ_FIELDCMP' 
if not exists (select * from sysobjects where id = object_id(N'[dbo].[MES_CQ_FIELDCMP]'))
begin
CREATE TABLE [dbo].[MES_CQ_FIELDCMP](
	[TaskType] INT NOT NULL, --任务类型    0 CQ 1 XT 2 DS
	[id] [nvarchar](30) NOT NULL,
	[ccode] [nvarchar](30) NOT NULL,
	[cname] [nvarchar](60) NOT NULL,
	[cfrombillcardnum] [nvarchar](60) NOT NULL,
	[ctobillcardnum] [nvarchar](60) NOT NULL,
	[vt_id] [nvarchar](40) NOT NULL,
	[cmodifer] [nvarchar](30) NULL,
	[dmodifydate] [datetime] NULL,
	[ufts] [timestamp] NOT NULL,
	[iprintcount] [int] NULL,
 CONSTRAINT [PK_MES_CQ_FIELDCMP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]
end
GO


print 'dbo.MES_CQ_FIELDCMPS' 
if not exists (select * from sysobjects where id = object_id(N'[dbo].[MES_CQ_FIELDCMPS]'))
begin
CREATE TABLE [dbo].[MES_CQ_FIELDCMPS](
    [TaskType] INT NOT NULL, --任务类型   0CQ 1协同,后续可继续加
	[autoid] [nvarchar](30) NOT NULL,
	[id] [nvarchar](30) NOT NULL,
	[ccode] [nvarchar](30) NULL,
	[ctype] [int] NULL,
	[cvalue] [nvarchar](2000) NULL,
	[cfunid] [nvarchar](100) NULL,
	[cardsection] [nvarchar](4) NOT NULL,
	[fieldname] [nvarchar](80) NOT NULL,
	[carditemname] [nvarchar](200) NULL,
	[isnull] [bit] NOT NULL,
	[cremark] [nvarchar](200) NULL,
	[isvisable] [bit] NULL,
	[guid] [nvarchar](60) NULL,
	[seq] float NULL,  --排序
 CONSTRAINT [PK_MES_CQ_FIELDCMPS] PRIMARY KEY CLUSTERED 
(
	[TaskType],[ID],[cardsection],[fieldname]  
)
) ON [PRIMARY]
end 
GO


/****** Object:  Table [dbo].[MES_CQ_FIXVALUE]    Script Date: 09/24/2013 11:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if not exists (select * from sysobjects where id = object_id(N'[dbo].[MES_CQ_FIXVALUE]'))
begin
CREATE TABLE [dbo].[MES_CQ_FIXVALUE](
	[did] [nvarchar](30) NOT NULL,
	[autoid] [nvarchar](30) NOT NULL,
	[cfunid] [nvarchar](60) NULL,
	[ctype] [nvarchar](60) NULL,
	[accid] [nvarchar](30) NULL,
	[cvalue] [nvarchar](60) NULL,
	[cno] [int] NULL,
	[cfunparareturn] [nvarchar](60) NULL,
	[cardsection] [nvarchar](4) NULL,
	[cfromortobill] [nvarchar](4) NULL,
	[guid] [nvarchar](60) NULL,
 CONSTRAINT [PK_XY_MES_CQ_FIXVALUE] PRIMARY KEY CLUSTERED 
(
	[autoid] ASC
)
) ON [PRIMARY]
end
GO


/****** Object:  Table [dbo].[MES_CQ_FUNCTION]    Script Date: 09/24/2013 11:01:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if not exists (select * from sysobjects where id = object_id(N'[dbo].[MES_CQ_FUNCTION]'))
begin
CREATE TABLE [dbo].[MES_CQ_FUNCTION](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cfunid] [nvarchar](60) NOT NULL,
	[cfunesc] [nvarchar](60) NULL,
	[cfuntype] [nvarchar](30) NULL,
	[cfunobject] [nvarchar](60) NULL,
	[cfunclass] [nvarchar](60) NULL,
	[cfunname] [nvarchar](60) NULL,
	[cfunsql] [nvarchar](4000) NULL,
	[cfunvba] [nvarchar](30) NULL,
	[accid] [nvarchar](30) NULL,
	[excdatabase] [nvarchar](30) NULL,
 CONSTRAINT [PK_XY_MES_CQ_FUNCTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]
end
GO

 
/****** Object:  Table [dbo].[MES_CQ_FUNCTIONS]    Script Date: 09/24/2013 11:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if not exists (select * from sysobjects where id = object_id(N'[dbo].[MES_CQ_FUNCTIONS]'))
begin
--drop table MES_CQ_FUNCTIONS
CREATE TABLE [dbo].[MES_CQ_FUNCTIONS](
	[autoid] [int] IDENTITY(1,1) NOT NULL,
	[cfunid] [nvarchar](60) NOT NULL,
	[ctype] [nvarchar](60) NULL,
	[cfunparareturn] [nvarchar](60) NULL,
	[cvaluetype] [nvarchar](60) NULL,
	[cno] [int] NULL,
	[cfunparareturndesc] [nvarchar](120) NULL,
 CONSTRAINT [PK_XY_MES_CQ_FUNCTIONS] PRIMARY KEY CLUSTERED 
(
	[autoid] ASC
)
) ON [PRIMARY]
end
GO

