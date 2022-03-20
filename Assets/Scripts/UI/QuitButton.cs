using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button m_quitButton = null;

    private void Awake()
    {
        this.m_quitButton = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.m_quitButton.onClick.AddListener(this.EndGame);
    }

    private void OnDisable()
    {
        this.m_quitButton.onClick.RemoveListener(this.EndGame);
    }

    private void EndGame()
    {
        Application.Quit();
    }
}
