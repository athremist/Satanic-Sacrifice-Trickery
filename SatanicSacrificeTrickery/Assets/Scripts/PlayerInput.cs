using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    const float PLAYER_SPEED = 2;

    Vector2 velocity;

    void Start()
    {
        velocity = Vector2.zero;
    }

    void Update()
    {
        Movement();
        PlayerActions();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, PLAYER_SPEED * Time.deltaTime, 0);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-PLAYER_SPEED * Time.deltaTime, 0, 0);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -PLAYER_SPEED * Time.deltaTime, 0);
            //TODO add sprite animation here
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(PLAYER_SPEED * Time.deltaTime, 0, 0);
            //TODO add sprite animation here
        }

        if (!Input.anyKey)
        {
            velocity = Vector2.zero;
            //TODO add sprite animation here
        }
    }

    void PlayerActions()
    {

    }
}
