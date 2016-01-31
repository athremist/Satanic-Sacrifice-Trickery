using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    const int BOSS_START_HEALTH = 100;

    Vector2 m_RetreatPos;
    Vector2 m_AttackPos;

    public int Health
    {
        get;
        private set;
    }

    void Start()
    {
        Health = BOSS_START_HEALTH;

        m_RetreatPos = this.transform.position;
    }

    void Update()
    {
        if (Health >= 0)
        {
            HasDied();
        }
    }

    public void ApplyDamage(int aDamage)
    {
        if (aDamage > Health)
        {
            Health = 0;
        }
        else
        {
            Health -= aDamage;
        }
    }

    void HasDied()
    {

    }
}
