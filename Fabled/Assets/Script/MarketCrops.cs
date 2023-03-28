using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketCrops : MonoBehaviour
{
    public Inventory inv;

    public void buyFuction(string item)
    {
        switch (item)
        {
            case "Carrot":
                if (inv.Money > 10)
                {
                    inv.carrots++;
                    inv.Money -= 10;

                }
                break;
            case "Wheat":
                if (inv.Money > 30)
                {
                    inv.wheat++;
                    inv.Money -= 30;

                }
                break;
            case "Eggplant":
                if (inv.Money > 60)
                {
                    inv.eggPlant++;
                    inv.Money -= 60;

                }

                break;
            case "Potato":
                if (inv.Money > 250)
                {
                    inv.Money -= 250;
                    inv.potatoes++;

                }

                break;
            case "Pumpkin":
                if (inv.Money > 500)
                {
                    inv.pumpkins++;
                    inv.Money -= 500;

                }
                break;

            default:
                break;
        }
        inv.refreashUI();
    }
    public void sellFuction(string item)
    {
        switch (item)
        {
            case "Carrot":
                if (inv.carrots > 0)
                {
                    inv.carrots--;
                    inv.Money += 10;
                }
                break;
            case "Wheat":
                if (inv.wheat > 0)
                {
                    inv.wheat--;
                    inv.Money += 30;
                }
                break;
            case "Eggplant":
                if (inv.eggPlant > 0)
                {
                    inv.eggPlant--;
                    inv.Money += 60;
                }
                break;
            case "Potato":
                if (inv.potatoes > 250)
                {
                    inv.potatoes--;
                    inv.Money += 62;
                }
                break;
            case "Pumpkin":
                if (inv.pumpkins > 0)
                {
                    inv.pumpkins--;
                    inv.Money += 500;
                }
                break;
            default:
                break;
        }
        inv.refreashUI();

    }
}
