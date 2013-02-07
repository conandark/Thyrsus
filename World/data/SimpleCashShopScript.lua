t_shop_type=
{
        SIMPLE_CASH_NEW                 = 0,
        SIMPLE_CASH_POPULAR     = 1,
        SIMPLE_CASH_LIMITED     = 2,
        SIMPLE_CASH_RENTAL              = 3,
        SIMPLE_CASH_PERPETUITY  = 4,
        SIMPLE_CASH_BUFF                = 5,
        SIMPLE_CASH_RECOVERY    = 6,
        SIMPLE_CASH_ETC                 = 7,
};

t_item_price =
{
        {t_shop_type.SIMPLE_CASH_NEW,   "Boarding_Halter_Box",39},
        {t_shop_type.SIMPLE_CASH_POPULAR,       "Boarding_Halter_Box",39},
        {t_shop_type.SIMPLE_CASH_LIMITED,       "Token_Of_Siegfried_Box",25},
        {t_shop_type.SIMPLE_CASH_RENTAL,        "Boarding_Halter_Box",39},
        
        {t_shop_type.SIMPLE_CASH_PERPETUITY,    "Leaf_Cat_Box",159},
        
        {t_shop_type.SIMPLE_CASH_BUFF,          "Str_Dish_Box",10},
        {t_shop_type.SIMPLE_CASH_BUFF,          "Agi_Dish_Box",10},
        {t_shop_type.SIMPLE_CASH_BUFF,          "Int_Dish_Box",10},
        {t_shop_type.SIMPLE_CASH_BUFF,          "Dex_Dish_Box",10},
        {t_shop_type.SIMPLE_CASH_BUFF,          "Luk_Dish_Box",10},
        {t_shop_type.SIMPLE_CASH_BUFF,          "Vit_Dish_Box",10},
        
        {t_shop_type.SIMPLE_CASH_RECOVERY,      "Small_Life_Potion_Box50",129},
        
        {t_shop_type.SIMPLE_CASH_ETC,   "Enriched_Elunium_Box",15},
        {t_shop_type.SIMPLE_CASH_ETC,   "Enriched_Oridecon_Box",15},
};

function main()
        for k,v in pairs(t_item_price) do
                if not add_cash_item(v[1],v[2],v[3])
                then return false, v[2]; end
        end
        return true , "success";
end
