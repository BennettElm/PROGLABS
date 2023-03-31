using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int coins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Added " + amount.ToString() + " coins. Total coins: " + coins.ToString());
    }
}

