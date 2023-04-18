using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    InventoryManager inventoryManager;
    public ItemScript item;

    [SerializeField] AudioClip pickUpSound;
    private void Awake()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioManager.playSound(pickUpSound, 1f);
            inventoryManager.AddItem(item);
            Destroy(gameObject);
        }
    }
}
