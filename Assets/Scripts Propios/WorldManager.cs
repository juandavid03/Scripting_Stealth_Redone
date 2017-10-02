using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public Queue<int> switchOrder;
    public float timeLeft = 10;
    public bool canBeGhostly = true;
    public bool isGhostly = false;
    public GameObject camara;
    public Image ghostTimer;
    public GameObject character;
    public GameObject characterVisor;
    public Material ghost;
    public Material normal;

    // Use this for initialization
    void Start ()
    {
        //INICIALIZACION DE LA LISTA PARA MANTENER EL ORDEN DE LOS SWICHES
        switchOrder = new Queue<int>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ghostTimer.fillAmount = timeLeft / 10;
        if (canBeGhostly == false)
        {
            ghostTimer.color = Color.grey;
        }
        if (isGhostly == true)
        {
            canBeGhostly = false;
            timeLeft -= Time.deltaTime;
        }

        //REGRESA AL MUNDO REAL, Y BLOQUEA EL CAMBIO POR UN TIEMPO (TIEMPO DETERMINADO EN LA CORRUTINA)
        if (timeLeft <= 0)
        {
            StartCoroutine(CoolDownCR());
            timeLeft = 10;
            changeDimension();
        }

        //PARA COMPROBAR EL ORDEN DE LA LISTA, NO TIENE FUNCION REAL EN EL JUEGO.
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(switchOrder.Peek());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            switchOrder.Dequeue();
        }

        //PARA CAMBIAR AL MUNDO FANTASMA
        if (Input.GetKeyDown(KeyCode.P) && canBeGhostly == true)
        {
            changeDimension();
        }

    }

    //CORRUTINA PARA PODER VOLVER A ACTIVAR EL PODER
    private IEnumerator CoolDownCR()
    {
        yield return new WaitForSeconds(3);
        ghostTimer.color = Color.white;
        canBeGhostly = true;
        Debug.Log(canBeGhostly);
    }

    //PARA ACTIVAR EL PODER DE CAMBIAR DE DIMENSION
    //CAMBIA LA VARIABLE DE "isGhostly" PARA QUE LOS ENEMIGOS SEPAN COMO COMPORTARSE RESPECTO A EL EN DETERMINADO MOMENTO.
    //CAMBIA LOS MATERIALES AL PERSONAJE, DE FANTASMAGORICO A NORMAL Y VICEVERSA.
    private void changeDimension()
    {
        isGhostly = !isGhostly;
        if (isGhostly == true)
        {
        character.GetComponent<Renderer>().material = ghost;
        characterVisor.GetComponent<Renderer>().material = ghost;
        }
        else if(isGhostly == false)
        {
        character.GetComponent<Renderer>().material = normal;
        characterVisor.GetComponent<Renderer>().material = normal;
        }
        if (this.gameObject.layer == LayerMask.NameToLayer( "Jugador" ))
        {
            this.gameObject.layer = LayerMask.NameToLayer( "Ignore Rayast" );
        }
        else if (this.gameObject.layer == LayerMask.NameToLayer( "Ignore Rayast" ))
        {
            this.gameObject.layer = LayerMask.NameToLayer( "Jugador" );
        }
        Debug.Log("is ghostly: " + isGhostly);
    }
    
    //METE EL NUMERO DEL SWICHE QUE TOCO A LA LISTA
    public void addSwitch(int numeroSwitch)
    {
        switchOrder.Enqueue(numeroSwitch);
    }
    public void Perder()
    {
        Debug.Log("PERDISTE WEY!");
    }

}
