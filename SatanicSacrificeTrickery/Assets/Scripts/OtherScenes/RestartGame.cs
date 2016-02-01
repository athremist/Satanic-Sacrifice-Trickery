using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
{
    public void RestartButton()
    {
        Application.LoadLevel("StartScene");
    }
}
