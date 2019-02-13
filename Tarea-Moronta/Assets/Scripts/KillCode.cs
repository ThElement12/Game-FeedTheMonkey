using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCode : MonoBehaviour
{
    CentroJuegos centro;

    
    private void OnCollisionEnter(Collision collision)
    {
        //centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
        if (collision.gameObject.tag == "Banana")
        {
            if(gameObject.tag == "Foe")
            //if (gameObject.tag == "Body" || gameObject.tag == "Head")
            {
                Destroy(collision.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Foe"));
                centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
                centro.acertado = true;

                // centro.bananaAlive = false;
                CentroJuegos.turno = CentroJuegos.eTurno.Comprobando;
            }

            else if(gameObject.tag == "Respawn")
            {
                Destroy(collision.gameObject);
                centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
                centro.bananaAlive = false;
                CentroJuegos.turno = CentroJuegos.eTurno.Comprobando;
            }

            
        }
        if(collision.gameObject.tag == "Poop")
        {
            if(gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                
                CentroJuegos.turno = CentroJuegos.eTurno.Fin;
            }

           // CentroJuegos.turno = CentroJuegos.eTurno.Comprobando;
        }

    }
}
