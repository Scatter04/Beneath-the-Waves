using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour, IPointerClickHandler
{
    //Weapon data
    public string weaponName;
    public Sprite weaponSprite;
    public bool isFull;
    public Color color;

    //Weapon slot
    [SerializeField]
    private Image weaponImage;

    public GameObject selectedShader;
    public bool thisWeaponSelected;
    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddWeaponSlot(string weaponName, Sprite weaponSprite)
    {
        this.weaponName = weaponName;
        this.weaponSprite = weaponSprite;
        isFull = true;

        weaponImage.sprite = weaponSprite;
        color = weaponImage.color;
        color.a = 255;
        weaponImage.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisWeaponSelected = true;
    }
}
