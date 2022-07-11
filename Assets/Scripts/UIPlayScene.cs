using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayScene : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void OnPausePree()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void OnMainPress()
    {
        Time.timeScale = 0f;
        SceneNavigation.NavigateMain();
    }

    public void OnResumePress()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
