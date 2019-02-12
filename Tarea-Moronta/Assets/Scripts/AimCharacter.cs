using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{
    float _VELOCIDAD = 1f;
    public float periodo = 150;
    public float amplitud = 100;
    float VELOCIDADANGULAR;
    float angulo;
    float variacion;

    // Start is called before the first frame update
    void Start()
    {
       VELOCIDADANGULAR = (Mathf.PI / periodo) * 5;
    }
    
    // Update is called once per frame
    void Update()
    {
        angulo += (2 * Mathf.PI) / periodo;

        variacion = amplitud * Mathf.Sin(angulo);

        if(gameObject.transform.rotation.z < 90)
        {
            gameObject.GetComponent<Transform>().Rotate(Vector3.forward, -variacion * Time.deltaTime * _VELOCIDAD);
        }
        else
        {
            gameObject.GetComponent<Transform>().Rotate(Vector3.forward, variacion * Time.deltaTime * _VELOCIDAD);
        }
        
  //      gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0,
//        Input.GetAxis("Vertical")) * _VELOCIDAD * Time.deltaTime * (gameObject.name == "Articulacion 1" ? -1 : 1));
        
    }


}