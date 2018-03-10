--销售订单主表 FOR CQ  DELETE  MES_FIELDCMP where  ctable= 'MES_CQ_SO_SOMain'
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'id',  '日志主键', 32,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cSoCode' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cSoCode',  '订单号', 30,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cSoCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cCusCode' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cCusCode',  '客户代码', 20,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cCusCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cCusName' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cCusName',  '客户名称', 98,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cCusName',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cBusTypeID' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cBusTypeID',  '业务类型ID', 15,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cBusType',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cBusType' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cBusType',  '业务类型名称', 8,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cBusType',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cStCode' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cStCode',  '销售类型ID', 2,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cStCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cStName' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cStName',  '销售类型名称', 20,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cStName',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepCode',  '销售部门ID', 12,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cDepCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepName' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepName',  '销售部门名称', 255,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cDepName',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPersonCode' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cPersonCode',  '业务员代码', 20,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cPersonCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPersonName' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cPersonName',  '业务员名称', 40,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '871',  'cPersonName',  1,  '业务类')
--if not exists(select * from MES_FIELDCMP where cfield= 'Flag' and ctable= 'MES_CQ_SO_SOMain')
--  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
--  ('0',  0, null,  'Flag',  '操作标识',  2,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '861',  '1',  3,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_SO_SOMain')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SOMain',  '销售订单主表',  '861',  '6',  3,  '业务类') 
   
    
GO
    
--销售订单子表 FOR CQ  DELETE  MES_FIELDCMP where  ctable= 'MES_CQ_SO_SODetails'
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '861',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'did',  '日志子表主键', 32,  'nvarchar',  '销售订单主表',  'MES_CQ_SO_SODetails',  '销售订单主表',  '871',  '##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'isosid' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'isosid',  '行ID', 32,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '871',  'isosid',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cinvcode' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cinvcode',  '产品编码', 20,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '871',  'cinvcode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cinvname' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cinvname',  '产品名称', 255,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '871',  'cinvname',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'iquantity',  '订单数量', 32,  'decimal',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '871',  'iquantity',  1,  '业务类')
--if not exists(select * from MES_FIELDCMP where cfield= 'Flag' and ctable= 'MES_CQ_SO_SODetails')
--  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
--  ('0',  0, null,  'Flag',  '操作标识',  2,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '861',  '1',  3,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_SO_SODetails')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '销售订单子表',  'MES_CQ_SO_SODetails',  '销售订单子表',  '861',  '6',  3,  '业务类') 
   
GO 
 
--采购到货单子表 FOR CQ  DELETE  MES_FIELDCMP where  ctable= 'MES_CQ_PU_ArrivalVouchs'
if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'did',  '日志子表主键', 32,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '871',  '##newguid',  5,  '业务类')

if not exists(select * from MES_FIELDCMP where cfield= 'dhCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'dhCode',  '到货单号',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'dhCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'dhid' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'dhid',  '到货单明细行号ID',  20,  'int',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'dhid',  1,  '业务类')
  
   
if not exists(select * from MES_FIELDCMP where cfield= 'ibilltype' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'ibilltype',  '单据类型',  20,  'int',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'ibilltype',  1,  '业务类')
  
  
if not exists(select * from MES_FIELDCMP where cfield= 'cPoCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cPoCode',  '采购订单号',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cPoCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'ddate' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'ddate',  '到货日期',  20,  'datetime',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'ddate',  1,  '业务类')
 if not exists(select * from MES_FIELDCMP where cfield= 'cVenCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cVenCode',  '供应商编码',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cVenCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cDepCode',  '部门编码',  12,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cDepCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPersonCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cPersonCode',  '业务员编码',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cPersonCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPTCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cPTCode',  '采购类型编码',  2,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cPTCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPTName' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cPTName',  '采购类型名称',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cPTName',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCode',  '存货编码',  20,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'cInvCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iquantity',  '数量',  32,  'Decimal',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  'iquantity',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_PU_ArrivalVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '采购到货单子表',  'MES_CQ_PU_ArrivalVouchs',  '采购到货单子表',  '861',  '6',  3,  '业务类') 
      
GO



    
----事件字段对照表	 
/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 生产订单主表 
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_mom_order')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '生产订单',  'MES_CQ_mom_order',  '生产订单主表',  '861',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_mom_order')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '生产订单',  'MES_CQ_mom_order',  '生产订单主表',  '861',  '6',  3,  '业务类') 
     
GO

-- 生产订单子表  
--if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_Mom_orderdetail')
--  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
--  ('0',  0, null,  'did',  '主表id',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  '##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'main|##newguid',  5,  '业务类')

if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCode',  '产品编码',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'DInvCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'MoCode' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'MoCode',  '生产订单号',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'MoCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iquantity',  '数量',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'DQty',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'PStartDate' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'PStartDate',  '开工日期',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'DStartDate',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'PStartDate' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'PDueDate',  '完工日期',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'DDueDate',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'MoType' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'MoType',  '订单类型',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'DMoTypeCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'MoType' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cSoCode',  '销售订单号',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  'SoCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_Mom_orderdetail')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '生产订单',  'MES_CQ_Mom_orderdetail',  '生产订单子表',  '861',  '6',  3,  '业务类') 
      
GO


-- 生产订单BOM
if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'did',  '主表id',  32,  'nvarchar',  '生产订单Bom',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  '##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '生产订单Bom',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'BomID' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'BomID',  'BomID',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  'BomID',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCode',  '产品编码',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  'DInvCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'MoCode' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'MoCode',  '生产订单号',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  'MoCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iquantity',  '数量',  32,  'nvarchar',  '生产订单子表',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  'DQty',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_Mom_OrderBom')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '生产订单',  'MES_CQ_Mom_OrderBom',  '生产订单BOM',  '861',  '6',  3,  '业务类') 
        
GO

/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 部门档案
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_Department')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '部门档案',  'MES_CQ_Department',  '部门基本信息',  '861',  'main|##newguid',  5,  '部门类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_Department')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepCode',  '部门编码',  12,  'nvarchar',  '部门档案',  'MES_CQ_Department',  '部门基本信息',  '861',  'cDepCode',  1,  '部门类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepName' and ctable= 'MES_CQ_Department')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepName',  '部门名称',  255,  'nvarchar',  '部门档案',  'MES_CQ_Department',  '部门基本信息',  '861',  'cDepName',  1,  '部门类')
if not exists(select * from MES_FIELDCMP where cfield= 'cLDepCode' and ctable= 'MES_CQ_Department')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cLDepCode',  '上级部门',  255,  'nvarchar',  '部门档案',  'MES_CQ_Department',  '部门基本信息',  '861',  '2',  3,  '部门类') 
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_Department')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '部门档案',  'MES_CQ_Department',  '部门基本信息',  '861',  '6',  3,  '部门类') 

GO

/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 人员档案
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'main|##newguid',  5,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPersonCode' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cPersonCode',  '人员编码',  20,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'cPsn_Num',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPersonName' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cPersonName',  '姓名',  40,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'cPsn_Name',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'PersonType' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'PersonType',  '人员类别',  30,  'Nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'rPersonType',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepCode',  '部门',  12,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'cDept_num',  1,  '人员类') 
if not exists(select * from MES_FIELDCMP where cfield= 'Sex' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'Sex',  '性别',  2,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'rSex',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'dBirthDate' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'dBirthDate',  '出生日期',  10,  'datetime',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'dBirthDate',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'cPsnEmail' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cPsnEmail',  '邮箱',  100,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '人员基本信息表',  '861',  'cPsnEmail',  1,  '人员类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_Person')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '人员档案',  'MES_CQ_Person',  '部门基本信息',  '861',  '6',  3,  '部门类') 

GO


/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 存货档案  
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'main|##newguid',  5,  '存货类')

if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cInvCode',  '存货编码',  20,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cInvCode',  1,  '存货类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cInvName' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cInvName',  '存货名称',  255,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cInvName',  1,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvStd' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvStd',  '规格型号',  255,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cInvStd',  1,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'cWhCode' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cWhCode',  '仓库编码',  10,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cDefWareHouse',  1,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvAddCode' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cInvAddCode',  '存货代码',  255,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cInvAddCode',  1,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'bPropertyCheck' and ctable= 'MES_CQ_Inventory') 
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bPropertyCheck',  '是否质检',  1,  'bit',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'bPropertyCheck',  1,  '存货类')

if not exists(select * from MES_FIELDCMP where cfield= 'cComUnitCode' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cComUnitCode',  '主计量单位编码',  35,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cComUnitCode',  6,  '存货类')  --4
if not exists(select * from MES_FIELDCMP where cfield= 'cInvCCode' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cInvCCode',  '存货大类编码',  12,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'cInvCCode',  6,  '存货类') --3 
if not exists(select * from MES_FIELDCMP where cfield= 'bPurchase' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bPurchase',  '是否外购',  1,  'bit',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'bPurchase',  6,  '存货类') 
if not exists(select * from MES_FIELDCMP where cfield= 'bSelf' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bSelf',  '是否自制',  1,  'bit',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'bSelf',  6,  '存货类')  
if not exists(select * from MES_FIELDCMP where cfield= 'bBomMain' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bBomMain',  '允许BOM母件',  1,  'bit',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'bBomMain',  6,  '存货类') 
if not exists(select * from MES_FIELDCMP where cfield= 'bBomSub' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bBomSub',  '允许BOM子件',  1,  'bit',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  'bBomSub',  6,  '存货类') 

if not exists(select * from MES_FIELDCMP where cfield= 'cInvCName' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCName',  '存货大类名称',  255,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  '3',  3,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'cComUnitName' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cComUnitName',  '主计量单位名称',  20,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  '4', 3,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'iInvType' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iInvType',  '存货大类名称',  10,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '存货档案',  '861',  '5',  3,  '存货类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_Inventory')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '存货档案',  'MES_CQ_Inventory',  '部门基本信息',  '861',  '6',  3,  '存货类') 
   
    
GO




    
----事件字段对照表	 
/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 组装单主表 
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  '6',  3,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cAVCode' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cAVCode',  '组装单号',  30,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'cAVCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'dAVDate' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'dAVDate',  '组装日期',  255,  'Datetime',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'dAVDate',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cIRdCode' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cIRdCode',  '入库类别',  5,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'cIRdCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepCode',  '部门',  12,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'cDepCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cORdCode' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cORdCode',  '其他出库单类别',  5,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'cORdCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cODepCode' and ctable= 'MES_CQ_AssemVouch')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cODepCode',  '其他出、入库部门',  12,  'nvarchar',  '组装单',  'MES_CQ_AssemVouch',  '组装单主表',  '861',  'cDepCode',  1,  '业务类') 
           
GO

-- 组装单子表  delete from MES_FIELDCMP where ctable= 'MES_CQ_AssemVouchs'
if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'did',  '子表id',  32,  'nvarchar',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  '##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'main|##newguid',  5,  '业务类')

if not exists(select * from MES_FIELDCMP where cfield= 'cAVDID' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cAVDID',  '子表行号',  32,  'int',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'autoid',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'bAVType' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bAVType',  '类型',  20,  'nvarchar',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'bAVType',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCode',  '存货编码',  20,  'nvarchar',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'cInvCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cWhCode' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cWhCode',  '仓库',  20,  'nvarchar',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'cWhCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iquantity',  '数量',  32,  'Decimal',  '组装单子表',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  'iavquantity',  1,  '业务类')
   
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_AssemVouchs')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '组装单',  'MES_CQ_AssemVouchs',  '组装单子表',  '861',  '6',  3,  '业务类') 

GO




----拆卸单  事件字段对照表	 
/*======================= table data: [MES_FIELDCMP] ========================*/
print 'dbo.[MES_FIELDCMP] data...'  
-- 拆卸单主表 
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'main|##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  '6',  3,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cAVCode' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cAVCode',  '拆卸单号',  30,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'cAVCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'dAVDate' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'dAVDate',  '组装日期',  255,  'Datetime',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'dAVDate',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cIRdCode' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cIRdCode',  '入库类别',  5,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'cIRdCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cDepCode' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cDepCode',  '部门',  12,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'cDepCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cORdCode' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cORdCode',  '其他出库单类别',  5,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'cORdCode',  1,  '业务类') 
if not exists(select * from MES_FIELDCMP where cfield= 'cODepCode' and ctable= 'MES_CQ_AssemVouchRet')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'cODepCode',  '其他出、入库部门',  12,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRet',  '拆卸单主表',  '861',  'cDepCode',  1,  '业务类') 
           
GO

-- 拆卸单子表  delete from MES_FIELDCMP where ctable= 'MES_CQ_AssemVouchRets'
if not exists(select * from MES_FIELDCMP where cfield= 'did' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'did',  '子表id',  32,  'nvarchar',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  '##newguid',  5,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'id' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'id',  '主表id',  32,  'nvarchar',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'main|##newguid',  5,  '业务类')

if not exists(select * from MES_FIELDCMP where cfield= 'cAVDID' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cAVDID',  '子表行号',  32,  'int',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'autoid',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'bAVType' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'bAVType',  '类型',  20,  'nvarchar',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'bAVType',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cInvCode' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cInvCode',  '存货编码',  20,  'nvarchar',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'cInvCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'cWhCode' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'cWhCode',  '仓库',  20,  'nvarchar',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'cWhCode',  1,  '业务类')
if not exists(select * from MES_FIELDCMP where cfield= 'iquantity' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  0, null,  'iquantity',  '数量',  32,  'Decimal',  '拆卸单子表',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  'iavquantity',  1,  '业务类')
   
if not exists(select * from MES_FIELDCMP where cfield= 'opertype' and ctable= 'MES_CQ_AssemVouchRets')
  insert into MES_FIELDCMP ( bfixed,bvisible,cdefult,cfield,cfielddesc,cfieldlength,cfieldtype,cname,ctable,ctabledesc,cversion,igetvalue,igetvaluetype,itype ) values 
  ('0',  1, null,  'opertype',  '操作类型',  255,  'nvarchar',  '拆卸单',  'MES_CQ_AssemVouchRets',  '拆卸单子表',  '861',  '6',  3,  '业务类') 

GO


