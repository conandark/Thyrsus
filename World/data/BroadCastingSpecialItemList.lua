

-- �������� lua ������ ���� �ۼ��ؾ� �մϴ�.
-- �� ������ ���͵�� �������� Ư���Ѿ������� ȹ�������� ��ε�ĳ���ø޼����� �����ش�.
-- �ּ��� -- ǥ���Դϴ�.
-- ����ϴ� ���Ϳ� ������ ������ ȹ��ÿ� ����� ������, ������ ������Ʈ ī�带 ������ ����ϰ� �Ǵ���
-- '���� : ������ ����Ͽ� ������Ʈ ī�带 ȹ���Ͽ����ϴ�.' ��� ���·� ����� ������ �˴ϴ�.
-- ȹ�� ĳ���� ���� ����Ʈ�� ĳ���� ���� ���� ���� 2���� **�� ǥ�ð��Ǹ�, Ro.inf�� �����Ͽ� �̸��� ��� ǥ�õǵ���
-- ���� �����մϴ�.
-- ��� ����� �־
--	tbl={	
--		{ID,"DB NAME"},
--		{738,"���ʲ���"},
--	};
-- ��� �������� ID�� DB Name�� ������ �׸��� �����ϸ� �ȵ˴ϴ�.

--function main()
--
--	tbl={	
--		{ID,"DB NAME"},
--		{738,"���ʲ���"},
--	};
--	
--	for k,v in pairs(tbl) do
--		result,msg = InsertItem(v);
--		if( not result) then return false,msg; end		
--	end	
--	
--	return true,"����";
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

