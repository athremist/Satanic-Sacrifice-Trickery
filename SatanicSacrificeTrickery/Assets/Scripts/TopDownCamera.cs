using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{
    const float m_Speed = 10;

    public Vector3 targetPos
    {
        get;
        set;
    }

    void Start()
    {
        targetPos = this.transform.position;
        //Camera.main.pixelRect = new Rect(0, 0, 1920, 1080);
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, m_Speed * Time.deltaTime);
    }
}
