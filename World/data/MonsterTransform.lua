-- ���� ���� �ý���--
-- 1. ���� Ÿ�Կ� ���ž������� �ߺ����� �ʰ� �߰��Ͻø� �˴ϴ�.
-- 2. ���ο� ���� ���� Ÿ��(["MALE"]..)�� �߰��Ͻø� �����ڵ忡�� �߰��ؾߵǼ� ���α׷����� �˷��ּ���.
--  2.1 "DEFAULT", "ARCHER", "MAGICIAN", "FEMALE", "MALE"
-- 3. ��ũ��Ʈ��ɾ� ����
--   ex) Montransfrom ���� 30(��) "EFST_MTF_ASPD"(���������)


TransformTbl = 
{
	[ [[Trans_Scroll_Poring]] ]			= {	[[DEFAULT]],	[[PORING]]},
	[ [[Trans_Scroll_Mavka]] ]			= {	[[DEFAULT]],	[[MAVKA]]},
	[ [[Trans_Scroll_Devi]] ]			= {	[[DEFAULT]],	[[DEVIRUCHI]]},
	[ [[Trans_Scroll_Marduk]] ]			= {	[[DEFAULT]],	[[MARDUK]]},
	[ [[Trans_Scroll_Ray_Arch]] ]			= {	[[DEFAULT]],	[[RAYDRIC_ARCHER]]},
	[ [[Trans_Scroll_Banshee]] ]			= {	[[DEFAULT]],	[[BANSHEE]]},
	[ [[Trans_Scroll_Golem]] ]			= {	[[DEFAULT]],	[[GOLEM]]},
};


function main()
	
	for key, value in pairs(TransformTbl) do
		result, msg = InsertTbl(key, value[1], value[2]);
		if ( not result ) then 
			return false, msg; 
		end
	end

	return true,"success"
end
