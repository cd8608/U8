
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMP WHERE TaskType = '0' AND cfrombillcardnum='MQ6303' AND ctobillcardnum='MO21' )  
BEGIN
 insert into MES_CQ_FIELDCMP (TaskType, ccode,cfrombillcardnum,cname,ctobillcardnum,id,iprintcount,vt_id ) values 
  ('0','0000000014','MQ6303','生产计划生成生产订单','MO21','1000000014',null,'17')
END

GO
 
-- 生产计划生成生产订单  SELECT * FROM MES_CQ_FIELDCMP 
-- DELETE FROM MES_CQ_FIXVALUE WHERE DID IN (SELECT AUTOID FROM  MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000014')
-- DELETE FROM MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000014'

-- 表头
IF (1=1)  
BEGIN

    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'T' AND fieldname='MoId') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产订单id','T','0000000014',null,null,1,'111','MoId',null,'1000000014',1,1)
	END 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'T' AND fieldname='MoCode') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','生产订单号','T','0000000014',null,null,1,'1111','MoCode',null,'1000000014',1,1)
	--END   
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'T' AND fieldname='MoCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产订单号','T','0000000014',null,null,0,'表体|生产订单号,B|MES_MoCode','MoCode',null,'1000000014',1,1)
	END   
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'T' AND fieldname='CreateUser') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','制单人','T','0000000014',null,null,1,'demo','CreateUser',null,'1000000014',1,1)
	END   
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'T' AND fieldname='RelsUser') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','审核人','T','0000000014',null,null,1,'demo','RelsUser',null,'1000000014',1,1)
	--END   
	
	
END
GO
 
-- 表体
IF (1=1)   
BEGIN 

	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMoClass') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','类型','B','0000000014',null,null,0,'表体|类型,B|MES_MOTYPE','DMoClass',null,'1000000014',1,1)
	--END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMoClass') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','类型','B','0000000014',null,null,1,'0','DMoClass',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DInvCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','存货编码','B','0000000014',null,null,0,'表体|存货编码,B|MES_cInvCode','DInvCode',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DStartDate') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','开工日期','B','0000000014',null,null,0,'表体|开工日期,B|MES_PStartDate','DStartDate',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DDueDate') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','完工日期','B','0000000014',null,null,0,'表体|完工日期,B|MES_PDueDate','DDueDate',null,'1000000014',1,1)
	END  
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DQty') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产数量','B','0000000014',null,null,0,'表体|生产数量,B|MES_iquantity','DQty',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DSortSeq') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','行号','B','0000000014',null,null,1,'1','DSortSeq',null,'1000000014',1,1)
	END 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMoTypeId') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','生产订单类别','B','0000000014',null,null,0,'表体|订单类别,B|MES_MoType','DMoTypeId',null,'1000000014',1,1)
	--END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMoTypeCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产订单类别','B','0000000014',null,null,0,'表体|订单类别,B|PRO_MoType','DMoTypeCode',null,'1000000014',1,1)
	END                                                                   
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DOrderType') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','销售订单类别','B','0000000014',null,null,1,'1','DOrderType',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DOrderCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','销售订单号','B','0000000014',null,null,0,'表体|销售订单号,B|sob_cSOCode','DOrderCode',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DOrderSeq') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','销售订单行号','B','0000000014',null,null,0,'表体|销售订单行号,B|sob_iRowNo','DOrderSeq',null,'1000000014',1,1)
	END  
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMDeptCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产部门','B','0000000005',null,null,0,'表体|生产部门,B|MES_cWcCode','DMDeptCode',null,'1000000014',1,1)
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DDemandId') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','生产计划ID','B','0000000005',null,null,0,'表体|生产计划ID,B|DemandId','DDemandId',null,'1000000014',1,1)
	--END
	
	
	
END
 

-- 子件用料表
IF (1=1)   
BEGIN 

	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DQty') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','子件数量','C','0000000014',null,null,0,'表体|子件数量,C|MES_C_iquantity','DQty',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DSortSeq') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','子件行号','C','0000000014',null,null,1,'1','DSortSeq',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DOpSeq') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','工序行号','C','0000000014',null,null,1,'0000','DOpSeq',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DInvCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','子件编码','C','0000000014',null,null,0,'表体|子件编码,C|MES_cInvCode','DInvCode',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DBaseQtyN') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','基本用量','C','0000000014',null,null,0,'表体|基本用量,C|MES_iquantity','DBaseQtyN',null,'1000000014',1,1)
	END 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DBaseQtyD') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','基础数量','C','0000000014',null,null,0,'表体|基础数量,C|MES_iquantity','DBaseQtyD',null,'1000000014',1,1)
	--END    
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DBaseQtyD') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','基础数量','C','0000000014',null,null,1,'1','DBaseQtyD',null,'1000000014',1,1)
	END    
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'C' AND fieldname='DStartDemDate') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','需求日期','C','0000000014',null,null,0,'表体|需求日期,C|MES_DmandDate','DStartDemDate',null,'1000000014',1,1)
	END  
	 
END 
GO
    	