

-- 이파일은 lua 문법에 따라 작성해야 합니다.
-- 이 파일은 관리자 권한 설정 파일입니다.


function main()
	RightTbl = {
		DEVELOPER = 0, -- 이값은 코드와 연관됩니다.
		HACKSHIELD_EXCEPT =  1,
	};

	-- 개발자 디버깅 지원 권한
	DeveloperTbl = {
	};
	
	for k,v in pairs(DeveloperTbl) do
		result,msg = InsertRight(RightTbl.DEVELOPER,v[1],v[2]);
		if( not result) then return false,msg; end		
	end	
	
	-- 핵쉴드 제외 권한
	HackshieldExceptTbl = {
	};
	
	for k,v in pairs(HackshieldExceptTbl) do
		result,msg = InsertRight(RightTbl.HACKSHIELD_EXCEPT,v[1],v[2]);
		if( not result) then return false,msg; end		
	end
	
	
	return true,"success";
end




