using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionT : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void onCollisionEnter(Collision col) 
    {
       if(col.gameObject.tag == "Enemy") 
       {
            Destroy(col.gameObject);

       }

    }
}
