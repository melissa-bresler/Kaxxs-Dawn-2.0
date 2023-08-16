using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTriggerVolume2 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam2;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                CameraSwitcher.SwitchCamera(cam2);

        }
            
    }
    
}
