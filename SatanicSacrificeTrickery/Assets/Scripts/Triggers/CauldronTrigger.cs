using UnityEngine;
using System.Collections;

public class CauldronTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            player.AtCauldron = true;

            CanvasGroup inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CanvasGroup>();
            if (inventory.alpha == 0)
            {
                inventory.alpha = 1;
                inventory.interactable = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            player.AtCauldron = false;
        }

        CanvasGroup inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CanvasGroup>();
        if (inventory.alpha == 1)
        {
            inventory.alpha = 0;
            inventory.interactable = false;
        }
    }
}
