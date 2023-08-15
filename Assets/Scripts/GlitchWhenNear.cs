using UnityEngine;
using Kino;
using static Unity.VisualScripting.Member;
using System.Collections;

public class GlitchWhenNear : MonoBehaviour
{

    public AnalogGlitch GlitchEffect;

    private AudioSource sfx;

    private bool isGlitching = false;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        //StartCoroutine(GlitchLoop());
    }

    private IEnumerator GlitchLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 10f));
            isGlitching = true;
            StartGlitch();
            yield return new WaitForSeconds(0.5f);
            StopGlitch();
            isGlitching = false;
        }
    }

    /*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            sfx.Play();
        }
    }
    */

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!isGlitching)
            {
                //Vector3 distanceVector = collider.transform.position - transform.position;
                //GlitchEffect.intensity = distanceVector.magnitude;
                StartGlitch();
                //Debug.Log("Glitch Triggered.");
                sfx.Play();
            }
        }
        if (collider.tag == "Trigger")
        {
            //GlitchLoop();
            StartCoroutine(GlitchLoop());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Vector3 distanceVector = collider.transform.position - transform.position;
            StopGlitch();
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
}
