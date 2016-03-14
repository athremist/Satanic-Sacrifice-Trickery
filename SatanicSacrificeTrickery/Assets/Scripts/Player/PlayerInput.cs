using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    const float PLAYER_SPEED = 4;

    public float m_SpeedTest = 1;

    Rigidbody2D m_RB;

    public float Speed
    {
        get;
        set;
    }

    public float AttackSpeed
    {
        get;
        set;
    }

    [SerializeField]
    GameObject m_Weapon;
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GameObject m_HowTo;

    Text m_HowToText;
    bool m_HasTextChanged;

    [SerializeField]
    string m_Direction;

    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();
        m_Weapon.SetActive(false);
        m_Direction = "Down";
        Speed = m_SpeedTest;
        AttackSpeed = 0.5f;
        m_HowToText = m_HowTo.GetComponent<Text>();
    }

    void Update()
    {
        Movement();
        Animations();
        PlayerActions();
    }

    void Movement()
    {
        Vector2 newPos = this.transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos += new Vector2(0, PLAYER_SPEED * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos += new Vector2(-PLAYER_SPEED * Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos += new Vector2(0, -PLAYER_SPEED * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos += new Vector2(PLAYER_SPEED * Speed * Time.deltaTime, 0);
        }

        m_RB.MovePosition(newPos);
    }

    void Animations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Animator.Play("Anim_Player_WalkForward");
            m_Direction = "Up";
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_Animator.Play("Anim_Player_Walk1");
            m_Direction = "Down";
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_Animator.Play("Anim_Player_WalkLeft");
            m_Direction = "Left";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_Animator.Play("Anim_Player_WalkRight");
            m_Direction = "Right";
        }

        //Idles
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                m_Animator.Play("Anim_Player_IdleForward");
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                m_Animator.Play("Anim_Player_IdleLeft");
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                m_Animator.Play("Anim_Player_Idle");
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                m_Animator.Play("Anim_Player_IdleRight");
            }
        }
    }

    void PlayerActions()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_HowTo.activeSelf == true && m_HasTextChanged == true)
            {
                m_HowTo.SetActive(false);
            }
            UseWeapon();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CanvasGroup inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CanvasGroup>();

            if (inventory.alpha == 0)
            {
                inventory.alpha = 1;
                inventory.interactable = true;
            }
            else
            {
                inventory.alpha = 0;
                inventory.interactable = false;
            }

            //Once player presses I they know how to open inventory :P
            if (m_HasTextChanged == false)
            {
                m_HasTextChanged = true;
                m_HowToText.text = "Now press Space to attack";
            }
        }
    }

    void SetWeaponDirection()
    {
        if (m_Direction == "Up")
        {
            m_Weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            m_Weapon.transform.localPosition = new Vector3(-0.35f, 1.25f, 0.0f);
            m_Animator.Play("Anim_Player_PunchUp");
        }
        else if (m_Direction == "Down")
        {
            m_Weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            m_Weapon.transform.localPosition = new Vector3(0.4f, -1.0f, 0.0f);
            m_Animator.Play("Anim_Player_PunchDown");
        }
        else if (m_Direction == "Left")
        {
            m_Weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            m_Weapon.transform.localPosition = new Vector3(-0.15f, 0.5f, 0.0f);
            m_Animator.Play("Anim_Player_PunchLeft");
        }
        else if (m_Direction == "Right")
        {
            m_Weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            m_Weapon.transform.localPosition = new Vector3(0.4f, 0.58f, 0.0f);
            m_Animator.Play("Anim_Player_PunchRight");
        }
    }

    void UseWeapon()
    {
        if (m_Weapon.activeSelf == false)
        {
            SetWeaponDirection();
            m_Weapon.SetActive(true);
            StartCoroutine(DrawWeapon());
        }
    }

    IEnumerator DrawWeapon()
    {
        yield return new WaitForSeconds(AttackSpeed);
        m_Weapon.SetActive(false);

        if (m_Direction == "Up")
        {
            m_Animator.Play("Anim_Player_IdleForward");
        }
        else if (m_Direction == "Down")
        {
            m_Animator.Play("Anim_Player_Idle");
        }
        else if (m_Direction == "Left")
        {
            m_Animator.Play("Anim_Player_IdleLeft");
        }
        else if (m_Direction == "Right")
        {
            m_Animator.Play("Anim_Player_IdleRight");
        }
    }
}
