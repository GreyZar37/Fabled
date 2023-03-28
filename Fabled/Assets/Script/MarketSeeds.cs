using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSeeds : MonoBehaviour
{
    public Inventory inv;

    public void buyFuction(string item)
    {
        switch (item)
        {
            case "Carrot":
                if(inv.Money > 5)
                {
                    inv.carrotsSeeds++;
                    inv.Money -= 5;
                }
             
                break;
            case "Wheat":
                if (inv.Money > 15)
                {
                    inv.wheatSeeds++;
                    inv.Money -= 15;

                }

                break;
            case "Eggplant":
                if (inv.Money > 30)
                {
                    inv.eggPlantSeeds++;
                    inv.Money -= 30;

                }

                break;
            case "Potato":
                if (inv.Money > 125)
                {
                    inv.potatoesSeeds++;
                    inv.Money -= 125;
                }

                break;
            case "Pumpkin":
                if (inv.Money > 250)
                {
                    inv.pumpkinsSeeds++;
                    inv.Money -= 250;
                }
                break;

            default:
                break;
        }
        inv.refreashUI();
    }
    public void sellFuction( string item)
    {
        switch (item)
        {
            case "Carrot":
                if(inv.carrotsSeeds > 0)
                {
                    inv.carrotsSeeds--;
                    inv.Money += 2;
                }
                break;
            case "Wheat":
                if(inv.wheatSeeds > 0)
                {
                    inv.wheatSeeds--;
                    inv.Money += 7;
                }
                break;
            case "Eggplant":
                if(inv.eggPlantSeeds > 0)
                {
                    inv.eggPlantSeeds--;
                    inv.Money += 15;
                }
                break;
            case "Potato":
                if(inv.potatoesSeeds > 0)
                {
                    inv.potatoesSeeds--;
                    inv.Money += 62;
                }
                break;
            case "Pumpkin":
                if(inv.pumpkinsSeeds > 0)
                {
                    inv.pumpkinsSeeds--;
                    inv.Money += 125;
                }
                break;
            default:
                break;
        }
        inv.refreashUI();

    }

}
