using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicWhenNear : MonoBehaviour
{
    private AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>(); //Links music to script
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player") //If collision with player
        {
            music.Play(); //Plays music
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player") //If collision with player
        {
            music.Stop(); //Stops music
        }
    }
}
