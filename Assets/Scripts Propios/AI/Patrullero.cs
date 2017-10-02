using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullero : AIControler
{
    private void Start()
    {
        currentState = states[Estados.Patrol];
    }
    private void Update()
    {
        currentState.EjecutarEstado();
        Debug.Log(currentState);
        enemigo = LanzarRayo();
        if (enemigo != null)
        {
            ToChase(enemigo);
        }
        else
        {
            ToPatrol();
        }
    }
    void ToChase(GameObject obj)
    {
        Debug.Log("To Chase");
        MakeTransition(Estados.Chase, obj);
    }

    void ToPatrol()
    {
        MakeTransition(Estados.Patrol);
    }
}
