----产成品入库单
--测试数据  新增
INSERT INTO MES_CQ_rdrecord10 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,1,'000001','put005','1','05')

INSERT INTO MES_CQ_rdrecords10 (id,opertype,MoCode,cInvCode,iquantity)
VALUES (1,1,'000001','cp001',100)
 

 
--测试数据  删除 
INSERT INTO MES_CQ_rdrecord10 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000013','put005','1','05')

INSERT INTO MES_CQ_rdrecords10 (id,opertype,MoCode,cInvCode,iquantity)
VALUES ( @@IDENTITY,1,'0000000014','cp001',100)
GO

INSERT INTO MES_CQ_rdrecord10 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000014','put005','1','05')

INSERT INTO MES_CQ_rdrecords10 (id,opertype,MoCode,cInvCode,iquantity)
VALUES ( @@IDENTITY,1,'0000000014','cp001',100)
GO
 



----发货单
 
--测试数据  新增
DECLARE @ID AS INT
INSERT INTO MES_CQ_DispatchList (operflag,opertype,cRdCode,cSoCode)
VALUES (0,1,'01','00000003')

SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000003','put005','cp001',100)
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000004','put005','cp001',40)
 
GO

--新增  
update MES_CQ_DispatchList set operflag = 0,opertype=0, finishTime = null,cerrordesc = null
update MES_CQ_DispatchLists  set opertype=0 
 
--测试数据  删除 
INSERT INTO MES_CQ_rdrecord10 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000013','put005','1','05')

INSERT INTO MES_CQ_rdrecords10 (id,opertype,MoCode,cInvCode,iquantity)
VALUES ( @@IDENTITY,1,'0000000014','cp001',100)
GO

INSERT INTO MES_CQ_rdrecord10 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000014','put005','1','05')

INSERT INTO MES_CQ_rdrecords10 (id,opertype,MoCode,cInvCode,iquantity)
VALUES ( @@IDENTITY,1,'0000000014','cp001',100)
GO
  
--删除
update MES_CQ_DispatchList set operflag = 0,opertype=2, finishTime = null,cerrordesc = null
update MES_CQ_DispatchLists  set opertype=0 
  


 --测试数据  修改
DECLARE @ID AS INT
INSERT INTO MES_CQ_DispatchList (operflag,opertype,cRdCode,cdlcode,cSoCode)
VALUES (0,1,'01','0000000004','00000003')

SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000003','put005','cp001',100)
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000004','put005','cp001',20)
 
GO

update MES_CQ_DispatchList set operflag = 0,opertype=1, finishTime = null,cerrordesc = null
update MES_CQ_DispatchLists  set opertype=0 



----退货单
 
--测试数据  新增 
DECLARE @ID AS NVARCHAR(36)   
DECLARE @DID AS NVARCHAR(36)  
SET @ID = NEWID()
INSERT INTO MES_CQ_DispatchListRet (id,operflag,opertype,cRdCode,cSoCode)
VALUES (@ID,0,1,'01','00000003')

SET @DID = NEWID()
INSERT INTO MES_CQ_DispatchListRets (id,did,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,@DID,1,'1000000003','put005','cp001',100)
SET @DID = NEWID()
INSERT INTO MES_CQ_DispatchListRets (id,did,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,@DID,1,'1000000004','put005','cp001',40)
GO

--新增  
update MES_CQ_DispatchListRet set operflag = 0,opertype=0, finishTime = null,cerrordesc = null
update MES_CQ_DispatchListRets  set opertype=0 
 
--测试数据  删除  
--删除
update MES_CQ_DispatchListRet set operflag = 0,opertype=2, finishTime = null,cerrordesc = null
update MES_CQ_DispatchLists  set opertype=0 
  


 --测试数据  修改
DECLARE @ID AS INT
INSERT INTO MES_CQ_DispatchList (operflag,opertype,cRdCode,cdlcode,cSoCode)
VALUES (0,1,'01','0000000004','00000003')

SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000003','put005','cp001',100)
INSERT INTO MES_CQ_DispatchLists (id,opertype,isosid,cWhCode,cInvCode,iquantity)
VALUES (@ID,1,'1000000004','put005','cp001',20)
 
GO

update MES_CQ_DispatchListRet set operflag = 0,opertype=1, finishTime = null,cerrordesc = null
update MES_CQ_DispatchListRets  set opertype=0 
   


----采购入库单
--测试数据  新增  

DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord01 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode,cVenCode,cPersonCode)
VALUES (0,0,'000001','put005','1','501','XYCG09120001','ZZM')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords01 (id,opertype,dhcode,dhid,cInvCode,iquantity)
VALUES (@ID,0,'0000000001','1000000001','CP001',100)
INSERT INTO MES_CQ_rdrecords01 (id,opertype,dhcode,dhid,cInvCode,iquantity)
VALUES (@ID,0,'0000000001','1000000002','CP001',10)
 
GO
 
--测试数据  删除 
DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord01 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode,cVenCode,cPersonCode)
VALUES (0,2,'0000000004','put005','1','501','XYCG09120001','ZZM')

SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords01 (id,opertype,dhcode,dhid,cInvCode,iquantity)
VALUES (@ID,0,'0000000001','1000000001','CP001',100)
INSERT INTO MES_CQ_rdrecords01 (id,opertype,dhcode,dhid,cInvCode,iquantity)
VALUES (@ID,0,'0000000001','1000000002','CP001',10)

GO


----其它入库单
--测试数据  新增  
 
DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord08 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,0,'000001','put005','1','501')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords08 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001')
INSERT INTO MES_CQ_rdrecords08 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',10,'XYCG09120001')
 
GO
 
--测试数据  删除  


DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord08 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000002','put005','1','501')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords08 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001')
INSERT INTO MES_CQ_rdrecords08 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',10,'XYCG09120001')

GO




----材料出库单
--测试数据  新增   
DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord11 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,0,'000001','PT001','1','501') 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords11 (id,opertype,MoCode,cPInvCode,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'0000000002','CP001','BCP001',100,'XYCG09120001') 
GO
 
--测试数据  删除    
DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord11 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000004','PT001','1','501') 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords11 (id,opertype,MoCode,cPInvCode,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'0000000002','CP001','BCP001',100,'XYCG09120001') 
GO



----其它出库单
--测试数据  新增  
 
DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord09 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,0,'000001','put005','1','501')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords09 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001')
INSERT INTO MES_CQ_rdrecords09 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',10,'XYCG09120001')
 
GO
 
--测试数据  删除  


DECLARE @ID AS INT
INSERT INTO MES_CQ_rdrecord09 (operflag,opertype,crdcode,cWhCode,cRdStyleCode,cDepCode)
VALUES (0,2,'0000000001','put005','1','501')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_rdrecords09 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001')
INSERT INTO MES_CQ_rdrecords09 (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',10,'XYCG09120001')

GO

----调拨单
--测试数据  新增  
DECLARE @ID AS INT
INSERT INTO MES_CQ_TransVouch (operflag,opertype,cTVCode,dTVDate,cOWhCode,cIWhCode,cIRdCode,cORdCode
)
VALUES (0,0,'0000000001','2015-07-01 00:00:00.000','PT001','PT004',null,null)
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_TransVouchs (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001') 
 
GO
 
--测试数据  删除  
DECLARE @ID AS INT
INSERT INTO MES_CQ_TransVouch (operflag,opertype,cTVCode,dTVDate,cOWhCode,cIWhCode,cIRdCode,cORdCode
)
VALUES (0,2,'0000000002','2015-07-01 00:00:00.000','PT001','PT004',null,null)
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_TransVouchs (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001') 
 
GO


----盘点单 delete from MES_CQ_CheckVouchs
--测试数据  新增  
DECLARE @ID AS INT
INSERT INTO MES_CQ_CheckVouch (operflag,opertype,cCVCode,dCVDate,dACDate,
cDepCode,cPersonCode,cWhCode
)
VALUES (0,0,'0000000001','2015-07-01 00:00:00.000','2015-07-01 00:00:00.000',
'501','zzm','put005')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_CheckVouchs (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001') 
 
GO
 
--测试数据  删除  
DECLARE @ID AS INT
INSERT INTO MES_CQ_CheckVouch (operflag,opertype,cCVCode,dCVDate,dACDate,
cDepCode,cPersonCode,cWhCode
)
VALUES (0,2,'0000000001','2015-07-01 00:00:00.000','2015-07-01 00:00:00.000',
'501','zzm','put005')
 
SELECT @ID = @@IDENTITY
INSERT INTO MES_CQ_CheckVouchs (id,opertype,cInvCode,iquantity,cVenCode)
VALUES (@ID,0,'NoFree1',100,'XYCG09120001') 
 
GO
 