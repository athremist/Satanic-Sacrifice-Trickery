using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    const float BOSS_MAX_HEALTH = 100;

    Vector2 m_RetreatPos;
    Vector2 m_AttackPos;

    [SerializeField]
    GameObject m_HealthBar;
    [SerializeField]
    Text m_HealthAmount;

    public float Health
    {
        get;
        private set;
    }

    void Start()
    {
        Health = BOSS_MAX_HEALTH;
        m_HealthAmount.text = Health.ToString() + " / " + BOSS_MAX_HEALTH.ToString();

        m_RetreatPos = this.transform.position;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Health >= 0)
        {
            HasDied();
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

        m_HealthBar.transform.localScale = new Vector2(Health / BOSS_MAX_HEALTH, 1);
        m_HealthAmount.text = Health.ToString() + " / " + BOSS_MAX_HEALTH.ToString();
    }

    void HasDied()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerWeapon")
        {
            PlayerStats player = collider.transform.parent.gameObject.GetComponent<PlayerStats>();
            ApplyDamage(player.AttackDamage);
        }
    }
}
