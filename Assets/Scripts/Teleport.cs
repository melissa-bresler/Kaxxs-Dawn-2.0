using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>(); //Links sound effect to script
    }

    public void Unlock()
    {
        Debug.Log("Teleport unlocked!");
        sfx.Play(); //Plays sound effect once correct code has been input into the keyboard
    }
}
