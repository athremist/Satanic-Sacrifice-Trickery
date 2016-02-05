using UnityEngine;
using System.Collections;

public class BloodGem : Item
{
    void Awake()
    {
        ItemName = "BloodGem";
        ItemValue = 4;
        ItemSprite = Resources.Load<Sprite>("Bloodgem");
        ItemStat = "Heal";
        ItemSacrificeStat = "Damage";

        ItemDescriptionUse = "Heals by " + (ItemValue * HealModifier).ToString();
        ItemDescriptionSacrifice = "Deals " + (ItemValue * DamageModifier).ToString() + " direct damage to satan";
    }
}
