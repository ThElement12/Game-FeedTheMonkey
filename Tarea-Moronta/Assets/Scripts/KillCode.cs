using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killcode : MonoBehaviour
{
    CentroJuegos centro;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Banana" && (gameObject.tag == "Body" || gameObject.tag == "Head") && gameObject.tag != "Respawn")
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Foe"));
            centro = GameObject.Find("Main Camera").GetComponent<CentroJuegos>();
            centro.acertado = true;
        }
    }
}
