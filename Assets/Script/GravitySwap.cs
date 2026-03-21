using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class GravitySwap : MonoBehaviour
{
    Rigidbody2D rb;
    bool gravityDown = true;

    public float gravityStrength = 1f;

    int gPressCount = 0;

    async void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection(); // 👈 สำคัญมาก
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gPressCount++;

            var ev = new CustomEvent("G_Click");
            ev["Gravity"] = gPressCount;

            AnalyticsService.Instance.RecordEvent(ev);

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