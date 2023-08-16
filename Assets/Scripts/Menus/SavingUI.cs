using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingUI : MonoBehaviour
{
    [SerializeField] private GameObject savingObject;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveText()
    {
        StartCoroutine(SavingCanvas());
    }

    IEnumerator SavingCanvas()
    {
        savingObject.SetActive(true);
        Debug.Log("Saving text should appear now.");

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
