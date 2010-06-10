/*======================= table data: MES_CQ_DLLReflect ========================*/
print 'dbo.MES_CQ_DLLReflect data...' 
  
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND cvouchertype = '0411' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'RdRecord10','op','0411','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0411' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0411','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
----销售发货单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '01' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType, ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'Consignment','op','01','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '01' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','01','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
----销售退货单   
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '03' AND ClassType='op' AND TaskType =0)  
BEGIN
insert into MES_Comm_DLLReflect (TaskType, ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'DispatchList','op','03','U8.Interface.Bus.ApiService.Voucher.OP.Factory.CQ','U8.Interface.Bus.ApiService.Voucher.OP.Factory.CQ')
END    
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '03' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType, ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','03','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
----采购入库单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '24' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'PuStoreIn','op','24','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '24' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType, ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','24','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
----其它入库单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0301' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'RdRecord08','op','0301','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0301' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0301','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END

----材料出库单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0412' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'RdRecord11','op','0412','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0412' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0412','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END

----其它出库单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0302' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'RdRecord09','op','0302','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0302' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect (TaskType, ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0302','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
 
----调拨单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0304' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'TransVouch','op','0304','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0304' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0304','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END
 
----盘点单
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0307' AND ClassType='op')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'CheckVouch','op','0307','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
END
IF NOT EXISTS (SELECT 1 FROM MES_Comm_DLLReflect WHERE TaskType =0 AND  cvouchertype = '0307' AND ClassType='data')  
BEGIN
insert into MES_Comm_DLLReflect ( TaskType,ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
  (0,'APIData','data','0307','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
END

----组装单
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_DLLReflect WHERE cvouchertype = '0308' AND ClassType='op')  
--BEGIN
--insert into MES_CQ_DLLReflect ( ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
--  ('AssemVouch','op','0308','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_DLLReflect WHERE cvouchertype = '0308' AND ClassType='data')  
--BEGIN
--insert into MES_CQ_DLLReflect ( ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
--  ('APIData','data','0308','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
--END

------拆卸单
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_DLLReflect WHERE cvouchertype = '0309' AND ClassType='op')  
--BEGIN
--insert into MES_CQ_DLLReflect ( ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
--  ('AssemVouch','op','0309','U8.Interface.Bus.ApiService.Voucher','U8.Interface.Bus.ApiService.Voucher.CQ')
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_DLLReflect WHERE cvouchertype = '0309' AND ClassType='data')  
--BEGIN
--insert into MES_CQ_DLLReflect ( ClassName,ClassType,cvouchertype,Dllpath,Namespace ) values 
--  ('APIData','data','0309','U8.Interface.Bus.ApiService','U8.Interface.Bus.ApiService.Model')
--END

GO


 
----  函数表  开始  ----

/*======================= table data: MES_CQ_FUNCTION ========================*/
print 'dbo.MES_CQ_FUNCTION data...' 

if not exists (SELECT 1 FROM MES_CQ_FUNCTION WHERE cfunid = '010') 
begin
insert into MES_CQ_FUNCTION ( accid,cfunclass,cfunesc,cfunid,cfunname,cfunobject,cfunsql,cfuntype,cfunvba,excdatabase ) values 
  (null,null,'根据存货获取计量单位信息','010','GetComUnitCodeByInvCode',null,'select iChangRate,iGroupType ,i.cGroupCode ,i.cComUnitCode ,cAssComUnitCode ,cSAComUnitCode ,cPUComUnitCode ,cSTComUnitCode ,cCAComUnitCode 
 from inventory i left join  ComputationUnit c on i.cComUnitCode=c.cComunitCode  where i.cinvcode=''{0}''','1',null,'D')
end
--DELETE FROM MES_CQ_FUNCTIONS WHERE cfunid = '010'
if not exists (SELECT 1 FROM MES_CQ_FUNCTIONS WHERE cfunid = '010') 
begin
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','igrouptype','计量单位组类别',2,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','ccomunitcode','主计量单位编码',3,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','casscomunitcode','辅计量单位编码',4,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','csacomunitcode','销售默认计量单位编码',5,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','cpucomunitcode','采购默认计量单位编码',6,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','cstcomunitcode','库存默认计量单位编码',7,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','ccacomunitcode','成本默认计量单位编码',8,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','cinvcode','存货编码',1,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('010','cgroupcode','计量单位组编码',9,'1','String')
end 
go

if not exists (SELECT 1 FROM MES_CQ_FUNCTION WHERE cfunid = '019') 
begin
insert into MES_CQ_FUNCTION ( accid,cfunclass,cfunesc,cfunid,cfunname,cfunobject,cfunsql,cfuntype,cfunvba,excdatabase ) values 
  (null,'U8.Interface.Bus.Function.Compelete','记录订单跟踪信息','019','GetDidTraceInfo','FunctionDLL',null,'2',null,null)
end 
--DELETE FROM MES_CQ_FUNCTIONS WHERE cfunid = '019'
if not exists (SELECT 1 FROM MES_CQ_FUNCTIONS WHERE cfunid = '019') 
begin
	--返回
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_accid','来源单据账套ID',1,'1','string')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','d_accid','目标单据账套ID',2,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_vouchertype','来源单据类型',3,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','d_vouchertype','目标单据类型',4,'1','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_did','来源单据表体ID',5,'1','String')
	--输入  
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_accid','来源单据账套ID',1,'0','string')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','d_accid','目标单据账套ID',2,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_vouchertype','来源单据类型',3,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','d_vouchertype','目标来源单据类型',4,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('019','s_did','来源单据表体ID',5,'0','String')
end 
GO


if not exists (SELECT 1 FROM MES_CQ_FUNCTION WHERE cfunid = '020') 
begin
insert into MES_CQ_FUNCTION ( accid,cfunclass,cfunesc,cfunid,cfunname,cfunobject,cfunsql,cfuntype,cfunvba,excdatabase ) values 
  (null,'U8.Interface.Bus.Function.Compelete','获取上游单据的字段值','020','GetValueByAccVouchnoItemname','FunctionDLL',null,'2',null,null)
end 
--delete MES_CQ_FUNCTIONS WHERE cfunid = '020'
if not exists (SELECT 1 FROM MES_CQ_FUNCTIONS WHERE cfunid = '020') 
begin
	--返回
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('020','b_res','字段值',1,'1','string')
	--输入  
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('020','c_routeid','当前路线号',1,'0','string')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('020','b_accid','上游单据账套ID',2,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('020','b_vouchertype','上游单据类型',3,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('020','b_fieldname','字段名称',4,'0','String') 
end 
GO

--获取需求跟踪信息
if not exists (SELECT 1 FROM MES_CQ_FUNCTION WHERE cfunid = '021') 
begin
insert into MES_CQ_FUNCTION ( accid,cfunclass,cfunesc,cfunid,cfunname,cfunobject,cfunsql,cfuntype,cfunvba,excdatabase ) values 
  (null,'U8.Interface.Bus.Function.Compelete','获取需求跟踪信息','021','GetSRPolicy','FunctionDLL',null,'2',null,null)
end 
--delete MES_CQ_FUNCTIONS WHERE cfunid = '021'
if not exists (SELECT 1 FROM MES_CQ_FUNCTIONS WHERE cfunid = '021') 
begin
	--返回
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('021','ipesotype','pe需求跟踪方式',1,'1','string')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('021','cpesocode','pe需求跟踪号',2,'1','string')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('021','ipesoseq','pe需求跟踪行号',3,'1','string') 
	--输入   
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('021','d_accid','目标单据账套ID',1,'0','String')
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('021','cinvcode','存货编码',2,'0','String') 
end 

GO 

--退货专用函数,根据来源账套采购订单子表ID获取目标账套销售订单信息
if not exists (SELECT 1 FROM MES_CQ_FUNCTION WHERE cfunid = '030') 
begin
insert into MES_CQ_FUNCTION ( accid,cfunclass,cfunesc,cfunid,cfunname,cfunobject,cfunsql,cfuntype,cfunvba,excdatabase ) values 
  (null,'U8.Interface.Bus.Function.Compelete','根据来源账套采购订单子表ID获取目标账套销售订单信息','030','GetSoInfoForReturnOrder','FunctionDLL',null,'2',null,null)
end 
--delete MES_CQ_FUNCTIONS WHERE cfunid = '030'
if not exists (SELECT 1 FROM MES_CQ_FUNCTIONS WHERE cfunid = '030') 
begin
	--返回
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('030','b_res','字段值',1,'1','string')
	--输入  
	insert into MES_CQ_FUNCTIONS ( cfunid,cfunparareturn,cfunparareturndesc,cno,ctype,cvaluetype ) values 
	  ('030','so_fieldname','销售订单字段名称',5,'0','String') 
end 

GO



----  函数表  结束  ----


--函数取值表
