using UnityEngine;
using System.Collections;

public class PickupLifeGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //Add item
            LifeGem item = Item.CreateInstance<LifeGem>();
            PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
            inventory.AddItem(item);
            //Remove pickup item
            Destroy(this.gameObject);
        }
    }
}
