using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType
{
    Coin,
    PowerUp,
    HealthPack
}


public class CollectibleItem : MonoBehaviour
{

    public CollectibleType collectibleType;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Collect();
        }
    }

    public virtual void Collect()
    {
        Debug.Log("Collected a coin" + collectibleType.ToString());
        Destroy(gameObject);
    }



}
