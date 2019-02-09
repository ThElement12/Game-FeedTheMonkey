using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCode : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Banana")
        {
            Destroy(other.gameObject);
            
        }
    }
}
