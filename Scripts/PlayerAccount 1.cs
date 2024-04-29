using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour
{
    private static int coins = 0;

    public static void AddCoin()
    {
        coins++;
        Debug.Log("Coin collected! Total coins: " + coins);
    }

    public static int GetCoins()
    {
        return coins;
    }
}
