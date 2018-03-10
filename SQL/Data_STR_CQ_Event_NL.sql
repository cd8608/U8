
 
---- 事件表  开始 ----

--销售订单
/*==============================MES_CQ_DispatchList structure =============================*/
print 'dbo.MES_CQ_SO_SOMain...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_SO_SOMain') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_SO_SOMain
(
	id  nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息
	cRemark	Nvarchar(255), --备注	
	 
	cSoCode	Nvarchar(30), --订单号	唯一KEY
	cCusCode	Nvarchar(20)	, --客户代码
	cCusName	Nvarchar(98)	, --客户名称
	cBusTypeID	Nvarchar(15), --业务类型ID	
	cBusType	Nvarchar(8)	, -- 业务类型名称
	cStCode	Nvarchar(2)	, --销售类型ID
	cStName	Nvarchar(20)	, --销售类型名称
	cDepCode	Nvarchar(12)	, --销售部门ID
	cDepName	Nvarchar(255)	,--销售部门名称
	cPersonCode	Nvarchar(20)	,--业务员代码
	cPersonName	Nvarchar(40)	,--业务员名称
	cStatus	int	default 0, --订单状态 0=有效，1=无效。(MES只需要知道哪些订单需要发货，哪些不需要)
	cSoRemark	Nvarchar(60), --备注	  
  CONSTRAINT PK_MES_CQ_SO_SOMain PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_SO_SODetails structure =============================*/
print 'dbo.MES_CQ_SO_SODetails...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_SO_SODetails') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_SO_SODetails
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	isosid	int, --行ID
	cinvcode	Nvarchar(20), --产品编号
	cinvname	Nvarchar(255), --产品名称
	iquantity	Decimal(32,12), --订单数量


	 
  CONSTRAINT PK_MES_CQ_SO_SODetails PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO


--采购到货单 子表  ERP->MES
/*==============================MES_CQ_PU_ArrivalVouchs structure =============================*/
print 'dbo.MES_CQ_PU_ArrivalVouchs...'   
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_PU_ArrivalVouchs') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_PU_ArrivalVouchs
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否 

	dhCode	Nvarchar(20)	, --到货单号
	dhid	int	 , --到货单明细行号ID
	ibilltype int default 0, -- 0:到货  1:退货 2:拒收
	cPoCode	Nvarchar(20), --采购订单号	
	ddate	datetime	, --到货日期
	cVenCode	Nvarchar(20)	, --供应商编码
	cDepCode	Nvarchar(12),--部门编码	
	cPersonCode	Nvarchar(20)	, --业务员编码
	cPTCode	Nvarchar(2)	,--采购类型编码
	cPTName	Nvarchar(20), --采购类型名称	
	cInvCode	Nvarchar(20)	,-- 存货编码
	iquantity	Decimal(32,12),--数量	
	cstatus	int default 0, -- 单据状态	0=有效，1=无效
	 
  CONSTRAINT PK_MES_CQ_PU_ArrivalVouchs PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO
  
----采购退货 红字采购入库单
--/*==============================MES_CQ_rdrecord01Ret structure =============================*/
--print 'dbo.MES_CQ_rdrecord01Ret...'
--if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord01Ret') and sysstat & 0xf = 3)
--BEGIN
--CREATE TABLE dbo.MES_CQ_rdrecord01Ret
--(

--	id nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
--	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
--	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
--	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
--	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
--    cerrordesc nvarchar(4000) null ,  --错误信息

--	cRdCode	Nvarchar(30),	--入库单号
--	ddate	datetime,       --入库日期	
--	cWhCode	Nvarchar(10),   --仓库	仓库编码
--	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
--    cDepCode	Nvarchar(12), --部门(工作中心)	
--	cVenCode	Nvarchar(20), -- 供应商	 
--	cPersonCode	Nvarchar(20), -- 业务员	 	
--	cRemark	Nvarchar(255), --备注	   

--  CONSTRAINT PK_MES_CQ_rdrecord01Ret PRIMARY KEY  CLUSTERED
--  (
--    id
--  )
--)
--END

--GO

/*==============================MES_CQ_rdrecords01Ret structure =============================*/
print 'dbo.MES_CQ_rdrecord10...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords01Ret') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords01Ret
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

  	dhCode	Nvarchar(20), -- 到货单号	
	cPoCode	Nvarchar(20), -- 订单号
	dhid int , -- 到货单行号ID		 
	cInvCode	Nvarchar(20), -- 存货编码 
	iquantity	Decimal(32,12), -- 数量 
	  
  CONSTRAINT PK_MES_CQ_rdrecords01Ret PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO
 
--生产计划  MRP    MQ6303 

/*==============================MES_CQ_mps_netdemand structure =============================*/
print 'dbo.MES_CQ_mps_netdemand...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_mps_netdemand') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_mps_netdemand
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否
 
	PlanCode	Nvarchar(30), --计划号	
	DemandId	int	, --计划单行号
	cInvCode	Nvarchar(20)	, --产品编码
	iquantity	Decimal(32,12)	, --数量
	cSoCode	Nvarchar(30), --销售订单号	
	cForCode	Nvarchar(30)	, --预测订单号
	PStartDate	datetime	,--计划开始日期
	PDueDate	datetime	,--计划结束日期
	DmandDate	datetime	, --需求日期
	cRemark	Nvarchar(255)	, --备注
	plancodeDH nvarchar(40) , --计划代号

	  
  CONSTRAINT PK_MES_CQ_mps_netdemand PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO



--生产订单
/*==============================MES_CQ_mom_order structure =============================*/
print 'dbo.MES_CQ_mom_order...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_mom_order') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_mom_order  
(

	id nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	PlanCode	Nvarchar(30), --计划号	
	MoCode	Nvarchar(30)	, --生产订单号
	cWcCode	Nvarchar(8)	, --工作中心
	cInvCode	Nvarchar(20)	, --产品编码
	iquantity	Decimal(32,12)	, --数量
	cSoCode	Nvarchar(30)	, --销售订单号
	cForCode	Nvarchar(30)	, --预测订单号
	PStartDate	datetime	, --计划开始日期
	PDueDate	datetime	, --计划结束日期
	DmandDate	datetime	, --需求日期
	MoType	int	, --订单类型 0/1/2 (正常/返修/试制)id
	cremark	NVarchar(255)	, -- 备注
   

  CONSTRAINT PK_MES_CQ_mom_order PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_mom_orderdetail structure =============================*/
print 'dbo.MES_CQ_mom_orderdetail...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_mom_orderdetail') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_mom_orderdetail  
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

  	MoCode	Varchar(32)	, --订单号
	BomID	Varchar(32), --BOM编号	取订单BOM的ID号
	cInvCode	Nvarchar(20), --材料编号	
	iquantity	float,-- 数量(用量)	各工序汇总

	  
  CONSTRAINT PK_MES_CQ_mom_orderdetail PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END
GO



/*==============================MES_CQ_mom_orderdetailsub structure =============================*/
print 'dbo.MES_CQ_mom_orderdetailsub...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_mom_orderdetailsub') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_mom_orderdetailsub  
(
	ddid nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	did	nvarchar(36),--Int, -- 关联子件表ID 
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

	Sequence int, -- 替代序号 
    Factor float,  --替代比例
    ReplaceFlag bit, --是否替换料
    PartId int, -- 料品ID
    EffBegDate datetime, --生效时间
    EffEndDate datetime, --结束时间 
	  
  CONSTRAINT PK_MES_CQ_mom_orderdetailsub PRIMARY KEY  CLUSTERED
  (
    ddid
  )
)
END
GO



--BOM
/*==============================MES_CQ_bom_bom structure =============================*/
print 'dbo.MES_CQ_bom_bom...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_bom_bom') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_bom_bom
(

	id nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	bomid	Int	, --BOM编号
	[Version]	Int	, --版本号
	VersionEffDate	datetime, --版本时间	
	cInvCode	Nvarchar(20), --产品编号	
	status	int default 0, --状态	0=有效，1=无效 

  CONSTRAINT PK_MES_CQ_bom_bom PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_bom_opcomponent structure =============================*/
print 'dbo.MES_CQ_bom_opcomponent...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_bom_opcomponent') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_bom_opcomponent
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

	cInvCode	Nvarchar(20), --物料编号	
	BaseQtyN	float, --标准数量	子件数量
	BaseQtyD	float, --标准基数	母件数量
	 
  CONSTRAINT PK_MES_CQ_bom_opcomponent PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END
GO


/*==============================MES_CQ_bom_opcomponentsub structure =============================*/
print 'dbo.MES_CQ_bom_opcomponentsub...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_bom_opcomponentsub') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_bom_opcomponentsub
(
	ddid nvarchar(36), --Int IDENTITY(1,1) not null , --替代料表ID	该子表数据唯一KEY
	did	nvarchar(36),  --关联子表ID	该子表数据唯一KEY 
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

	cInvCode	Nvarchar(20), -- 物料编号	
	Sequence	Int, -- 替代次序
	Factor	float, -- 替代比
	ReplaceFlag bit, -- 替换料
	 
  CONSTRAINT PK_MES_CQ_bom_opcomponentsub PRIMARY KEY  CLUSTERED
  (
    ddid
  )
)
END
GO

 
--组装单     0308
print 'dbo.MES_CQ_AssemVouch...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_AssemVouch') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_AssemVouch
(

	id nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

    cAVCode	Nvarchar(30)	, --单号
	dAVDate	Datetime	, --日期
	cIRdCode	Nvarchar(5), --入库类别	组装单
	cDepCode	Nvarchar(12), --部门	
	cORdCode	Nvarchar(5), --出库类型	其他出库单类别
	cODepCode	Nvarchar(12), --部门	其他出、入库部门

	 
  CONSTRAINT PK_MES_CQ_AssemVouch PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_AssemVouchs structure =============================*/
print 'dbo.MES_CQ_AssemVouchs...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_AssemVouchs') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_AssemVouchs
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

	cAVDID	int, --子表行号	ERP
	bAVType	Nvarchar(20), --类型	值：散件、套件。套件作为其他入库明细，散件作为其他出库明细。
	cInvCode	Nvarchar(20)	, --存货编码
	cWhCode	Nvarchar(10), --仓库	作为其他出入库的仓库
	iquantity	Decimal(32,12)	, --数量


  CONSTRAINT PK_MES_CQ_AssemVouchs PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO

  

--拆卸单     0309
print 'dbo.MES_CQ_AssemVouchRet...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_AssemVouchRet') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_AssemVouchRet
(

	id nvarchar(36),--Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

    cAVCode	Nvarchar(30)	, --单号
	dAVDate	Datetime	, --日期
	cIRdCode	Nvarchar(5), --入库类别	组装单
	cDepCode	Nvarchar(12), --部门	
	cORdCode	Nvarchar(5), --出库类型	其他出库单类别
	cODepCode	Nvarchar(12), --部门	其他出、入库部门
   
  CONSTRAINT PK_MES_CQ_AssemVouchRet PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_AssemVouchRets structure =============================*/
print 'dbo.MES_CQ_AssemVouchRets...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_AssemVouchRets') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_AssemVouchRets
(
	did	nvarchar(36),--Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	nvarchar(36),--Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime  default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	 
	cAVDID	int, --子表行号	ERP
	bAVType	Nvarchar(20), --类型	值：散件、套件。套件作为其他入库明细，散件作为其他出库明细。
	cInvCode	Nvarchar(20)	, --存货编码
	cWhCode	Nvarchar(10), --仓库	作为其他出入库的仓库
	iquantity	Decimal(32,12)	, --数量
	 
  CONSTRAINT PK_MES_CQ_AssemVouchRets PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO


/*==============================MES_CQ_Department structure =============================*/
print 'dbo.MES_CQ_Department...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_Department') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_Department
(
	id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
	operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息

	cDepCode	Nvarchar(12),--部门编号
	cDepName	Nvarchar(255), --部门名称
	cLDepCode	Nvarchar(12), --上级部门 
  CONSTRAINT PK_MES_CQ_Department PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO


/*==============================MES_CQ_WorkCenter structure =============================*/
print 'dbo.MES_CQ_WorkCenter...'   
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_WorkCenter') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_WorkCenter
(
	id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
	operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime  default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息

	WcCode	Nvarchar(8), --编号	
	[Description]	Nvarchar(60), --名称	
	iType	Nvarchar(10), --工作中心类型	生产中心、仓库,如果编码在部门表内,则是生产中心,如果再仓库档案内,则是仓库
    [bProxyWh]  bit default 0, --是否代管仓
  CONSTRAINT PK_MES_CQ_WorkCenter PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

--客户档案
/*==============================MES_CQ_Customer structure =============================*/
print 'dbo.MES_CQ_Customer...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_Customer') and sysstat & 0xf = 3)
BEGIN
	CREATE TABLE dbo.MES_CQ_Customer
	(
		id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
		operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
		createTime Datetime default getdate(),	--创建时间 该数据创建时间
		finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
		opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
		cerrordesc nvarchar(4000) null ,  --错误信息

		cCusCode	Nvarchar(20), --编号
		cCusName	Nvarchar(98), --名称
		cCCCode	Nvarchar(12), --客户分类
		cCusAddress	Nvarchar(255),--送货地址
		cCusOType	Nvarchar(10), --发运方式编号
		cCusDefine1 NVARCHAR(40), --客户自定义项1
	  CONSTRAINT PK_MES_CQ_Customer PRIMARY KEY  CLUSTERED
	  (
		id
	  )
	)
END

GO

--供应商档案
/*==============================MES_CQ_Vendor structure =============================*/
print 'dbo.MES_CQ_Vendor...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_Vendor') and sysstat & 0xf = 3)
BEGIN
	CREATE TABLE dbo.MES_CQ_Vendor
	(
		id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
		operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
		createTime Datetime  default getdate(),	--创建时间 该数据创建时间
		finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
		opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
		cerrordesc nvarchar(4000) null ,  --错误信息

		cVenCode	Nvarchar(20), --编号
		cVenName	Nvarchar(98), --名称
		cVCCode	Nvarchar(12), --供应商类别
		cVenContact	Nvarchar(20),--联系人
		cVenContactPhone	Nvarchar(30), --联系电话
	  CONSTRAINT PK_MES_CQ_Vendor PRIMARY KEY  CLUSTERED
	  (
		id
	  )
	)
END

GO

--人员资料
/*==============================MES_CQ_Person structure =============================*/
print 'dbo.MES_CQ_Person...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_Person') and sysstat & 0xf = 3)
BEGIN
	CREATE TABLE dbo.MES_CQ_Person
	(
		id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
		operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
		createTime Datetime  default getdate(),	--创建时间 该数据创建时间
		finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
		opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
		cerrordesc nvarchar(4000) null ,  --错误信息

		cPersonCode	Nvarchar(20), --编号
		cPersonName	Nvarchar(40), --姓名
		PersonType	Nvarchar(30),--人员类别
		cDepCode	Nvarchar(12), --所属部门
		Sex	Nvarchar(2), --性别
		dBirthDate	datetime,--出生日期
		cPsnEmail	Nvarchar(100), --邮箱
	  CONSTRAINT PK_MES_CQ_Person PRIMARY KEY  CLUSTERED
	  (
		id
	  )
	)
END

GO


--存货档案
/*==============================MES_CQ_Inventory structure =============================*/
print 'dbo.MES_CQ_Inventory...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_Inventory') and sysstat & 0xf = 3)
BEGIN
	CREATE TABLE dbo.MES_CQ_Inventory
	(
		id	nvarchar(36),--Int IDENTITY(1,1) not null , --表ID	该子表数据唯一KEY 
		operflag Int default 0, -- 处理标示 0未处理 1处理成功 2处理失败	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
		createTime Datetime default getdate(),	--创建时间 该数据创建时间
		finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
		opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
		cerrordesc nvarchar(4000) null ,  --错误信息

		cInvCode	Nvarchar(20),--物料编码	
		cInvName	Nvarchar(255),--物料名称
		cInvAddCode NVARCHAR(255), --存货代码,	
		cInvStd	Nvarchar(255), --规格型号	取一个字段
		cWhCode	Nvarchar(10), --默认仓库	
		cInvCName	Nvarchar(255), --物料类别	存货分类ERP
		iInvType	Nvarchar(10), --物料类型	采购(普通物料)、自制(产成品),
		cComUnitName	Nvarchar(20), --主计量单位	
		bPropertyCheck	bit	,--是否质检

	  CONSTRAINT PK_MES_CQ_Inventory PRIMARY KEY  CLUSTERED
	  (
		id
	  )
	)
END

GO




	


	


 
---- 事件表结束 ----