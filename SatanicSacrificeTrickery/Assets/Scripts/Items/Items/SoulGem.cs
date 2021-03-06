﻿using UnityEngine;
using System.Collections;

public class SoulGem : Item
{
    void Awake()
    {
        ItemName = "SoulGem";
        ItemValue = 6;
        ItemSprite = Resources.Load<Sprite>("SoulGem");
        ItemStat = "Speed";
        ItemSacrificeStat = "AttackSpeed";

        ItemDescriptionUse = "Increases movement speed by " + (ItemValue * SpeedModifier).ToString();
        ItemDescriptionSacrifice = "Increases attack speed by " + (ItemValue * -DamageModifier).ToString();
    }
}
