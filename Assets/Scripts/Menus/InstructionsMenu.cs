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
        instructionsMenuUI.SetActive(false); //Disables instructions UI
        Time.timeScale = 1f; //Resumes time
        GameIsPaused = false;
    }

    void Pause()
    {
        instructionsMenuUI.SetActive(true); //Enables instructions UI
        Time.timeScale = 0f; //Stops time
        GameIsPaused = true;

    }
}
