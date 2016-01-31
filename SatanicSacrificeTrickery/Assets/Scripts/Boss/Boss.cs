using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    enum AttackState
    {
        Idle,
        Charge,
        Spin
    }

    const float BOSS_MAX_HEALTH = 100;

    Vector2 m_RetreatPos;
    Vector2 m_AttackPos;
    AttackState m_State;
    float m_IdleTimer;
    bool m_AttackPosAcquired;

    [SerializeField]
    GameObject m_HealthBar;
    [SerializeField]
    Text m_HealthAmount;
    [SerializeField]
    GameObject m_Weapon;

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
        m_State = AttackState.Idle;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Health <= 0)
        {
            HasDied();
        }

        if (m_State == AttackState.Idle)
        {
            Idle();
        }
        else if (m_State == AttackState.Charge)
        {
            ChargeAttack();
        }
        else if (m_State == AttackState.Spin)
        {
            Idle();
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
        this.gameObject.SetActive(false);
    }

    void Idle()
    {
        m_IdleTimer += 1 * Time.deltaTime;

        if (m_IdleTimer >= 4.0f)
        {
            int randomState = Random.Range((int)AttackState.Charge, (int)AttackState.Spin);

            m_IdleTimer = 0;
            m_State = (AttackState)randomState;
        }
    }

    void ChargeAttack()
    {
        if (m_AttackPosAcquired == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            m_AttackPos = player.transform.position;

            Vector3 dir = m_Weapon.transform.position - player.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            m_Weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            m_AttackPosAcquired = true;
        }
        else
        {
            Vector2 distance = new Vector2(transform.position.x, transform.position.y) - m_AttackPos;
            if (distance.magnitude <= 1)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                Vector3 dir = m_Weapon.transform.position - player.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
                m_Weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                m_State = AttackState.Idle;
                m_AttackPosAcquired = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(this.transform.position, m_AttackPos, 3 * Time.deltaTime);
            }
        }
    }

    void Spin()
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
