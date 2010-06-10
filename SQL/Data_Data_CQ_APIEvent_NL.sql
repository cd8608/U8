----销售订单审核
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='SA' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('SA','销售管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='SaleOrder' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('SaleOrder','销售订单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeSaleOrderAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeSaleOrderAudit','Mes服务销售订单审核前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Audit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Audit_Before','审核前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----销售订单弃审前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='SA' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('SA','销售管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='SaleOrder' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('SaleOrder','销售订单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeSaleOrderCancelAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeSaleOrderCancelAudit','Mes服务销售订单弃审前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='CancelAudit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('CancelAudit_Before','弃审前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',2,0,'',0,0,0)  
end 
go

----采购到货单审核前 
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='PU' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('PU','采购管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='ArrivedGoods' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('ArrivedGoods','采购到货单(退货单)',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforePU_ArrivalVouchAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforePU_ArrivalVouchAudit','Mes服务采购到货单审核前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Audit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Audit_Before','审核前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----采购到货单弃审前 
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='PU' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('PU','采购管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='ArrivedGoods' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('ArrivedGoods','采购到货单(退货单)',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforePU_ArrivalVouchCancelAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforePU_ArrivalVouchCancelAudit','Mes服务采购订单弃审前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='CancelAudit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('CancelAudit_Before','弃审前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',2,0,'',0,0,0)  
end 
go
 
----物料清单保存后
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8M' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8M','生产制造',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='BOM' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('BOM','物料清单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.AfterBomSave' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.AfterBomSave','Mes服务物料清单保存后事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_DataSet" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_DataSet" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Save_After' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Save_After','保存后事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomds" type="DataSet" direction="in" desc="物料清单数据集合 ( 类: UFSoft.U8.U8M.DOSchema.BO.StandardBomDs, 程序集: UFSoft.U8.U8M.DOSchema.dll )" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomds" type="DataSet" direction="in" desc="物料清单数据集合 ( 类: UFSoft.U8.U8M.DOSchema.BO.StandardBomDs, 程序集: UFSoft.U8.U8M.DOSchema.dll )" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----物料清单审核前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8M' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8M','生产制造',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='BOM' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('BOM','物料清单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeBomAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeBomAudit','Mes服务物料清单审核前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_BomId" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_BomId" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Audit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Audit_Before','审核前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomid" type="int" direction="in" desc="物料清单ID ( 表: Bom_Bom.BomId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomid" type="int" direction="in" desc="物料清单ID ( 表: Bom_Bom.BomId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----组装单弃审前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8M' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8M','生产制造',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='BOM' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('BOM','物料清单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeBomCancelAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeBomCancelAudit','Mes服务物料清单弃审前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_BomId" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.PMEvent" description="" display="true" /><param name="MethodName" value="DoAPI_BomId" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='CancelAudit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('CancelAudit_Before','弃审前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomid" type="int" direction="in" desc="物料清单ID ( 表: Bom_Bom.BomId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="bomid" type="int" direction="in" desc="物料清单ID ( 表: Bom_Bom.BomId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----组装单审核前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='ST' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('ST','库存管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='GroupVouch' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('GroupVouch','组装单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeGroupAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeGroupAudit','Mes服务组装单审核前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Audit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Audit_Before','审核前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

----组装单弃审前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='ST' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('ST','库存管理',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='GroupVouch' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('GroupVouch','组装单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeGroupCancelAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeGroupCancelAudit','Mes服务组装单弃审前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeVoucherEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='CancelAudit_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('CancelAudit_Before','弃审前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="domhead" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表头" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="dombody" type="MSXML2.IXMLDOMDocument2" direction="inout" desc="表体" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-----   生产订单 开始   ----
-- 生产订单 审核后
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8M' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8M','生产制造',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='MOrder' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('MOrder','生产订单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.AfterMoorderAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.AfterMoorderAudit','Mes服务生产订单审核后事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.MoEvent" description="" display="true" /><param name="MethodName" value="DoAPIEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.MoEvent" description="" display="true" /><param name="MethodName" value="DoAPIEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Audit_After' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Audit_After','审核后事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="moid" type="int" direction="in" desc="生产订单ID ( 表: mom_order.MoId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="modid" type="int" direction="in" desc="生产订单明细ID ( 表: mom_orderdetail.MoDId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="moid" type="int" direction="in" desc="生产订单ID ( 表: mom_order.MoId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="modid" type="int" direction="in" desc="生产订单明细ID ( 表: mom_orderdetail.MoDId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-- 生产订单 弃审后 
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8M' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8M','生产制造',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='MOrder' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('MOrder','生产订单',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.AfterMoorderUnAudit' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.AfterMoorderUnAudit','Mes服务生产订单弃审后事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.MoEvent" description="" display="true" /><param name="MethodName" value="DoAPIEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.MoEvent" description="" display="true" /><param name="MethodName" value="DoAPIEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='CancelAudit_After' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('CancelAudit_After','弃审后事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="moid" type="int" direction="in" desc="生产订单ID ( 表: mom_order.MoId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="modid" type="int" direction="in" desc="生产订单明细ID ( 表: mom_orderdetail.MoDId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="moid" type="int" direction="in" desc="生产订单ID ( 表: mom_order.MoId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="modid" type="int" direction="in" desc="生产订单明细ID ( 表: mom_orderdetail.MoDId )" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="2" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-----   生产订单 结束   ----


-----   部门档案事件 开始   ----

-- 部门新增前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='department' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('department','部门档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeDeptIns' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeDeptIns','Mes服务部门新增前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Add_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Add_Before','新增前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-- 部门删除前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='department' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('department','部门档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeDeptDel' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeDeptDel','Mes服务部门删除前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Delete_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Delete_Before','删除前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-- 部门修改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='department' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('department','部门档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeDeptMod' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeDeptMod','Mes服务部门修改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Modify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Modify_Before','修改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-----   部门档案事件 结束   ----


-----   人员档案事件 开始   ----
-- 人员新增前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='hr_hi_person' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('hr_hi_person','人员档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforePsnInv' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforePsnInv','Mes服务人员新增前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Add_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Add_Before','新增前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-- 人员删除前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='hr_hi_person' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('hr_hi_person','人员档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforePsnDel' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforePsnDel','Mes服务人员删除前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Delete_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Delete_Before','删除前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

-- 人员修改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='hr_hi_person' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('hr_hi_person','人员档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforePsnMod' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforePsnMod','
Mes服务人员修改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Modify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Modify_Before','修改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
-----   人员档案事件 结束   ----





-----   存货档案事件 开始   ----
--存货新增前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='inventory' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('inventory','存货档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeInvIns' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeInvIns','Mes服务存货新增前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Add_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Add_Before','新增前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',2,0,'',0,0,0)  
end 
go

-- 存货删除前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='inventory' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('inventory','存货档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeInvDel' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeInvDel','Mes服务存货删除前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Delete_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Delete_Before','删除前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',2,0,'',0,0,0)  
end 
go

-- 存货修改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='inventory' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('inventory','存货档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeInvMod' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeInvMod','Mes服务存货修改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Modify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Modify_Before','修改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',2,0,'',0,0,0)  
end 
go

-- 存货批改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='inventory' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('inventory','存货档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeInvBat' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeInvBat','Mes服务存货批改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='MulModify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('MulModify_Before','批改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
-----   存货档案事件 结束   ----



-----   客户档案事件 开始   ----

--客户新增前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='customer' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('customer','客户档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeCusIns' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeCusIns','Mes服务客户档案新增前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Add_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Add_Before','新增前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

--客户修改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='customer' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('customer','客户档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeCusMod' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeCusMod','Mes服务客户档案修改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Modify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Modify_Before','修改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go


--客户批改前

declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='customer' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('customer','客户档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeCusBatch' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeCusBatch','Mes服务客户档案批改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='MulModify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('MulModify_Before','批改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

--客户删除前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='customer' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('customer','客户档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeCusDel' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeCusDel','Mes服务客户档案删除前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Delete_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Delete_Before','删除前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',5,0,'',0,0,0)  
end 
go

--客户并户前

declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='customer' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('customer','客户档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeCusMerge' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeCusMerge','Mes服务客户档案并户前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Merge_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Merge_Before','并户前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go


-----   客户档案事件 结束   ----


 
-----   供应商档案事件 开始   ----

--供应商新增前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='vendor' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('vendor','供应商档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeVenIns' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeVenIns','Mes服务供应商档案新增前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Add_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Add_Before','新增前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go

--供应商修改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='vendor' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('vendor','供应商档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeVenMod' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeVenMod','Mes服务供应商档案修改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Modify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Modify_Before','修改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
--供应商删除前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='vendor' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('vendor','供应商档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeVenDel' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeVenDel','Mes服务供应商档案删除前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Delete_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Delete_Before','删除前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
--供应商批改前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='vendor' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('vendor','供应商档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeVenBatch' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeVenBatch','Mes服务供应商档案批改前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='MulModify_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('MulModify_Before','批改前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
--供应商并户前
declare @AppSysID int,@AppTypeID int,@AppTagID int,@EndpointID nvarchar(50),@MsgTypeID int,@MsgTypeCategoryID int,@MsgFilterID int,@ParentAppTypeID int 
select @AppSysID=IB_AppSys.ID from IB_AppSys,IB_Entities where IB_Entities.ID=IB_AppSys.EntityID and IB_Entities.EntityTag='U8API' 
if @AppSysID is null 
begin 
insert into IB_Entities(EntityTag,FriendName)values('U8API','U8API') 
insert into IB_AppSys(AppSystem,FriendName,EntityID)values('U8API','U8API',@@identity) 
set @AppSysID=@@identity 
end 
set @ParentAppTypeID=0 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='U8Archive' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('U8Archive','基础档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
set @AppTypeID=0 
select @AppTypeID=ID from IB_AppType where AppType='vendor' and AppSysID=@AppSysID 
if @AppTypeID is null or @AppTypeID=0 
begin 
insert into IB_AppType(AppType,FriendName,AppSysID)values('vendor','供应商档案',@AppSysID) 
select @AppTypeID=@@identity 
if @ParentAppTypeID>0 
begin 
update IB_AppType set ParentID=@ParentAppTypeID where ID=@AppTypeID 
end 
end 
set @ParentAppTypeID=@AppTypeID 
select @AppTagID=ID from IB_AppTag where AppTag='HY_ME_SVREvent.BeforeVenMerge' and AppTypeID=@AppTypeID 
if @AppTagID is null 
begin 
insert into IB_AppTag(AppTag,FriendName,AppTypeID,ExtendProperties,Description,Customize,IsPlugin) 
 values('HY_ME_SVREvent.BeforeVenMerge','Mes服务供应商档案并户前事件',@AppTypeID,'','',0,1) 
set @AppTagID=@@identity 
end 
else 
begin 
update IB_AppTag set ExtendProperties='',Description='',Customize=0 where ID=@AppTagID 
end 
select top 1 @EndpointID=ID from IB_EndPoint where AppTagID=@AppTagID 
if @EndpointID is null 
begin 
insert into IB_EndPoint(Address,ProtocolID,ProtocolParams,AppTagID) 
 values('','DotNetAssemblyForRPC','<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>',@AppTagID) 
end 
else 
begin 
update IB_EndPoint set Address='',ProtocolID='DotNetAssemblyForRPC',ProtocolParams='<?xml version="1.0" encoding="utf-8"?><momEndPointProtocol name="DotNetAssemblyForRPC"><runtimeParameters><param name="AssemblyPath" value="%U8SOFT%\HY\client\HY_ME_SVR\Event\U8.Interface.Bus.Event.SyncAdapter.dll" description="" display="true" /><param name="ClassFullName" value="U8.Interface.Bus.Event.SyncAdapter.EventBase" description="" display="true" /><param name="MethodName" value="InvokeArchiveEvent" description="" display="true" /><param name="TransactionType" value="" description="" display="true" /></runtimeParameters></momEndPointProtocol>' where ID=@EndpointID 
end 
select @MsgTypeCategoryID=ID from MOM_MsgTypeCategories where MsgTypeCategory='插件事件' 
select @MsgFilterID=ID from IB_MsgFilter where FilterName='XPathFilter' 
select @MsgTypeID=ID from IB_MsgType where MsgType='Merge_Before' and AppTypeID=@AppTypeID 
if @MsgTypeID is null 
begin 
insert into IB_MsgType(MsgType,FriendName,MsgSchema,AppTypeID,MsgTypeCategoryID,MsgFilterID,ExtendProperties) values('Merge_Before','并户前事件','<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',@AppTypeID,@MsgTypeCategoryID,@MsgFilterID,'') 
 set @MsgTypeID=@@identity 
end 
else 
begin 
update IB_MsgType set MsgSchema='<?xml version="1.0" encoding="utf-8" ?><serviceInterface transactionType=""><operation name="" ><parameters><parameter index="0" name="archivedata" type="MSXML2.IXMLDOMDocument2" direction="in" desc="档案数据XmlDom" optional="false" byRef="true" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter index="1" name="errmsg" type="string" direction="inout" desc="返回错误信息" optional="false" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /><parameter type="bool" direction="retval" desc="返回值: true:成功, false: 失败" byRef="false" uapMetaType="" uapMetaID="" uapMetaName="" isBoHead="false" isBoBody="false" /></parameters></operation></serviceInterface>',ExtendProperties='' where ID=@MsgTypeID 
end 
if (select count(*) from IB_Event_Plugin where AppTagID=@AppTagID and MsgTypeID=@MsgTypeID) = 0 
begin 
insert into IB_Event_Plugin(AppTagID,MsgTypeID,AccID,OrderNO,IsSyncOrAsync,Description,Disabled,UnVisible,UnDeleted) values(@AppTagID,@MsgTypeID,'',1,0,'',0,0,0)  
end 
go
-----   供应商档案事件 结束   ----