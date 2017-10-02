using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIStateBase
{
    protected AIControler controled;

    public AIStateBase(AIControler controlled)
    {
        this.controled = controlled;
    }

    public abstract void EjecutarEstado();
    public virtual void IniciarEstado(GameObject obj)
    {
    }
    public virtual void IniciarEstado(float time)
    {
    }


    public virtual void OnTriggerEnter(Collider other)
    {
    }
}
