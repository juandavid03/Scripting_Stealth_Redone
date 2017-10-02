using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : AIStateBase
{
    public float radio;
    public float alertTime = 0;
    private bool sawEnemy;

    public AlertState(AIControler controlled): base (controlled)
    {
        controled = controlled;
    }
    void Update()
    {
        Debug.Log(alertTime);
        if (sawEnemy)
        {
            alertTime -= Time.deltaTime;
            alertTime = 10;
        }
        if (alertTime > 0)
        {
            GritarSphereCast();
            Gritar();
            
        }
        if (alertTime <= 0)
        {
            ToIdle();
            sawEnemy = false;
        }
    }

    void Gritar()
    {
        Collider[] hitColliders = Physics.OverlapSphere(controled.transform.position, radio);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log(hitColliders[i]);
            if (hitColliders[i].tag == "enemy")
            {
                Debug.Log(hitColliders[i]);
                hitColliders[i].gameObject.GetComponent<AIControler>().MakeTransition(Estados.Chase);

            }
            i++;
        }
    }
    void GritarSphereCast()
    {
        RaycastHit[] hits;
        Ray ray = new Ray(controled.transform.position, Vector3.zero);
        hits = Physics.SphereCastAll(ray, radio);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i]);
            //hits[i].collider.gameObject.GetComponent<AIControler>().MakeTransition(Estados.Chase);
        }
    }
    public override void EjecutarEstado()
    {
        sawEnemy = true;

    }
    public override void IniciarEstado(float time)
    {
        base.IniciarEstado(time);
        alertTime = time;
    }
    private void OnDrawGizmosSelected()
    {
     Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(controled.transform.position, radio);
    }
    void ToIdle()
    {
        controled.MakeTransition(Estados.Idle);
    }
}
