using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    private Button m_homeButton = null;

    private void Awake()
    {
        this.m_homeButton = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.m_homeButton.onClick.AddListener(this.ChangeScene);
    }

    private void OnDisable()
    {
        this.m_homeButton.onClick.RemoveListener(this.ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
}
