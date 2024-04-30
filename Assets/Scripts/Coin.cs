using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            PlayerAccount.AddCoin();
            Destroy(gameObject);
        }
    }
}