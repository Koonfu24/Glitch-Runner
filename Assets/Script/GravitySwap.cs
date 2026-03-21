using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    Rigidbody2D rb;
    bool gravityDown = true;

    public float gravityStrength = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // กด G เพื่อสลับ
        {
            SwapGravity();
        }
    }

    void SwapGravity()
    {
        gravityDown = !gravityDown;

        if (gravityDown)
        {
            rb.gravityScale = gravityStrength;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rb.gravityScale = -gravityStrength;
            transform.localScale = new Vector3(1, -1, 1);
        }
        rb.WakeUp();
    }
}