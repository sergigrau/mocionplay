using UnityEngine;

namespace Personajes
{
    public class NPCController : MonoBehaviour
    {
        [HideInInspector]public bool spawned = false;

        private int reqNum;
        // Start is called before the first frame update
        void Start()
        {
            reqNum = GameObject.FindGameObjectsWithTag("Respawn").Length;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void CheckSpawn()
        {
            if (!spawned && reqNum-- <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
