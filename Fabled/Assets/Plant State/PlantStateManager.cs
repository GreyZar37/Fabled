using UnityEngine;

public class PlantStateManager : MonoBehaviour
{

    public int DaysToGrow;
    public int DaysLeft;
    public Sprite[] plantSprite = new Sprite[4];
    public SpriteRenderer spriteRenderer;

    PlantBaseState currentState;
    public PlantGrowingState GrowingState = new PlantGrowingState();
    public PlantWholeState plantWholeState = new PlantWholeState();
    public PlantRottenState plantRottenState = new PlantRottenState();

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DaysLeft = DaysToGrow;
        currentState = GrowingState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DaysLeft -= 1;
        }
        currentState.UpdateState(this);
    }

    public void SwitchState(PlantBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
