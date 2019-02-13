using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteBanana : MonoBehaviour
{
    CentroJuegos centro;
    public void OnCollisionEnter(Collision collision)
    {
        //Esto destruye el proyectil (banana) al entrar en contacto


        if (gameObject.name == "Respawn")
        {
            Destroy(collision.gameObject);
            centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
            centro.bananaAlive = false;         
        }
      
    }

}