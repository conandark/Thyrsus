


dofile("LsObjectApp.lua"); -- lua script object application���� ����ϴ� �����ҵ��� �����´�.
dofile("LsSKID.lua");      -- lua script object application���� ����ϴ� �����ҵ��� �����´�.

-- �������̺��� �����Ѵ�.
EfstBook = {}; 

dofile("scriptdata(efst)/EfstIdentity.lua"); -- EFST_XXXX ������ ������� �����Ѵ�.

-- �⺻ Ŭ������ ���� �Ѵ�.
EFST_XXX = {};

function EFST_XXX:new(in_ID,in_Name)
	local newEFST = {};
	
	-- Identity �ʵ带 �ʱ�ȭ�Ѵ�.
	newEFST.ID   = in_ID;
	newEFST.Name = in_Name;
	-- Attr �ʵ带 �ʱ�ȭ �Ѵ�.
	newEFST.Attr ={};
	newEFST.Attr.ResetDead = false;	
	newEFST.Attr.ResetDispel = false;	
	newEFST.Attr.Save = false;	
	newEFST.Attr.Send = false;	
	newEFST.Attr.IgnorePretendDead = false;	
	newEFST.Attr.DeBuff = false;	
	newEFST.Attr.ResetCLEARANCE = false;	
	newEFST.Attr.ActorAppearance = false;
	newEFST.Attr.SendMultiCast = false;
	newEFST.Attr.backward_compatibility_send = false;
	
	setmetatable(newEFST,self);
	self.__index = self;
	return newEFST;
end

function EFST_XXX:OnInit()

	local result,msg = app.SetAttr(		
		self.ID,
		self.Name,
		self.Attr.ResetDead,
		self.Attr.ResetDispel,
		self.Attr.Save,
		self.Attr.Send,
		self.Attr.IgnorePretendDead,
		self.Attr.DeBuff,
		self.Attr.ResetCLEARANCE,
		self.Attr.ActorAppearance,
		self.Attr.SendMultiCast,
		self.Attr.backward_compatibility_send);
		
	return result,msg;
end



dofile("scriptdata(efst)/EfstStartup.lua");



function main()

	-- �۷ι������� �����Ҽ� ������ ó���Ѵ�.
	setmetatable( _G,{ __newindex = function( t, k, v ) error( "attempt to update a read-only table", 2 ) end }) 

	-- �ʱ�ȭ �Լ��� ������� �ش�.
	for k,Efst in pairs(EfstBook) do	
		local result,msg = Efst:OnInit();
		if(not result) then return false,msg; end		
	end	
	
	
	
	
	return true,"����";
end


------------------------------------------------------------------------------
-- Efst�� �����Ҷ� 
------------------------------------------------------------------------------
-- ������ �˻��մϴ�.
-- bool ���� �����մϴ�.
function EventSetCheckup(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].SetCheckup) == "function")) then return EfstBook[in_Efst]:SetCheckup(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
	return true,in_Time,in_Val1,in_Val2,in_Val3;
end

-- Efst�� Set�ɶ��� �۾��� �����մϴ�.
-- ���ϰ��� �������� �ʴ´�.
function EventSet(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].Set) == "function")) then EfstBook[in_Efst]:Set(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
end

------------------------------------------------------------------------------
-- Efst�� �����Ҷ�
------------------------------------------------------------------------------
-- ������ �˻��մϴ�.
-- bool ���� �����մϴ�.
function EventResetCheckup(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].ResetCheckup) == "function")) then return EfstBook[in_Efst]:ResetCheckup(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
	return true;
end

-- Efst�� ���µɶ��� �۾��� ���� �մϴ�.
function EventReset(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if(EfstBook[in_Efst] and (type(EfstBook[in_Efst].Reset) == "function")) then EfstBook[in_Efst]:Reset(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
end




















