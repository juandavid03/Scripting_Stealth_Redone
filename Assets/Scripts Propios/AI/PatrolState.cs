using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AIStateBase
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private int nextWayPoint;

    public PatrolState(AIControler controlled): base (controlled)
    {
        controled = controlled;
    }
    void Start()
    {
        agent = controled.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        SetCurrentPath();

    }

    public override void EjecutarEstado()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (!controled.navMeshAgent.IsMoving)
        {
            nextWayPoint = (nextWayPoint + 1) % controled.wayPoints.Length;
            SetCurrentPath();
        }
    }

    private void SetCurrentPath()
    {
        controled.navMeshAgent.SetDestination(controled.wayPoints[nextWayPoint].position);
    }

}
