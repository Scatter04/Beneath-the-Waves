using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text balanceText;  

    void Update()
    {
        balanceText.text = "Balance: " + PlayerAccount.GetCoins();
    }
}
