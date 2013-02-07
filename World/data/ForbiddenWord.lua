


function main()

	-- 금지어 리스트
	ForbiddenWordTbl = {		
	}; 

	for k,v in pairs(ForbiddenWordTbl) do
		result,msg = AddForbiddenWord(v);
		if( not result) then return false,msg; end		
	end	
			
	return true,"성공";
end
