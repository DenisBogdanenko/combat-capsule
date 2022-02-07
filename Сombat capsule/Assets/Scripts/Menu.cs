using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menuWindow;

    public MonoBehaviour[] componentsToDisable;

    public void OpenMenuWimdow()
    {
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
        Time.timeScale = 0.01f;

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    public void CloseMenuWimdow()
    {
        menuButton.SetActive(true);
        menuWindow.SetActive(false);
        Time.timeScale = 1f;

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
