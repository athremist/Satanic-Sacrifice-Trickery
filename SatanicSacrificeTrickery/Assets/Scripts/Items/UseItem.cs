using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour, IPointerDownHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //Left click
        if (Input.GetMouseButtonDown(0))
        {
            PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
            inventory.UseItem(this.transform.gameObject);
        }

        //Right click
        if (Input.GetMouseButtonDown(1))
        {
            PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (player.AtCauldron == true)
            {
                PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
                inventory.SacrificeItem(this.transform.gameObject);
            }
        }
    }
}
