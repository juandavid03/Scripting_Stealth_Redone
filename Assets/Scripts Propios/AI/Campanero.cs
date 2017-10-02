using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campanero : AIControler
{
    protected AIControler controlled;
    public float radio;
    public float alertTime;
    //public Campanero(AIControler controlled)
    //{
    //    this.controlled = controlled;
    //}
    // Use this for initialization

    public void Update()
    {
        currentState.EjecutarEstado();
        Debug.Log(currentState);
        enemigo = LanzarRayo();
        if (enemigo != null)
        {
            ToAlert();
        }
    }

    void ToAlert()
    {
       MakeTransition(Estados.Alert);
    }
    void ToIdle()
    {
        MakeTransition(Estados.Idle);
    }


}
