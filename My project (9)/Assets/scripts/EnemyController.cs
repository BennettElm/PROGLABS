using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private int health = 5;

    public int Health
    {
        get { return health; }
        set { health = Mathf.Max(value, 0); }
    }

    public IEnumerator DamageEnemy(int damage, float delay)
    {
        yield return new WaitForSeconds(delay);
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
