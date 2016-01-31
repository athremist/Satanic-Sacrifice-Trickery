using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Room transition
            TopDownCamera cam = Camera.main.GetComponent<TopDownCamera>();
            cam.targetPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        }
    }
}
