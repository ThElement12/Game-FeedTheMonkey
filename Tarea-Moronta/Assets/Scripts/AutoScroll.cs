using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public GameObject mapa1;
    public GameObject mapa2;
    public GameObject mapa3;
    public GameObject personaje;
    GameObject nextmap;
    CentroJuegos centro;
    // Start is called before the first frame update
    void Start()
    {
        nextmap = Instantiate(mapa1);
        //firstmap.SetActive(false);
        nextmap.transform.position = new Vector3(mapa1.transform.position.x - 19.422f, mapa1.transform.position.y + 4.08948f);
        mapa1 = nextmap;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
