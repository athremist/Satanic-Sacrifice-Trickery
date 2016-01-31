using UnityEngine;
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
    }
}
