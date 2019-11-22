using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer ParkDay;
    public SpriteRenderer ParkNight;
    public SpriteRenderer Bedroom1;
    public SpriteRenderer Bedroom2;
    public SpriteRenderer Bedroom3;
    public SpriteRenderer ScreenFade;

    public void setBackground(System.String name)
    {
        disableAll();
        switch (name)
        {
            case "park_day":
                ParkDay.enabled = true;
                break;
            case "IceCream2":
                ParkNight.enabled = true;
                break;
            case "bedroom_one_no_pc":
            case "bedroom_one_pc":
                Bedroom1.enabled = true;
                break;
            case "Bedroom2":
                Bedroom2.enabled = true;
                break;
            case "bedroom":
            case "bedroom_unplugged":
                Bedroom3.enabled = true;
                break;
            default:
                break;
        }
    }

    public IEnumerator FadeScene(float time, string name, Action callback)
    {
        Color color = ScreenFade.color;
        float start_a = color.a;
        float t = 0;
        while(t < time)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / time);

            color.a = Mathf.Lerp(start_a, 1, blend);
            ScreenFade.color = color;
            yield return null;
        }
        setBackground(name);
        DoorScript[] doors = FindObjectsOfType<DoorScript>();
        foreach (DoorScript d in doors)
        {
            Destroy(d.gameObject);
        }
        start_a = color.a;
        t = 0;
        while (t < time)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / time);

            color.a = Mathf.Lerp(start_a, 0, blend);
            ScreenFade.color = color;
            yield return null;
        }
        //callback.Invoke();
        
    }

    public void disableAll()
    {
        ParkDay.enabled = false;
        ParkNight.enabled = false;
        Bedroom1.enabled = false;
        Bedroom2.enabled = false;
        Bedroom3.enabled = false;
    }
}
