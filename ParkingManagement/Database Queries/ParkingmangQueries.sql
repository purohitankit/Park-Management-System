

--Alter procedure AddRemoveVechicles
--(
--	@VechicleId int,
--	@VechicleType varchar(20),
--	@Action varchar(10)
--)
--as
--begin
	
--	declare @OccpCnt int;
--	declare @AvailCnt int;
--	if(@Action ='Add')
--	begin
--		if((select count(*) from AuditVechicleData where VechicleId=@VechicleId and OccupiedCount !=MaxCount) =1)
--		begin
			
--			set @OccpCnt=(select OccupiedCount from AuditVechicleData where VechicleId=@VechicleId)
--			set @AvailCnt=(select AvailableCount from AuditVechicleData where VechicleId=@VechicleId)
--			update AuditVechicleData set OccupiedCount=@OccpCnt+1,AvailableCount=@AvailCnt-1 where VechicleId=@VechicleId

--		end
--		else
--		begin
--			declare @IncrementedVId int;			
--			set @IncrementedVId=(select top 1 VechicleId from AuditVechicleData where OccupiedCount != MaxCount order by 1 desc)

--			set @OccpCnt=(select OccupiedCount from AuditVechicleData where VechicleId=@IncrementedVId)
--			set @AvailCnt=(select AvailableCount from AuditVechicleData where VechicleId=@IncrementedVId)

--			update AuditVechicleData set OccupiedCount=@OccpCnt+1,AvailableCount=@AvailCnt-1 where VechicleId=@IncrementedVId
		
--		end
--		select 'Added'
--	end
--	else if(@Action ='Remove')
--	begin
		
--		set @OccpCnt=(select OccupiedCount from AuditVechicleData where VechicleId=@VechicleId)
--		set @AvailCnt=(select AvailableCount from AuditVechicleData where VechicleId=@VechicleId)
--		update AuditVechicleData set OccupiedCount=@OccpCnt-1,AvailableCount=@AvailCnt+1 where VechicleId=@VechicleId

--		select 'Removed'
--	end		
--end

	

--alter procedure AddDataToAuditVechicle
--(
--	@VechicleType varchar(50),
--	@VechicleName varchar(50),
--	@SlotSize int
--)
--as
--begin
--	declare @Vid int
--	set @Vid=(select max(VechicleId) from AuditVechicleData)
--	insert into AuditVechicleData values(@Vid+1,@VechicleType,0,@SlotSize,@SlotSize)
--	insert into ddlVechicleCategory values(@Vid+1,@VechicleName)
--	insert into ddlVechicleSubCategory values(@Vid+1,@VechicleType)

--	select 1
--end

--ALTER procedure [dbo].[GetCountOfVechicleSlots]
--(
--@vechicleId int
--)
--as
--begin
--	select OccupiedCount,AvailableCount from AuditVechicleData where VechicleId=@vechicleId
--end


--ALTER procedure [dbo].[SPGetVechicleName]
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

