


function main()

	-- ������ ����Ʈ
	ForbiddenWordTbl = {		
	}; 

	for k,v in pairs(ForbiddenWordTbl) do
		result,msg = AddForbiddenWord(v);
		if( not result) then return false,msg; end		
	end	
			
	return true,"����";
end
