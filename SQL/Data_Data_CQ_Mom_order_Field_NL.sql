
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

    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='MoId') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产订单id','T','0000000014',null,null,1,'111','MoId',null,'1000000014',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='MoCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','生产订单号','T','0000000014',null,null,1,'1111','MoCode',null,'1000000014',1,1)
	END   
END
GO
 
-- 表体
IF (1=1)   
BEGIN 

	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DMoClass') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','类型','B','0000000014',null,null,0,'表体|类型,B|MES_MOTYPE','DMoClass',null,'1000000014',1,1)
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
	
END
 

-- 子件用料表
IF (1=1)   
BEGIN 

	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000014' AND cardsection = 'B' AND fieldname='DQty') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','子件行号','C','0000000014',null,null,0,'表体|子件行号,B|MES_iquantity','DQty',null,'1000000014',1,1)
	END 
	
			Mom_MoAllocate[0]["DSortSeq"] = ""; //子件行号(必须)，int类型
			Mom_MoAllocate[0]["DOpSeq"] = ""; //工序行号，string类型
			Mom_MoAllocate[0]["DInvCode"] = ""; //子件编码(必须)，string类型
			Mom_MoAllocate[0]["DBaseQtyN"] = ""; //基本用量，double类型
			Mom_MoAllocate[0]["DBaseQtyD"] = ""; //基础数量，double类型
			Mom_MoAllocate[0]["DStartDemDate"] = ""; //需求日期，DateTime类型
END 
GO
    	