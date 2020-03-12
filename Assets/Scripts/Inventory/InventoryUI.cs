﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Transform itemsPerent;
    InventorySlot[ ] slots;
    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start(){
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsPerent.GetComponentsInChildren<InventorySlot>( );
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive( !inventoryUI.activeSelf );
        }
    }

    void UpdateUI()
    {
        Debug.Log( "UPDATING UI" );
        for(int i = 0 ; i < slots.Length ; i++ )
        {
            if(i <inventory.items.Count)
            {
                slots[ i ].AddItem( inventory.items[ i ] );
            }
            else
            {
                slots[ i ].ClearSlot( );
            }
        }
    }
}
