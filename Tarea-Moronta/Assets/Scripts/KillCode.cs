﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCode : MonoBehaviour
{
    CentroJuegos centro;
    private void OnCollisionEnter(Collision collision)
    {
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
            }

            else if(gameObject.tag == "Respawn")
            {
                Destroy(collision.gameObject);
                centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
                centro.bananaAlive = false;
            }

        }
        if(collision.gameObject.tag == "Poop")
        {
            if(gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player"));

            }
        }
    }
}
