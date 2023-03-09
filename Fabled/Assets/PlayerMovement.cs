using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float speed = 6;
    float vertical;
    float horizontal;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal, vertical).normalized * speed;

        if(horizontal > 0)
        {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

    }
}
