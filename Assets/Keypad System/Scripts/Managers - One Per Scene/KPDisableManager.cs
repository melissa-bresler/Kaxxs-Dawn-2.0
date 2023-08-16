using UnityEngine;

namespace KeypadSystem
{
    public class KPDisableManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private PlayerMovement playerMovemenetScript = null;

        
        public static KPDisableManager instance;

        
        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }
        
        private void Start()
        {
            //player = GameObject.FindWithTag("Player");
            playerMovemenetScript = player.GetComponent<PlayerMovement>();
            //Debug.Log("Player status: " + player + "\n Script: " + playerMovemenetScript);
        }

        public void DisablePlayer(bool disable)
        {
            playerMovemenetScript.Enabled = !disable;
            //KPUIManager.instance.ShowCrosshair(disable);
        }
    }
}
