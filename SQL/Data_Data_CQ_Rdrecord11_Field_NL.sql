
 /*======================= table data: MES_CQ_FIELDCMP ========================*/
print 'dbo.MES_CQ_FIELDCMP data...' 
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMP WHERE TaskType = '0' AND cfrombillcardnum='MO21' AND ctobillcardnum='0412' )  
BEGIN
 INSERT INTO MES_CQ_FIELDCMP (TaskType, ccode,cfrombillcardnum,cname,ctobillcardnum,id,iprintcount,vt_id ) values 
  ('0','0000000005','MO21','生产订单生成材料出库单','0412','1000000005',null,'17')
END 
GO
 
 /*======================= table data: MES_CQ_FIELDCMPS ========================*/
print 'dbo.MES_CQ_FIELDCMPS data...' 
 -- DELETE FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005'
        --///来源单据
        --public const int Fieldcmps_Ctype_Source = 0;
        --///固定值
        --public const int Fieldcmps_Ctype_Const = 1;
        --///函数
        --public const int Fieldcmps_Ctype_Funtion = 2;
        --///分账套
        --public const int Fieldcmps_Ctype_MutiValue = 3;
   

-- 生产订单生成材料出库单
IF (1=1)  
BEGIN
  
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND fieldname='id' )  
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType,autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable ) values 
  (0,'1000000084','ID','T','0000000005',null,null,1,null,'id',null,'1000000005','0','0')
END 
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cSource') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','单据来源','T','0000000005',null,null,1,'生产订单','cSource',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cWhCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','仓库编码','T','0000000005',null,null,0,'表头|仓库编码,T|mes_cWhCode','cWhCode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ccode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','出库单号','T','0000000005',null,null,1,'001','cCode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ddate') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','入库日期','T','0000000005',null,null,0,'表头|入库日期,T|dDate','dDate',null,'1000000005',1,1)
END

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='csysbarcode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','单据条码','T','0000000005',null,null,1,null,'csysbarcode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cdepcode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','部门编码','T','0000000005',null,null,0,'表头|部门编码,T|mes_cdepcode','cdepcode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cBusType') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','业务类型','T','0000000005',null,null,1,'领料','cBusType',null,'1000000005',1,1)
END 
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cvencode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','供应商编码','T','0000000005',null,null,0,'表头|供应商编码,T|mes_cvencode','cvencode',null,'1000000005',1,1)
END


--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='id') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','与主表关联项','T','0000000005',null,null,0,'表头|与主表关联项,T|id','ID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','自动编号','T','0000000005',null,null,0,'表头|自动编号,T|ID','ID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bRdFlag') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','收发标志','T','0000000005',null,null,0,'表头|收发标志,T|bRdFlag','bRdFlag',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cVouchType') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单据类型','T','0000000005',null,null,0,'表头|单据类型,T|cVouchType','cVouchType',null,'1000000005',1,1)
--END 
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cBusCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cBusCode','T','0000000005',null,null,0,'表头|cBusCode,T|cBusCode','cBusCode',null,'1000000005',1,1)
--END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cRdCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','入库类别编码','T','0000000005',null,null,0,'表头|入库类别编码,T|cRdCode','cRdCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDepCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','部门编码','T','0000000005',null,null,0,'表头|部门编码,T|cDepCode','cDepCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cPersonCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','业务员编码','T','0000000005',null,null,0,'表头|业务员编码,T|cPersonCode','cPersonCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cPTCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cPTCode','T','0000000005',null,null,0,'表头|cPTCode,T|cPTCode','cPTCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cSTCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cSTCode','T','0000000005',null,null,0,'表头|cSTCode,T|cSTCode','cSTCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cCusCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cCusCode','T','0000000005',null,null,0,'表头|cCusCode,T|cCusCode','cCusCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cVenCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cVenCode','T','0000000005',null,null,0,'表头|cVenCode,T|cVenCode','cVenCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cOrderCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cOrderCode','T','0000000005',null,null,0,'表头|cOrderCode,T|cOrderCode','cOrderCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cARVCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cARVCode','T','0000000005',null,null,0,'表头|cARVCode,T|cARVCode','cARVCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cBillCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cBillCode','T','0000000005',null,null,0,'表头|cBillCode,T|cBillCode','cBillCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDLCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cDLCode','T','0000000005',null,null,0,'表头|cDLCode,T|cDLCode','cDLCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cProBatch') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产批号','T','0000000005',null,null,0,'表头|生产批号,T|cProBatch','cProBatch',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cHandler') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核人','T','0000000005',null,null,0,'表头|审核人,T|cHandler','cHandler',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cMemo') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','备注','T','0000000005',null,null,0,'表头|备注,T|cMemo','cMemo',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bTransFlag') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bTransFlag','T','0000000005',null,null,0,'表头|bTransFlag,T|bTransFlag','bTransFlag',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cAccounter') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','记账人','T','0000000005',null,null,0,'表头|记账人,T|cAccounter','cAccounter',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cMaker') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','制单人','T','0000000005',null,null,0,'表头|制单人,T|cMaker','cMaker',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine1') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项1','T','0000000005',null,null,0,'表头|表头自定义项1,T|cDefine1','cDefine1',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine2') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项2','T','0000000005',null,null,0,'表头|表头自定义项2,T|cDefine2','cDefine2',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine3') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项3','T','0000000005',null,null,0,'表头|表头自定义项3,T|cDefine3','cDefine3',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine4') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项4','T','0000000005',null,null,0,'表头|表头自定义项4,T|cDefine4','cDefine4',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine5') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项5','T','0000000005',null,null,0,'表头|表头自定义项5,T|cDefine5','cDefine5',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine6') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项6','T','0000000005',null,null,0,'表头|表头自定义项6,T|cDefine6','cDefine6',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine7') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项7','T','0000000005',null,null,0,'表头|表头自定义项7,T|cDefine7','cDefine7',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine8') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项8','T','0000000005',null,null,0,'表头|表头自定义项8,T|cDefine8','cDefine8',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine9') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项9','T','0000000005',null,null,0,'表头|表头自定义项9,T|cDefine9','cDefine9',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cDefine10') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表头自定义项10','T','0000000005',null,null,0,'表头|表头自定义项10,T|cDefine10','cDefine10',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dKeepDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','dKeepDate','T','0000000005',null,null,0,'表头|dKeepDate,T|dKeepDate','dKeepDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dVeriDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核日期','T','0000000005',null,null,0,'表头|审核日期,T|dVeriDate','dVeriDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bpufirst') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bpufirst','T','0000000005',null,null,0,'表头|bpufirst,T|bpufirst','bpufirst',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='biafirst') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','biafirst','T','0000000005',null,null,0,'表头|biafirst,T|biafirst','biafirst',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iMQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iMQuantity','T','0000000005',null,null,0,'表头|iMQuantity,T|iMQuantity','iMQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dARVDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','dARVDate','T','0000000005',null,null,0,'表头|dARVDate,T|dARVDate','dARVDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cChkCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cChkCode','T','0000000005',null,null,0,'表头|cChkCode,T|cChkCode','cChkCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dChkDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验日期','T','0000000005',null,null,0,'表头|检验日期,T|dChkDate','dChkDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cChkPerson') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验员','T','0000000005',null,null,0,'表头|检验员,T|cChkPerson','cChkPerson',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='VT_ID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','模版号','T','0000000005',null,null,0,'表头|模版号,T|VT_ID','VT_ID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bIsSTQc') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bIsSTQc','T','0000000005',null,null,0,'表头|bIsSTQc,T|bIsSTQc','bIsSTQc',null,'1000000005',1,1)
--END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cMPoCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产订单号','T','0000000005',null,null,0,'表头|生产订单号,T|cMPoCode','cMPoCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='gspcheck') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','gspcheck','T','0000000005',null,null,0,'表头|gspcheck,T|gspcheck','gspcheck',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ipurorderid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','ipurorderid','T','0000000005',null,null,0,'表头|ipurorderid,T|ipurorderid','ipurorderid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iproorderid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产订单ID','T','0000000005',null,null,0,'表头|生产订单ID,T|iproorderid','iproorderid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ufts') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','时间戳','T','0000000005',null,null,0,'表头|时间戳,T|ufts','ufts',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iExchRate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iExchRate','T','0000000005',null,null,0,'表头|iExchRate,T|iExchRate','iExchRate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cExch_Name') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cExch_Name','T','0000000005',null,null,0,'表头|cExch_Name,T|cExch_Name','cExch_Name',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bOMFirst') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bOMFirst','T','0000000005',null,null,0,'表头|bOMFirst,T|bOMFirst','bOMFirst',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bFromPreYear') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bFromPreYear','T','0000000005',null,null,0,'表头|bFromPreYear,T|bFromPreYear','bFromPreYear',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bIsLsQuery') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bIsLsQuery','T','0000000005',null,null,0,'表头|bIsLsQuery,T|bIsLsQuery','bIsLsQuery',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bIsComplement') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bIsComplement','T','0000000005',null,null,0,'表头|bIsComplement,T|bIsComplement','bIsComplement',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iDiscountTaxType') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iDiscountTaxType','T','0000000005',null,null,0,'表头|iDiscountTaxType,T|iDiscountTaxType','iDiscountTaxType',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='ireturncount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','ireturncount','T','0000000005',null,null,0,'表头|ireturncount,T|ireturncount','ireturncount',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iverifystate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iverifystate','T','0000000005',null,null,0,'表头|iverifystate,T|iverifystate','iverifystate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iswfcontrolled') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iswfcontrolled','T','0000000005',null,null,0,'表头|iswfcontrolled,T|iswfcontrolled','iswfcontrolled',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cModifyPerson') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改人','T','0000000005',null,null,0,'表头|修改人,T|cModifyPerson','cModifyPerson',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dModifyDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改日期','T','0000000005',null,null,0,'表头|修改日期,T|dModifyDate','dModifyDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dnmaketime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','制单时间','T','0000000005',null,null,0,'表头|制单时间,T|dnmaketime','dnmaketime',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dnmodifytime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','修改时间','T','0000000005',null,null,0,'表头|修改时间,T|dnmodifytime','dnmodifytime',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='dnverifytime') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','审核时间','T','0000000005',null,null,0,'表头|审核时间,T|dnverifytime','dnverifytime',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='bredvouch') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bredvouch','T','0000000005',null,null,0,'表头|bredvouch,T|bredvouch','bredvouch',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iFlowId') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iFlowId','T','0000000005',null,null,0,'表头|iFlowId,T|iFlowId','iFlowId',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cPZID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cPZID','T','0000000005',null,null,0,'表头|cPZID,T|cPZID','cPZID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cSourceLs') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cSourceLs','T','0000000005',null,null,0,'表头|cSourceLs,T|cSourceLs','cSourceLs',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cSourceCodeLs') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cSourceCodeLs','T','0000000005',null,null,0,'表头|cSourceCodeLs,T|cSourceCodeLs','cSourceCodeLs',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='iPrintCount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iPrintCount','T','0000000005',null,null,0,'表头|iPrintCount,T|iPrintCount','iPrintCount',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'T' AND fieldname='cCurrentAuditor') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cCurrentAuditor','T','0000000005',null,null,0,'表头|cCurrentAuditor,T|cCurrentAuditor','cCurrentAuditor',null,'1000000005',1,1)
--END
--GO



 
END 
GO
 
IF (1=1) 
BEGIN


IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cmocode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','生产订单号','B','0000000005',null,null,0,'表体|生产订单号,B|mes_mocode','cmocode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iopseq') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','工序行号','B','0000000005',null,null,0,'表体|工序行号,B|opseq','iopseq',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='impoids') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','子件用料表id','B','0000000005',null,null,0,'表体|子件用料表id,B|AllocateId','impoids',null,'1000000005',1,1)
END 
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bLPUseFree') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bLPUseFree','B','0000000005',null,null,1,'0','bLPUseFree',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iOriTrackID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iOriTrackID','B','0000000005',null,null,1,'0','iOriTrackID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bCosting') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bCosting','B','0000000005',null,null,1,'1','bCosting',null,'1000000005',1,1)
--END 

IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='invcode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','产品编码','B','0000000005',null,null,0,'表体|产品编码,B|mes_cPInvCode','invcode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cInvCode') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','材料编码','B','0000000005',null,null,0,'表体|材料编码,B|mes_cInvCode','cInvCode',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iQuantity') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','数量','B','0000000005',null,null,0,'表体|数量,B|mes_iQuantity','iQuantity',null,'1000000005',1,1)
END  
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree1') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项1','B','0000000005',null,null,0,'表体|存货自由项1,B|Free1','cFree1',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree2') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项2','B','0000000005',null,null,0,'表体|存货自由项2,B|Free2','cFree2',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree3') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项3','B','0000000005',null,null,0,'表体|存货自由项3,B|Free3','cFree3',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree4') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项4','B','0000000005',null,null,0,'表体|存货自由项4,B|Free4','cFree4',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree5') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项5','B','0000000005',null,null,0,'表体|存货自由项5,B|Free5','cFree5',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree6') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项6','B','0000000005',null,null,0,'表体|存货自由项6,B|Free6','cFree6',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree7') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项7','B','0000000005',null,null,0,'表体|存货自由项7,B|Free7','cFree7',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree8') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项8','B','0000000005',null,null,0,'表体|存货自由项8,B|Free8','cFree8',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree9') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项9','B','0000000005',null,null,0,'表体|存货自由项9,B|Free9','cFree9',null,'1000000005',1,1)
END
IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cFree10') 
BEGIN
insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
('0','1','存货自由项10','B','0000000005',null,null,0,'表体|存货自由项10,B|Free10','cFree10',null,'1000000005',1,1)
END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='AutoID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','子表ID号','B','0000000005',null,null,0,'表体|子表ID号,B|AutoID','AutoID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='ID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','与主表关联项','B','0000000005',null,null,0,'表体|与主表关联项,B|ID','ID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='ID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','自动编号','B','0000000005',null,null,0,'表体|自动编号,B|ID','ID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','件数','B','0000000005',null,null,0,'表体|件数,B|iNum','iNum',null,'1000000005',1,1)
--END

--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iUnitCost') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单价','B','0000000005',null,null,0,'表体|单价,B|iUnitCost','iUnitCost',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','金额','B','0000000005',null,null,0,'表体|金额,B|iPrice','iPrice',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iAPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iAPrice','B','0000000005',null,null,0,'表体|iAPrice,B|iAPrice','iAPrice',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iPUnitCost') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','计划单价','B','0000000005',null,null,0,'表体|计划单价,B|iPUnitCost','iPUnitCost',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iPPrice') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','计划金额','B','0000000005',null,null,0,'表体|计划金额,B|iPPrice','iPPrice',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatch') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批号','B','0000000005',null,null,0,'表体|批号,B|cBatch','cBatch',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cVouchCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','对应入库单id','B','0000000005',null,null,0,'表体|对应入库单id,B|cVouchCode','cVouchCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cInVouchCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','对应入库单号','B','0000000005',null,null,0,'表体|对应入库单号,B|cInVouchCode','cInVouchCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cinvouchtype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','对应入库单类型','B','0000000005',null,null,0,'表体|对应入库单类型,B|cinvouchtype','cinvouchtype',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iSOutQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','累计出库数量','B','0000000005',null,null,0,'表体|累计出库数量,B|iSOutQuantity','iSOutQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iSOutNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','累计出库件数','B','0000000005',null,null,0,'表体|累计出库件数,B|iSOutNum','iSOutNum',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iFlag') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iFlag','B','0000000005',null,null,0,'表体|iFlag,B|iFlag','iFlag',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iFNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','实际件数','B','0000000005',null,null,0,'表体|实际件数,B|iFNum','iFNum',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iFQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','实际数量','B','0000000005',null,null,0,'表体|实际数量,B|iFQuantity','iFQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='dVDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','失效日期','B','0000000005',null,null,0,'表体|失效日期,B|dVDate','dVDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cPosition') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','货位编码','B','0000000005',null,null,0,'表体|货位编码,B|cPosition','cPosition',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine22') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项1','B','0000000005',null,null,0,'表体|表体自定义项1,B|cDefine22','cDefine22',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine23') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项2','B','0000000005',null,null,0,'表体|表体自定义项2,B|cDefine23','cDefine23',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine24') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项3','B','0000000005',null,null,0,'表体|表体自定义项3,B|cDefine24','cDefine24',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine25') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项4','B','0000000005',null,null,0,'表体|表体自定义项4,B|cDefine25','cDefine25',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine26') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项5','B','0000000005',null,null,0,'表体|表体自定义项5,B|cDefine26','cDefine26',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine27') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项6','B','0000000005',null,null,0,'表体|表体自定义项6,B|cDefine27','cDefine27',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cItem_class') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目大类编码','B','0000000005',null,null,0,'表体|项目大类编码,B|cItem_class','cItem_class',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cItemCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目编码','B','0000000005',null,null,0,'表体|项目编码,B|cItemCode','cItemCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目','B','0000000005',null,null,0,'表体|项目,B|cName','cName',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cItemCName') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','项目大类名称','B','0000000005',null,null,0,'表体|项目大类名称,B|cItemCName','cItemCName',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBarCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','条形码','B','0000000005',null,null,0,'表体|条形码,B|cBarCode','cBarCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iNQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','应收数量','B','0000000005',null,null,0,'表体|应收数量,B|iNQuantity','iNQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iNNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','应收件数','B','0000000005',null,null,0,'表体|应收件数,B|iNNum','iNNum',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cAssUnit') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','库存单位码','B','0000000005',null,null,0,'表体|库存单位码,B|cAssUnit','cAssUnit',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='dMadeDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产日期','B','0000000005',null,null,0,'表体|生产日期,B|dMadeDate','dMadeDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iMassDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','保质期','B','0000000005',null,null,0,'表体|保质期,B|iMassDate','iMassDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine28') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项7','B','0000000005',null,null,0,'表体|表体自定义项7,B|cDefine28','cDefine28',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine29') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项8','B','0000000005',null,null,0,'表体|表体自定义项8,B|cDefine29','cDefine29',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine30') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项9','B','0000000005',null,null,0,'表体|表体自定义项9,B|cDefine30','cDefine30',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine31') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项10','B','0000000005',null,null,0,'表体|表体自定义项10,B|cDefine31','cDefine31',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine32') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项11','B','0000000005',null,null,0,'表体|表体自定义项11,B|cDefine32','cDefine32',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine33') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项12','B','0000000005',null,null,0,'表体|表体自定义项12,B|cDefine33','cDefine33',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine34') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项13','B','0000000005',null,null,0,'表体|表体自定义项13,B|cDefine34','cDefine34',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine35') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项14','B','0000000005',null,null,0,'表体|表体自定义项14,B|cDefine35','cDefine35',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine36') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项15','B','0000000005',null,null,0,'表体|表体自定义项15,B|cDefine36','cDefine36',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cDefine37') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','表体自定义项16','B','0000000005',null,null,0,'表体|表体自定义项16,B|cDefine37','cDefine37',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iMPoIds') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产订单子表ID','B','0000000005',null,null,0,'表体|生产订单子表ID,B|iMPoIds','iMPoIds',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iCheckIds') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验单子表ID','B','0000000005',null,null,0,'表体|检验单子表ID,B|iCheckIds','iCheckIds',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBVencode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','供应商编码','B','0000000005',null,null,0,'表体|供应商编码,B|cBVencode','cBVencode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bGsp') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bGsp','B','0000000005',null,null,0,'表体|bGsp,B|bGsp','bGsp',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cGspState') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cGspState','B','0000000005',null,null,0,'表体|cGspState,B|cGspState','cGspState',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cCheckCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验单号','B','0000000005',null,null,0,'表体|检验单号,B|cCheckCode','cCheckCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iCheckIdBaks') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验单子表id','B','0000000005',null,null,0,'表体|检验单子表id,B|iCheckIdBaks','iCheckIdBaks',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cRejectCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','不良品处理单号','B','0000000005',null,null,0,'表体|不良品处理单号,B|cRejectCode','cRejectCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iRejectIds') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','不良品处理单id','B','0000000005',null,null,0,'表体|不良品处理单id,B|iRejectIds','iRejectIds',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cCheckPersonCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验员编码','B','0000000005',null,null,0,'表体|检验员编码,B|cCheckPersonCode','cCheckPersonCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='dCheckDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','检验日期','B','0000000005',null,null,0,'表体|检验日期,B|dCheckDate','dCheckDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cMassUnit') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','保质期单位','B','0000000005',null,null,0,'表体|保质期单位,B|cMassUnit','cMassUnit',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cMoLotCode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产批号','B','0000000005',null,null,0,'表体|生产批号,B|cMoLotCode','cMoLotCode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bChecked') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bChecked','B','0000000005',null,null,0,'表体|bChecked,B|bChecked','bChecked',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bRelated') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','是否联副产品','B','0000000005',null,null,0,'表体|是否联副产品,B|bRelated','bRelated',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cmworkcentercode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','工作中心编码','B','0000000005',null,null,0,'表体|工作中心编码,B|cmworkcentercode','cmworkcentercode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bLPUseFree') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bLPUseFree','B','0000000005',null,null,0,'表体|bLPUseFree,B|bLPUseFree','bLPUseFree',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iRSRowNO') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iRSRowNO','B','0000000005',null,null,0,'表体|iRSRowNO,B|iRSRowNO','iRSRowNO',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iOriTrackID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iOriTrackID','B','0000000005',null,null,0,'表体|iOriTrackID,B|iOriTrackID','iOriTrackID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='coritracktype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','coritracktype','B','0000000005',null,null,0,'表体|coritracktype,B|coritracktype','coritracktype',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cbaccounter') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','记账人','B','0000000005',null,null,0,'表体|记账人,B|cbaccounter','cbaccounter',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='dbKeepDate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','dbKeepDate','B','0000000005',null,null,0,'表体|dbKeepDate,B|dbKeepDate','dbKeepDate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bCosting') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','是否核算','B','0000000005',null,null,0,'表体|是否核算,B|bCosting','bCosting',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bVMIUsed') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','代管消耗标识','B','0000000005',null,null,0,'表体|代管消耗标识,B|bVMIUsed','bVMIUsed',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iVMISettleQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','代管挂账确认单数量','B','0000000005',null,null,0,'表体|代管挂账确认单数量,B|iVMISettleQuantity','iVMISettleQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iVMISettleNum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','代管挂账确认单件数','B','0000000005',null,null,0,'表体|代管挂账确认单件数,B|iVMISettleNum','iVMISettleNum',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cvmivencode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','代管商代码','B','0000000005',null,null,0,'表体|代管商代码,B|cvmivencode','cvmivencode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iInvSNCount') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已指定序列号量','B','0000000005',null,null,0,'表体|已指定序列号量,B|iInvSNCount','iInvSNCount',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cwhpersoncode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cwhpersoncode','B','0000000005',null,null,0,'表体|cwhpersoncode,B|cwhpersoncode','cwhpersoncode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cwhpersonname') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cwhpersonname','B','0000000005',null,null,0,'表体|cwhpersonname,B|cwhpersonname','cwhpersonname',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cserviceoid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cserviceoid','B','0000000005',null,null,0,'表体|cserviceoid,B|cserviceoid','cserviceoid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cbserviceoid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','cbserviceoid','B','0000000005',null,null,0,'表体|cbserviceoid,B|cbserviceoid','cbserviceoid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iinvexchrate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','换算率','B','0000000005',null,null,0,'表体|换算率,B|iinvexchrate','iinvexchrate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='corufts') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','对应单据时间戳','B','0000000005',null,null,0,'表体|对应单据时间戳,B|corufts','corufts',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cmocode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产订单号','B','0000000005',null,null,0,'表体|生产订单号,B|cmocode','cmocode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='imoseq') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','生产订单行号','B','0000000005',null,null,0,'表体|生产订单行号,B|imoseq','imoseq',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iopseq') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','工序行号','B','0000000005',null,null,0,'表体|工序行号,B|iopseq','iopseq',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='copdesc') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','工序说明','B','0000000005',null,null,0,'表体|工序说明,B|copdesc','copdesc',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='strContractGUID') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','strContractGUID','B','0000000005',null,null,0,'表体|strContractGUID,B|strContractGUID','strContractGUID',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iExpiratDateCalcu') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','有效期推算方式','B','0000000005',null,null,0,'表体|有效期推算方式,B|iExpiratDateCalcu','iExpiratDateCalcu',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cExpirationdate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','有效期至','B','0000000005',null,null,0,'表体|有效期至,B|cExpirationdate','cExpirationdate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='dExpirationdate') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','有效期计算项','B','0000000005',null,null,0,'表体|有效期计算项,B|dExpirationdate','dExpirationdate',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cciqbookcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','手册号','B','0000000005',null,null,0,'表体|手册号,B|cciqbookcode','cciqbookcode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iBondedSumQty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','累计保税处理抽取数量','B','0000000005',null,null,0,'表体|累计保税处理抽取数量,B|iBondedSumQty','iBondedSumQty',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='productinids') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','productinids','B','0000000005',null,null,0,'表体|productinids,B|productinids','productinids',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iorderdid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','来源订单子表ID','B','0000000005',null,null,0,'表体|来源订单子表ID,B|iorderdid','iorderdid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iordertype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','来源订单类型','B','0000000005',null,null,0,'表体|来源订单类型,B|iordertype','iordertype',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iordercode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','来源订单号','B','0000000005',null,null,0,'表体|来源订单号,B|iordercode','iordercode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iorderseq') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','来源订单行号','B','0000000005',null,null,0,'表体|来源订单行号,B|iorderseq','iorderseq',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='isodid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','销售订单子表ID','B','0000000005',null,null,0,'表体|销售订单子表ID,B|isodid','isodid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='isotype') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需求跟踪方式','B','0000000005',null,null,0,'表体|需求跟踪方式,B|isotype','isotype',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='csocode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需求跟踪号','B','0000000005',null,null,0,'表体|需求跟踪号,B|csocode','csocode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='isoseq') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','需求跟踪行号','B','0000000005',null,null,0,'表体|需求跟踪行号,B|isoseq','isoseq',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty1') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性1','B','0000000005',null,null,0,'表体|批次属性1,B|cBatchProperty1','cBatchProperty1',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty2') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性2','B','0000000005',null,null,0,'表体|批次属性2,B|cBatchProperty2','cBatchProperty2',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty3') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性3','B','0000000005',null,null,0,'表体|批次属性3,B|cBatchProperty3','cBatchProperty3',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty4') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性4','B','0000000005',null,null,0,'表体|批次属性4,B|cBatchProperty4','cBatchProperty4',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty5') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性5','B','0000000005',null,null,0,'表体|批次属性5,B|cBatchProperty5','cBatchProperty5',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty6') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性6','B','0000000005',null,null,0,'表体|批次属性6,B|cBatchProperty6','cBatchProperty6',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty7') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性7','B','0000000005',null,null,0,'表体|批次属性7,B|cBatchProperty7','cBatchProperty7',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty8') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性8','B','0000000005',null,null,0,'表体|批次属性8,B|cBatchProperty8','cBatchProperty8',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty9') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性9','B','0000000005',null,null,0,'表体|批次属性9,B|cBatchProperty9','cBatchProperty9',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cBatchProperty10') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','批次属性10','B','0000000005',null,null,0,'表体|批次属性10,B|cBatchProperty10','cBatchProperty10',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cbMemo') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','备注','B','0000000005',null,null,0,'表体|备注,B|cbMemo','cbMemo',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='irowno') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','行号','B','0000000005',null,null,0,'表体|行号,B|irowno','irowno',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='strowguid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','rowguid','B','0000000005',null,null,0,'表体|rowguid,B|strowguid','strowguid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cservicecode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','服务单号','B','0000000005',null,null,0,'表体|服务单号,B|cservicecode','cservicecode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='rowufts') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','rowufts','B','0000000005',null,null,0,'表体|rowufts,B|rowufts','rowufts',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='ipreuseqty') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','ipreuseqty','B','0000000005',null,null,0,'表体|ipreuseqty,B|ipreuseqty','ipreuseqty',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='ipreuseinum') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','ipreuseinum','B','0000000005',null,null,0,'表体|ipreuseinum,B|ipreuseinum','ipreuseinum',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='OutCopiedQuantity') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已复制数量','B','0000000005',null,null,0,'表体|已复制数量,B|OutCopiedQuantity','OutCopiedQuantity',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cbsysbarcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','单据行条码','B','0000000005',null,null,0,'表体|单据行条码,B|cbsysbarcode','cbsysbarcode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='cplanlotcode') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','计划批号','B','0000000005',null,null,0,'表体|计划批号,B|cplanlotcode','cplanlotcode',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='bmergecheck') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','bmergecheck','B','0000000005',null,null,0,'表体|bmergecheck,B|bmergecheck','bmergecheck',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='imergecheckautoid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','imergecheckautoid','B','0000000005',null,null,0,'表体|imergecheckautoid,B|imergecheckautoid','imergecheckautoid',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iposflag') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','已分配货位','B','0000000005',null,null,0,'表体|已分配货位,B|iposflag','iposflag',null,'1000000005',1,1)
--END
--IF NOT EXISTS (SELECT 1 FROM MES_CQ_FIELDCMPS WHERE TaskType = '0' AND id='1000000005' AND cardsection = 'B' AND fieldname='iorderdetailid') 
--BEGIN
--insert into MES_CQ_FIELDCMPS ( TaskType, autoid,carditemname,cardsection,ccode,cfunid,cremark,ctype,cvalue,fieldname,guid,id,isnull,isvisable  ) values 
--('0','1','iorderdetailid','B','0000000005',null,null,0,'表体|iorderdetailid,B|iorderdetailid','iorderdetailid',null,'1000000005',1,1)
--END

END
GO