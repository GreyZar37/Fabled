using UnityEngine;
using UnityEngine.Tilemaps;

public enum seedsNeeded
{
    pumpkingsSeeds, carrotsSeeds, wheatSeeds, eggPlantSeeds, potatoesSeeds
}
public class PlantStateManager : MonoBehaviour
{

    public int id;

    public float TimeToGrow;
    public float currentGrowTime;
    public Sprite[] plantSprite = new Sprite[4];
    public SpriteRenderer spriteRenderer;

    PlantBaseState currentState;
    public PlantGrowingState GrowingState = new PlantGrowingState();
    public PlantWholeState plantWholeState = new PlantWholeState();
    public PlantRottenState plantRottenState = new PlantRottenState();

    public bool fullyGorwn;

    public int amount;
    public string CropName;

    public seedsNeeded seeds;
    // Start is called before the first frame update
    void Start()
    {
        TimeToGrow *= UpgradeShop.instance.plantGrowAmountMultipier;

        currentState = GrowingState;

        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentGrowTime += Time.deltaTime;
     
        currentState.UpdateState(this);
    }

    public void SwitchState(PlantBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    
}
