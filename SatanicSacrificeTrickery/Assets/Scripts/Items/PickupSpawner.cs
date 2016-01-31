using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour
{
    int m_RandomNumber;

    void Start()
    {
        m_RandomNumber = Random.Range(1, 101);

        SpawnPickup();
    }

    void SpawnPickup()
    {
        if (m_RandomNumber <= 72)//72%
        {
            GameObject pickup = Instantiate(Resources.Load<GameObject>("Pickups/BloodGem"));
            pickup.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        else if (m_RandomNumber <= 93)//22%
        {
            GameObject pickup = Instantiate(Resources.Load<GameObject>("Pickups/SoulGem"));
            pickup.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        else if (m_RandomNumber <= 100)//7%
        {
            GameObject pickup = Instantiate(Resources.Load<GameObject>("Pickups/LifeGem"));
            pickup.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        //else if (m_RandomNumber <= 60)//20%
        //{
        //    GameObject pickup = Instantiate(Resources.Load<GameObject>("Pickups/BloodGem"));
        //    pickup.transform.position = this.transform.position;
        //    Destroy(this.gameObject);
        //}
        //else if (m_RandomNumber <= 100)//40%
        //{
        //    GameObject pickup = Instantiate(Resources.Load<GameObject>("Pickups/BloodGem"));
        //    pickup.transform.position = this.transform.position;
        //    Destroy(this.gameObject);
        //}
    }
}
