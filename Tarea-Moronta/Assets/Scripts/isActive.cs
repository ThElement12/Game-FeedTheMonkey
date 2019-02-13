using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isActive : MonoBehaviour
{
    static bool isactive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(isactive);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
