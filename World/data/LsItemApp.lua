

dofile("LsObjectApp.lua"); -- lua script object application에서 사용하는 공용요소들을 가져온다.
dofile("LsSKID.lua");      -- lua script object application에서 사용하는 공용요소들을 가져온다.

-- 메인테이블을 정의한다.
ItemBook = {};

dofile("scriptdata(item)/ItemStartup.lua");



function main()
	-- 글로벌변수를 생성할수 없도록 처리한다.
	setmetatable( _G,{ __newindex = function( t, k, v ) error( "attempt to update a read-only table", 2 ) end }) 	
	return true,"성공";
end

-- 이벤트 핸들러를 등록한다 --
function EventConsumeCheckup(in_ItemName,in_AID)	
	if( ItemBook[in_ItemName] and (type(ItemBook[in_ItemName].ConsumeCheckup) == "function")) then return ItemBook[in_ItemName].ConsumeCheckup(in_AID); end
	return true,MSI.NONE;
end

function EventConsume(in_ItemName,in_AID)
	if( ItemBook[in_ItemName] and (type(ItemBook[in_ItemName].Consume) == "function")) then ItemBook[in_ItemName].Consume(in_AID); end
end

function EventStartEquip(in_ItemName,in_AID)
	if( ItemBook[in_ItemName] and (type(ItemBook[in_ItemName].StartEquip) == "function")) then ItemBook[in_ItemName].StartEquip(in_AID); end
end


function EventFinishEquip(in_ItemName,in_AID)
	if( ItemBook[in_ItemName] and (type(ItemBook[in_ItemName].FinishEquip) == "function")) then ItemBook[in_ItemName].FinishEquip(in_AID); end
end

function EventThrow(in_ItemName,in_SourceAID,in_TargetAID)
	if( ItemBook[in_ItemName] and (type(ItemBook[in_ItemName].Throw) == "function")) then ItemBook[in_ItemName].Throw(in_SourceAID,in_TargetAID); end
end

