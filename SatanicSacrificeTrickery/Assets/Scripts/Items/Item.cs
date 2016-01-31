using UnityEngine;
using System.Collections;

public class Item : ScriptableObject
{
    public string ItemName
    {
        get;
        protected set;
    }

    public float ItemValue
    {
        get;
        protected set;
    }

    public Sprite ItemSprite
    {
        get;
        protected set;
    }

    public string ItemStat
    {
        get;
        protected set;
    }

    public string ItemSacrificeStat
    {
        get;
        protected set;
    }
}
