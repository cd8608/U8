 
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMP WHERE TaskType = '0' AND cfrombillcardnum='26' AND ctobillcardnum='26' )  
BEGIN
 insert into MES_CQ_FIELDCMP (TaskType, ccode,cfrombillcardnum,cname,ctobillcardnum,id,iprintcount,vt_id ) values 
  ('0','0000000012','26','采购到货单生成采购退货单','26','1000000012',null,'17')
END

GO

 
-- 采购到货单生成采购退货单
-- DELETE FROM MES_CQ_FIXVALUE WHERE DID IN (SELECT AUTOID FROM  MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000012')
-- DELETE FROM MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000012'
-- 表头
IF (1=1)  
BEGIN
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iVTid')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','单据模版号','T','0000000012',null,null,0,'表头|单据模版号,T|iVTid','iVTid',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cchanger')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','变更人','T','0000000012',null,null,0,'表头|变更人,T|cchanger','cchanger',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iflowid')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','流程ID','T','0000000012',null,null,0,'表头|流程ID,T|iflowid','iflowid',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cReviser')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','修改人','T','0000000012',null,null,0,'表头|修改人,T|cReviser','cReviser',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cverifier')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','审核人','T','0000000012',null,null,0,'表头|审核人,T|cverifier','cverifier',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iverifystateex')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','审核状态','T','0000000012',null,null,0,'表头|审核状态,T|iverifystateex','iverifystateex',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='ireturncount')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','打回次数','T','0000000012',null,null,0,'表头|打回次数,T|ireturncount','ireturncount',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='IsWfControlled')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','是否启用工作流','T','0000000012',null,null,1,'false','IsWfControlled',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='caudittime')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','审核时间','T','0000000012',null,null,0,'表头|审核时间,T|caudittime','caudittime',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cAuditDate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','审核日期','T','0000000012',null,null,0,'表头|审核日期,T|cAuditDate','cAuditDate',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cVenPUOMProtocol')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','收付款协议编码','T','0000000012',null,null,0,'表头|收付款协议编码,T|cVenPUOMProtocol','cVenPUOMProtocol',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine15')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项15','T','0000000012',null,null,0,'表头|表头自定义项15,T|cDefine15','cDefine15',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine12')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项12','T','0000000012',null,null,0,'表头|表头自定义项12,T|cDefine12','cDefine12',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine13')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项13','T','0000000012',null,null,0,'表头|表头自定义项13,T|cDefine13','cDefine13',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine10')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项10','T','0000000012',null,null,0,'表头|表头自定义项10,T|cDefine10','cDefine10',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine11')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项11','T','0000000012',null,null,0,'表头|表头自定义项11,T|cDefine11','cDefine11',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine8')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项8','T','0000000012',null,null,0,'表头|表头自定义项8,T|cDefine8','cDefine8',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine9')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项9','T','0000000012',null,null,0,'表头|表头自定义项9,T|cDefine9','cDefine9',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine7')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项7','T','0000000012',null,null,0,'表头|表头自定义项7,T|cDefine7','cDefine7',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cPersonCode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','职员编号','T','0000000012',null,null,0,'表头|职员编号,T|cPersonCode','cPersonCode',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cPayCode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','付款条件编码','T','0000000012',null,null,0,'表头|付款条件编码,T|cPayCode','cPayCode',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine4')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项4','T','0000000012',null,null,0,'表头|表头自定义项4,T|cDefine4','cDefine4',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine5')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项5','T','0000000012',null,null,0,'表头|表头自定义项5,T|cDefine5','cDefine5',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cPTCode')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','采购类型编码','T','0000000012',null,null,0,'表头|采购类型编码,T|cPTCode','cPTCode',null,'1000000012',1,1)  
	END
 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine2')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项2','T','0000000012',null,null,0,'表头|表头自定义项2,T|cDefine2','cDefine2',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cVenCode')
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values ('0','1','供货单位编号','T','0000000012',null,null,0,'表头|供货单位编号,T|MES_cVenCode','cVenCode',null,'1000000012',1,1)  
	END
	
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cvenabbname')
	--BEGIN  
	--	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--	values ('0','1','供货单位编号','T','0000000012',null,null,0,'表头|供货单位编号,T|MES_cVenCode','cvenabbname',null,'1000000012',1,1)  
	--END
	 
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDepCode')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','部门编号','T','0000000012',null,null,0,'表头|部门编号,T|MES_cDepCode','cDepCode',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cdepname')   
	--BEGIN  
	--	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--	values   ('0','1','部门编号','T','0000000012',null,null,0,'表头|部门编号,T|MES_cDepCode','cdepname',null,'1000000012',1,1)  
	--END
	
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine1')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项1','T','0000000012',null,null,0,'表头|表头自定义项1,T|cDefine1','cDefine1',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cMemo')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','备注','T','0000000012',null,null,0,'表头|备注,T|cMemo','cMemo',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iExchRate')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','汇率','T','0000000012',null,null,0,'表头|汇率,T|iExchRate','iExchRate',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine16')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项16','T','0000000012',null,null,0,'表头|表头自定义项16,T|cDefine16','cDefine16',null,'1000000012',1,1)  END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='ID')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','主表id','T','0000000012',null,null,1,'','ID',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cexch_name')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','币种','T','0000000012',null,null,0,'表头|币种,T|cexch_name','cexch_name',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='bNegative')   
	BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','负发票标志','T','0000000012',null,null,1,'1','bNegative',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iTaxRate')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','税率','T','0000000012',null,null,0,'表头|税率,T|iTaxRate','iTaxRate',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cSCCode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','运输方式编码','T','0000000012',null,null,0,'表头|运输方式编码,T|cSCCode','cSCCode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='dDate')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','日期','T','0000000012',null,null,0,'表头|日期,T|mes_dDate','dDate',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cBusType')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','业务类型','T','0000000012',null,null,0,'表头|业务类型,T|cBusType','cBusType',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cMaker')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','制单人','T','0000000012',null,null,0,'表头|制单人,T|cMaker','cMaker',null,'1000000012',1,1) 
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='ccloser')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','关闭人','T','0000000012',null,null,0,'表头|关闭人,T|ccloser','ccloser',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iBillType')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','单据类型','T','0000000012',null,null,1,'1','iBillType',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cMakeTime')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','制单时间','T','0000000012',null,null,0,'表头|制单时间,T|cMakeTime','cMakeTime',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cModifyTime')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','修改时间','T','0000000012',null,null,0,'表头|修改时间,T|cModifyTime','cModifyTime',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cModifyDate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','修改日期','T','0000000012',null,null,0,'表头|修改日期,T|cModifyDate','cModifyDate',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cpocode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','订单号','T','0000000012',null,null,0,'表头|订单号,T|cpocode','cpocode',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='csysbarcode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','单据条码','T','0000000012',null,null,0,'表头|单据条码,T|csysbarcode','csysbarcode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='iDiscountTaxType')   
	BEGIN  insert 
	into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','扣税类别','T','0000000012',null,null,0,'表头|扣税类别,T|iDiscountTaxType','iDiscountTaxType',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cCode')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','单据号','T','0000000012',null,null,1,'111','cCode',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine3')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表头自定义项3','T','0000000012',null,null,0,'表头|表头自定义项3,T|cDefine3','cDefine3',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine6')   
	--BEGIN  
	--	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--	values   ('0','1','表头自定义项6','T','0000000012',null,null,0,'表头|表头自定义项6,T|cDefine6','cDefine6',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'T' AND fieldname='cDefine14')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','表头自定义项14','T','0000000012',null,null,0,'表头|表头自定义项14,T|cDefine14','cDefine14',null,'1000000012',1,1)  
	--END

END
GO
 
-- 表体
IF (1=1)   
BEGIN
  
  --  IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		--AND fieldname='iorderid')   
  --  BEGIN  
		--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		--values   
		--('0','1','订单ID','B','0000000012',null,null,0,'表体|订单ID,B|iorderid','iorderid',null,'1000000012',1,1)  
  --  END 
    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		AND fieldname='iorderdid')   
    BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   
		('0','1','订单表体ID','B','0000000012',null,null,0,'表体|订单表体ID,B|iorderdid','iorderdid',null,'1000000012',1,1)  
    END
    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		AND fieldname='cordercode')   
    BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   
		('0','1','订单编号','B','0000000012',null,null,0,'表体|订单编号,B|cordercode','cordercode',null,'1000000012',1,1)  
    END
    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		AND fieldname='iPOsID')   
    BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   
		('0','1','采购订单表体ID','B','0000000012',null,null,0,'表体|采购订单表体ID,B|iPOsID','iPOsID',null,'1000000012',1,1)  
    END 
  --  IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		--AND fieldname='carrivalcode')   
  --  BEGIN  
		--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		--values   
		--('0','1','采购到货单单号','B','0000000012',null,null,0,'表体|采购到货单单号,B|cCode','carrivalcode',null,'1000000012',1,1)  
  --  END 
    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' 
		AND fieldname='iCorId')   
    BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   
		('0','1','到货单表体ID','B','0000000012',null,null,0,'表体|到货单表体ID,B|AUTOID','iCorId',null,'1000000012',1,1)  
    END  
    IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iTaxRate')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','税率','B','0000000012',null,null,0,'表体|税率,B|iTaxRate','iTaxRate',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iinvexchrate')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','换算率','B','0000000012',null,null,0,'表体|换算率,B|iinvexchrate','iinvexchrate',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iOriCost')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','原币单价','B','0000000012',null,null,0,'表体|原币单价,B|iOriCost','iOriCost',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iOriTaxCost')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','含税单价','B','0000000012',null,null,0,'表体|含税单价,B|iOriTaxCost','iOriTaxCost',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iOriMoney')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','原币金额','B','0000000012',null,null,0,'表体|原币金额,B|pro_iOriMoney','iOriMoney',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iOriTaxPrice')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','原币税额','B','0000000012',null,null,0,'表体|原币税额,B|pro_iOriTaxPrice','iOriTaxPrice',null,'1000000012',1,1)  
	--END
 --   IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iOriSum')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','原币价税合计','B','0000000012',null,null,0,'表体|原币价税合计,B|pro_iOriSum','iOriSum',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iCost')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','本币单价','B','0000000012',null,null,0,'表体|本币单价,B|iCost','iCost',null,'1000000012',1,1)  
	--END 
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iMoney')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','本币金额','B','0000000012',null,null,0,'表体|本币金额,B|pro_iMoney','iMoney',null,'1000000012',1,1)  
	--END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iTaxPrice')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','本币税额','B','0000000012',null,null,0,'表体|本币税额,B|pro_iTaxPrice','iTaxPrice',null,'1000000012',1,1)  
	--END  
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iSum')   
	--BEGIN  
	--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	--values   ('0','1','本币价税合计','B','0000000012',null,null,0,'表体|本币价税合计,B|pro_iSum','iSum',null,'1000000012',1,1)  
	--END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cInvCode')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','存货编码','B','0000000012',null,null,0,'表体|存货编码,B|MES_cInvCode','cInvCode',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iQuantity')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','主计量数量','B','0000000012',null,null,0,'表体|主计量数量,B|MES_iQuantity','iQuantity',null,'1000000012',1,1)  
	END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree1')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项1','B','0000000012',null,null,0,'表体|自由项1,B|cFree1','cFree1',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine31')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项10','B','0000000012',null,null,0,'表体|表体自定义项10,B|cDefine31','cDefine31',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine32')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项11','B','0000000012',null,null,0,'表体|表体自定义项11,B|cDefine32','cDefine32',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine33')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项12','B','0000000012',null,null,0,'表体|表体自定义项12,B|cDefine33','cDefine33',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine34')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项13','B','0000000012',null,null,0,'表体|表体自定义项13,B|cDefine34','cDefine34',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine35')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项14','B','0000000012',null,null,0,'表体|表体自定义项14,B|cDefine35','cDefine35',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine36')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项15','B','0000000012',null,null,0,'表体|表体自定义项15,B|cDefine36','cDefine36',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine37')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项16','B','0000000012',null,null,0,'表体|表体自定义项16,B|cDefine37','cDefine37',null,'1000000012',1,1)  END
	
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iCorId')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','到货单子表id','B','0000000012',null,null,0,'表体|到货单子表id,B|iCorId','iCorId',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatch')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批号','B','0000000012',null,null,0,'表体|批号,B|cBatch','cBatch',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='dPDate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','生产日期','B','0000000012',null,null,0,'表体|生产日期,B|dPDate','dPDate',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='dVDate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','失效日期','B','0000000012',null,null,0,'表体|失效日期,B|dVDate','dVDate',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='imassdate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','保质期','B','0000000012',null,null,0,'表体|保质期,B|imassdate','imassdate',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='bGsp')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','是否检验','B','0000000012',null,null,0,'表体|是否检验,B|bGsp','bGsp',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='Autoid')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','子表id','B','0000000012',null,null,1,'','Autoid',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='ID')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','主表id','B','0000000012',null,null,0,'表体|主表id,B|ID','ID',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cWhCode')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','仓库编码','B','0000000012',null,null,0,'表体|仓库编码,B|MES_cWhCode','cWhCode',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='ivouchrowno')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','行号','B','0000000012',null,null,0,'表体|行号,B|ivouchrowno','ivouchrowno',null,'1000000012',1,1)  END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cItemCode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','项目编码','B','0000000012',null,null,0,'表体|项目编码,B|cItemCode','cItemCode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cItem_class')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','项目大类编码','B','0000000012',null,null,0,'表体|项目大类编码,B|cItem_class','cItem_class',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iPOsID')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','订单子表ID','B','0000000012',null,null,0,'表体|订单子表ID,B|iPOsID','iPOsID',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cItemName')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','项目名称','B','0000000012',null,null,0,'表体|项目名称,B|cItemName','cItemName',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree3')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项3','B','0000000012',null,null,0,'表体|自由项3,B|cFree3','cFree3',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree4')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项4','B','0000000012',null,null,0,'表体|自由项4,B|cFree4','cFree4',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree5')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项5','B','0000000012',null,null,0,'表体|自由项5,B|cFree5','cFree5',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree6')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项6','B','0000000012',null,null,0,'表体|自由项6,B|cFree6','cFree6',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree7')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项7','B','0000000012',null,null,0,'表体|自由项7,B|cFree7','cFree7',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree8')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项8','B','0000000012',null,null,0,'表体|自由项8,B|cFree8','cFree8',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree9')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项9','B','0000000012',null,null,0,'表体|自由项9,B|cFree9','cFree9',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine29')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项8','B','0000000012',null,null,0,'表体|表体自定义项8,B|cDefine29','cDefine29',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine30')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项9','B','0000000012',null,null,0,'表体|表体自定义项9,B|cDefine30','cDefine30',null,'1000000012',1,1)  END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iNum')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','件数','B','0000000012',null,null,1,'-1','iNum',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cupsocode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','不良品处理单号','B','0000000012',null,null,0,'表体|不良品处理单号,B|cupsocode','cupsocode',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty1')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性1','B','0000000012',null,null,0,'表体|批次属性1,B|cBatchProperty1','cBatchProperty1',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty2')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性2','B','0000000012',null,null,0,'表体|批次属性2,B|cBatchProperty2','cBatchProperty2',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty3')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性3','B','0000000012',null,null,0,'表体|批次属性3,B|cBatchProperty3','cBatchProperty3',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty4')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性4','B','0000000012',null,null,0,'表体|批次属性4,B|cBatchProperty4','cBatchProperty4',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty5')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性5','B','0000000012',null,null,0,'表体|批次属性5,B|cBatchProperty5','cBatchProperty5',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty6')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性6','B','0000000012',null,null,0,'表体|批次属性6,B|cBatchProperty6','cBatchProperty6',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty7')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性7','B','0000000012',null,null,0,'表体|批次属性7,B|cBatchProperty7','cBatchProperty7',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty8')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性8','B','0000000012',null,null,0,'表体|批次属性8,B|cBatchProperty8','cBatchProperty8',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty9')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性9','B','0000000012',null,null,0,'表体|批次属性9,B|cBatchProperty9','cBatchProperty9',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cBatchProperty10')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','批次属性10','B','0000000012',null,null,0,'表体|批次属性10,B|cBatchProperty10','cBatchProperty10',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iorderdid')   
	BEGIN  
		insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
		values   ('0','1','销售订单子表id ','B','0000000012',null,null,0,'表体|销售订单子表id ,B|iorderdid','iorderdid',null,'1000000012',1,1)
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iordertype')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','销售订单类型 ','B','0000000012',null,null,0,'表体|销售订单类型 ,B|iordertype','iordertype',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='csoordercode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','销售订单号 ','B','0000000012',null,null,0,'表体|销售订单号 ,B|csoordercode','csoordercode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iorderseq')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','销售订单行号 ','B','0000000012',null,null,0,'表体|销售订单行号 ,B|iorderseq','iorderseq',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='fRefuseQuantity')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','拒收数量','B','0000000012',null,null,0,'表体|拒收数量,B|fRefuseQuantity','fRefuseQuantity',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='fRefuseNum')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','拒收件数','B','0000000012',null,null,0,'表体|拒收件数,B|fRefuseNum','fRefuseNum',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='bexigency')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','是否急料','B','0000000012',null,null,0,'表体|是否急料,B|bexigency','bexigency',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cmassunit')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','保质期单位','B','0000000012',null,null,0,'表体|保质期单位,B|cmassunit','cmassunit',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iPPartId')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','母件Id','B','0000000012',null,null,0,'表体|母件Id,B|iPPartId','iPPartId',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='bInspect')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','是否已报检','B','0000000012',null,null,0,'表体|是否已报检,B|bInspect','bInspect',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='igrouptype')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','igrouptype','B','0000000012',null,null,1,'0','igrouptype',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='bTaxCost')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','单价标准','B','0000000012',null,null,0,'表体|单价标准,B|bTaxCost','bTaxCost',null,'1000000012',1,1)  
	END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='carrivalcode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','到货单号','B','0000000012',null,null,0,'表体|到货单号,B|carrivalcode','carrivalcode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cbcloser')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','行关闭人','B','0000000012',null,null,0,'表体|行关闭人,B|cbcloser','cbcloser',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cbMemo')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','备注','B','0000000012',null,null,0,'表体|备注,B|cbMemo','cbMemo',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cbsysbarcode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','单据行条码','B','0000000012',null,null,0,'表体|单据行条码,B|cbsysbarcode','cbsysbarcode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine22')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项1','B','0000000012',null,null,0,'表体|表体自定义项1,B|cDefine22','cDefine22',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine23')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项2','B','0000000012',null,null,0,'表体|表体自定义项2,B|cDefine23','cDefine23',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine24')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项3','B','0000000012',null,null,0,'表体|表体自定义项3,B|cDefine24','cDefine24',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine25')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项4','B','0000000012',null,null,0,'表体|表体自定义项4,B|cDefine25','cDefine25',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine26')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项5','B','0000000012',null,null,0,'表体|表体自定义项5,B|cDefine26','cDefine26',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine27')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项6','B','0000000012',null,null,0,'表体|表体自定义项6,B|cDefine27','cDefine27',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cDefine28')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','表体自定义项7','B','0000000012',null,null,0,'表体|表体自定义项7,B|cDefine28','cDefine28',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cExpirationdate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','有效期至','B','0000000012',null,null,0,'表体|有效期至,B|cExpirationdate','cExpirationdate',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree10')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项10','B','0000000012',null,null,0,'表体|自由项10,B|cFree10','cFree10',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cFree2')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','自由项2','B','0000000012',null,null,0,'表体|自由项2,B|cFree2','cFree2',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='ContractCode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','合同号','B','0000000012',null,null,0,'表体|合同号,B|ContractCode','ContractCode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='ContractRowGUID')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','合同标的GUID','B','0000000012',null,null,0,'表体|合同标的GUID,B|ContractRowGUID','ContractRowGUID',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='ContractRowNo')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','合同标的编码','B','0000000012',null,null,0,'表体|合同标的编码,B|ContractRowNo','ContractRowNo',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cordercode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','订单号','B','0000000012',null,null,0,'表体|订单号,B|cordercode','cordercode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='csocode')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','需求跟踪号','B','0000000012',null,null,0,'表体|需求跟踪号,B|csocode','csocode',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cUnitID')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','单位编码','B','0000000012',null,null,0,'表体|单位编码,B|cUnitID','cUnitID',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='cinvm_unit')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','cinvm_unit','B','0000000012',null,null,0,'表体|单位编码,B|cUnitID','cinvm_unit',null,'1000000012',1,1)  
	END
	
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='dExpirationdate')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','有效期计算项','B','0000000012',null,null,0,'表体|有效期计算项,B|dExpirationdate','dExpirationdate',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='finValidQuantity')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','不合格数量','B','0000000012',null,null,0,'表体|不合格数量,B|finValidQuantity','finValidQuantity',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='fRealQuantity')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','实收数量','B','0000000012',null,null,0,'表体|实收数量,B|fRealQuantity','fRealQuantity',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='FSumRefuseNum')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','已拒收件数','B','0000000012',null,null,0,'表体|已拒收件数,B|FSumRefuseNum','FSumRefuseNum',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='fSumRefuseQuantity')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','已拒收数量','B','0000000012',null,null,0,'表体|已拒收数量,B|fSumRefuseQuantity','fSumRefuseQuantity',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='fValidQuantity')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','合格数量','B','0000000012',null,null,0,'表体|合格数量,B|fValidQuantity','fValidQuantity',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iExpiratDateCalcu')   
	BEGIN  
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','有效期推算方式','B','0000000012',null,null,0,'表体|有效期推算方式,B|iExpiratDateCalcu','iExpiratDateCalcu',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iInvMPCost')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','最高进价','B','0000000012',null,null,0,'表体|最高进价,B|iInvMPCost','iInvMPCost',null,'1000000012',1,1)  END

	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='iPTOSeq')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','选配序号','B','0000000012',null,null,0,'表体|选配序号,B|iPTOSeq','iPTOSeq',null,'1000000012',1,1)  END
	--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='irejectautoid')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','irejectautoid','B','0000000012',null,null,0,'表体|irejectautoid,B|irejectautoid','irejectautoid',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='irowno')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','需求跟踪行号','B','0000000012',null,null,0,'表体|需求跟踪行号,B|irowno','irowno',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='SoDId')   BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values   ('0','1','需求跟踪子表ID','B','0000000012',null,null,0,'表体|需求跟踪子表ID,B|SoDId','SoDId',null,'1000000012',1,1)  END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='SoType')   
	BEGIN  insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) 
	values   ('0','1','需求跟踪方式','B','0000000012',null,null,0,'表体|需求跟踪方式,B|SoType','SoType',null,'1000000012',1,1)  
	END
	IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000012' AND cardsection = 'B' AND fieldname='editprop') 
	BEGIN
	insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0','1','操作标识','B','0000000012',null,null,0,'表体|操作标识,B|editprop','editprop',null,'1000000012',1,1)
	END

END 
GO
 
    