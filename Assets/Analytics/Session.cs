using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class Session : MonoBehaviour
{
    private float startTime;
    private bool isPlaying = false;

    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    // กด Start ครั้งแรก
    public void StartGame()
    {
        startTime = Time.time;
        isPlaying = true;

        Debug.Log("Start Session");
    }

    // กด Respawn
    public void OnRespawn()
    {
        if (isPlaying)
        {
            float duration = Time.time - startTime;

            CustomEvent myEvent = new CustomEvent("session_length");
            myEvent["session_duration"] = duration;

            AnalyticsService.Instance.RecordEvent(myEvent);
            AnalyticsService.Instance.Flush();

            Debug.Log("Session Length: " + duration);
        }

        // 🔥 เริ่มนับใหม่ทันที
        startTime = Time.time;
        isPlaying = true;

        Debug.Log("New Session Started");
    }
}