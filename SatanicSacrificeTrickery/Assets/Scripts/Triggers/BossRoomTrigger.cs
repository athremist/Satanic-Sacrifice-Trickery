using UnityEngine;
using System.Collections;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject m_BackWall;
    GameObject m_Boss;

    void Awake()
    {
        m_Boss = GameObject.FindGameObjectWithTag("Boss");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Room transition
            TopDownCamera cam = Camera.main.GetComponent<TopDownCamera>();
            cam.targetPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
            BoxCollider2D boxCollider = m_BackWall.GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = false;

            m_Boss.SetActive(true);
        }
    }
}
