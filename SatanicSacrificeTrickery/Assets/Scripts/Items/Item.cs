using UnityEngine;
using System.Collections;

public class Item : ScriptableObject
{
    float m_Damage = 0.5f;
    public float DamageModifier
    {
        private set { m_Damage = 0.5f; }
        get { return m_Damage; }
    }

    float m_AttSpd = -0.0075f;
    public float AttackSpeedModifier
    {
        private set { m_AttSpd = -0.0075f; }
        get { return m_AttSpd; }
    }

    float m_AttDmg = 0.4f;
    public float AttackDamageModifier
    {
        private set { m_AttDmg = 0.4f; }
        get { return m_AttDmg; }
    }

    float m_Heal = 4;
    public float HealModifier
    {
        private set { m_Heal = 4; }
        get { return m_Heal; }
    }

    float m_Spd = 0.1f;
    public float SpeedModifier
    {
        private set { m_Spd = 0.1f; }
        get { return m_Spd; }
    }

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

    public string ItemDescriptionUse
    {
        get;
        protected set;
    }

    public string ItemDescriptionSacrifice
    {
        get;
        protected set;
    }
}
