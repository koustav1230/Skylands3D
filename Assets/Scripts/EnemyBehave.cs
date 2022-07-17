using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehave : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{this.name} hitted by {other.gameObject.name}");
       
        Destroy(gameObject,2f);
    }

}
