using UnityEngine;

namespace KeypadSystem
{
    public class KeypadTrigger : MonoBehaviour
    {
        [Header("Keypad Object")]
        [SerializeField] private KeypadItem keypadObject = null;

        private bool canUse;

        private void Update()
        {
            ShowKeypadUI();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                canUse = true;
                KPUIManager.instance.ShowInteractPrompt(canUse);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Player")
            {
                    canUse = false;
                    KPUIManager.instance.ShowInteractPrompt(canUse);
            }
        }

        void ShowKeypadUI()
        {
            if (canUse)
            {
                if (Input.GetKeyDown(KPInputManager.instance.triggerInteractKey))
                {
                    keypadObject.ShowKeypadUI();
                    KPUIManager.instance.ShowInteractPrompt(false);
                }
            }
        }
    }
}
