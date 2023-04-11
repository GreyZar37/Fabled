using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
     public bool owned = true;
     public ItemScript item;
     public int count = 1;

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI textDisplayCount;
    public GameObject countBoarder;


    public Transform parentAfterDrag;
    Canvas playerCanvas;

    public Market shop;

    public void InitialiseItem(ItemScript newItem)
    {
        item = newItem;
        image.sprite = newItem.Image;
        owned = true;
        refreshCount();
    }

    private void Start()
    {
        refreshCount();
        playerCanvas = GameObject.FindGameObjectWithTag("PlayerCanvas").GetComponent<Canvas>();
        shop = GameObject.FindAnyObjectByType<Market>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(playerCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        shop.CalculateSellValue();
        shop.CalculateBuyValue();

    }

    public void refreshCount()
    {
        if(count <= 1)
        {
            textDisplayCount.text = "";
            countBoarder.SetActive(false);
        }
        else
        {
            textDisplayCount.text = count.ToString();
            countBoarder.SetActive(true);

        }
    }


}
