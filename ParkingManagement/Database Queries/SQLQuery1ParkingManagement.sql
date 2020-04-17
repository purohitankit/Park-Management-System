--create table AuditVechicleData(id int identity(1,1),
-- VechicleId int not null constraint pkVechicleId primary key(VechicleId), 
-- VechicleType varchar(50),
-- OccupiedCount int, 
-- AvailableCount int)

--------------------------------------------------------------------

--insert into AuditVechicleData values(1,'small',0,50) 
--insert into AuditVechicleData values(2,'medium',0,30) 
--insert into AuditVechicleData values(3,'large',0,20) 


--create table ddlVechicleCategory (VId int not null constraint pkVId primary key (VId),
--VechicleType varchar(50))

--insert into ddlVechicleCategory values(1,'Small')
--insert into ddlVechicleCategory values(2,'Medium')
--insert into ddlVechicleCategory values(3,'Large')

------------------------------------------------------------------------------------

--create table ddlVechicleSubCategory (VId int not null constraint fkVechicleId foreign key(VId) references ddlVechicleCategory(VId),
--VechicleName varchar(60))

--insert into ddlVechicleSubCategory values(1,'Tata Altroz')
--insert into ddlVechicleSubCategory values(1,'Hyundai Elitr i20')
--insert into ddlVechicleSubCategory values(1,'Maruti Alto')
--insert into ddlVechicleSubCategory values(2,'Honda Amaze')
--insert into ddlVechicleSubCategory values(2,'Tata Tigor')
--insert into ddlVechicleSubCategory values(2,'Ford Aspire')
--insert into ddlVechicleSubCategory values(3,'Toyato')
--insert into ddlVechicleSubCategory values(3,'Nissan Armanda')
--insert into ddlVechicleSubCategory values(3,'Ford Expedition')

-------------------------------------------------------------------------------------------

--create procedure SPGetVechicleType
--as
--begin
--	select VId,VechicleType from ddlVechicleCategory
--end

--create procedure SPGetVechicleName
--(
--	@vechicleId int
--)
--as
--begin
--	select VId,
--	VechicleName 
--	from 
--	ddlVechicleSubCategory
--	where VId=@vechicleId
--end 



