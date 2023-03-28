
using UnityEngine;

public class PlantWholeState : PlantBaseState
{
    PlantStateManager plantManager;
    public override void EnterState(PlantStateManager plant)
    {
        plantManager = plant;
        plant.fullyGorwn = true;
    }


    public override void UpdateState(PlantStateManager plant)
    {

    }


    public override void OnCollisionEnter(PlantStateManager plant)
    {

    }

  


}
