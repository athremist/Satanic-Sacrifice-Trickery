using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text m_ItemDescription;

    private void Start()
    {
        Transform descriptionPanel = GameObject.FindGameObjectWithTag("Inventory").transform.GetChild(0).GetChild(2);
        m_ItemDescription = descriptionPanel.GetChild(0).GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerItems inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();

        string itemName = gameObject.name;
        Item item = Item.CreateInstance(itemName) as Item;

        m_ItemDescription.text = "Left click: (Use)\n" + item.ItemDescriptionUse
                               + "\n\nRight click: (Sacrifice)\n" + item.ItemDescriptionSacrifice;
        m_ItemDescription.transform.parent.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_ItemDescription.text = "";
        m_ItemDescription.transform.parent.gameObject.SetActive(false);
    }
}
