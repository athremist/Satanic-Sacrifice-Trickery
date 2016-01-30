using UnityEngine;
using System.Collections;

public class ItemTest : Item
{
    void Awake()
    {
        ItemName = "ItemTest";
        ItemValue = 1.5f;
        //ItemSprite = Resources.Load<Sprite>("Stuff");
    }
}
