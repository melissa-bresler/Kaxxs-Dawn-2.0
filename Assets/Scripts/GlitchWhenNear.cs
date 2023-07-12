using UnityEngine;
using Kino;

public class GlitchWhenNear : MonoBehaviour
{

    public AnalogGlitch GlitchEffect;

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
