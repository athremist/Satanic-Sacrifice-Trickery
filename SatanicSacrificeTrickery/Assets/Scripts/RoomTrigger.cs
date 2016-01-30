using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Room transition
            CameraMovement camMove = Camera.main.GetComponent<CameraMovement>();
            camMove.targetPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);

            //Vector3 currentPos = Camera.main.transform.position;
            //Vector3 newPos = this.transform.position;
            //Camera.main.transform.position = new Vector3(Mathf.Lerp(currentPos.x, newPos.x, 1.0f), Mathf.Lerp(currentPos.y, newPos.y, 1.0f), -10);
        }
    }
}
