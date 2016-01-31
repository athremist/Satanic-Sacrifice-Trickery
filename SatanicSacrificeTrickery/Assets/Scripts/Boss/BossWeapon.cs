using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour
{
    const int DAMAGE = 12;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats player = collider.gameObject.GetComponent<PlayerStats>();
            player.ApplyDamage(DAMAGE);
        }
    }
}
