using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class SessionTracker : MonoBehaviour
{
    float startTime;

    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("Analytics Initialized!");
        }
        catch
        {
            Debug.LogError("Analytics Init Failed");
        }

        startTime = Time.realtimeSinceStartup;
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SendSession();
        }
    }

    void OnApplicationQuit()
    {
        SendSession();
    }

    void SendSession()
    {
        int sessionLength = (int)(Time.realtimeSinceStartup - startTime);

        CustomEvent myEvent = new CustomEvent("Session_Lenght")
        {
            { "Time", sessionLength }
        };

        AnalyticsService.Instance.RecordEvent(myEvent);

        // 🔥 สำคัญ: บังคับส่งขึ้น Cloud
        AnalyticsService.Instance.Flush();

        Debug.Log("Send Session: " + sessionLength);
    }
}