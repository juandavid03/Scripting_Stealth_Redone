using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIStateBase
{

    public IdleState(AIControler controlled): base (controlled)
    {
        controled = controlled;
    }
    public override void EjecutarEstado()
    {
    }
}
