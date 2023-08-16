using UnityEngine;

namespace KeypadSystem
{
    public class KeypadItem : MonoBehaviour
    {
        [SerializeField] private KeypadController _keypadController = null;

        public void ShowKeypadUI()
        {
            _keypadController.ShowKeypad();
        }
    }
}
