using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour
{
    GameObject m_InventoryPanel;
    GameObject m_SlotPanel;
    [SerializeField]
    GameObject m_InventorySlot;
    [SerializeField]
    GameObject m_InventoryItem;

    int m_AmountOfSlots;
    public List<Item> m_Items = new List<Item>();
    public List<GameObject> m_Slots = new List<GameObject>();

    void Start()
    {
        m_AmountOfSlots = 28;
        m_InventoryPanel = GameObject.Find("Inventory Panel");
        m_SlotPanel = m_InventoryPanel.transform.FindChild("Slot Panel").gameObject;

        AddSlots();
        BloodGem item = Item.CreateInstance<BloodGem>();
        AddItem(item);
    }

    void AddSlots()
    {
        for (int i = 0; i < m_AmountOfSlots; ++i)
        {
            Item item = Item.CreateInstance<Item>();
            m_Items.Add(item);
            m_Slots.Add(Instantiate(m_InventorySlot));
            m_Slots[i].transform.SetParent(m_SlotPanel.transform);
            m_Slots[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void AddItem(Item aItem)
    {
        for (int i = 0; i < m_AmountOfSlots; ++i)
        {
            if (m_Slots[i].transform.childCount == 0)
            {
                //m_Items.Add(aItem);
                GameObject item = Instantiate(m_InventoryItem);
                item.transform.SetParent(m_Slots[i].transform);
                item.GetComponent<Image>().sprite = aItem.ItemSprite;
                item.GetComponent<RectTransform>().localPosition = Vector2.zero;
                item.GetComponent<RectTransform>().localScale = new Vector3(0.75f, 0.75f, 0.75f);
                item.name = aItem.ItemName;
                break;
            }
        }
    }

    public void SacrificeItem(GameObject aItem)
    {
        for (int i = 0; i < m_Slots.Count; ++i)
        {
            //Make sure the slot contains something
            if (m_Slots[i].transform.childCount > 0)
            {
                if (m_Slots[i].transform.GetChild(0).gameObject == aItem)
                {
                    Item item = Item.CreateInstance(aItem.name) as Item;

                    PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
                    Boss boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();

                    if (item.ItemSacrificeStat == "Damage")
                    {
                        boss.ApplyDamage(item.ItemValue * item.DamageModifier);
                    }
                    else if (item.ItemSacrificeStat == "AttackSpeed")
                    {
                        player.AddAttackSpeed(item.ItemValue * item.AttackSpeedModifier);
                    }
                    else if (item.ItemSacrificeStat == "AttackDamage")
                    {
                        player.AddDamage(item.ItemValue * item.AttackDamageModifier);
                    }

                    m_Items.RemoveAt(i);
                    Destroy(m_Slots[i].transform.GetChild(0).gameObject);
                    break;
                }
            }
        }
    }

    public void UseItem(GameObject aItem)
    {
        for (int i = 0; i < m_Items.Count; ++i)
        {
            //Make sure the slot contains something
            if (m_Slots[i].transform.childCount > 0)
            {
                if (m_Slots[i].transform.GetChild(0).gameObject == aItem)
                {
                    //Use item here / item buffs
                    Item item = Item.CreateInstance(aItem.name) as Item;

                    PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

                    if (item.ItemStat == "Heal")
                    {
                        player.AddHealth(item.ItemValue * item.HealModifier);
                    }
                    else if (item.ItemStat == "Speed")
                    {
                        player.AddSpeed(item.ItemValue * item.SpeedModifier);
                    }

                    m_Items.RemoveAt(i);
                    Destroy(m_Slots[i].transform.GetChild(0).gameObject);
                    break;
                }
            }
        }
    }
}
