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
    public SpriteRenderer BedroomNoPC;
    public SpriteRenderer Dinner1;
    public SpriteRenderer Dinner2;
    public SpriteRenderer Dinner3;
    public SpriteRenderer VirtualWorld;

    public AudioClip[] ParkDaySounds;
    public AudioClip[] ParkNightSounds;
    public AudioClip[] Bedroom1Sounds;
    public AudioClip[] BedroomNoPCSounds;
    public AudioClip[] Dinner1Sounds;
    public AudioClip[] VirtualWorldSounds;

    public AudioSource audioPrefab;

    public List<AudioSource> currentAudioSources;

    public CanvasRenderer RealDialogueBox;
    public CanvasRenderer VirtualDialogueBox;

    public WorldType currentWorldType = WorldType.Real;

    public enum WorldType
    {
        Real, Virtual
    }

    public void setBackground(System.String name)
    {
        disableAll();
        switch (name)
        {
            case "park_day":
                ParkDay.enabled = true;
                playAudioForScene(ParkDaySounds);
                setDialogueBox(WorldType.Real);
                break;
            case "park_night":
                ParkNight.enabled = true;
                playAudioForScene(ParkNightSounds);
                setDialogueBox(WorldType.Real);
                break;
            case "bedroom_one_no_pc":
                BedroomNoPC.enabled = true;
                playAudioForScene(BedroomNoPCSounds);
                setDialogueBox(WorldType.Real);
                break;
            case "bedroom_one_pc":
                Bedroom1.enabled = true;
                playAudioForScene(Bedroom1Sounds);
                setDialogueBox(WorldType.Real);
                break;
            case "Bedroom2":
                Bedroom2.enabled = true;
                playAudioForScene(Bedroom1Sounds);
                setDialogueBox(WorldType.Real);
                break;
            case "bedroom":
            case "bedroom_unplugged":
                Bedroom3.enabled = true;
                playAudioForScene(BedroomNoPCSounds);
                setDialogueBox(WorldType.Real);
                break;
            case "dinner_one":
                Dinner1.enabled = true;
                playAudioForScene(Dinner1Sounds);
                setDialogueBox(WorldType.Real);
                break;
            case "dinner_three":
                Dinner3.enabled = true;
                playAudioForScene(Dinner1Sounds);
                setDialogueBox(WorldType.Real);
                break;
            case "virtual_one":
            case "virtual_two":
            case "virtual_three":
                VirtualWorld.enabled = true;
                playAudioForScene(VirtualWorldSounds);
                setDialogueBox(WorldType.Virtual);
                break;
            default:
                break;
        }
    }

    public IEnumerator FadeScene(float time, float pause, string name, Action duringFade, Action callback)
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
        duringFade.Invoke();
        DoorScript[] doors = FindObjectsOfType<DoorScript>();
        foreach (DoorScript d in doors)
        {
            Destroy(d.gameObject);
        }

        yield return new WaitForSeconds(pause);
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
        callback.Invoke();
        
    }

    public void disableAll()
    {
        ParkDay.enabled = false;
        ParkNight.enabled = false;
        Bedroom1.enabled = false;
        Bedroom2.enabled = false;
        Bedroom3.enabled = false;
        Dinner1.enabled = false;
        Dinner2.enabled = false;
        Dinner3.enabled = false;
        BedroomNoPC.enabled = false;
        VirtualWorld.enabled = false;

        RealDialogueBox.gameObject.SetActive(false);
        VirtualDialogueBox.gameObject.SetActive(false);

        foreach(AudioSource s in currentAudioSources)
        {
            s.Pause();
            Destroy(s.gameObject);
        }
        currentAudioSources =  new List<AudioSource>();
    }

    public void playAudioForScene(AudioClip[] clips)
    {
        foreach(AudioClip c in clips)
        {
            AudioSource src = Instantiate(audioPrefab.gameObject).GetComponent<AudioSource>();
            src.clip = c;
            src.loop = true;
            src.Play();
            currentAudioSources.Add(src);
        }
    }

    public void setDialogueBox(WorldType world)
    {
        currentWorldType = world;
        if (world == WorldType.Real)
        {
            RealDialogueBox.gameObject.SetActive(true);
        }
        else
        {
            VirtualDialogueBox.gameObject.SetActive(true);
        }
    }
}