using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCode : MonoBehaviour
{
    CentroJuegos centro;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Banana")
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Foe"));
            centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
            centro.acertado = true;
            
            
            
        }
    }
}
