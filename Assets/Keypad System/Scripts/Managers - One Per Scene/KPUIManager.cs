using UnityEngine;
using UnityEngine.UI;

namespace KeypadSystem
{
    public class KPUIManager : MonoBehaviour
    {
        [Header("Crosshair")]
        [SerializeField] private Image crosshair = null;

        [Header("UI Prompt")]
        [SerializeField] private GameObject interactPrompt = null;

        [Header("Keypad Type Input Fields")]
        [SerializeField] private InputField modernCodeText = null;
        [SerializeField] private InputField scifiCodeText = null;
        [SerializeField] private InputField keyboardCodeText = null;

        [Header("Phone Type Canvas Fields")]
        [SerializeField] private GameObject modernCanvas = null;
        [SerializeField] private GameObject scifiCanvas = null;
        [SerializeField] private GameObject keyboardCanvas = null;

        private bool firstClick;
        private KeypadController _keypadController;

        private KeypadType _keypadType;
        private enum KeypadType { None, Modern, Scifi, Keyboard };

        public static KPUIManager instance;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void SetKeypadController(KeypadController _myController)
        {
            _keypadController = _myController;
        }

        public void ShowModernCanvas(bool on)
        {
            modernCanvas.SetActive(on);
            _keypadType = KeypadType.Modern;
        }

        public void ShowScifiCanvas(bool on)
        {
            scifiCanvas.SetActive(on);
            _keypadType = KeypadType.Scifi;
        }

        public void ShowKeyboardCanvas(bool on)
        {
            keyboardCanvas.SetActive(on);
            _keypadType = KeypadType.Keyboard;
        }

        public void KeyPressString(string keyString)
        {
            _keypadController.SingleBeepSound();

            if (!firstClick)
            {
                if (modernCodeText != null)
                {
                    modernCodeText.text = string.Empty;
                }
                if (scifiCodeText != null)
                {
                    scifiCodeText.text = string.Empty;
                }
                if (keyboardCodeText != null)
                {
                    keyboardCodeText.text = string.Empty;
                }
                firstClick = true;
            }

            switch (_keypadType)
            {
                case KeypadType.Modern:
                    if (modernCodeText.characterLimit <= (_keypadController.inputLimit - 1))
                    {
                        modernCodeText.characterLimit++;
                        modernCodeText.text += keyString;
                    }
                    break;
                case KeypadType.Scifi:
                    if (scifiCodeText.characterLimit <= (_keypadController.inputLimit - 1))
                    {
                        scifiCodeText.characterLimit++;
                        scifiCodeText.text += keyString;
                    }
                    break;
                case KeypadType.Keyboard:
                    if (keyboardCodeText.characterLimit <= (_keypadController.inputLimit - 1))
                    {
                        keyboardCodeText.characterLimit++;
                        keyboardCodeText.text += keyString;
                    }
                    break;
            }
        }

        public void KeyPressEnt()
        {
            _keypadController.SingleBeepSound();
            switch(_keypadType)
            {
                case KeypadType.Modern: _keypadController.CheckCode(modernCodeText);
                    break;
                case KeypadType.Scifi: _keypadController.CheckCode(scifiCodeText);
                    break;
                case KeypadType.Keyboard: _keypadController.CheckCode(keyboardCodeText);
                    break;

            }
        }

        public void KeyPressClr()
        {
            _keypadController.SingleBeepSound();

            switch (_keypadType)
            {
                case KeypadType.Modern: ResetInputField(modernCodeText);
                    break;
                case KeypadType.Scifi: ResetInputField(scifiCodeText);
                    break;
                case KeypadType.Keyboard: ResetInputField(keyboardCodeText);
                    break;
            }
        }

        void ResetInputField(InputField inputText)
        {
            inputText.characterLimit = 0;
            inputText.text = string.Empty;
        }

        public void KeyPressClose()
        {
            KeyPressClr();
            _keypadController.SingleBeepSound();
            _keypadController.CloseKeypad();
        }

        public void HighlightCrosshair(bool on)
        {
            if (on)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }

        public void ShowInteractPrompt(bool on)
        {
            interactPrompt.SetActive(on);
        }

        public void ShowCrosshair(bool on)
        {
            crosshair.enabled = !on;
            if (on)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;  
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
