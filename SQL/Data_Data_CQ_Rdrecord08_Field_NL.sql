
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMP WHERE TaskType = '0' AND cfrombillcardnum='' AND ctobillcardnum='0301' )  
BEGIN
 insert into MES_CQ_FIELDCMP (TaskType, ccode,cfrombillcardnum,cname,ctobillcardnum,id,iprintcount,vt_id ) values 
  ('0','0000000004','','MES生成其它入库单','0301','1000000004',null,'17')
END

GO
 
-- MES生成其它入库单
-- DELETE FROM MES_CQ_FIXVALUE WHERE DID IN (SELECT AUTOID FROM  MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000004')
-- DELETE FROM MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000004'
-- 表头
IF (1=1)  
BEGIN
	
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='dDate') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','入库日期','T','0000000004',null,null,0,'表头|入库日期,T|dDate','dDate',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='dnmaketime') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','制单时间','T','0000000004',null,null,0,'表头|制单时间,T|dnmaketime','dnmaketime',null,'1000000004',1,1)
	END 
	
 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cWhCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','仓库编码','T','0000000004',null,null,0,'表头|仓库编码,T|MES_cWhCode','cWhCode',null,'1000000004',1,1)
	END

	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cDepCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','部门编码','T','0000000004',null,null,0,'表头|部门编码,T|MES_cDepCode','cDepCode',null,'1000000004',1,1)
	END
	 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cVouchType') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','单据类型','T','0000000004',null,null,1,'08','cVouchType',null,'1000000004',1,1)
	END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cSource') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','单据来源','T','0000000004',null,null,1,'库存','cSource',null,'1000000004',1,1)
	END	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cBusType') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','业务类型','T','0000000004',null,null,1,'其他入库','cBusType',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','入库单号','T','0000000004',null,null,0,'表头|入库单号,T|cCode','cCode',null,'1000000004',1,1)
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cVenCode') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','供货单位编码','T','0000000004',null,null,0,'表头|供货单位编码,T|MES_cVenCode','cVenCode',null,'1000000004',1,1)
	--END 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cPersonCode') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','业务员编码','T','0000000004',null,null,0,'表头|业务员编码,T|MES_cPersonCode','cPersonCode',null,'1000000004',1,1)
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='iTaxRate') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','税率','T','0000000004',null,null,0,'表头|税率,T|iTaxRate','iTaxRate',null,'1000000004',1,1)
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='iExchRate') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','汇率','T','0000000004',null,null,1,'1','iExchRate',null,'1000000004',1,1)
	--END  
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='iFlowId') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','流程模式ID','T','0000000004',null,null,1,NULL,'iFlowId',null,'1000000004',1,1)
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'T' AND fieldname='cExch_Name') 
	--BEGIN
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	--('0','1','币种','T','0000000004',null,null,1,'人民币','cExch_Name',null,'1000000004',1,1)
	--END 
 
END
GO
 
-- 表体
IF (1=1)   
BEGIN  
	   
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='cInvCode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','存货编码','B','0000000004',null,null,0,'表体|存货编码,B|mes_cInvCode','cInvCode',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='iQuantity') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','数量','B','0000000004',null,null,0,'表体|数量,B|mes_iquantity','iQuantity',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='editprop') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','操作标识','B','0000000004',null,null,0,'表体|操作标识,B|editprop','editprop',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='cMassUnit') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','保质期单位','B','0000000004',null,null,1,'0','cMassUnit',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='cvmivencode') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','供货商编码','B','0000000004',null,null,0,'表体|供货商编码,B|mes_cvencode','cvmivencode',null,'1000000004',1,1)
	END 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='iExpiratDateCalcu') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','有效期推算方式','B','0000000004',null,null,1,0,'iExpiratDateCalcu',null,'1000000004',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000004' AND cardsection = 'B' AND fieldname='dExpirationdate') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','有效期计算项','B','0000000004',null,null,1,null,'dExpirationdate',null,'1000000004',1,1)
	END 
 
END

GO
 
    