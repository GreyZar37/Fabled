using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int pumpkins, carrots, wheat, eggPlant, potatoes;
    public int pumpkinsSeeds, carrotsSeeds, wheatSeeds, eggPlantSeeds, potatoesSeeds;

    public int Money = 0;
    public TextMeshProUGUI moneyText;


    public TextMeshProUGUI pumkingNumText, carrotsNumText, wheatNumText, strawberriesNumText, potatoesNumText;
    public TextMeshProUGUI pumkinSeedNumText, carrotsSeedNumText, wheatSeedNumText, strawberriesSeedNumText, potatoesSeedNumText;

    // Start is called before the first frame update
    void Start()
    {
        refreashUI();

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = Money.ToString()+"$";
    }

    public void refreashUI()
    { 
        pumkinSeedNumText.text = pumpkinsSeeds.ToString();
        carrotsSeedNumText.text = carrotsSeeds.ToString();
        wheatSeedNumText.text = wheatSeeds.ToString();
        strawberriesSeedNumText.text = eggPlantSeeds.ToString();
        potatoesSeedNumText.text = potatoesSeeds.ToString();

        pumkingNumText.text = pumpkins.ToString();
        carrotsNumText.text = carrots.ToString();
        wheatNumText.text = wheat.ToString();
        strawberriesNumText.text = eggPlant.ToString();
        potatoesNumText.text = potatoes.ToString();


    }

    public void addCrop(string crop, int amount)
    {

        switch (crop)
        {
            case "Potato":
                potatoes += amount;

                break;
            case "EggPlant":
                eggPlant += amount;

                break;
            case "Wheat":
                wheat += amount;

                break;
            case "Carrot":
                carrots += amount;

                break;
            case "Pumpkin":
                pumpkins += amount;
                break;
        }
        refreashUI();

    }

    public void removeCrop(string crop, int amount)
    {
        switch (crop)
        {
            case "Potato":
                potatoes -= amount;

                break;
            case "EggPlant":
                eggPlant -= amount;

                break;
            case "Wheat":
                wheat -= amount;

                break;
            case "Carrot":
                carrots -= amount;

                break;
            case "Pumpkin":
                pumpkins -= amount;
                break;
        }
        refreashUI();

    }
}
