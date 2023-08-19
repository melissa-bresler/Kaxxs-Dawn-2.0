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
        sfx = GetComponent<AudioSource>();
    }
   
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Trigger")
        {
            glitchLoop = true;
            StartCoroutine(GlitchLoop());
        }
    }
    

    private void OnTriggerStay(Collider collider)
    {

        if (collider.tag == "Player")
        {
            if (!isGlitching)
            {
                StartGlitch();
                sfx.Play();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StopGlitch();
        }
        if (collider.tag == "Trigger")
        {
            glitchLoop = false;
        }
    }

    private void StartGlitch()
    {
        GlitchEffect.colorDrift = 1f;
        GlitchEffect.verticalJump = 0.2f;
        GlitchEffect.scanLineJitter = 0.4f;
    }

    private void StopGlitch()
    {
        GlitchEffect.colorDrift = 0f;
        GlitchEffect.verticalJump = 0f;
        GlitchEffect.scanLineJitter = 0f;
    }

    private IEnumerator GlitchLoop()
    {
        while (glitchLoop)
        {
            yield return new WaitForSeconds(Random.Range(2f, 7f));
            isGlitching = true;
            StartGlitch();
            yield return new WaitForSeconds(0.5f);
            StopGlitch();
            isGlitching = false;
        }
    }
}
