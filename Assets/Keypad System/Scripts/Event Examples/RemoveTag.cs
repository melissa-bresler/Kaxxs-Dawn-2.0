using UnityEngine;

namespace KeypadSystem
{
    public class RemoveTag : MonoBehaviour
    {
        [SerializeField] private GameObject taggedObject = null;

        public void RemoveTags()
        {
            taggedObject.tag = "Untagged";
        }
    }
}
