using UnityEngine;

namespace KeypadSystem
{
    public class KPInputManager : MonoBehaviour
    {
        [Header("Raycast Pickup Input")]
        public KeyCode interactKey;
        public KeyCode closeKey;

        [Header("Trigger Inputs")]
        public KeyCode triggerInteractKey;

        public static KPInputManager instance;

        /// <summary>
        /// INPUTS IN THE: KeypadTrigger / Keypad Controller scripts
        /// </summary>

        private void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }
    }
}
