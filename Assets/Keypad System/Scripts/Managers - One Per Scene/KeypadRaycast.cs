using UnityEngine;

namespace KeypadSystem
{
    [RequireComponent(typeof(Camera))]
    public class KeypadRaycast : MonoBehaviour
    {
        [Header("Raycast Features")]
        [SerializeField] private float interactDistance = 5;
        private KeypadItem keypadItem;
        private Camera _camera;

        [Header("Raycast Keypad Tag")]
        [SerializeField] private string keypadTag = "Keypad";

        void Start()
        {
            _camera = GetComponent<Camera>();
        }

        void Update()
        {
            if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, interactDistance))
            {
                var examineItem = hit.collider.GetComponent<KeypadItem>();
                if (examineItem != null && examineItem.CompareTag(keypadTag))
                {
                    keypadItem = examineItem;
                    HighlightCrosshair(true);
                }
                else
                {
                    ClearInteractable();
                } 
            }
            else
            {
                ClearInteractable();
            }

            if (keypadItem != null)
            {
                if (Input.GetKeyDown(KPInputManager.instance.interactKey))
                {
                    keypadItem.ShowKeypadUI();
                }
            }
        }

        private void ClearInteractable()
        {
            if (keypadItem != null)
            {
                HighlightCrosshair(false);
                keypadItem = null;
            }
        }

        void HighlightCrosshair(bool on)
        {
            KPUIManager.instance.HighlightCrosshair(on);
        }
    }
}
