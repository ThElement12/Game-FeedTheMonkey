using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killcode : MonoBehaviour
{
    CentroJuegos centro;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Banana")
        {
            if(gameObject.tag == "Foe" && (gameObject.tag == "Body" || gameObject.tag == "Head"))
            //if (gameObject.tag == "Body" || gameObject.tag == "Head")
            {
                Destroy(collision.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Foe"));
                centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
                centro.acertado = true;
            }

            else if(gameObject.tag == "Respawn")
            {
                Destroy(collision.gameObject);
                centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
                centro.bananaAlive = false;
            }

        }
    }
}
