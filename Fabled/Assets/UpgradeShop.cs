using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeShop : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    public static UpgradeShop instance;


    [HideInInspector] public float growSpeedMultiplier = 1;
    [HideInInspector] public float plantGrowAmountMultipier = 1;
    [HideInInspector] public float longerCropReachMultiplier = 1;
    [HideInInspector] public float speedMultiplier = 1;
    [HideInInspector] public float moneyMultiplier = 1;
    [HideInInspector] public float longerPlowReachMultiplier = 1;

    public AudioClip buySound;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = GameManager.Instance.money.ToString();
    }

    public void buyQuickSeeds(int price)
    {
        if(GameManager.Instance.money >= price)
        {
            growSpeedMultiplier = 0.90f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound, 1f);

        }
    }
    public void FertilizedSoil(int price)
    {
        if (GameManager.Instance.money >= price)
        {
            plantGrowAmountMultipier = 1.25f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound, 1f);

        }
    }
    public void BigHoe(int price)
    {
        if (GameManager.Instance.money >= price)
        {
            longerPlowReachMultiplier = 1.30f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound, 1f);

        }
    }
    public void WolfPotion(int price)
    {
        if (GameManager.Instance.money >= price)
        {
            speedMultiplier = 1.20f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound, 1f);

        }
    }
    public void Salesman(int price)
    {
        if (GameManager.Instance.money >= price)
        {
            moneyMultiplier = 1.20f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound, 1f);

        }
    }
    public void longReach(int price)
    {
        if (GameManager.Instance.money >= price)
        {
            longerCropReachMultiplier = 1.30f;
            GameManager.Instance.money -= price;
            AudioManager.playSound(buySound,1f);
        }

    }
}
