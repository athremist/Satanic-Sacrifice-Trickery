using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{
    float m_TextSpeed;

    [SerializeField]
    string m_Introduction;
    [SerializeField]
    Text m_Text;
    [SerializeField]
    GameObject m_Skip;

    string m_StoreText;

    void Start()
    {
        m_TextSpeed = 0.05f;

        m_StoreText = "";

        StartCoroutine(TextAdder());
    }

    void Update()
    {
        if (m_StoreText.Length == m_Introduction.Length)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Application.LoadLevel("LevelScene");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (m_Skip.activeSelf)
                {
                    m_TextSpeed = 0.00001f;
                    m_Skip.SetActive(false);
                }
            }
            else
            {
                if (!m_Skip.activeSelf)
                {
                    m_TextSpeed = 0.05f;
                    m_Skip.SetActive(true);
                }
            }
        }
    }

    IEnumerator TextAdder()
    {
        m_StoreText = "";

        for (int i = 0; i < m_Introduction.Length; i++)
        {
            m_StoreText += m_Introduction[i];
            m_Text.text = m_StoreText;

            yield return new WaitForSeconds(m_TextSpeed);
        }

        StartCoroutine(GameTransition());
    }

    IEnumerator GameTransition()
    {
        yield return new WaitForSeconds(23.0f);
        Application.LoadLevel("LevelScene");
    }
}
