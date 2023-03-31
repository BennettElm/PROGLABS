using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectibleItem
{

    public override void Collect()
    {
        GameManager.Instance.AddCoins(1);
        base.Collect();
    }
}

