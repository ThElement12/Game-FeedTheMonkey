using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteBanana : MonoBehaviour
{
    CentroJuegos centro;
    public void OnCollisionEnter(Collision collision)
    {

        if (gameObject.name != "cube")
        {
            Destroy(collision.gameObject);
            centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
            centro.bananaAlive = false;
        }
      
    }

}