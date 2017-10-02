using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIStateBase
{
    private GameObject target;
    public ChaseState(AIControler controlled): base (controlled)
    {
        controled = controlled;
    }
    public override void EjecutarEstado()
    {
        Persiguir(target);
    }

    private void Persiguir(GameObject obj)
    {
        controled.navMeshAgent.SetDestination(obj.transform.position);
    }

    public override void IniciarEstado(GameObject obj)
    {
        base.IniciarEstado(obj);
        target = obj;
    }
    private void Look()
    {
        Transform player = controled.LanzarRayo().transform;
        if (player != null)
            controled.enemigo = target;
    }
}
