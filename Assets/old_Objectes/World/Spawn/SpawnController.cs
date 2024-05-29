using System;
using System.Collections.Generic;
using Personajes;
using Personajes.Carlos;
using UnityEngine;

namespace old_Objectes.World.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] List<Spawn> spawns = new List<Spawn>();
        private int fase;
        [HideInInspector]public bool ready = false;
        void Start()
        {
            fase = PlayerPrefs.GetInt("fase");
            if (spawns.Count>0)
            {
                foreach (var spawn in spawns)
                {
                    if (spawn.fase == fase)
                    {
                        if (spawn.personatge.CompareTag("Player"))
                        {
                            continue;
                        }
                        Vector3 pos = transform.position;
                        spawn.personatge.transform.position = new Vector3(pos.x, 0, pos.z);
                        spawn.personatge.transform.rotation = transform.rotation;
                        spawn.personatge.GetComponent<NPCController>().spawned = true;
                    }
                }
            }

            ready = true;
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

    [Serializable]
    public class Spawn
    {
        public int fase;
        public GameObject personatge;

        public Spawn(int fase, GameObject personatge)
        {
            this.fase = fase;
            this.personatge = personatge;
        }
    }
}