using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class RetryRate : MonoBehaviour
{
    public void OnRetry(int level)
    {
        // สร้าง CustomEvent พร้อมข้อมูล (ล่าสุดจะใช้รูปแบบนี้)
        CustomEvent myEvent = new CustomEvent("Retry")
        {
            { "retryplay", level }
        };

        AnalyticsService.Instance.RecordEvent(myEvent);

        // ส่งข้อมูลทันที
        AnalyticsService.Instance.Flush();
    }
}