using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Room transition
            Camera.main.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -10);
        }
    }
}
