using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button m_restartButton = null;

    private void Awake()
    {
        this.m_restartButton = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.m_restartButton.onClick.AddListener(this.ChangeScene);
    }

    private void OnDisable()
    {
        this.m_restartButton.onClick.RemoveListener(this.ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("InGame_Scene");
    }
}
