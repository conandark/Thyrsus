-- ��ũ�� ����
RankType = {	
		 S = 0, 
	     A = 1,
  	     B = 2,
	     C = 3 
	}


-- �����ۺ� ��ũ
RuneRankList = {
		["Runstone_Verkana"]		= RankType.S ,		-- ����ī��		
		["Runstone_Rhydo"]		= RankType.C ,		-- ���̵�	
		["Runstone_Nosiege"]		= RankType.A ,		-- �뾾��		
		["Runstone_Turisus"]		= RankType.C ,		-- Ʃ������
		["Runstone_Hagalas"]		= RankType.C ,		-- �ϰ�����		
		["Runstone_Isia"]		= RankType.B ,		-- ���̻�	
		["Runstone_Pertz"]		= RankType.B ,		-- �丣��
		["Runstone_Asir"]		= RankType.C ,		-- ���̽ø�		
		["Runstone_Urj"]		= RankType.A		-- �츣��		
	}

-- ��ũ�� ���� Ȯ�� ������
RankSuccessPercent = {
		S = -20,
		A = -15,
		B = -10,
		C = -5
	}

-- ���� ���� Ȯ�� ����
RawRuneSuccessPercent = {
		["Runstone_Ordinary"]		= 2,		-- �Ϲݷ�,	
		["Runstone_Quality"]		= 5,		-- ��޷�,	
		["Runstone_Rare"]		= 8,		-- ��ͷ�,	
		["Runstone_Ancient"]		= 11,		-- ����,	
		["Runstone_Mystic"]		= 14		-- �ź��ѷ�,
	}


-- �鸶���͸� ��ų ������ ���ۼ�����
RuneMastery_MakeSuccessPercent = {
		53, 55, 57, 59, 61, 63, 65, 67, 69, 71
	}

-- �鸶���͸�, ��ų ������ ���� �ּҼ���
RuneMastery_MakeMinCount = {
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1
	}

-- �鸶���͸�, ��ų ������ ���� �ִ����
RuneMastery_MakeMaxCount = {
		1, 1, 1, 1, 2, 2, 2, 2, 2, 3
	}

-- �鸶���͸� ��ų ������ ��뼺����
RuneMastery_UseSuccessPercent = {
		56, 57, 58, 59, 60, 61, 62, 63, 64, 65
	}

	
-- �� ������ �ִ� ���� ����
RuneItem_MaxCount = {
		["Runstone_Turisus"]		= 20,		-- Ʃ������
		["Runstone_Isia"]		= 20,		-- ���̻�
		["Runstone_Pertz"]		= 20,		-- �丣��
		["Runstone_Hagalas"]		= 20,		-- �ϰ�����
		["Runstone_Asir"]		= 20,		-- ���̽ø�
		["Runstone_Urj"]			= 20,		-- �츣��
		["Runstone_Rhydo"]		= 20,		-- ���̵�
		["Runstone_Nosiege"]		= 20,		-- �뾾��
		["Runstone_Verkana"]		= 20		-- ����ī��
	}


-- �鸶���͸� ��ų ������ ���� ���� ������ ��
RuneMasteryLevel_MakableItem = {
		"Runstone_Turisus",		-- Ʃ������
		"Runstone_Isia",		-- ���̻�
		"Runstone_Pertz",		-- �丣��
		"Runstone_Hagalas",		-- �ϰ�����
		"Runstone_Asir",		-- ���̽ø�
		"Runstone_Urj",			-- �츣��
		"Runstone_Rhydo",		-- ���̵�
		"Runstone_Nosiege",		-- �뾾��
		"Runstone_Verkana"		-- ����ī��
	}


-- �����ۿ� �ʿ��� ������, ���̺� �̸��� �ѱ۸��� ����� �� ���... itemID�� ����! ����!

Rune_12731 = {		-- Ʃ������
		["Elder_Branch"]		= 1,		
		["Cobold_Hair"]		= 1,		
		["Claw_Of_Desert_Wolf"]		= 1,		
	}

Rune_12728 = {		-- ���̻� 
		["Elder_Branch"]		= 1,		
		["Burning_Heart"]		= 1,		
	}

Rune_12732 = {		-- �丣�� 
		["Elder_Branch"]		= 1,		
		["Light_Granule"]	= 1,		
		["Tangled_Chain"]		= 1,		
		["Dragon_Canine"]		= 1,		
	}

Rune_12733 = {		-- �ϰ����� 
		["Elder_Branch"]		= 1,		
		["Round_Shell"]	= 1,		
		["Dragon's_Skin"]		= 1,		
	}

Rune_12729 = {		-- ���̽ø� 
		["Elder_Branch"]		= 1,		
		["Light_Granule"]	= 1,		
		["Ogre_Tooth"]		= 1,		
	}

Rune_12730 = {			-- �츣�� 
		["Elder_Branch"]		= 1,		
		["Slender_Snake"]	= 1,		
		["Honey"]		= 1,		
	}

Rune_12726 = {	-- ���̵� 
		["Elder_Branch"]		= 1,		
		["Light_Granule"]	= 1,		
		["Red_Gemstone"]		= 1,		
	}

Rune_12725 = {		-- �뾾�� 
		["Elder_Branch"]		= 1,		
		["Light_Granule"]	= 1,		
		["Broken_Armor_Piece"]		= 1,		
		["Old_Magic_Circle"]		= 1,		
	}

Rune_12727 = {		-- ����ī�� 
		["Elder_Branch"]		= 1,		
		["Dullahan_Armor"]	= 1,		
	}
