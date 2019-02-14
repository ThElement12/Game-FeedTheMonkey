using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    // Start is called before the first frame update

    public float BSpeedX = 4f;
    bool derecha = true;
    public float BSpeedY = 4f;
    GameObject banana;
    public GameObject proyectil;
    GameObject miPadre;
    GameObject objetivo;
    CentroJuegos centro;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dispararBanana()
    {
        miPadre = GameObject.Find("Disparador");
        banana = Instantiate(proyectil, new Vector3(miPadre.transform.position.x, miPadre.transform.position.y, miPadre.transform.position.z), miPadre.transform.rotation);

        banana.GetComponent<Rigidbody>().AddForce(miPadre.transform.rotation * new Vector3(gameObject.transform.position.x * (derecha ? -5: 5), gameObject.transform.position.y)
        , ForceMode.Impulse);
        derecha = !derecha;
        banana.transform.parent = null;
    }
    public void dispararPoop()
    {
        miPadre = GameObject.FindGameObjectWithTag("Foe");
        objetivo = GameObject.FindGameObjectWithTag("Player");

        banana = Instantiate(proyectil, objetivo.transform);
        banana.transform.position = new Vector3(miPadre.transform.position.x +2, miPadre.transform.position.y, miPadre.transform.position.z);
        banana.transform.parent = null;
        banana.GetComponent<Rigidbody>().AddForce(new Vector3(3, -1, 0)*BSpeedX, ForceMode.Impulse);

       
                

        
        
    }
}
