using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class keySlot : MonoBehaviour, IPointerClickHandler
{
    //Key data
    public string keyName;
    public Sprite keySprite;
    public bool isFull;
    public Color color;

    //Key slot
    [SerializeField]
    private Image keyImage;

    public GameObject selectedShader;
    public bool thisKeySelected;
    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddKeySlot(string keyName, Sprite keySprite)
    {
        this.keyName = keyName;
        this.keySprite = keySprite;
        isFull = true;

        keyImage.sprite = keySprite;
        color = keyImage.color;
        color.a = 255;
        keyImage.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisKeySelected = true;
    }
}
