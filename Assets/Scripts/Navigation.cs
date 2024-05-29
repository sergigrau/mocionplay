using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform[] targets; // Los objetivos a los que los personajes se moverán
    private NavMeshAgent[] agents; // Los componentes NavMeshAgent de los personajes

    void Start()
    {
        agents = new NavMeshAgent[targets.Length];
        // Obtener los componentes NavMeshAgent de los personajes
        for (int i = 0; i < targets.Length; i++)
        {
            agents[i] = InstantiateCharacter(targets[i]);
        }

        // Iniciar el movimiento de los personajes
        foreach (NavMeshAgent agent in agents)
        {
            SetRandomDestination(agent);
        }
    }

    // Crear un nuevo personaje y configurar su NavMeshAgent
    private NavMeshAgent InstantiateCharacter(Transform target)
    {
        GameObject character = new GameObject("Character");
        NavMeshAgent agent = character.AddComponent<NavMeshAgent>();
        agent.Warp(target.position); // Colocar al personaje en la posición inicial
        return agent;
    }

    // Establecer un destino aleatorio para el personaje
    private void SetRandomDestination(NavMeshAgent agent)
    {
        if (agent == null)
            return;

        Vector3 randomDestination = RandomNavmeshLocation(10f); // Rango de búsqueda del destino aleatorio
        agent.SetDestination(randomDestination);
    }

    // Obtener una posición aleatoria en la malla de navegación
    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }
}

