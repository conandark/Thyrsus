--무덤관련 정보--
--각 나라마다 문자가 달라 lua파일에 출력할 텍스트를 지정한다
--NPC 이름 도 여기서 지정한다
function main()
	tbl={
		[[Tomb]],--npc이름
		[[Has met its demise.]],  --다이얼로그메시지#1
		[[Time of death]],				--다이얼로그메시지#2
		[[Defeated by]],             --다이얼로그메시지#3
	};

	if not SetMobTombInfo(tbl[1],tbl[2],tbl[3],tbl[4]) then return false,tbl[1];end
	return true,"success";
end
