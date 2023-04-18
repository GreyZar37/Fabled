using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Market : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject shopPanel;
    public GameObject PlayerStats;
    public GameObject PlayerInventory;

    public GameObject[] itemsForSale;


    public InventorySlot[] buySlots;


    public InventorySlot[] sellSlots;

    public List<InventoryItem> itemsSelling = new List<InventoryItem>();
    public List<InventoryItem> itemsBuying = new List<InventoryItem>();

    public TextMeshProUGUI sellValueText;
    public TextMeshProUGUI buyValueText;

    public TextMeshProUGUI playerMoneyText;
    public float refreashTimer;
    public GameObject InventoryItemPrefab;

    public int sellValue;
    public int buyValue;

    public AudioClip buySound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopPanel.SetActive(true);
        PlayerStats.SetActive(false);
        PlayerInventory.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInventory.SetActive(false);

        PlayerStats.SetActive(true);
        shopPanel.SetActive(false);
        returnItemToShopSlots();
    }

    private void Start()
    {
      
        InvokeRepeating("refreashShop", 0 , refreashTimer);
    }
    private void Update()
    {
        sellValueText.text = "$" + sellValue.ToString();
        buyValueText.text = "$" + buyValue.ToString();

        playerMoneyText.text = "$" + GameManager.Instance.money.ToString();

    }
    public void CalculateSellValue()
    {

        sellValue = 0;
        itemsSelling.Clear();
        for (int i = 0; i < sellSlots.Length; i++)
        {
            InventoryItem sellItem = sellSlots[i].GetComponentInChildren<InventoryItem>();


            if (sellItem != false)
            {
                if (sellItem.owned)
                {
                    itemsSelling.Add(sellSlots[i].GetComponentInChildren<InventoryItem>());
                    InventoryItem item = sellSlots[i].GetComponentInChildren<InventoryItem>();
                    sellValue += item.item.Sellvalue * item.count;
                }
                else
                {
                    for (int c = 0; c < buySlots.Length; c++)
                    {

                        InventoryItem slotItem = buySlots[c].GetComponentInChildren<InventoryItem>();
                        if (slotItem == false)
                        {
                            sellItem.transform.SetParent(buySlots[c].transform);
                            break;
                        }
                    }
                }
            }

        }
    }

    public void CalculateBuyValue()
    {

        buyValue = 0;
        itemsBuying.Clear();
        for (int i = 0; i < inventoryManager.inventorySlots.Length; i++)
        {
            InventoryItem buyItem = inventoryManager.inventorySlots[i].GetComponentInChildren<InventoryItem>();
            if (buyItem != false && !buyItem.owned)
            {
                itemsBuying.Add(inventoryManager.inventorySlots[i].GetComponentInChildren<InventoryItem>());
                InventoryItem item = inventoryManager.inventorySlots[i].GetComponentInChildren<InventoryItem>();
                buyValue += item.item.BuyValue * item.count;
            }
        }
    }

    public void sell()
    {
        foreach (var item in itemsSelling)
        {
            GameManager.Instance.money += item.item.Sellvalue * item.count;
            Destroy(item.gameObject);

        }
        sellValue = 0;
        itemsSelling.Clear();
        AudioManager.playSound(buySound, 1f);
    }

    public void buy()
    {
        AudioManager.playSound(buySound, 1f);

        if (GameManager.Instance.money >= buyValue)
        {
            foreach (var item in itemsBuying)
            {
                GameManager.Instance.money -= item.item.BuyValue * item.count;
                item.owned = true;

            }
            CalculateBuyValue();
        }

    }

    void returnItemToShopSlots()
    {
        foreach (var item in itemsBuying)
        {

            if (!item.owned)
            {
                for (int i = 0; i < buySlots.Length; i++)
                {
                    if (buySlots[i].GetComponentInChildren<InventoryItem>() == false)
                    {
                        item.transform.SetParent(buySlots[i].transform);
                        break;
                    }
                }
            }
        }
        buyValue = 0;
        itemsBuying.Clear();
    }

    void refreashShop()
    {
        for (int i = 0; i < buySlots.Length; i++)
        {
          
            InventoryItem item = buySlots[i].GetComponentInChildren<InventoryItem>();
            if (item != null)
            {
                itemsBuying.Remove(inventoryManager.inventorySlots[i].GetComponentInChildren<InventoryItem>());
                Destroy(item.gameObject);
            }
        }


        for (int i = 0; i < itemsForSale.Length; i++)
        {
            Instantiate(itemsForSale[i], buySlots[i].transform);
        }
        for (int i = itemsForSale.Length; i < itemsForSale.Length *2; i++)
        {
            Instantiate(itemsForSale[i- itemsForSale.Length], buySlots[i].transform);
        }

    }


}
