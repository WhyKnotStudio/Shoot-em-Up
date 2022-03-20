using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button m_startButton = null;

    private void Awake()
    {
        this.m_startButton = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.m_startButton.onClick.AddListener(this.ChangeScene);
    }

    private void OnDisable()
    {
        this.m_startButton.onClick.RemoveListener(this.ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("InGame_Scene");
    }
}
