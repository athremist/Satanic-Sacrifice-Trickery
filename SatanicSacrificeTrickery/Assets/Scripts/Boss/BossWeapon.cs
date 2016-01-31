using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour
{
    const float DAMAGE = 15;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats player = collider.gameObject.GetComponent<PlayerStats>();
            player.ApplyDamage(DAMAGE);
        }
    }
}
