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

    // Start is called before the first frame update
    void Start()
    {
        estado = Estado.subiendo;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, _ANGULO));
        if (gameObject.name == "Articulacion 1")
        {

            if (estado == Estado.subiendo && gameObject.transform.rotation.z >= -90f)
            {
                _ANGULO -= 0.05f;
                if (gameObject.transform.rotation.z <= -90f)
                {
                    estado = Estado.bajando;
                }

            }
            if (estado == Estado.bajando && gameObject.transform.rotation.z <= 0f)
            {
                _ANGULO += 0.05f;
                if (gameObject.transform.eulerAngles.z >= 0)
                {
                    estado = Estado.subiendo;
                }
            }

        }
    }
}