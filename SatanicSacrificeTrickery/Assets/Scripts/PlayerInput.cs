using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    const float PLAYER_SPEED = 2;

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
            newPos += new Vector2(0, PLAYER_SPEED * Time.deltaTime);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos += new Vector2(-PLAYER_SPEED * Time.deltaTime, 0);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos += new Vector2(0, -PLAYER_SPEED * Time.deltaTime);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos += new Vector2(PLAYER_SPEED * Time.deltaTime, 0);
            //TODO add sprite animation here
        }

        if (!Input.anyKey)
        {
            velocity = Vector2.zero;
            //TODO add sprite animation here
        }

        m_RB.MovePosition(newPos);
    }

    void PlayerActions()
    {

    }
}
