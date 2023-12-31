using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;

    [SerializeField]
    private float maxMoonLightIntensity;

    [SerializeField]
    private Material skyboxMaterial;

    [SerializeField]
    private TimeSpan pestSpawnTime;

    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;

    private bool eventFired;

    public static event Action OnSunrise;

    public DateTime CurrentTime { get { return currentTime; } }

    public TimeSpan PestSpawnTime { get { return pestSpawnTime; } }

    // gets the current time from local storage if exists
    private void Awake()
    {
        if (ES3.FileExists() && ES3.KeyExists("currentTime"))
        {
            currentTime = ES3.Load<DateTime>("currentTime");
        }
        else
        {
            currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        }

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);

        eventFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    // updates the current time of the day
    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        //  Debug.Log("Current Time: " + currentTime.TimeOfDay.TotalHours);
        //  Debug.Log("Sunrise Time: " + sunriseTime);

        // when a time range is reached, the event is invoked
        if (currentTime.TimeOfDay <= sunriseTime.Add(TimeSpan.FromMinutes(1)) && currentTime.TimeOfDay >= sunriseTime)
        {
            if (!eventFired)
            {
                OnSunrise?.Invoke();

                GetRandomTime();
                // Debug.Log(pestSpawnTime.Hours);

                // ensure the event is invoked once
                eventFired = true;

                // Debug.Log("Sunrise triggered!");
            }
        }
        else
        {
            eventFired = false;
        }
    }

    // rotates the sun based on the current time of day
    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else 
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    // control the lighting of the sun based on the current time
    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    // calculates the differeance between given time
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan diff = toTime - fromTime;

        if (diff.TotalSeconds < 0)
        {
            diff += TimeSpan.FromHours(24);
        }

        return diff;
    }

    // this method generates a random time between sunrise and sunset
    public void GetRandomTime()
    {
        TimeSpan totalDuration = sunsetTime - sunriseTime;

        // generate a random number within the total duration
        double randomTicks = UnityEngine.Random.Range(0.0f, (float)totalDuration.TotalMilliseconds);

        pestSpawnTime = sunriseTime.Add(TimeSpan.FromMilliseconds(randomTicks));
    }
}
