
---- 中间表  开始 ----

--销售发货单
/*==============================MES_CQ_DispatchList structure =============================*/
print 'dbo.MES_CQ_DispatchList...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_DispatchList') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_DispatchList
(

	id nvarchar(36), --Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	0/1/2/3/4 未处理/处理完成/处理中/错误/作废 ,(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2	 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息
	cRemark	Nvarchar(255), --备注	
	 
	cdlcode	Nvarchar(30) , --发货单号	生单成功后，回来生成的入库单号
	ddate	datetime, --出库日期
	cRdCode	Nvarchar(5), --收发类别	此字段是编码字段
	cBusTypeID	Nvarchar(15)	, -- 业务类型ID
	cBusType	Nvarchar(8)	, -- 业务类型名称
	cSTCode	Nvarchar(2)	, -- 销售类型ID
	cSTName	Nvarchar(20), -- 销售类型名称	
	cSoCode	Nvarchar(30), -- 订单号	
	cCusCode	Nvarchar(20)	, -- 客户代码
	cDepCode	Nvarchar(12)	, -- 销售部门代码
	cPersonCode	Nvarchar(20)	, -- 业务员代码
	cAddress	Nvarchar(255)	, -- 发货地址 客户档案中取得，可修改
	cSCCode	Nvarchar(2), -- 发运方式	客户档案中取得，可修改。发运方式双方系统各自维护，代码名称一致即可。
 	
  CONSTRAINT PK_MES_CQ_DispatchList PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_DispatchLists structure =============================*/
print 'dbo.MES_CQ_DispatchLists...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_DispatchLists') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_DispatchLists
(
	did	nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示 	0/1/2/3 未处理/处理完成/处理中/错误 ,	(采用整型便于后续拓展)	是/否

	isosid	Int	, -- 销售订单子表行号ID
	mesid nvarchar(36), -- 明细行号ID			MES明细行号
	cWhCode	Nvarchar(10), --仓库	仓库编码
	cinvcode	Nvarchar(20)	, --存货编码
	iquantity	Decimal(32,12)	, -- 数量
	cVenCode	Nvarchar(20), -- 供应商编号	材料出库时取材料的供应商，成品出库时为空。
	 
  CONSTRAINT PK_MES_CQ_DispatchLists PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO



--销售退货单
/*==============================MES_CQ_DispatchListRet structure =============================*/
print 'dbo.MES_CQ_DispatchListRet...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_DispatchListRet') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_DispatchListRet
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	0/1/2/3 未处理/处理完成/处理中/错误  (采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息
	cRemark	Nvarchar(255), --备注	
	 
	cdlcode	Nvarchar(30) , --发货单号	生单成功后，回来生成的入库单号
	ddate	datetime, --退货日期
	cRdCode	Nvarchar(5), --收发类别	此字段是编码字段
	cBusTypeID	Nvarchar(15)	, -- 业务类型ID
	cBusType	Nvarchar(8)	, -- 业务类型名称
	cSTCode	Nvarchar(2)	, -- 销售类型ID
	cSTName	Nvarchar(20), -- 销售类型名称	
	cSoCode	Nvarchar(30), -- 订单号	
	cCusCode	Nvarchar(20)	, -- 客户代码
	cDepCode	Nvarchar(12)	, -- 销售部门代码
	cPersonCode	Nvarchar(20)	, -- 业务员代码
	cAddress	Nvarchar(255)	, -- 发货地址 客户档案中取得，可修改
	cSCCode	Nvarchar(2), -- 发运方式	客户档案中取得，可修改。发运方式双方系统各自维护，代码名称一致即可。
	tdlcode	Nvarchar(30)	, -- 退货单号   

 	
  CONSTRAINT PK_MES_CQ_DispatchListRet PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_DispatchListRets structure =============================*/
print 'dbo.MES_CQ_DispatchListRets...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_DispatchListRets') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_DispatchListRets
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示  0/1/2/3 未处理/处理完成/处理中/错误	(采用整型便于后续拓展)	是/否

	isosid	Int	, -- 销售订单子表行号ID
	mesid nvarchar(36), -- 明细行号ID			MES明细行号
	cWhCode	Nvarchar(10), --仓库	仓库编码
	cinvcode	Nvarchar(20)	, --存货编码
	iquantity	Decimal(32,12)	, -- 数量
	cVenCode	Nvarchar(20), -- 供应商编号	材料出库时取材料的供应商，成品出库时为空。
	  
  CONSTRAINT PK_MES_CQ_DispatchListRets PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO



--产成品入库单
/*==============================MES_CQ_rdrecord10 structure =============================*/
print 'dbo.MES_CQ_rdrecord10...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord10') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecord10
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--入库单号
	ddate	datetime,       --入库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)		
	cRemark	Nvarchar(255), --备注	

  CONSTRAINT PK_MES_CQ_rdrecord10 PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_rdrecords10 structure =============================*/
print 'dbo.MES_CQ_rdrecord10...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords10') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords10
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

  	MoCode	Nvarchar(30), -- 生产订单号	
	cInvCode	Nvarchar(20), -- 产品编码	
	iquantity	Decimal(32,12), -- 数量	根据生产订单号和产品编码汇总

  CONSTRAINT PK_MES_CQ_rdrecords10 PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO
  
  
  

--产成品入库单(红字)
/*==============================MES_CQ_rdrecord10Ret structure =============================*/
print 'dbo.MES_CQ_rdrecord10Ret...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord10Ret') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecord10Ret
( 
	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--入库单号
	ddate	datetime,       --入库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)		
	cRemark	Nvarchar(255), --备注	

  CONSTRAINT PK_MES_CQ_rdrecord10Ret PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_rdrecords10Ret structure =============================*/
print 'dbo.MES_CQ_rdrecords10Ret...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords10Ret') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords10Ret
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

  	MoCode	Nvarchar(30), -- 生产订单号	
	cInvCode	Nvarchar(20), -- 产品编码	
	iquantity	Decimal(32,12), -- 数量	根据生产订单号和产品编码汇总

  CONSTRAINT PK_MES_CQ_rdrecords10Ret PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO
  
  
--采购入库单
/*==============================MES_CQ_rdrecord01 structure =============================*/
print 'dbo.MES_CQ_rdrecord01...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord01') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecord01
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--入库单号
	ddate	datetime,       --入库日期	
	bIsRedVouch bit default 0,     --1 红字单据，其它默认为蓝字
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)	
	cVenCode	Nvarchar(20), -- 供应商	 
	cPersonCode	Nvarchar(20), -- 业务员	 	
	cRemark	Nvarchar(255), --备注	   

  CONSTRAINT PK_MES_CQ_rdrecord01 PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_rdrecords01 structure =============================*/
print 'dbo.MES_CQ_rdrecord10...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords01') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords01
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

  	dhCode	Nvarchar(20), -- 到货单号	
	cPoCode	Nvarchar(20), -- 订单号
	dhid int , -- 到货单行号ID		 
	cInvCode	Nvarchar(20), -- 存货编码 
	iquantity	Decimal(32,12), -- 数量 
	  
  CONSTRAINT PK_MES_CQ_rdrecords01 PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO



--采购退货  \ 采购入库单(红字)
/*==============================MES_CQ_rdrecord01Ret structure =============================*/
print 'dbo.MES_CQ_rdrecord01Ret...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord01Ret') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecord01Ret
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 采购退货单 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  --采购退货单 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息
    cerrordesc_rd nvarchar(4000) null ,  -- 生成 采购入库单(红字) 错误信息

	operflag_rd Int default 0, -- 采购入库单(红字) 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	opertype_rd Int default 0, -- 采购入库单(红字) 操作标识

    cCode	Nvarchar(30),	--生成的退货单号
    cPuRdCode	Nvarchar(30), --生成的采购入库单号(红字)
	cRdCode	Nvarchar(30),	--MES传入的出库单号(红字)
	ddate	datetime,       --入库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)	
	cVenCode	Nvarchar(20), -- 供应商	 
	cPersonCode	Nvarchar(20), -- 业务员	 	
	cRemark	Nvarchar(255), --备注	   

  CONSTRAINT PK_MES_CQ_rdrecord01Ret PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_rdrecords01 structure =============================*/
print 'dbo.MES_CQ_rdrecord10...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords01Ret') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords01Ret
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	opertype_rd Int default 0, -- 采购入库单(红字) 操作标识
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




--其它入库单
/*==============================MES_CQ_rdrecord08 structure =============================*/
print 'dbo.MES_CQ_rdrecord08...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecord08') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecord08
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--入库单号
	ddate	datetime,       --入库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)	
	cVenCode	Nvarchar(20), -- 供应商	 
	--cPersonCode	Nvarchar(20), -- 业务员	 	
	cRemark	Nvarchar(255), --备注	   

  CONSTRAINT PK_MES_CQ_rdrecord08 PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END
 
GO

/*==============================MES_CQ_rdrecords08 structure =============================*/
print 'dbo.MES_CQ_rdrecords08...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_rdrecords08') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_rdrecords08
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	 
	cVenCode	Nvarchar(20), -- 供应商	  
	cInvCode	Nvarchar(20), -- 存货编码 
	iquantity	Decimal(32,12), -- 数量 
	  
  CONSTRAINT PK_MES_CQ_rdrecords08 PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO


--材料出库单  
print 'dbo.MES_CQ_RdRecord11...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_RdRecord11') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_RdRecord11
( 
	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--出库单单号
	ddate	datetime,       --出库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --收发类别	此字段是编码字段
    cDepCode	Nvarchar(12), --部门(工作中心)	
	cVenCode	Nvarchar(20), -- 供应商	  	
	cRemark	Nvarchar(255), --备注	   
	 
  CONSTRAINT PK_MES_CQ_RdRecord11 PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END 

GO

/*==============================MES_CQ_rdrecords11 structure =============================*/
print 'dbo.MES_CQ_RdRecords11...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_RdRecords11') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_RdRecords11
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息 
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否

	MESDID	Nvarchar(20), --MES行号 
	MoCode	Nvarchar(30)	, --生产订单号
	cPInvCode	Nvarchar(20), --产品编码	
	cInvCode	Nvarchar(20), --材料编码
	iquantity	Decimal(32,12), --数量	
	cVenCode	Nvarchar(20),--供应商编码	

	  
  CONSTRAINT PK_MES_CQ_RdRecords11 PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO



--其它出库单  
print 'dbo.MES_CQ_RdRecord09...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_RdRecord09') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_RdRecord09
(

	id nvarchar(36),--  Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cRdCode	Nvarchar(30),	--出库单单号
	ddate	datetime,       --出库日期	
	cWhCode	Nvarchar(10),   --仓库	仓库编码
	cRdStyleCode	Nvarchar(5),    --出库类型	ERP提供,编码
    cDepCode	Nvarchar(12), --部门(工作中心)	
	cVenCode	Nvarchar(20), -- 供应商	 
	cCusCode NVARCHAR(40),  -- 客户
	cDefine2 NVARCHAR(40), 	--
	cRemark	Nvarchar(255), --备注	  

  CONSTRAINT PK_MES_CQ_RdRecord09 PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

IF not exists( select 1 from syscolumns where id = object_id('dbo.MES_CQ_RdRecord09') and name = 'cCusCode')
BEGIN
    alter table dbo.MES_CQ_RdRecord09 add cCusCode nvarchar(40) null     
END 
IF not exists( select 1 from syscolumns where id = object_id('dbo.MES_CQ_RdRecord09') and name = 'cDefine2')
BEGIN
    alter table dbo.MES_CQ_RdRecord09 add cDefine2 nvarchar(40) null     
END 
--ELSE	
--BEGIN	
--	alter table dbo.MES_CQ_RdRecord09
--	alter column cDefine2 nvarchar(40) null
--END 

GO

/*==============================MES_CQ_rdrecords08 structure =============================*/
print 'dbo.MES_CQ_RdRecords09...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_RdRecords09') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_RdRecords09
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	 
	cVenCode	Nvarchar(20), -- 供应商	  
	cInvCode	Nvarchar(20), -- 存货编码 
	iquantity	Decimal(32,12), -- 数量  

  CONSTRAINT PK_MES_CQ_RdRecords09 PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO

--调拨单  0304
print 'dbo.MES_CQ_TransVouch...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_TransVouch') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_TransVouch
(

	id  nvarchar(36),-- Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示  0/1/2 未处理/已处理/处理出错	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cTVCode	Nvarchar(30), --移库单号	
	dTVDate	Datetime, --移库日期	调拨日期
	cOWhCode	Nvarchar(10), --来源仓库	编码
	cIWhCode	Nvarchar(10), --目标仓库	编码
	cODepCode   nvarchar(12),--调出部门 编码
	cIDepCode   nvarchar(12),--调入部门 编码
	cIRdCode	Nvarchar(5), --入库类别	编码
	cORdCode	Nvarchar(5),-- 出库类别	编码
	cRemark	Nvarchar(255), --备注	
	cPersonCode Nvarchar(20),  --经办人
  

  CONSTRAINT PK_MES_CQ_TransVouch PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_TransVouchs structure =============================*/
print 'dbo.MES_CQ_TransVouchs...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_TransVouchs') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_TransVouchs
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	 
	MESDid	Varchar(32)	, --MES行号
	cInvCode	Nvarchar(20)	, --存货编码
	iquantity	Decimal(32,12)	, --数量
	cVenCode	Nvarchar(20)	, --供应商 
  CONSTRAINT PK_MES_CQ_TransVouchs PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO





--盘点单  0307
print 'dbo.MES_CQ_CheckVouch...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_CheckVouch') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_CheckVouch
(

	id nvarchar(36),--  Int  IDENTITY(1,1) not null ,-- 主表ID 主表唯一KEY。
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否，默认为否，表示该数据是否被读取处理或者被业务调用。
	createTime Datetime default getdate(),	--创建时间 该数据创建时间
	finishTime	Datetime, --完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举)	0/1/2 增加/修改/删除。用于记录该条记录是新增、修改还是删除。
    cerrordesc nvarchar(4000) null ,  --错误信息

	cIRdCode	Nvarchar(5), --入库类别	编码
	cORdCode	Nvarchar(5),-- 出库类别	编码
	cCVCode	Nvarchar(30), --盘点任务单号	
	dCVDate	datetime, --计划盘点日期	取计划盘点日期
	dACDate	datetime,--实际盘点日期	取盘点任务实际完成日期
	cDepCode	Nvarchar(12), --盘点部门	取盘点责任人所在部门
	cPersonCode	Nvarchar(20), --盘点人	取盘点责任人
	cWhCode	Nvarchar(10)	, --仓库
	 
  CONSTRAINT PK_MES_CQ_CheckVouch PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_CQ_CheckVouchs structure =============================*/
print 'dbo.MES_CQ_CheckVouchs...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_CQ_CheckVouchs') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_CQ_CheckVouchs
(
	did	 nvarchar(36),-- Int IDENTITY(1,1) not null , --子表ID	该子表数据唯一KEY
	id	 nvarchar(36),-- Int, -- 关联主表ID	所属主表记录的ID
	createTime Datetime default getdate(), --创建时间	该数据创建时间
	finishTime	Datetime,--完成时间	该数据完成时间，有些业务不需要回写，供需要的业务回写。
	opertype Int default 0,  -- 操作标示	(枚举) 0/1/2	增加/修改/删除。用于记录该条记录是新增、修改还是删除。
	cerrordesc nvarchar(4000) null ,  --错误信息
	operflag Int default 0, -- 处理标示	(采用整型便于后续拓展)	是/否
	 
	cInvCode	Nvarchar(20), --存货编码	
	iquantity	Decimal(32,12), --数量	按照存货编码、供应商来汇总，数量分正负值。
	cVenCode	Nvarchar(20), --供应商	

  CONSTRAINT PK_MES_CQ_CheckVouchs PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO





--组装单     0308
print 'dbo.MES_Int_CQ_AssemVouch...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_Int_CQ_AssemVouch') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_Int_CQ_AssemVouch
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

	 
  CONSTRAINT PK_MES_Int_CQ_AssemVouch PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO

/*==============================MES_Int_CQ_AssemVouchs structure =============================*/
print 'dbo.MES_Int_CQ_AssemVouchs...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_Int_CQ_AssemVouchs') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_Int_CQ_AssemVouchs
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


  CONSTRAINT PK_MES_Int_CQ_AssemVouchs PRIMARY KEY  CLUSTERED
  (
    did
  )
)
END

GO

  

--拆卸单     0309
print 'dbo.MES_Int_CQ_AssemVouchRet...'
if not exists (select * from sysobjects where id = object_id('dbo.MES_Int_CQ_AssemVouchRet') and sysstat & 0xf = 3)
BEGIN
CREATE TABLE dbo.MES_Int_CQ_AssemVouchRet
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
   
  CONSTRAINT PK_MES_Int_CQ_AssemVouchRet PRIMARY KEY  CLUSTERED
  (
    id
  )
)
END

GO


---- 中间表结束 ----