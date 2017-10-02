using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControler : MonoBehaviour
{
    //public float sightRange = 20f;
    //public Transform[] wayPoints;
    //public Transform eyes;
    //public Vector3 offset = new Vector3(0, .5f, 0);
    //public float searchingTurnSpeed = 120f;
    //public float searchingDuration = 4f;
    //public NavMeshAgentController navMeshAgent;
    //[HideInInspector]
    //public Transform chaseTarget;

    [SerializeField]
    protected AIStateBase currentState;
    protected Dictionary<Estados, AIStateBase> states;
    public GameObject enemigo;
    public NavMeshAgentController navMeshAgent;
    public Transform[] wayPoints;


    private void Awake()
    {
        states = new Dictionary<Estados, AIStateBase>();
        states.Add(Estados.Patrol, new PatrolState(this));
        states.Add(Estados.Alert, new AlertState(this));
        states.Add(Estados.Chase, new ChaseState(this));
        states.Add(Estados.Idle, new IdleState(this));
        currentState = states[Estados.Idle];
        currentState.EjecutarEstado();
    }

    private void Update()
    {
        currentState.EjecutarEstado();
        LanzarRayo();
    }

    public void MakeTransition(Estados state)
    {
        currentState = states[state];
        //currentState.IniciarEstado();
    }
    public void MakeTransition(Estados state, GameObject obj)
    {
        currentState = states[state];
        currentState.IniciarEstado(obj);
    }
    public void MakeTransition(Estados state, float time)
    {
        currentState = states[state];
        currentState.IniciarEstado(time);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    public GameObject LanzarRayo()
    {
        RaycastHit sphereHit;
        var posicionRayo = this.transform.position;
        Ray rayo = new Ray(this.transform.position, Vector3.forward);

        if (Physics.Raycast(rayo, out sphereHit, 30))
        {
            Debug.DrawLine(transform.position, sphereHit.point, Color.red);
            if (sphereHit.transform.gameObject.name == "Jugador")
            {
                var ghostly = sphereHit.transform.gameObject.GetComponent<DimensionManager>().isGhostly;
                if (!ghostly)
                {
                    enemigo = sphereHit.transform.gameObject;
                    StartCoroutine(OlvidarEnemigo());
                    return enemigo;
                }
            }

            return enemigo;
        }
        return null;
    }

    private IEnumerator OlvidarEnemigo()
    {
        yield return new WaitForSeconds(3);
        enemigo = null;
    }
}
