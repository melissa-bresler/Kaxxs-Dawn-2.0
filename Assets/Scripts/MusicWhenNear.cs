using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicWhenNear : MonoBehaviour
{
    private AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            music.Play();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            music.Stop();
        }
    }
}
