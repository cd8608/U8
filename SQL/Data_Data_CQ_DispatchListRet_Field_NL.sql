
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMP WHERE TaskType = '0' AND cfrombillcardnum='17' AND ctobillcardnum='03' )  
BEGIN
 insert into MES_CQ_FIELDCMP (TaskType, ccode,cfrombillcardnum,cname,ctobillcardnum,id,iprintcount,vt_id ) values 
  ('0','0000000009','17','销售订单生成销售退货单','03','1000000009',null,'17')
END

GO
 

-- 销售订单生成销售发货单
-- DELETE FROM MES_CQ_FIXVALUE WHERE DID IN (SELECT AUTOID FROM  MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000009')
-- DELETE FROM MES_CQ_FIELDCMPS  WHERE TaskType = '0' AND id='1000000009'   DELETE FROM MES_CQ_FIXVALUE
-- 表头
IF (1=1)  
BEGIN

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine1') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项1','T','0000000009',null,null,0,'表头|表头自定义项1,T|cDefine1','cDefine1',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine2') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项2','T','0000000009',null,null,0,'表头|表头自定义项2,T|cDefine2','cDefine2',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine3') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项3','T','0000000009',null,null,0,'表头|表头自定义项3,T|cDefine3','cDefine3',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine4') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项4','T','0000000009',null,null,0,'表头|表头自定义项4,T|cDefine4','cDefine4',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine5') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项5','T','0000000009',null,null,0,'表头|表头自定义项5,T|cDefine5','cDefine5',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine6') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项6','T','0000000009',null,null,0,'表头|表头自定义项6,T|cDefine6','cDefine6',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine7') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项7','T','0000000009',null,null,0,'表头|表头自定义项7,T|cDefine7','cDefine7',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine8') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项8','T','0000000009',null,null,0,'表头|表头自定义项8,T|cDefine8','cDefine8',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine9') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项9','T','0000000009',null,null,0,'表头|表头自定义项9,T|cDefine9','cDefine9',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine10') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项10','T','0000000009',null,null,0,'表头|表头自定义项10,T|cDefine10','cDefine10',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine11') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项11','T','0000000009',null,null,0,'表头|表头自定义项11,T|cDefine11','cDefine11',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine12') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项12','T','0000000009',null,null,0,'表头|表头自定义项12,T|cDefine12','cDefine12',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine13') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项13','T','0000000009',null,null,0,'表头|表头自定义项13,T|cDefine13','cDefine13',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine14') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项14','T','0000000009',null,null,0,'表头|表头自定义项14,T|cDefine14','cDefine14',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine15') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项15','T','0000000009',null,null,0,'表头|表头自定义项15,T|cDefine15','cDefine15',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine16') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表头自定义项16','T','0000000009',null,null,0,'表头|表头自定义项16,T|cDefine16','cDefine16',null,'1000000009',1,1)
END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cMaker') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','制单人','T','0000000009',null,null,0,'表头|制单人,T|cMaker','cMaker',null,'1000000009',1,1)
END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='DLID') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','autoid','T','0000000009',null,null,1,'111','DLID',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDLCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','发货单号','T','0000000009',null,null,1,'111','cDLCode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cVouchType') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','单据类型编码','T','0000000009',null,null,1,'05','cVouchType',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ccreditcuscode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','信用单位编码','T','0000000009',null,null,1,'NULL','ccreditcuscode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSTCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','销售类型编码','T','0000000009',null,null,0,'表头|销售类型编码,T|cSTCode','cSTCode',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发货日期','T','0000000009',null,null,0,'表头|发货日期,T|dDate','dDate',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDepCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','部门编码','T','0000000009',null,null,0,'表头|部门编码,T|cDepCode','cDepCode',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cPersonCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','业务员编码','T','0000000009',null,null,0,'表头|业务员编码,T|cPersonCode','cPersonCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='SBVID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','销售发票ID','T','0000000009',null,null,0,'表头|销售发票ID,T|SBVID','SBVID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSBVCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发票号','T','0000000009',null,null,0,'表头|发票号,T|cSBVCode','cSBVCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSOCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','订单号','T','0000000009',null,null,0,'表头|订单号,T|cSOCode','cSOCode',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cCusCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','客户编码','T','0000000009',null,null,0,'表头|客户编码,T|cCusCode','cCusCode',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cPayCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','付款条件编码','T','0000000009',null,null,0,'表头|付款条件编码,T|cPayCode','cPayCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSCCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发运方式编码','T','0000000009',null,null,0,'表头|发运方式编码,T|cSCCode','cSCCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cShipAddress') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发货地址','T','0000000009',null,null,0,'表头|发货地址,T|cShipAddress','cShipAddress',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cexch_name') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','币种','T','0000000009',null,null,0,'表头|币种,T|cexch_name','cexch_name',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iExchRate') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','汇率','T','0000000009',null,null,0,'表头|汇率,T|iExchRate','iExchRate',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iTaxRate') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','税率','T','0000000009',null,null,0,'表头|税率,T|iTaxRate','iTaxRate',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bFirst') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','期初标志','T','0000000009',null,null,0,'表头|期初标志,T|bFirst','bFirst',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bReturnFlag') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','退货标识','T','0000000009',null,null,1,'1','bReturnFlag',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cMemo') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','备    注','T','0000000009',null,null,0,'表头|备    注,T|cMemo','cMemo',null,'1000000009',1,1)
--END


--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cVerifier') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核人','T','0000000009',null,null,0,'表头|审核人,T|cVerifier','cVerifier',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cMaker') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','制单人','T','0000000009',null,null,0,'表头|制单人,T|cMaker','cMaker',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iSale') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否先发货','T','0000000009',null,null,1,'0','iSale',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cCusName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','客户名称','T','0000000009',null,null,0,'表头|客户名称,T|cCusName','cCusName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iVTid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单据模版号','T','0000000009',null,null,0,'表头|单据模版号,T|iVTid','iVTid',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ufts') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','时间戳','T','0000000009',null,null,0,'表头|时间戳,T|ufts','ufts',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cBusType') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','业务类型','T','0000000009',null,null,0,'表头|业务类型,T|cBusType','cBusType',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cCloser') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','关闭人','T','0000000009',null,null,0,'表头|关闭人,T|cCloser','cCloser',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cCreChpName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','信用审核人','T','0000000009',null,null,0,'表头|信用审核人,T|cCreChpName','cCreChpName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine11') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项11','T','0000000009',null,null,0,'表头|表头自定义项11,T|cDefine11','cDefine11',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine12') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项12','T','0000000009',null,null,0,'表头|表头自定义项12,T|cDefine12','cDefine12',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine13') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项13','T','0000000009',null,null,0,'表头|表头自定义项13,T|cDefine13','cDefine13',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine14') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项14','T','0000000009',null,null,0,'表头|表头自定义项14,T|cDefine14','cDefine14',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine15') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项15','T','0000000009',null,null,0,'表头|表头自定义项15,T|cDefine15','cDefine15',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cDefine16') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项16','T','0000000009',null,null,0,'表头|表头自定义项16,T|cDefine16','cDefine16',null,'1000000009',1,1)
--END


--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cgatheringplan') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收付款协议编码','T','0000000009',null,null,0,'表头|收付款协议编码,T|cgatheringplan','cgatheringplan',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dCreditStart') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','立账日','T','0000000009',null,null,0,'表头|立账日,T|dCreditStart','dCreditStart',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dGatheringDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','到期日','T','0000000009',null,null,0,'表头|到期日,T|dGatheringDate','dGatheringDate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='icreditdays') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','账期','T','0000000009',null,null,0,'表头|账期,T|icreditdays','icreditdays',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bCredit') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否为立账单据','T','0000000009',null,null,1,'否','bCredit',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='caddcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货地址编码','T','0000000009',null,null,0,'表头|收货地址编码,T|caddcode','caddcode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iverifystate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iverifystate','T','0000000009',null,null,0,'表头|iverifystate,T|iverifystate','iverifystate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ireturncount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','ireturncount','T','0000000009',null,null,0,'表头|ireturncount,T|ireturncount','ireturncount',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iswfcontrolled') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iswfcontrolled','T','0000000009',null,null,0,'表头|iswfcontrolled,T|iswfcontrolled','iswfcontrolled',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='icreditstate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','icreditstate','T','0000000009',null,null,0,'表头|icreditstate,T|icreditstate','icreditstate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cmodifier') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改人','T','0000000009',null,null,0,'表头|修改人,T|cmodifier','cmodifier',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dmoddate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改日期','T','0000000009',null,null,0,'表头|修改日期,T|dmoddate','dmoddate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dverifydate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核日期','T','0000000009',null,null,0,'表头|审核日期,T|dverifydate','dverifydate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ccusperson') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','联系人','T','0000000009',null,null,0,'表头|联系人,T|ccusperson','ccusperson',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dcreatesystime') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','制单时间','T','0000000009',null,null,0,'表头|制单时间,T|dcreatesystime','dcreatesystime',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ddate') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','入库日期','T','0000000009',null,null,0,'表头|入库日期,T|ddate','ddate',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dverifysystime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核时间','T','0000000009',null,null,0,'表头|审核时间,T|dverifysystime','dverifysystime',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dmodifysystime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改时间','T','0000000009',null,null,0,'表头|修改时间,T|dmodifysystime','dmodifysystime',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='csvouchtype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','csvouchtype','T','0000000009',null,null,0,'表头|csvouchtype,T|csvouchtype','csvouchtype',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iflowid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','流程id','T','0000000009',null,null,0,'表头|流程id,T|iflowid','iflowid',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bsigncreate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','签回损失生成','T','0000000009',null,null,0,'表头|签回损失生成,T|bsigncreate','bsigncreate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bcashsale') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','现款结算','T','0000000009',null,null,0,'表头|现款结算,T|bcashsale','bcashsale',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cgathingcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收款单号','T','0000000009',null,null,0,'表头|收款单号,T|cgathingcode','cgathingcode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cChanger') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','变更人','T','0000000009',null,null,0,'表头|变更人,T|cChanger','cChanger',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cChangeMemo') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','变更原因','T','0000000009',null,null,0,'表头|变更原因,T|cChangeMemo','cChangeMemo',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bmustbook') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','必有定金','T','0000000009',null,null,0,'表头|必有定金,T|bmustbook','bmustbook',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='baccswitchflag') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','存货核算切换选项','T','0000000009',null,null,0,'表头|存货核算切换选项,T|baccswitchflag','baccswitchflag',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ccuspersoncode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','联系人编码','T','0000000009',null,null,0,'表头|联系人编码,T|ccuspersoncode','ccuspersoncode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSourceCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','来源单据号','T','0000000009',null,null,0,'表头|来源单据号,T|cSourceCode','cSourceCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bsaleoutcreatebill') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','出库单开发票','T','0000000009',null,null,0,'表头|出库单开发票,T|bsaleoutcreatebill','bsaleoutcreatebill',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cSysBarCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单据条码','T','0000000009',null,null,0,'表头|单据条码,T|cSysBarCode','cSysBarCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='csscode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','结算方式编码','T','0000000009',null,null,0,'表头|结算方式编码,T|csscode','csscode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cinvoicecompany') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','开票单位编码','T','0000000009',null,null,0,'表头|开票单位编码,T|cinvoicecompany','cinvoicecompany',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='fEBweight') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','重量','T','0000000009',null,null,0,'表头|重量,T|fEBweight','fEBweight',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBweightUnit') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','重量单位','T','0000000009',null,null,0,'表头|重量单位,T|cEBweightUnit','cEBweightUnit',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBExpressCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','快递单号','T','0000000009',null,null,0,'表头|快递单号,T|cEBExpressCode','cEBExpressCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='iEBExpressCoID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','物流公司ID','T','0000000009',null,null,0,'表头|物流公司ID,T|iEBExpressCoID','iEBExpressCoID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='SeparateID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','分拣号','T','0000000009',null,null,0,'表头|分拣号,T|SeparateID','SeparateID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='bNotToGoldTax') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bNotToGoldTax','T','0000000009',null,null,0,'表头|bNotToGoldTax,T|bNotToGoldTax','bNotToGoldTax',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBTrnumber') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','交易编号','T','0000000009',null,null,0,'表头|交易编号,T|cEBTrnumber','cEBTrnumber',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBBuyer') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','买家留言','T','0000000009',null,null,0,'表头|买家留言,T|cEBBuyer','cEBBuyer',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBBuyerNote') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','卖家备注','T','0000000009',null,null,0,'表头|卖家备注,T|cEBBuyerNote','cEBBuyerNote',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='ccontactname') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货联系人','T','0000000009',null,null,0,'表头|收货联系人,T|ccontactname','ccontactname',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBprovince') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货人省','T','0000000009',null,null,0,'表头|收货人省,T|cEBprovince','cEBprovince',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBcity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货人市','T','0000000009',null,null,0,'表头|收货人市,T|cEBcity','cEBcity',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cEBdistrict') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货人区','T','0000000009',null,null,0,'表头|收货人区,T|cEBdistrict','cEBdistrict',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cmobilephone') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收货联系人手机','T','0000000009',null,null,0,'表头|收货联系人手机,T|cmobilephone','cmobilephone',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cInvoiceCusName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发票抬头','T','0000000009',null,null,0,'表头|发票抬头,T|cInvoiceCusName','cInvoiceCusName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='cweighter') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','称重人','T','0000000009',null,null,0,'表头|称重人,T|cweighter','cweighter',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'T' AND fieldname='dweighttime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','称重时间','T','0000000009',null,null,0,'表头|称重时间,T|dweighttime','dweighttime',null,'1000000009',1,1)
--END
END 

GO


-- 表体
IF (1=1)   
BEGIN 


IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine28') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项28','B','0000000009',null,null,0,'表体|表体自定义项28,B|cDefine28','cDefine28',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine29') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项29','B','0000000009',null,null,0,'表体|表体自定义项29,B|cDefine29','cDefine29',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine30') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项30','B','0000000009',null,null,0,'表体|表体自定义项30,B|cDefine30','cDefine30',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine31') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项31','B','0000000009',null,null,0,'表体|表体自定义项31,B|cDefine31','cDefine31',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine32') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项32','B','0000000009',null,null,0,'表体|表体自定义项32,B|cDefine32','cDefine32',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine33') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项33','B','0000000009',null,null,0,'表体|表体自定义项33,B|cDefine33','cDefine33',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine34') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项34','B','0000000009',null,null,0,'表体|表体自定义项34,B|cDefine34','cDefine34',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine35') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项35','B','0000000009',null,null,0,'表体|表体自定义项35,B|cDefine35','cDefine35',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine36') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','表体自定义项36','B','0000000009',null,null,0,'表体|表体自定义项36,B|cDefine36','cDefine36',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree1') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项1','B','0000000009',null,null,0,'表体|自由项1,B|cFree1','cFree1',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree2') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项2','B','0000000009',null,null,0,'表体|自由项2,B|cFree2','cFree2',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree1') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项1','B','0000000009',null,null,0,'表体|自由项1,B|cFree1','cFree1',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree2') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项2','B','0000000009',null,null,0,'表体|自由项2,B|cFree2','cFree2',null,'1000000009',1,1)
END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree3') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项3','B','0000000009',null,null,0,'表体|自由项3,B|cFree3','cFree3',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree4') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项4','B','0000000009',null,null,0,'表体|自由项4,B|cFree4','cFree4',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree5') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项5','B','0000000009',null,null,0,'表体|自由项5,B|cFree5','cFree5',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree6') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项6','B','0000000009',null,null,0,'表体|自由项6,B|cFree6','cFree6',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree7') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项7','B','0000000009',null,null,0,'表体|自由项7,B|cFree7','cFree7',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree8') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项8','B','0000000009',null,null,0,'表体|自由项8,B|cFree8','cFree8',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree9') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项9','B','0000000009',null,null,0,'表体|自由项9,B|cFree9','cFree9',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cFree10') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','自由项10','B','0000000009',null,null,0,'表体|自由项10,B|cFree10','cFree10',null,'1000000009',1,1)
END

-- IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='AutoID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','自动编号','B','0000000009',null,null,0,'表体|自动编号,B|AutoID','AutoID',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='DLID') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','发货单 38','B','0000000009',null,null,1,'','DLID',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iCorID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','原发货单ID','B','0000000009',null,null,0,'表体|原发货单ID,B|iCorID','iCorID',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cWhCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','仓库编码','B','0000000009',null,null,0,'表体|仓库编码,B|mes_cWhCode','cWhCode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cInvCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货编码','B','0000000009',null,null,0,'表体|存货编码,B|cInvCode','cInvCode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iQuantity') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','数量','B','0000000009',null,null,0,'表体|数量,B|mes_iquantity','iQuantity',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','件数','B','0000000009',null,null,0,'表体|件数,B|iNum','iNum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iQuotedPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','报价','B','0000000009',null,null,0,'表体|报价,B|iQuotedPrice','iQuotedPrice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iUnitPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','无税单价','B','0000000009',null,null,0,'表体|无税单价,B|iUnitPrice','iUnitPrice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iTaxUnitPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','含税单价','B','0000000009',null,null,0,'表体|含税单价,B|iTaxUnitPrice','iTaxUnitPrice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iMoney') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','无税金额','B','0000000009',null,null,0,'表体|无税金额,B|iMoney','iMoney',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iTax') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','税额','B','0000000009',null,null,0,'表体|税额,B|iTax','iTax',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iSum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','价税合计','B','0000000009',null,null,0,'表体|价税合计,B|iSum','iSum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iDisCount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','折扣额','B','0000000009',null,null,0,'表体|折扣额,B|iDisCount','iDisCount',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNatUnitPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','本币单价','B','0000000009',null,null,0,'表体|本币单价,B|iNatUnitPrice','iNatUnitPrice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNatMoney') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','本币金额','B','0000000009',null,null,0,'表体|本币金额,B|iNatMoney','iNatMoney',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNatTax') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','本币税额','B','0000000009',null,null,0,'表体|本币税额,B|iNatTax','iNatTax',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNatSum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','本币价税合计','B','0000000009',null,null,0,'表体|本币价税合计,B|iNatSum','iNatSum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iNatDisCount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','本币折扣额','B','0000000009',null,null,0,'表体|本币折扣额,B|iNatDisCount','iNatDisCount',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iSettleNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','开票金额','B','0000000009',null,null,0,'表体|开票金额,B|iSettleNum','iSettleNum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iSettleQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','开票数量','B','0000000009',null,null,0,'表体|开票数量,B|iSettleQuantity','iSettleQuantity',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iBatch') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次','B','0000000009',null,null,0,'表体|批次,B|iBatch','iBatch',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cBatch') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批号','B','0000000009',null,null,0,'表体|批号,B|cBatch','cBatch',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bSettleAll') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','结算标志','B','0000000009',null,null,1,'False','bSettleAll',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cMemo') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','备注','B','0000000009',null,null,0,'表体|备注,B|cMemo','cMemo',null,'1000000009',1,1)
--END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iTB') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','退补标志','B','0000000009',null,null,1,'正常','iTB',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='dvDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','失效日期','B','0000000009',null,null,0,'表体|失效日期,B|dvDate','dvDate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iSOsID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','对应订单子表ID','B','0000000009',null,null,0,'表体|对应订单子表ID,B|iSOsID','iSOsID',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iDLsID') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','子表id','B','0000000009',null,null,1,'','iDLsID',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='KL') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','扣率（%）','B','0000000009',null,null,0,'表体|扣率（%）,B|KL','KL',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='KL2') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','扣率2（%）','B','0000000009',null,null,0,'表体|扣率2（%）,B|KL2','KL2',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cInvName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','存货名称','B','0000000009',null,null,0,'表体|存货名称,B|cInvName','cInvName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iTaxRate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','税率（%）','B','0000000009',null,null,0,'表体|税率（%）,B|iTaxRate','iTaxRate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine22') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项1','B','0000000009',null,null,0,'表体|表体自定义项1,B|cDefine22','cDefine22',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine23') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项2','B','0000000009',null,null,0,'表体|表体自定义项2,B|cDefine23','cDefine23',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine24') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项3','B','0000000009',null,null,0,'表体|表体自定义项3,B|cDefine24','cDefine24',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine25') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项4','B','0000000009',null,null,0,'表体|表体自定义项4,B|cDefine25','cDefine25',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine26') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项5','B','0000000009',null,null,0,'表体|表体自定义项5,B|cDefine26','cDefine26',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine27') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项6','B','0000000009',null,null,0,'表体|表体自定义项6,B|cDefine27','cDefine27',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cItemCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目编码','B','0000000009',null,null,0,'表体|项目编码,B|cItemCode','cItemCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cItem_class') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目大类编码','B','0000000009',null,null,0,'表体|项目大类编码,B|cItem_class','cItem_class',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fSaleCost') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','零售单价','B','0000000009',null,null,0,'表体|零售单价,B|fSaleCost','fSaleCost',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fSalePrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','零售金额','B','0000000009',null,null,0,'表体|零售金额,B|fSalePrice','fSalePrice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cVenAbbName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','产地','B','0000000009',null,null,0,'表体|产地,B|cVenAbbName','cVenAbbName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cItemName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目名称','B','0000000009',null,null,0,'表体|项目名称,B|cItemName','cItemName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cItem_CName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目大类名称','B','0000000009',null,null,0,'表体|项目大类名称,B|cItem_CName','cItem_CName',null,'1000000009',1,1)
--END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bIsSTQc') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','库存期初','B','0000000009',null,null,1,'False','bIsSTQc',null,'1000000009',1,1)
END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','入库单号','B','0000000009',null,null,0,'表体|入库单号,B|cCode','cCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine28') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项7','B','0000000009',null,null,0,'表体|表体自定义项7,B|cDefine28','cDefine28',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine29') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项8','B','0000000009',null,null,0,'表体|表体自定义项8,B|cDefine29','cDefine29',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine30') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项9','B','0000000009',null,null,0,'表体|表体自定义项9,B|cDefine30','cDefine30',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine31') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项10','B','0000000009',null,null,0,'表体|表体自定义项10,B|cDefine31','cDefine31',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine32') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项11','B','0000000009',null,null,0,'表体|表体自定义项11,B|cDefine32','cDefine32',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine33') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项12','B','0000000009',null,null,0,'表体|表体自定义项12,B|cDefine33','cDefine33',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine34') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项13','B','0000000009',null,null,0,'表体|表体自定义项13,B|cDefine34','cDefine34',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine35') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项14','B','0000000009',null,null,0,'表体|表体自定义项14,B|cDefine35','cDefine35',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine36') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项15','B','0000000009',null,null,0,'表体|表体自定义项15,B|cDefine36','cDefine36',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cDefine37') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项16','B','0000000009',null,null,0,'表体|表体自定义项16,B|cDefine37','cDefine37',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='dMDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产日期','B','0000000009',null,null,0,'表体|生产日期,B|dMDate','dMDate',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bGsp') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否gsp检验','B','0000000009',null,null,1,'否','bGsp',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cSoCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','订单号','B','0000000009',null,null,0,'表体|订单号,B|cSoCode','cSoCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iPPartSeqID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','选配序号','B','0000000009',null,null,0,'表体|选配序号,B|iPPartSeqID','iPPartSeqID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iPPartID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','母件物料ID','B','0000000009',null,null,0,'表体|母件物料ID,B|iPPartID','iPPartID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cContractID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','合同编码','B','0000000009',null,null,0,'表体|合同编码,B|cContractID','cContractID',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cContractTagCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','合同标的编码','B','0000000009',null,null,0,'表体|合同标的编码,B|cContractTagCode','cContractTagCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cContractRowGuid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','合同标的RowGuid','B','0000000009',null,null,0,'表体|合同标的RowGuid,B|cContractRowGuid','cContractRowGuid',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iMassDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','保质期','B','0000000009',null,null,0,'表体|保质期,B|iMassDate','iMassDate',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cMassUnit') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','保质期单位','B','0000000009',null,null,1,'0','cMassUnit',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bQANeedCheck') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否质量检验','B','0000000009',null,null,1,'否','bQANeedCheck',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bQAUrgency') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否急料','B','0000000009',null,null,1,'否','bQAUrgency',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bQAChecking') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','是否在检','B','0000000009',null,null,1,'否','bQAChecking',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bQAChecked') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','是否报检','B','0000000009',null,null,1,'否','bQAChecked',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iQAQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验合格数量','B','0000000009',null,null,1,'0.0','iQAQuantity',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iQANum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验合格件数','B','0000000009',null,null,1,'0.0','iQANum',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='editprop') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','操作标识','B','0000000009',null,null,0,'表体|操作标识,B|editprop','editprop',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='csettleall') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','关闭标识','B','0000000009',null,null,1,'未关闭','csettleall',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='batomodel') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','是否ATO件','B','0000000009',null,null,1,'否','batomodel',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='csrpolicy') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','供需政策','B','0000000009',null,null,1,'PE','csrpolicy',null,'1000000009',1,1)
END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cCusInvCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','客户存货编码','B','0000000009',null,null,0,'表体|客户存货编码,B|cCusInvCode','cCusInvCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cCusInvName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','客户存货名称','B','0000000009',null,null,0,'表体|客户存货名称,B|cCusInvName','cCusInvName',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fsumsignquantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','累计签回数量','B','0000000009',null,null,0,'表体|累计签回数量,B|fsumsignquantity','fsumsignquantity',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fsumsignnum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','累计签回件数','B','0000000009',null,null,0,'表体|累计签回件数,B|fsumsignnum','fsumsignnum',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbaccounter') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','记账人','B','0000000009',null,null,1,null,'cbaccounter',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cordercode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','订单号','B','0000000009',null,null,0,'表体|订单号,B|cordercode','cordercode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iorderrowno') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','订单行号','B','0000000009',null,null,0,'表体|订单行号,B|iorderrowno','iorderrowno',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fcusminprice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','最低售价','B','0000000009',null,null,0,'表体|最低售价,B|fcusminprice','fcusminprice',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cvmivencode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','供货商编码','B','0000000009',null,null,1,null,'cvmivencode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iexchsum') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','累计原币收款金额','B','0000000009',null,null,1,null,'iexchsum',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='imoneysum') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','累计本币收款金额','B','0000000009',null,null,1,null,'imoneysum',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='irowno') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','行号','B','0000000009',null,null,0,'表体|行号,B|irowno','irowno',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iExpiratDateCalcu') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','有效期推算方式','B','0000000009',null,null,1,0,'iExpiratDateCalcu',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='dExpirationdate') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','有效期计算项','B','0000000009',null,null,1,null,'dExpirationdate',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cExpirationdate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','有效期至','B','0000000009',null,null,0,'表体|有效期至,B|cExpirationdate','cExpirationdate',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty1') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性1','B','0000000009',null,null,1,null,'cbatchproperty1',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty2') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性2','B','0000000009',null,null,1,null,'cbatchproperty2',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty3') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性3','B','0000000009',null,null,1,null,'cbatchproperty3',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty4') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性4','B','0000000009',null,null,1,null,'cbatchproperty4',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty5') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性5','B','0000000009',null,null,1,null,'cbatchproperty5',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty6') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性6','B','0000000009',null,null,1,null,'cbatchproperty6',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty7') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性7','B','0000000009',null,null,1,null,'cbatchproperty7',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty8') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性8','B','0000000009',null,null,1,null,'cbatchproperty8',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty9') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性9','B','0000000009',null,null,1,null,'cbatchproperty9',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbatchproperty10') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','批次属性10','B','0000000009',null,null,1,null,'cbatchproperty10',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='idemandtype') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','需求跟踪方式','B','0000000009',null,null,1,null,'idemandtype',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cdemandcode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','需求跟踪号','B','0000000009',null,null,1,null,'cdemandcode',null,'1000000009',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cdemandmemo') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','需求分类说明','B','0000000009',null,null,1,null,'cdemandmemo',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cdemandid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需求跟踪id','B','0000000009',null,null,0,'表体|需求跟踪id,B|cdemandid','cdemandid',null,'1000000009',1,1)
--END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='idemandseq') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','需求跟踪行号','B','0000000009',null,null,1,null,'idemandseq',null,'1000000009',1,1)
END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cvencode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','入库单供应商编码','B','0000000009',null,null,0,'表体|入库单供应商编码,B|mes_cvencode','cvencode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cReasonCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','退货原因编码','B','0000000009',null,null,0,'表体|退货原因编码,B|cReasonCode','cReasonCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iInvSNCount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','序列号个数','B','0000000009',null,null,0,'表体|序列号个数,B|iInvSNCount','iInvSNCount',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bneedsign') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需要签回','B','0000000009',null,null,0,'表体|需要签回,B|bneedsign','bneedsign',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bsignover') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发货签回完成','B','0000000009',null,null,0,'表体|发货签回完成,B|bsignover','bsignover',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bneedloss') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需要损失处理','B','0000000009',null,null,0,'表体|需要损失处理,B|bneedloss','bneedloss',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='flossrate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发货合理损耗率（%）','B','0000000009',null,null,0,'表体|发货合理损耗率（%）,B|flossrate','flossrate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='frlossqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','合理损耗数量','B','0000000009',null,null,0,'表体|合理损耗数量,B|frlossqty','frlossqty',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fulossqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','非合理损耗数量','B','0000000009',null,null,0,'表体|非合理损耗数量,B|fulossqty','fulossqty',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='isettletype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','责任承担处理','B','0000000009',null,null,0,'表体|责任承担处理,B|isettletype','isettletype',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='crelacuscode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','责任客户编码','B','0000000009',null,null,0,'表体|责任客户编码,B|crelacuscode','crelacuscode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cInVouchType') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cInVouchType','B','0000000009',null,null,0,'表体|cInVouchType,B|cInVouchType','cInVouchType',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='dkeepdate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','记账日期','B','0000000009',null,null,0,'表体|记账日期,B|dkeepdate','dkeepdate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cSCloser') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','行关闭人','B','0000000009',null,null,0,'表体|行关闭人,B|cSCloser','cSCloser',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bsaleprice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','报价含税','B','0000000009',null,null,0,'表体|报价含税,B|bsaleprice','bsaleprice',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bgift') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','赠品','B','0000000009',null,null,0,'表体|赠品,B|bgift','bgift',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='bmpforderclosed') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','是否订单关闭','B','0000000009',null,null,0,'表体|是否订单关闭,B|bmpforderclosed','bmpforderclosed',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cbSysBarCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单据行条码','B','0000000009',null,null,0,'表体|单据行条码,B|cbSysBarCode','cbSysBarCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fxjquantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已拣货量','B','0000000009',null,null,0,'表体|已拣货量,B|fxjquantity','fxjquantity',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fxjnum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已拣货件数','B','0000000009',null,null,0,'表体|已拣货件数,B|fxjnum','fxjnum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cParentCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','父节点编码','B','0000000009',null,null,0,'表体|父节点编码,B|cParentCode','cParentCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='cChildCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','子节点编码','B','0000000009',null,null,0,'表体|子节点编码,B|cChildCode','cChildCode',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fchildqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','使用数量','B','0000000009',null,null,0,'表体|使用数量,B|fchildqty','fchildqty',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fchildrate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','权重比例','B','0000000009',null,null,0,'表体|权重比例,B|fchildrate','fchildrate',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='iCalcType') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','发货模式','B','0000000009',null,null,0,'表体|发货模式,B|iCalcType','iCalcType',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fappretwkpqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','未开票退货申请数量','B','0000000009',null,null,0,'表体|未开票退货申请数量,B|fappretwkpqty','fappretwkpqty',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fappretwkpsum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','未开票退货申请金额','B','0000000009',null,null,0,'表体|未开票退货申请金额,B|fappretwkpsum','fappretwkpsum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fappretykpqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已开票退货申请数量','B','0000000009',null,null,0,'表体|已开票退货申请数量,B|fappretykpqty','fappretykpqty',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='fappretykpsum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已开票退货申请金额','B','0000000009',null,null,0,'表体|已开票退货申请金额,B|fappretykpsum','fappretykpsum',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='irtnappid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','退货申请单id','B','0000000009',null,null,0,'表体|退货申请单id,B|irtnappid','irtnappid',null,'1000000009',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000009' AND cardsection = 'B' AND fieldname='crtnappcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','退货申请单号','B','0000000009',null,null,0,'表体|退货申请单号,B|crtnappcode','crtnappcode',null,'1000000009',1,1)
--END
 
END

GO
 

declare @fieldcmpId nvarchar(20)
declare @fieldcmpCode nvarchar(20)
declare @autoid bigint
declare @guid nvarchar(120)
declare @autoidFixvalue bigint
declare @fieldname nvarchar(20)
set @autoid=0 
set @fieldcmpCode = '0000000009'
set @fieldcmpId = '1000000009'
IF not exists (select 1 from MES_CQ_FIELDCMPS where fieldname='cUnitID' AND cardsection = 'B'  and id=@fieldcmpId )  
BEGIN 
	SELECT @autoid=isnull(max(autoid),0)+1 from MES_CQ_FIELDCMPS
	SELECT @guid = NEWID()
	INSERT INTO MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0',@autoid,'销售单位编码','B',@fieldcmpCode,'010',null,2,'根据存货获取计量单位信息(来源单据.表体.存货编码).主计量单位编码','cUnitID',@guid,@fieldcmpId,1,1)
	DELETE FROM MES_CQ_FIXVALUE where did = @autoid
	SELECT @autoidFixvalue =isnull(max(Convert(int,autoid)),0)+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,'B','S','010','cinvcode',1,'2','来源单据.表体.存货编码',@autoid,@guid)
	SELECT @autoidFixvalue =max(isnull(Convert(int,autoid),0))+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,null,null,'010','cComUnitCode',7,'3','默认计量单位编码',@autoid,@guid) 
END 

set @fieldname = 'cgroupcode'
IF not exists (select 1 from MES_CQ_FIELDCMPS where fieldname= @fieldname AND cardsection = 'B'  and id=@fieldcmpId )  
BEGIN 
	SELECT @autoid=isnull(max(autoid),0)+1 from MES_CQ_FIELDCMPS
	SELECT @guid = NEWID()
	INSERT INTO MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0',@autoid,'销售单位编码','B',@fieldcmpCode,'010',null,2,'根据存货获取计量单位信息(来源单据.表体.存货编码).主计量单位编码',@fieldname,@guid,@fieldcmpId,1,1)
	DELETE FROM MES_CQ_FIXVALUE where did = @autoid
	SELECT @autoidFixvalue =isnull(max(Convert(int,autoid)),0)+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,'B','S','010','cinvcode',1,'2','来源单据.表体.存货编码',@autoid,@guid)
	SELECT @autoidFixvalue =max(isnull(Convert(int,autoid),0))+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,null,null,'010','cgroupcode',7,'3','默认计量单位编码',@autoid,@guid) 
END 

set @fieldname = 'cinva_unit'
IF not exists (select 1 from MES_CQ_FIELDCMPS where fieldname= @fieldname AND cardsection = 'B'  and id=@fieldcmpId )  
BEGIN 
	SELECT @autoid=isnull(max(autoid),0)+1 from MES_CQ_FIELDCMPS
	SELECT @guid = NEWID()
	INSERT INTO MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0',@autoid,'销售单位编码','B',@fieldcmpCode,'010',null,2,'根据存货获取计量单位信息(来源单据.表体.存货编码).主计量单位编码',@fieldname,@guid,@fieldcmpId,1,1)
	DELETE FROM MES_CQ_FIXVALUE where did = @autoid
	SELECT @autoidFixvalue =isnull(max(Convert(int,autoid)),0)+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,'B','S','010','cinvcode',1,'2','来源单据.表体.存货编码',@autoid,@guid)
	SELECT @autoidFixvalue =max(isnull(Convert(int,autoid),0))+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,null,null,'010','csacomunitcode',7,'3','默认计量单位编码',@autoid,@guid) 
END 


set @fieldname = 'igrouptype'
IF not exists (select 1 from MES_CQ_FIELDCMPS where fieldname= @fieldname AND cardsection = 'B'  and id=@fieldcmpId )  
BEGIN 
	SELECT @autoid=isnull(max(autoid),0)+1 from MES_CQ_FIELDCMPS
	SELECT @guid = NEWID()
	INSERT INTO MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
	('0',@autoid,'销售单位编码','B',@fieldcmpCode,'010',null,2,'根据存货获取计量单位信息(来源单据.表体.存货编码).主计量单位编码',@fieldname,@guid,@fieldcmpId,1,1)
	DELETE FROM MES_CQ_FIXVALUE where did = @autoid
	SELECT @autoidFixvalue =isnull(max(Convert(int,autoid)),0)+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,'B','S','010','cinvcode',1,'2','来源单据.表体.存货编码',@autoid,@guid)
	SELECT @autoidFixvalue =max(isnull(Convert(int,autoid),0))+1 from MES_CQ_FIXVALUE  
	INSERT INTO MES_CQ_FIXVALUE ( accid,autoid,cardsection,cfromortobill,cfunid,cfunparareturn,cno,ctype,cvalue,did,guid ) values 
	  ('001',@autoidFixvalue,null,null,'010','igrouptype',7,'3','默认计量单位编码',@autoid,@guid) 
END 


GO 
