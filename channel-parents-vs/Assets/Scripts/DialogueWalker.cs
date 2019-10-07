using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "dialogue config")]
public class DiagloueConfig : ScriptableObject
{
    [SerializeField] public float inter_spoken_wait_time = .1f;
    [SerializeField] public float inter_char_time = .05f;
}

public class DialogueWalker : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text tmpTextPrefab;

    [SerializeField] private Level currentLevel;
    
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
        StartCoroutine(blitText(currentLevel.openingDialogue));
    }
    
    IEnumerator blitText(TextLine[] lines)
    {
        foreach (Transform t in textHolder.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (var line in lines)
        {
            bool shouldContinue = true;
            foreach (var flag in line.required)
            {
                shouldContinue &= get_state(flag);
            }

            if (!shouldContinue)
                continue;
            
            
            yield return StartCoroutine(TypewriterText(
            Instantiate(tmpTextPrefab.gameObject, Vector3.zero, Quaternion.identity, textHolder.transform)
            
            .GetComponent<TMPro.TMP_Text>(),line.text,line.speaker));
            LayoutRebuilder.ForceRebuildLayoutImmediate(textHolder.GetComponent<RectTransform>());
            
            yield return new WaitForSeconds(config.inter_spoken_wait_time);
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
