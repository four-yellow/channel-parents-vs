using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "dialogue config")]
public class DiagloueConfig : ScriptableObject
{
    [SerializeField] public float inter_spoken_wait_time = .1f;
    [SerializeField] public float time_between_spoken_and_choices = .2f;
    [SerializeField] public float inter_choice_wait_time = .1f;
    [SerializeField] public float inter_char_time = .05f;
}

public class DialogueWalker : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text spokenPrefab;

    [SerializeField] private Button choicePrefab;

    [SerializeField] private CurrentText startingText;
    
    [SerializeField] private VerticalLayoutGroup textHolder;

    [SerializeField] private DiagloueConfig config;

    [SerializeField] private AudioClip[] text_sounds;

    [SerializeField] private AudioSource audioPrefab;

    public Dictionary<Flag, bool> state;

    private void Start()
    {
        state = new Dictionary<Flag, bool>();
        
        Begin();
    }

    bool get_state(Flag flag)
    {
        if (state.ContainsKey(flag))
            return state[flag];
        return false;
    }

    void set_state(Flag flag, bool b)
    {
        if (state.ContainsKey(flag))
            state[flag] = b;
        else
            state.Add(flag,b);
    }

    public void set_true(string flag)
    {
        Flag arg;
        if(Flag.TryParse(flag,out arg))
            set_state(arg,true);
    }
    
    
    public void Begin()
    {
        StartCoroutine(blitText(startingText));
    }
    
    IEnumerator blitText(CurrentText currentText)
    {
        foreach (Transform t in textHolder.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (var spoken in currentText.spoken)
        {
            bool shouldContinue = true;
            foreach (var flag in spoken.required)
            {
                shouldContinue &= get_state(flag);
            }

            if (!shouldContinue)
                continue;
            
            
            yield return StartCoroutine(TypewriterText(
            Instantiate(spokenPrefab.gameObject, Vector3.zero, Quaternion.identity, textHolder.transform)
            
            .GetComponent<TMPro.TMP_Text>(),spoken.text,spoken.speaker));
            LayoutRebuilder.ForceRebuildLayoutImmediate(textHolder.GetComponent<RectTransform>());
            
            yield return new WaitForSeconds(config.inter_spoken_wait_time);
        }
        yield return  new WaitForSeconds(config.time_between_spoken_and_choices);

        foreach (var choice in currentText.choices)
        {
            bool shouldContinue = true;
            foreach (var flag in choice.required)
            {
                shouldContinue &= get_state(flag);
            }

            if (!shouldContinue)
                continue;
            
            GameObject choice_object = Instantiate(choicePrefab.gameObject, textHolder.transform);
            choice_object.GetComponent<Button>().onClick.AddListener(() =>
            {
                foreach (var flag in choice.set_true)
                {
                    set_state(flag,true);
                }

                foreach (var flag in choice.set_false)
                {
                    set_state(flag,false);
                }
                StartCoroutine(blitText(choice.dest));
            });
            yield return StartCoroutine(TypewriterText(
                choice_object.GetComponentInChildren<TMPro.TMP_Text>(), choice.choice,Speaker.player
            ));
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(textHolder.GetComponent<RectTransform>());
            yield return new WaitForSeconds(config.inter_choice_wait_time);
        }
        
        
        yield return null;
    }


    IEnumerator KillAudio(AudioSource audioSource)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(audioSource.gameObject);
    }

    IEnumerator TypewriterText(TMPro.TMP_Text text, string line,Speaker speaker)
    {
        text.text = "";
        text.maxVisibleCharacters = 0;
        string[] words = line.Split(' ');
        for(int i = 0;i < words.Length;i++)
        {
            text.text += words[i];
            text.text += " ";
            for (int j = 0; j < words[i].Length; j++)
            {
                text.maxVisibleCharacters++;
                AudioSource src = Instantiate(audioPrefab.gameObject).GetComponent<AudioSource>();
                float varience = .04f;
                src.pitch += UnityEngine.Random.value * varience - varience * .5f;
                src.volume /= j;
                src.PlayOneShot(text_sounds[(int)speaker]);
                StartCoroutine(KillAudio(src));
                
                yield return new WaitForSeconds(config.inter_char_time);
            }

            text.maxVisibleCharacters++;

            yield return null; //unnecessary but I hate loops
        }

    }
}
