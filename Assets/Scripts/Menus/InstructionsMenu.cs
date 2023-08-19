using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject instructionsMenuUI;

    public void QuestionClicked()
    {

        if (GameIsPaused)
        {
            Resume();
        }
        else if (!GameIsPaused)
        {
            Pause();
        }
    }

    public void Resume()
    {
        instructionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        instructionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
}
