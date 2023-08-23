using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingUI : MonoBehaviour
{
    [SerializeField] private GameObject savingObject;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //Prevents game object with this script from being destroyed when changing scenes
    }

    public void SaveText()
    {
        StartCoroutine(SavingCanvas()); //Invokes co-routine
    }

    IEnumerator SavingCanvas() //Displays savingObject for 1 second regardless of whether game time is paused or not
    {
        savingObject.SetActive(true);

        float startTime = Time.realtimeSinceStartup;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }

        savingObject.SetActive(false);
    }

}
