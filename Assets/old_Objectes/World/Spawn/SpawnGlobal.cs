using System;
using System.Collections;
using System.Collections.Generic;
using old_Objectes.World.Spawn;
using Personajes;
using UnityEngine;

public class SpawnGlobal : MonoBehaviour
{
    private GameObject[] spawns;
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var o in spawns)
        {
            if (!o.GetComponent<SpawnController>().ready)
            {
                return;
            }
        }
        Despawn();
    }

    void Despawn()
    {
        foreach (var o in GameObject.FindGameObjectsWithTag("NPC"))
        {
            o.GetComponent<NPCController>().CheckSpawn();
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<NPCController>().CheckSpawn();
        Destroy(GetComponent<SpawnGlobal>());
    }
}