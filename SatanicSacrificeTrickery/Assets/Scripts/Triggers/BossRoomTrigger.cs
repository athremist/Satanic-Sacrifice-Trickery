using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField]
    Sprite m_Gate;
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
            BoxCollider2D boxCollider = m_BackWall.GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = false;
            m_BackWall.GetComponent<SpriteRenderer>().sprite = m_Gate;

            m_Boss.SetActive(true);
        }
    }
}
