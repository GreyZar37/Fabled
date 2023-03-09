using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int pumpkings, carrots, wheat, eggPlant, potatoes;

    public TextMeshProUGUI pumkingNumText, carrotsNumText, wheatNumText, strawberriesNumText, potatoesNumText;

    // Start is called before the first frame update
    void Start()
    {
        refreashUI();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void refreashUI()
    {
        pumkingNumText.text = pumpkings.ToString();
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
                pumpkings+= amount;
                break;
        }
        refreashUI();

    }

}
