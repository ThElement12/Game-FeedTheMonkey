using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{
    float _VELOCIDAD = 50;
    public float BSpeedX = 4f;
    public float BSpeedY = 4f;
    GameObject banana;
    public GameObject proyectil;
    GameObject miPadre;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0,
        Input.GetAxis("Vertical")) * _VELOCIDAD * Time.deltaTime * (gameObject.name == "Articulacion 1" ? -1 : 1));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        miPadre = GameObject.Find("Brazo 1");
        banana = Instantiate(proyectil, new Vector3(miPadre.transform.position.x, miPadre.transform.position.y, miPadre.transform.position.z), miPadre.transform.rotation);
        //banana.transform.SetParent(miPadre.transform);

        banana.transform.parent = null;
        banana.GetComponent<Rigidbody>().AddForce( BSpeedX* gameObject.transform.position.x * -1,
            BSpeedY* gameObject.transform.position.y * -1, gameObject.transform.position.z*-1, ForceMode.Impulse);
    }
}