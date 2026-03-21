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

    public void StartGame()
    {
        startTime = Time.time;
        isPlaying = true;
    }

    public void EndGame()
    {
        if (!isPlaying) return;

        float duration = Time.time - startTime;

        CustomEvent myEvent = new CustomEvent("session_length");
        myEvent["session_duration"] = duration;

        AnalyticsService.Instance.RecordEvent(myEvent);

        AnalyticsService.Instance.Flush();

        isPlaying = false;
    }
}