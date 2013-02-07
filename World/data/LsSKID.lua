


--[[스킬아이디를 정의합니다.--]]
-- SKID_SCRIPT_000		 = 11000,//스크립트에서 사용할 스킬아이디 번호대역(11000 ~ 11999)
-- SKID_SCRIPT_999		 = 11999,//스크립트에서 사용할 스킬아이디 번호대역(11000 ~ 11999)
SKID = {	
	ITEM_SAVAGE_STEAK         = 11000, -- 세비지통구이
	ITEM_COCKTAIL_WARG_BLOOD  = 11001, -- 칵테일 워그 블러드
	ITEM_MINOR_BBQ			  = 11002, -- 마이너 양지머리
	ITEM_SIROMA_ICE_TEA		  = 11003, -- 시로마 아이스티
	ITEM_DROCERA_HERB_STEAMED = 11004, -- 드로세라 허브찜
	ITEM_PUTTI_TAILS_NOODLES  = 11005, -- 쁘띠 꼬리 국수
	ITEM_BANANA_BOMB		  = 11006, -- 바나나 폭탄
	__newindex=function() error("unknown state"); end, -- 읽기전용으로 설정한다.
};	
setmetatable(SKID,SKID); -- 자기자신을 메타테이블로 지정한다.
	
	
	
	
	