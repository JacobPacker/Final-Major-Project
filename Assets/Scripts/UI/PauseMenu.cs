using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject Button;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
                Button.GetComponent<Button>().Select();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
