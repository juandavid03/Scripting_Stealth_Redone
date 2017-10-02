using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public int numero;
    public GameObject manager;
    [SerializeField]
    private bool isActive;
    public Image toDeactivate;
	// Use this for initialization
	void Start ()
    {
        isActive = true;
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision!");
        //AL COLISIONAR CON EL JUGADOR, LE PASA EL NUMERO QUE TIENE QUE AGREGAR AL WORLD MANAGER
        //DESACTIVA EL SWICHE PARA QUE NO PUEDA METER VARIAS VECES EL MISMO NUMERO
        //CAMBIA A GRIS EL COLOR DEL REPRESENTADOR DE UI DEL ORDEN DE LOS SWICHES
        if (collision.gameObject.tag == "jugador" && isActive == true)
        {
            toDeactivate.color = Color.grey;
            Debug.Log("Me Active!");
            manager.GetComponent<WorldManager1>().addSwitch(numero);
            isActive = false;
        }
    }
}
