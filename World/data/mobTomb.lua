--�������� ����--
--�� ���󸶴� ���ڰ� �޶� lua���Ͽ� ����� �ؽ�Ʈ�� �����Ѵ�
--NPC �̸� �� ���⼭ �����Ѵ�
function main()
	tbl={
		[[Tomb]],--npc�̸�
		[[Has met its demise.]],  --���̾�α׸޽���#1
		[[Time of death]],				--���̾�α׸޽���#2
		[[Defeated by]],             --���̾�α׸޽���#3
	};

	if not SetMobTombInfo(tbl[1],tbl[2],tbl[3],tbl[4]) then return false,tbl[1];end
	return true,"success";
end
