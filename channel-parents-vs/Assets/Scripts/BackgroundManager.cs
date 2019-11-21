using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer ParkDay;
    public SpriteRenderer ParkNight;
    public SpriteRenderer Bedroom1;
    public SpriteRenderer Bedroom2;
    public SpriteRenderer Bedroom3;

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
            case "Bedroom1":
                Bedroom1.enabled = true;
                break;
            case "Bedroom2":
                Bedroom2.enabled = true;
                break;
            case "Bedroom3":
                Bedroom3.enabled = true;
                break;
            default:
                break;
        }
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
