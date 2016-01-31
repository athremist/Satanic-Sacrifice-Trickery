using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    const float PLAYER_MAX_HEALTH = 69;
    const float BASE_DAMAGE = 2;

    [SerializeField]
    GameObject m_HealthBar;
    [SerializeField]
    Text m_HealthAmount;

    public bool AtCauldron
    {
        get;
        set;
    }

    public float Health
    {
        get;
        private set;
    }

    public float AttackDamage
    {
        get;
        set;
    }

    void Start()
    {
        Health = PLAYER_MAX_HEALTH;
        AttackDamage = BASE_DAMAGE;
        m_HealthAmount.text = Health.ToString() + " / " + PLAYER_MAX_HEALTH.ToString();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Death();
        }
    }

    public void ApplyDamage(float aDamage)
    {
        if (aDamage > Health)
        {
            Health = 0;
        }
        else
        {
            Health -= aDamage;
        }

        m_HealthBar.transform.localScale = new Vector2(Health / PLAYER_MAX_HEALTH, 1);
        m_HealthAmount.text = Health.ToString() + " / " + PLAYER_MAX_HEALTH.ToString();
    }

    public void AddHealth(float aAmount)
    {
        if ((aAmount + Health) > PLAYER_MAX_HEALTH)
        {
            Health = PLAYER_MAX_HEALTH;
        }
        else
        {
            Health += aAmount;
        }

        m_HealthBar.transform.localScale = new Vector2(Health / PLAYER_MAX_HEALTH, 1);
        m_HealthAmount.text = Health.ToString() + " / " + PLAYER_MAX_HEALTH.ToString();
    }

    public void AddSpeed(float aAmount)
    {
        PlayerInput player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        player.Speed += aAmount;
    }

    public void AddAttackSpeed(float aAmount)
    {
        PlayerInput player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        player.AttackSpeed += aAmount;

        if (player.AttackSpeed <= 0.001f)
        {
            player.AttackSpeed = 0.001f;
        }
    }

    void Death()
    {
        Application.LoadLevel(2);
    }
}
