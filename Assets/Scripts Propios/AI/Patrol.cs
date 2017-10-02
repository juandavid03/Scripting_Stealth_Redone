    // Patrol.cs tomado de la documentacion de unity, para el movimineto en el Nav Mesh
    //Adaptado para funcionar con el estado de patrulla.
    using UnityEngine;
    using System.Collections;
	using UnityEngine.AI;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;


        void Start () 
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() 
        {
            if (points.Length == 0)
                return;

            agent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Length;
        }


        void Update () 
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }