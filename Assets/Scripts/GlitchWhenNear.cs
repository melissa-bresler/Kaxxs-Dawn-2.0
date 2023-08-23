using UnityEngine;
using Kino;
using static Unity.VisualScripting.Member;
using System.Collections;

public class GlitchWhenNear : MonoBehaviour
{

    public AnalogGlitch GlitchEffect;

    private AudioSource sfx;

    private bool isGlitching = false;

    private bool glitchLoop = false;

    void Start()
    {
        sfx = GetComponent<AudioSource>(); //Links audio to script
    }
   
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Trigger") //If collision with trigger tag
        {
            glitchLoop = true;
            StartCoroutine(GlitchLoop()); //Invokes co-routine
        }
    }

    private void OnTriggerStay(Collider collider)
    {

        if (collider.tag == "Player") //If collision with player
        {
            if (!isGlitching)
            {
                StartGlitch();
                sfx.Play(); //Plays sound effect
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player") //If collision with player
        {
            StopGlitch();
        }
        if (collider.tag == "Trigger") //If collision with trigger tag
        {
            glitchLoop = false; //Stops the glitch loop
        }
    }

    private void StartGlitch() //Starts the glitch effect
    {
        GlitchEffect.colorDrift = 1f;
        GlitchEffect.verticalJump = 0.2f;
        GlitchEffect.scanLineJitter = 0.4f;
    }

    private void StopGlitch() //Stops the glitch effect
    {
        GlitchEffect.colorDrift = 0f;
        GlitchEffect.verticalJump = 0f;
        GlitchEffect.scanLineJitter = 0f;
    }

    private IEnumerator GlitchLoop()
    {
        while (glitchLoop)
        {
            yield return new WaitForSeconds(Random.Range(2f, 7f)); //Waits a random amount of time between 2-7 seconds
            isGlitching = true;
            StartGlitch(); //Starts glitch effect
            yield return new WaitForSeconds(0.5f); //Waits half a seconds
            StopGlitch(); //Stops glitch effect
            isGlitching = false;
        }
    }
}
