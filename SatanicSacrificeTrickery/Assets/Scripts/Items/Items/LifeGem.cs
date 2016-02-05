using UnityEngine;
using System.Collections;

public class LifeGem : Item
{
    void Awake()
    {
        ItemName = "LifeGem";
        ItemValue = 10;
        ItemSprite = Resources.Load<Sprite>("LifeGem");
        ItemStat = "Heal";
        ItemSacrificeStat = "AttackDamage";

        ItemDescriptionUse = "Heals by " + (ItemValue * HealModifier).ToString();
        ItemDescriptionSacrifice = "Increases attack damage by " + (ItemValue * AttackDamageModifier).ToString();
    }
}
