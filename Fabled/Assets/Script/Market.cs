using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Market : MonoBehaviour
{

    public GameObject shopPanel;

    public InventorySlot[] buySlots;
    public InventorySlot[] sellSlots;

    public List<ItemScript> itemsSelling = new List<ItemScript>();
    public List<ItemScript> itemsBuying = new List<ItemScript>();

    public TextMeshProUGUI sellValueText;
    public int sellValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shopPanel.SetActive(false);
    }

    private void Start()
    {
    
    }
    private void Update()
    {
        sellValueText.text = "$" + sellValue.ToString();
        if (Input.GetKeyDown(KeyCode.V))
        {
            CalculateSellValue();
        }
    }
    void CalculateSellValue()
    {
        sellValue = 0;
        for (int i = 0; i < sellSlots.Length; i++)
        {
            if(sellSlots[i].GetComponentInChildren<InventoryItem>() != false)
            {
                InventoryItem item = sellSlots[i].GetComponentInChildren<InventoryItem>();
                sellValue += item.item.Sellvalue * item.count;
            }
          
        }
    }
    

}
