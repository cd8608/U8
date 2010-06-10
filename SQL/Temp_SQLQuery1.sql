 

 UPDATE MES_CQ_CheckVouch SET operflag = 0,opertype=0,cerrordesc = null ,cPersonCode='zzm' 

select   dACDate,* from  MES_CQ_CheckVouch with(nolock)
select  * from MES_CQ_CheckVouchs  with(nolock)
    
	 
   
    select    * from  CheckVouch t with(nolock)   
    select   cCVCode,id,cBVencode,* from  CheckVouchs  t with(nolock)  
	   
	   select   lt.cCVCode as mes_cCVCode , lt.dCVDate as mes_dCVDate , lt.dACDate as mes_dACDate , lt.cDepCode as mes_cDepCode , lt.cPersonCode as mes_cPersonCode , lt.cWhCode as mes_cWhCode,  CASE lb.opertype WHEN 0 THEN 'A' WHEN 1 THEN 'M' WHEN '2' THEN 'D' ELSE 'A' END as editprop,  lb.cinvcode as mes_cinvcode ,   lb.iquantity as MES_iquantity,    lb.iquantity as mes_cvencode    from   MES_CQ_CheckVouchs lb with(nolock) INNER JOIN MES_CQ_CheckVouch lt with(nolock) on lt.id = lb.id where lt.id ='1' 