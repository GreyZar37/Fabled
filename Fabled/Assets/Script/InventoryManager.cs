using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxtStack = 16;
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;

    int selectedSlot = -1;

    void changeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();

        selectedSlot = newValue;
    }

    private void Start()
    {
        changeSelectedSlot(0);
    }


    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 7)
            {
                changeSelectedSlot(number - 1);
            }
        }
    }

    public bool AddItem(ItemScript item)
    {

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];

            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxtStack && itemInSlot.item.stackable)
            {
                itemInSlot.count += (int)Random.Range(item.randomAmount.x, item.randomAmount.y);

                if (itemInSlot.count > 16)
                {
                    itemInSlot.count = 16;
                }
                itemInSlot.refreshCount();
                return true;
            }
        }



        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];

            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;

    }

    void SpawnNewItem(ItemScript item, InventorySlot slot)
    {
        GameObject newItemGameObject = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public ItemScript GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];

        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            ItemScript item =  itemInSlot.item;

            if (use == true)
            {
                itemInSlot.count--;
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.refreshCount();
                }
            }

            return item;
          
        }
        else return null;
    }
}
