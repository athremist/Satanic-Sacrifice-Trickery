using UnityEngine;
using System.Collections;

public class PickupBloodGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Add item
            BloodGem item = Item.CreateInstance<BloodGem>();
            PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
            inventory.AddItem(item);
            //Remove pickup item
            Destroy(this.gameObject);
        }
    }
}
