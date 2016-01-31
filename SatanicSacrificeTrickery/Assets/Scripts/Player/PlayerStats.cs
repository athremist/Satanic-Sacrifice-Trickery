using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    const int PLAYER_MAX_HEALTH = 50;

    public int Health
    {
        get;
        private set;
    }

    void Start()
    {
        Health = PLAYER_MAX_HEALTH;
    }

    void Update()
    {
        if (Health <= 0)
        {
            Death();
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

    void Death()
    {
        Application.LoadLevel(2);
    }
}
