using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Characters.Commons
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navMesh;

        void Start()
        {
            navMesh = GetComponent<NavMeshAgent>();
        }
        public void MoveTo(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            navMesh.destination = destination;
            navMesh.isStopped = false;
        }

        public void Cancel()
        {
            navMesh.isStopped = true;

        }

    }
}
