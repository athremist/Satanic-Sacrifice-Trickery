using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour
{
    const float DAMAGE = 15;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.ApplyDamage(DAMAGE);
        }
    }
}
