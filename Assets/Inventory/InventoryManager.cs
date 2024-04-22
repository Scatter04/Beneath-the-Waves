using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour{
    
    public GameObject Inventory;
    private bool menuActivated;

    public WeaponSlot[] weaponSlot;
    public keySlot[] keySlot; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory") && menuActivated)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Inventory.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Inventory.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddWeapon(string weaponName, Sprite weaponSprite)
    {
        for (int i = 0; i < weaponSlot.Length; i++)
        {
            if (!weaponSlot[i].isFull)
            {
                weaponSlot[i].AddWeaponSlot(weaponName, weaponSprite);
                return;
            }
        }
    }
    
    public void AddKey(string keyName, Sprite keySprite)
    {
        for (int i = 0; i < keySlot.Length; i++)
        {
            if (!keySlot[i].isFull)
            {
                keySlot[i].AddKeySlot(keyName, keySprite);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < weaponSlot.Length; i++)
        {
            weaponSlot[i].selectedShader.SetActive(false);
        }

        for (int i = 0; i < keySlot.Length; i++)
        {
            keySlot[i].selectedShader.SetActive(false);
        }
    }
}
