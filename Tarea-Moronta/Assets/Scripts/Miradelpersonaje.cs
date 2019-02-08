using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miradelpersonaje : MonoBehaviour
{
    float _ANGULO = 0;

    enum Estado
    {
        subiendo,
        bajando
    }

    Estado estado;
    int _NEGACION = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0,0,_ANGULO));
        if(gameObject.name == "Articulacion 1")
        {

            if (estado == Estado.subiendo && _ANGULO >= -90)
            {
                _ANGULO -= 0.05f;      
                if(_ANGULO == -90)
                {
                    estado = Estado.bajando;
                }
                
            } 
            if(estado == Estado.bajando && _ANGULO <= 0)
            {
                _ANGULO += 0.05f;
                if(_ANGULO == 0)
                {
                    estado = Estado.subiendo;
                }
            }

        }
    }
}
