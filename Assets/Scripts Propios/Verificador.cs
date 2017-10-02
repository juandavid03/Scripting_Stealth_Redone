using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Verificador : MonoBehaviour
{
    public WorldManager1 manager;
    //PARA VERIFICAR CON VECTOR
    public Vector4 vectorCorrecto;
    public Vector4 vectorUsado;
    //PARA VERIFICAR CON ARRAY
    public int[] arrayCorrecto;
    public int[] arrayUsado;
    public bool isActive = true;
    public bool isCorrect;
    public int arrayLength;
    public GameObject door;
    // Use this for initialization
    void Start()
    {
        manager = manager.GetComponent<WorldManager1>();

        //INICIALIZACION DE LOS ARRAYS PARA LA VERIFICACION.
        arrayUsado = new int[arrayLength];
        arrayCorrecto = new int[5] {1,2,3,4,5};
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isCorrect == true)
            moveDoor();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jugador" && isActive == true)
        {
           //verificarVector();
           verificarArray();
        }
    }
    void moveDoor()
    {
        door.transform.Translate(-Vector3.forward);
    }

    //VERIFICA EL ORDEN DE LOS SWICHES QUE PRESIONO EL JUGADOR, CONTRA UN VECTOR PREVIAMENTE DETERMINADO.
    //PRIMER INTENTO(FUNCIONAL): PROBLEMAS: SOLO FUNCIONA PARA 4 SWICHES, CODIGO MAS LARGO, DEQEUE "MANUAL" DE CADA OBJETO.
    void verificarVector()
    {
        vectorUsado.x = manager.switchOrder.Peek();
        manager.switchOrder.Dequeue();
        vectorUsado.y = manager.switchOrder.Peek();
        manager.switchOrder.Dequeue();
        vectorUsado.z = manager.switchOrder.Peek();
        manager.switchOrder.Dequeue();
        vectorUsado.w = manager.switchOrder.Peek();
        manager.switchOrder.Dequeue();
        if (vectorCorrecto == vectorUsado)
        {
            isCorrect = true;
        }
        else if (vectorCorrecto != vectorUsado)
        {
            manager.Perder();
        }
        Debug.Log(vectorUsado);
        isActive = false;
    }

    //VERIFICA EL ORDEN DE LOS SWICHES QUE PRESIONO EL JUGADOR, CONTRA UN ARRAY PREVIAMENTE DETERMINADO.
    //SEGUNDO INTENTO (FUNCIONAL, MAS ESCALABLE).
    //AGREGA EL PRIMER NUMERO DE LA LISTA, AL ARRAY DE "USADOS", Y LO VERIFICA CONTRA EL PRIMERO DE LA LISTA DE "CORRECTOS"
    //SI ES IGUAL, CONTINUA CON EL SIGUIENTE, SI TODOS SON IGUALES LA VARIABLE ISEQUAL QUEDA TRUE
    //SI ALGUNO ES DIFERENTE, HACE UN BREAK, Y DISPARA EL METODO PERDER.
    void verificarArray()
    {
        isActive = false;
        var isEqual = true;
        for (int i = 0; i < arrayLength; i++)
        {
            arrayUsado[i] = manager.switchOrder.Peek();
            manager.switchOrder.Dequeue();
            if (arrayUsado[i] != arrayCorrecto[i] || arrayCorrecto.Length != arrayUsado.Length)
            {
                isEqual = false;
                manager.Perder();
                break;
            }
        }
        if (isEqual)
        {
            isCorrect = true;
        }


    }
}
