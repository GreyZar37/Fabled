using UnityEngine;


public enum playerState
{
    harvesting, plowing, idle, planting
}

public class PlayerMovement : MonoBehaviour

{
    public float speed = 6;
    float vertical;
    float horizontal;
    Rigidbody2D rb;

    Animator anim;
    [SerializeField] GameObject runningSystem;


    public static playerState currentPlayerState = playerState.idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentPlayerState == playerState.idle)
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");



            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
        }
        else
        {
            horizontal = 0;
            vertical = 0;
        }

        rb.velocity = new Vector2(horizontal, vertical).normalized * speed;
        anim.SetFloat("Velocity", Mathf.Abs(horizontal) + Mathf.Abs(vertical));


        if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0)
        {
            runningSystem.SetActive(true);
        }
        else
        {
            runningSystem.SetActive(false);

        }

    }
}
