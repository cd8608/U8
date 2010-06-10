
 
/*=========================MRP 生产计划 (业务类)=======================*/ 

/****** Object:  Trigger [T_MES_DS_mps_netdemand_INSERT]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_DS_mps_netdemand_INSERT' AND type='TR' )
DROP TRIGGER [T_MES_DS_mps_netdemand_INSERT]
GO
/****** Object:  Trigger [T_MES_DS_mps_netdemand_INSERT]    Script Date: 2014-01-23 15:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'Inventory' AND type='U')
	CREATE TRIGGER [T_MES_DS_mps_netdemand_INSERT]
	ON [mps_netdemand]
	AFTER INSERT 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT			
		
		SET @filename = '生产计划'
		SET @deal = 1 
		 
		 INSERT INTO MES_CQ_mps_netdemand
		(ID,opertype,PlanCode,DemandId,cInvCode,
		iquantity,cSoCode,cForCode,PStartDate,PDueDate,
		DmandDate
	    )
		SELECT 
		NEWID(),0,PlanCode,DemandId,b.invcode as cInvCode,
		planqty as iquantity,cSoCode,NULL AS cForCode,StartDate as PStartDate,DueDate as PDueDate,
		FirmDate as DmandDate 
		FROM inserted t INNER JOIN bas_part b WITH(NOLOCK) on b.partid =  t.PartId
		LEFT JOIN SO_SOMAIN S on s.ID = t.SrpSoDId

		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO
 
 
/*=========================MRP 生产计划(业务类)=======================*/ 

/****** Object:  Trigger [T_MES_DS_mps_netdemand_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_DS_mps_netdemand_DELETE' AND type='TR' )
DROP TRIGGER [T_MES_DS_mps_netdemand_DELETE]
GO

/****** Object:  Trigger [T_MES_DS_mps_netdemand_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'mps_netdemand' AND type='U')
	CREATE TRIGGER [T_MES_DS_mps_netdemand_DELETE]
	ON [mps_netdemand]
	AFTER DELETE 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '生产计划'
		SET @deal = 3	 
		DELETE FROM MES_CQ_mps_netdemand WHERE DemandId in (select deleted.DemandId from deleted )
		 

		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO



/*=========================MRP 生产计划(业务类)=======================*/ 

/****** Object:  Trigger [T_MES_DS_mps_netdemand_UPDATE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_DS_mps_netdemand_UPDATE' AND type='TR' )
DROP TRIGGER [T_MES_DS_mps_netdemand_UPDATE]
GO

/****** Object:  Trigger [T_MES_DS_mps_netdemand_UPDATE]    Script Date: 2014-01-23 15:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'sfc_morouting' AND type='U')
	CREATE TRIGGER [T_MES_DS_mps_netdemand_UPDATE]
	ON [mps_netdemand]
	AFTER UPDATE 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '生产计划'
		SET @deal = 2	 
		DELETE FROM MES_CQ_mps_netdemand WHERE DemandId in (select deleted.DemandId from deleted )
		 
		 INSERT INTO MES_CQ_mps_netdemand
		(ID,opertype,PlanCode,DemandId,cInvCode,
		iquantity,cSoCode,cForCode,PStartDate,PDueDate,
		DmandDate
	    )
		SELECT 
		NEWID(),0,PlanCode,DemandId,b.invcode as cInvCode,
		planqty as iquantity,cSoCode,NULL AS cForCode,StartDate as PStartDate,DueDate as PDueDate,
		FirmDate as DmandDate 
		FROM inserted t INNER JOIN bas_part b WITH(NOLOCK) on b.partid =  t.PartId
		LEFT JOIN SO_SOMAIN S on s.ID = t.SrpSoDId

		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO



/*========================= 工作中心 (业务类)=======================*/ 


/****** Object:  Trigger [T_MES_CQ_sfc_workcenter_INSERT]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_sfc_workcenter_INSERT' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_sfc_workcenter_INSERT]
GO
 
	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'Inventory' AND type='U')
CREATE TRIGGER [T_MES_CQ_sfc_workcenter_INSERT]
	ON [sfc_workcenter]
	AFTER INSERT 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT			
		
		SET @filename = '工作中心'
		SET @deal = 1 
		 
		DELETE FROM MES_CQ_workcenter WHERE WcCode in (select inserted.WcCode from inserted ) and itype = '生产中心'
		 
		INSERT INTO MES_CQ_workcenter
		 (ID,opertype, WcCode,Description,iType   )
		SELECT 
		NEWID(),0, WcCode,[description],'生产中心' as iType
		FROM inserted t  

		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO
 

 
/*=========================工作中心(业务类)=======================*/ 

/****** Object:  Trigger [T_MES_CQ_sfc_workcenter_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_sfc_workcenter_DELETE' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_sfc_workcenter_DELETE]
GO

/****** Object:  Trigger [T_MES_CQ_sfc_workcenter_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'sfc_workcenter' AND type='U')
	CREATE TRIGGER [T_MES_CQ_sfc_workcenter_DELETE]
	ON [sfc_workcenter] AFTER DELETE 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '工作中心'
		SET @deal = 3	 
		DELETE FROM MES_CQ_workcenter WHERE WcCode in (select deleted.WcCode from deleted )  and itype = '生产中心'
		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO



/*=========================工作中心 (业务类)=======================*/ 

/****** Object:  Trigger [T_MES_CQ_sfc_workcenter_UPDATE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_sfc_workcenter_UPDATE' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_sfc_workcenter_UPDATE]
GO

CREATE TRIGGER [T_MES_CQ_sfc_workcenter_UPDATE]
ON [sfc_workcenter] AFTER UPDATE 
AS
BEGIN

		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '工作中心'
		SET @deal = 2	 
		DELETE FROM MES_CQ_workcenter WHERE WcCode in (select deleted.WcCode from deleted )  and itype = '生产中心' 
		
		INSERT INTO MES_CQ_workcenter
		 (ID,opertype, WcCode,Description,iType   )
		SELECT 
		NEWID(),0, WcCode,[description],'生产中心' as iType
		FROM inserted t  

		IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:

END 
GO






/*========================= 仓库 (业务类)=======================*/ 
/****** Object:  Trigger [T_MES_CQ_WareHouse_INSERT]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_WareHouse_INSERT' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_WareHouse_INSERT]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'Warehouse' AND type='U')
CREATE TRIGGER [T_MES_CQ_WareHouse_INSERT]
	ON [Warehouse]
	AFTER INSERT 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT			
		
		SET @filename = '仓库'
		SET @deal = 1 
		
		set nocount on   
		DELETE FROM MES_CQ_workcenter WHERE  itype = '仓库' and WcCode in (select inserted.cWhCode from inserted  )    
		 
		INSERT INTO MES_CQ_workcenter
		 (ID,opertype, WcCode,Description,iType   )
		SELECT 
		NEWID(),0, cWhCode,cWhName,'仓库' as iType
		FROM inserted t  
		set nocount off 
		--IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:
   		
	END
GO
 

 
/*=========================仓库(业务类)=======================*/ 

/****** Object:  Trigger [T_MES_CQ_WareHouse_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_WareHouse_DELETE' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_WareHouse_DELETE]
GO

/****** Object:  Trigger [T_MES_CQ_WareHouse_DELETE]    Script Date: 2014-01-23 15:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	--IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'sfc_workcenter' AND type='U')
	CREATE TRIGGER [T_MES_CQ_WareHouse_DELETE]
	ON [Warehouse] AFTER DELETE 
	AS
	BEGIN		
		
		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '仓库'
		SET @deal = 3	 
		set nocount on 
		DELETE FROM MES_CQ_workcenter WHERE WcCode in (select deleted.cWhCode from deleted )  and itype = '仓库'
		--IF @@TRANCOUNT>=2 COMMIT
		set nocount off
		--结束 
   		CANCEL:
   		
	END
GO



/*=========================仓库 (业务类)=======================*/ 

/****** Object:  Trigger [T_MES_CQ_WareHouse_UPDATE]    Script Date: 2014-01-23 15:22:01 ******/
IF  EXISTS (SELECT 1 FROM sysobjects WHERE name = 'T_MES_CQ_WareHouse_UPDATE' AND type='TR' )
	DROP TRIGGER [T_MES_CQ_WareHouse_UPDATE]
GO

CREATE TRIGGER [T_MES_CQ_WareHouse_UPDATE]
ON [Warehouse] AFTER UPDATE 
AS
BEGIN

		DECLARE
		@aftid NVARCHAR(500),		 
		@befid NVARCHAR(500),		 
		@filename NVARCHAR(500),		--档案名称 
		@deal INT,						--处理模式 - 1:新增;2:修改;3:删除
		@error NVARCHAR(2000),			--错误信息
		@status BIT							
		
		SET @filename = '仓库'
		SET @deal = 2	
		set nocount on  
		DELETE FROM MES_CQ_workcenter WHERE WcCode in (select deleted.cWhCode from deleted )  and itype = '仓库'  
		INSERT INTO MES_CQ_workcenter
		 (ID,opertype, WcCode,Description,iType   )
		SELECT 
		NEWID(),0, cWhCode,cWhName,'仓库' as iType
		FROM inserted t  
		set nocount off
		--IF @@TRANCOUNT>=2 COMMIT
		
		--结束 
   		CANCEL:

END 
GO
