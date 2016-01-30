using UnityEngine;
using System.Collections;

public class PickupTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Add item
            ItemTest item = Item.CreateInstance<ItemTest>();
            PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
            inventory.AddItem(item);
            //Remove pickup item
            Destroy(this.gameObject);
        }
    }
}
