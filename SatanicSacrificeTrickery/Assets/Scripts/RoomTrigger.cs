using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Room transition
        }
    }
}
