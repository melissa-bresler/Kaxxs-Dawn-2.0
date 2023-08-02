using UnityEngine;
using Kino;
using static Unity.VisualScripting.Member;

public class GlitchWhenNear : MonoBehaviour
{

    public AnalogGlitch GlitchEffect;

    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
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
            //Vector3 distanceVector = collider.transform.position - transform.position;
            //GlitchEffect.intensity = distanceVector.magnitude;
            GlitchEffect.colorDrift = 1f;
            GlitchEffect.verticalJump = 0.2f;
            GlitchEffect.scanLineJitter = 0.4f;
            //Debug.Log("Glitch Triggered.");
            sfx.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Vector3 distanceVector = collider.transform.position - transform.position;
            GlitchEffect.colorDrift = 0f;
            GlitchEffect.verticalJump = 0f;
            GlitchEffect.scanLineJitter = 0f;
        }
    }
}
