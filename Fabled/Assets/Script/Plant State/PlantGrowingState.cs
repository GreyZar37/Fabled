
using UnityEngine;

public class PlantGrowingState : PlantBaseState
{
    public override void EnterState(PlantStateManager plant)
    {

        plant.spriteRenderer.sprite = plant.plantSprite[0];
    }

    public override void UpdateState(PlantStateManager plant)
    {
        if(plant.currentGrowTime >= plant.TimeToGrow * 0.30f && plant.currentGrowTime < plant.TimeToGrow * 0.70f)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[1];
        }
        else if (plant.currentGrowTime >= plant.TimeToGrow * 0.40 && plant.currentGrowTime < plant.TimeToGrow)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[2];
        }
        else if(plant.currentGrowTime >= plant.TimeToGrow)
        {
            plant.spriteRenderer.sprite = plant.plantSprite[3];
            plant.SwitchState(plant.plantWholeState);

        }
    }

    public override void OnCollisionEnter(PlantStateManager plant)
    {

    }

}
