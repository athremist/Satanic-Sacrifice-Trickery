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
    }
}
