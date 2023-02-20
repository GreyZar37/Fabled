
using UnityEngine;

public class PlantGrowingState : PlantBaseState
{
    public override void EnterState(PlantStateManager plant)
    {
        Debug.Log("Started Growing");
        plant.spriteRenderer.sprite = plant.plantSprite[0];
    }

    public override void UpdateState(PlantStateManager plant)
    {
        if(plant.DaysLeft <= plant.DaysToGrow * 0.75 && plant.DaysLeft > plant.DaysToGrow * 0.40)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[1];
        }
        else if (plant.DaysLeft <= plant.DaysToGrow * 0.40 && plant.DaysLeft > plant.DaysToGrow * 0)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[2];
        }
        else if(plant.DaysLeft == 0)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[3];

        }
    }

    public override void OnCollisionEnter(PlantStateManager plant)
    {

    }

}
