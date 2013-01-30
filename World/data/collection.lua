CollectionTBL = 
{
	[ [[E_CRAMP]] ] = { ConsumeItem = [[Leaf_Cat_Ball]], CreateItem_1 = [[Mystic_Leaf_Cat_Ball]], Random_1 = 100, CreateItem_2 = [[Green_Herb]], Random_2 = 5, CreateItem_3 = [[Jellopy]], Random_3 = 1 },
	[ [[E_SHINING_PLANT]] ] = { ConsumeItem = [[Empty_Potion_Bottle]], CreateItem_1 = [[Magic_Potion_Bottle]], Random_1 = 100, CreateItem_2 = [[Green_Herb]], Random_2 = 5, CreateItem_3 = [[White_Herb]], Random_3 = 1 },
};

function main()

	for key, value in pairs(CollectionTBL) do
		result, msg = InsertTBL(key, value.ConsumeItem, value.CreateItem_1, value.Random_1, value.CreateItem_2, value.Random_2, value.CreateItem_3, value.Random_3);

		if( not result ) then 
			return false, msg;
		end
	end

	return true, "success";
end