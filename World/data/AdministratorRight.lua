

-- �������� lua ������ ���� �ۼ��ؾ� �մϴ�.
-- �� ������ ������ ���� ���� �����Դϴ�.


function main()
	RightTbl = {
		DEVELOPER = 0, -- �̰��� �ڵ�� �����˴ϴ�.
		HACKSHIELD_EXCEPT =  1,
	};

	-- ������ ����� ���� ����
	DeveloperTbl = {
	};
	
	for k,v in pairs(DeveloperTbl) do
		result,msg = InsertRight(RightTbl.DEVELOPER,v[1],v[2]);
		if( not result) then return false,msg; end		
	end	
	
	-- �ٽ��� ���� ����
	HackshieldExceptTbl = {
	};
	
	for k,v in pairs(HackshieldExceptTbl) do
		result,msg = InsertRight(RightTbl.HACKSHIELD_EXCEPT,v[1],v[2]);
		if( not result) then return false,msg; end		
	end
	
	
	return true,"success";
end




