using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager1 : MonoBehaviour
{
    public Queue<int> switchOrder;


    // Use this for initialization
    void Start ()
    {
        //INICIALIZACION DE LA LISTA PARA MANTENER EL ORDEN DE LOS SWICHES
        switchOrder = new Queue<int>();
	}
	
	// Update is called once per frame
	void Update ()
    {


        //PARA COMPROBAR EL ORDEN DE LA LISTA, NO TIENE FUNCION REAL EN EL JUEGO.
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(switchOrder.Peek());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            switchOrder.Dequeue();
        }



    }

    //CORRUTINA PARA PODER VOLVER A ACTIVAR EL PODER
    
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
