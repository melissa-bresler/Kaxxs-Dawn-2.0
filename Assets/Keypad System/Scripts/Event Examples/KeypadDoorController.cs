using UnityEngine;

namespace KeypadSystem
{
    public class KeypadDoorController : MonoBehaviour
    {
        private Animator doorAnim;

        [Header("Animation Name")]
        [SerializeField] private string myAnimation = "OpenDoor";

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        public void PlayAnimation()
        {
            doorAnim.Play(myAnimation, 0, 0.0f);
        }
    }
}
