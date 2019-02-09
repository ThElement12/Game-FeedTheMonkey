using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{
    float _VELOCIDAD = 50;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0,
        Input.GetAxis("Vertical")) * _VELOCIDAD * Time.deltaTime * (gameObject.name == "Articulacion 1" ? -1 : 1));

    }


}