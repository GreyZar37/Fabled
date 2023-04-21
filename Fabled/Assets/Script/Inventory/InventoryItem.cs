using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
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
    public Discription box;

    public AudioClip PickupSound;
    public AudioClip DropSound;

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
        box = GameObject.FindAnyObjectByType<Discription>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(playerCanvas.transform);
        AudioManager.playSound(PickupSound, 1f);
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
        AudioManager.playSound(DropSound, 1f);

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item.type != ItemType.tool)
        {
            discriptionInfo(box);
            box.DiscriptionBox.gameObject.SetActive(true);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(item.type != ItemType.tool)
            box.DiscriptionBox.gameObject.SetActive(false);
    }

    public void discriptionInfo(Discription box)
    {
        box.Icon.sprite = item.Image;

        if(item.type == ItemType.seed)
        {
            box.growingTimeText.text = "Growing time: " + item.growTimer.ToString() + "s";

        }
        else
        {
            box.growingTimeText.text = "";

        }

        if (owned)
        {
            box.priceText.text = ((int)((item.Sellvalue * count) * UpgradeShop.instance.moneyMultiplier)).ToString();
        }
        else
        {
            box.priceText.text = (item.BuyValue * count).ToString();
        }
        box.nameText.text = item.cropName;
    }
}
