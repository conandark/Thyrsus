-- ���� ���� �ݰ� ����

BigMonsterTable =
{
--	[ [[�г���_Ż����_ǻ����]] ] = 1,
--	[ [[������_�ζ�]] ] = 1,
--	[ [[�����̾�]] ] = 1,
--	[ [[�����]] ] = 2,
--	[ [[�屺_����]] ] = 1,
--	[ [[ȣ��_����_����]] ] =1,
--	[ [[������_��ȣ��_ī����]] ] = 1,
	[ [[�ٵ�X]] ] = 2,
	[ [[E_VADON_X_H]] ] = 2,
	[ [[E_RSX_0805]] ] = 2,
};

function main()

	for key, value in pairs(BigMonsterTable) do
		result, msg = InsertTable(key, value);
		if ( not result ) then
			return false, msg;
		end
	end

	return true,"success"
end
