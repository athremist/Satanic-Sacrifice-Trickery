using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
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
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, m_Speed * Time.deltaTime);
    }
}
