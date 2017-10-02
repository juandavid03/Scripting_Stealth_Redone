using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatico : AIControler
{
    private void Start()
    {
        currentState = states[Estados.Idle];
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
            ToIdle();
        }
    }
    void ToChase(GameObject obj)
    {
        Debug.Log("To Chase");
        MakeTransition(Estados.Chase, obj);
    }

    void ToIdle()
    {
        MakeTransition(Estados.Idle);
    }
}
