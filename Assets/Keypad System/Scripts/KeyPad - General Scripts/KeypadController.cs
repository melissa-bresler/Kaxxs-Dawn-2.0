/// <summary>
/// PLEASE REMEMBER THAT THIS USES A CUSTOM INSPECTOR - WHEN YOU ADD VARIABLES / FIELDS TO THIS SCRIPT THEY WON'T APPEAR IN THE INSPECTOR UNLESS YOU EDIT "KeypadControllerEditor"
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

namespace KeypadSystem
{
    [System.Serializable]
    public class KeypadCodes
    {
        public string keypadCode;
        [Space(10)]
        public UnityEvent keypadEvent;
    }

    public class KeypadController : MonoBehaviour
    {
        [SerializeField] private KeypadType _keypadType = KeypadType.None;
        private enum KeypadType { None, Modern, Scifi, Keyboard };

        [SerializeField] private KeypadCodes[] keypadCodesList = null;

        [SerializeField] private Sound keypadBeep = null;
        [SerializeField] private Sound keypadDenied = null;

        public bool isTriggerEvent = false;
        [SerializeField] private KeypadTrigger triggerObject = null;

        public int inputLimit;
        private bool isOpen = false;

        public void ShowKeypad()
        {
            KPDisableManager.instance.DisablePlayer(true);
            KPUIManager.instance.SetKeypadController(this);
            isOpen = true;
            SwitchKeypadType(true);

            if (isTriggerEvent)
            {
                KPUIManager.instance.ShowInteractPrompt(false);
                triggerObject.enabled = false;
            }
        }

        public void CloseKeypad()
        {
            SwitchKeypadType(false);
            isOpen = false;
            KPUIManager.instance.KeyPressClr();
            KPDisableManager.instance.DisablePlayer(false);

            if (isTriggerEvent)
            {
                KPUIManager.instance.ShowInteractPrompt(true);
                triggerObject.enabled = true;
            }
        }

        void SwitchKeypadType(bool on)
        {
            switch (_keypadType)
            {
                case KeypadType.Modern:
                    KPUIManager.instance.ShowModernCanvas(on);
                    break;
                case KeypadType.Scifi:
                    KPUIManager.instance.ShowScifiCanvas(on);
                    break;
                case KeypadType.Keyboard:
                    KPUIManager.instance.ShowKeyboardCanvas(on);
                    break;
            }
        }

        public void CheckCode(InputField numberInputField)
        {
            try
            {
                var code = keypadCodesList.First(x => x.keypadCode == numberInputField.text);
                code.keypadEvent.Invoke();
            }
            catch
            {
                KeyPadDeniedSound();
            }
        }

        private void Update()
        {
            if (isOpen)
            {
                if (Input.GetKeyDown(KPInputManager.instance.closeKey))
                {
                    CloseKeypad();
                }
            }
        }

        public void SingleBeepSound()
        {
            KPAudioManager.instance.Play(keypadBeep.name);
        }

        public void KeyPadDeniedSound()
        {
            KPAudioManager.instance.Play(keypadDenied.name);

        }
    }
}
