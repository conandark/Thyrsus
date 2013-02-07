

-- 이파일은 lua 문법에 따라 작성해야 합니다.
-- 이 파일은 몬스터드랍 아이템중 특정한아이템을 획들했을시 브로드캐스팅메세지를 날려준다.
-- 주석은 -- 표시입니다.
-- 드롭하는 몬스터와 별개로 아이템 획득시에 방송이 나오며, 포링이 바포메트 카드를 먹은후 드롭하게 되더라도
-- '예시 : 포링을 사냥하여 바포메트 카드를 획득하였습니다.' 라는 형태로 방송이 나오게 됩니다.
-- 획득 캐릭터 명은 디폴트로 캐릭터 명의 뒤쪽 문자 2개가 **로 표시가되며, Ro.inf를 수정하여 이름이 모두 표시되도록
-- 변경 가능합니다.
-- 사용 방법에 있어서
--	tbl={	
--		{ID,"DB NAME"},
--		{738,"연필꽃이"},
--	};
-- 상기 구문안의 ID와 DB Name을 제외한 항목은 수정하면 안됩니다.

--function main()
--
--	tbl={	
--		{ID,"DB NAME"},
--		{738,"연필꽃이"},
--	};
--	
--	for k,v in pairs(tbl) do
--		result,msg = InsertItem(v);
--		if( not result) then return false,msg; end		
--	end	
--	
--	return true,"성공";
--end



function main()

	tbl={	
		{7782,"Gold_Key77"},
		{7783,"Silver_Key77"},
-- MVP Cards
		{4121,"Phreeoni_Card"},
		{4123,"Eddga_Card"},
		{4128,"Golden_Bug_Card"},
		{4131,"Moonlight_Flower_Card"},
		{4132,"Mistress_Card"},
		{4134,"Dracula_Card"},
		{4135,"Orc_Load_Card"},
		{4137,"Drake_Card"},
		{4142,"Doppelganger_Card"},
		{4143,"Orc_Hero_Card"},
		{4144,"Osiris_Card"},
		{4145,"Berzebub_Card"},
		{4146,"Maya_Card"},
		{4147,"Baphomet_Card"},
		{4148,"Pharaoh_Card"},
		{4168,"Dark_Lord_Card"},
		{4236,"Amon_Ra_Card"},
		{4263,"Incant_Samurai_Card"},
		{4276,"Lord_Of_Death_Card"},
		{4302,"Tao_Gunka_Card"},
		{4305,"Turtle_General_Card"},
		{4318,"Knight_Windstorm_Card"},
		{4324,"Garm_Card"},
		{4330,"Dark_Snake_Lord_Card"},
		{4342,"Rsx_0806_Card"},
		{4352,"B_Ygnizem_Card"},
		{4357,"B_Seyren_Card"},
		{4359,"B_Eremes_Card"},
		{4361,"B_Harword_Card"},
		{4363,"B_Magaleta_Card"},
		{4365,"B_Katrinn_Card"},
		{4367,"B_Shecil_Card"},
		{4372,"Bacsojin_Card"},
		{4374,"Apocalips_H_Card"},
		{4376,"Lady_Tanee_Card"},
		{4386,"Detale_Card"},
		{4399,"Thanatos_Card"},
		{4403,"Kiel_Card"},
		{4407,"Randgris_Card"},
		{4408,"Gloom_Under_Night_Card"},
		{4419,"Ktullanux_Card"},
		{4425,"Atroce_Card"},
		{4430,"Ifrit_Card"},
		{4441,"Fallen_Bishop_Card"},
		{4451,"Ant_Buyanne_Card"},
	};
	
	for k,v in pairs(tbl) do
		result,msg = InsertItem(v);
		if( not result) then return false,msg; end		
	end	
	
	return true,"Success";
end

