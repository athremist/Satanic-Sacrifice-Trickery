using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    const float PLAYER_SPEED = 2;

    public float m_SpeedTest = 1;

    Vector2 velocity;
    Rigidbody2D m_RB;

    void Start()
    {
        velocity = Vector2.zero;
        m_RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        PlayerActions();
    }

    void Movement()
    {
        Vector2 newPos = this.transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos += new Vector2(0, PLAYER_SPEED * m_SpeedTest * Time.deltaTime);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos += new Vector2(-PLAYER_SPEED * m_SpeedTest * Time.deltaTime, 0);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos += new Vector2(0, -PLAYER_SPEED * m_SpeedTest * Time.deltaTime);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos += new Vector2(PLAYER_SPEED * m_SpeedTest * Time.deltaTime, 0);
            //TODO add sprite animation here
        }

        m_RB.MovePosition(newPos);
    }

    void PlayerActions()
    {
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
        }
    }
}
