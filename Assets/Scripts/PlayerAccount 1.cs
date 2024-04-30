using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAccount
{
    private static int coins = 0;
    private static int bullets = 0;

    public static void AddCoin()
    {
        coins++;
        Debug.Log("Current Coins: " + coins);
    }

    public static void AddBullets(int amount)
    {
        bullets += amount;
        Debug.Log("Added bullets: " + amount + ", Total Bullets: " + bullets);
    }

    public static int GetCoins()
    {
        return coins;
    }

    public static int GetBullets()
    {
        return bullets;
    }
}


