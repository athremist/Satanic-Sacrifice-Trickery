using UnityEngine;
using System.Collections;

public class PickupSoulGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Add item
            SoulGem item = Item.CreateInstance<SoulGem>();
            PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
            inventory.AddItem(item);
            //Remove pickup item
            Destroy(this.gameObject);
        }
    }
}
