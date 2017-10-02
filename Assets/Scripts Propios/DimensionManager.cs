using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimensionManager : MonoBehaviour
{

    public float timeLeft = 10;
    public bool canBeGhostly = true;
    public bool isGhostly = false;
    public Image ghostTimer;
    public GameObject[] characterParts;
    //public GameObject characterVisor;
    public Material ghost;
    public Material normal;

	void Update()
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

		//PARA CAMBIAR AL MUNDO FANTASMA
        if (Input.GetKeyDown(KeyCode.P) && canBeGhostly == true)
        {
            changeDimension();
        }

	}
	//PARA ACTIVAR EL PODER DE CAMBIAR DE DIMENSION
    //CAMBIA LA VARIABLE DE "isGhostly" PARA QUE LOS ENEMIGOS SEPAN COMO COMPORTARSE RESPECTO A EL EN DETERMINADO MOMENTO.
    //CAMBIA LOS MATERIALES AL PERSONAJE, DE FANTASMAGORICO A NORMAL Y VICEVERSA.
	
    private IEnumerator CoolDownCR()
    {
        yield return new WaitForSeconds(3);
        ghostTimer.color = Color.white;
        canBeGhostly = true;
        Debug.Log(canBeGhostly);
    }

    private void changeDimension()
    {
        isGhostly = !isGhostly;
        if (isGhostly == true)
        {
            for (int i = 0; i<characterParts.Length; i++)
                characterParts[i].GetComponent<Renderer>().material = ghost;
        }
        else if(isGhostly == false)
        {
            for (int i = 0; i < characterParts.Length; i++)
                characterParts[i].GetComponent<Renderer>().material = normal;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer( "Jugador" ))
        {
            this.gameObject.layer = LayerMask.NameToLayer( "Ignore Raycast" );
        }
        else if (this.gameObject.layer == LayerMask.NameToLayer( "Ignore Raycast" ))
        {
            this.gameObject.layer = LayerMask.NameToLayer( "Jugador" );
        }
        Debug.Log("is ghostly: " + isGhostly);
    }
    
}
