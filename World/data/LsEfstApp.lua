


dofile("LsObjectApp.lua"); -- lua script object application에서 사용하는 공용요소들을 가져온다.
dofile("LsSKID.lua");      -- lua script object application에서 사용하는 공용요소들을 가져온다.

-- 메인테이블을 정의한다.
EfstBook = {}; 

dofile("scriptdata(efst)/EfstIdentity.lua"); -- EFST_XXXX 형태의 상수값을 정의한다.

-- 기본 클래스를 정의 한다.
EFST_XXX = {};

function EFST_XXX:new(in_ID,in_Name)
	local newEFST = {};
	
	-- Identity 필드를 초기화한다.
	newEFST.ID   = in_ID;
	newEFST.Name = in_Name;
	-- Attr 필드를 초기화 한다.
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

	-- 글로벌변수를 생성할수 없도록 처리한다.
	setmetatable( _G,{ __newindex = function( t, k, v ) error( "attempt to update a read-only table", 2 ) end }) 

	-- 초기화 함수을 실행시켜 준다.
	for k,Efst in pairs(EfstBook) do	
		local result,msg = Efst:OnInit();
		if(not result) then return false,msg; end		
	end	
	
	
	
	
	return true,"성공";
end


------------------------------------------------------------------------------
-- Efst를 적용할때 
------------------------------------------------------------------------------
-- 조건을 검사합니다.
-- bool 형을 린턴합니다.
function EventSetCheckup(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].SetCheckup) == "function")) then return EfstBook[in_Efst]:SetCheckup(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
	return true,in_Time,in_Val1,in_Val2,in_Val3;
end

-- Efst가 Set될때의 작업을 정의합니다.
-- 리턴값이 존재하지 않는다.
function EventSet(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].Set) == "function")) then EfstBook[in_Efst]:Set(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
end

------------------------------------------------------------------------------
-- Efst를 리셋할때
------------------------------------------------------------------------------
-- 조건을 검사합니다.
-- bool 형을 린턴합니다.
function EventResetCheckup(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if( EfstBook[in_Efst] and (type(EfstBook[in_Efst].ResetCheckup) == "function")) then return EfstBook[in_Efst]:ResetCheckup(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
	return true;
end

-- Efst가 리셋될때의 작업을 정의 합니다.
function EventReset(in_Efst,in_AID,in_Time,in_Val1,in_Val2,in_Val3)	
	if(EfstBook[in_Efst] and (type(EfstBook[in_Efst].Reset) == "function")) then EfstBook[in_Efst]:Reset(in_AID,in_Time,in_Val1,in_Val2,in_Val3); end
end




















