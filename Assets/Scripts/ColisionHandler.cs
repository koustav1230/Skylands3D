using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionHandler : MonoBehaviour
{

    
    void OnCollisionEnter(Collision obj)
    {

        Debug.Log($"{this.name} colides with {obj.gameObject.name}");
        
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log($"{this.name} is triggered by {other.gameObject.name}");
    }


}
