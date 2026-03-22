using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;

public class PlayerAna : MonoBehaviour
{
    public int gPressCount = 0;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gPressCount++;
            Debug.Log("G Count: " + gPressCount);
        }
    }

    // ✅ ฟังก์ชันที่ Endgame เรียก
    public void SendDataOnDeath()
    {
        CustomEvent ev = new CustomEvent("G_Press");
        ev["g_press_count"] = gPressCount;

        AnalyticsService.Instance.RecordEvent(ev);
        AnalyticsService.Instance.Flush();

        Debug.Log("Send G_Press: " + gPressCount);
    }

    // ✅ ฟังก์ชันที่ Endgame เรียก
    public void ResetData()
    {
        gPressCount = 0;
    }
}