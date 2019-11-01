using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

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

    [SerializeField] private TextAsset inkJSONAsset;

    [SerializeField] private Button buttonPrefab;

    [SerializeField] private VerticalLayoutGroup choicesBox;

    public Story story;

    public Dictionary<Flag, bool> state;

    private void Start()
    {
        state = new Dictionary<Flag, bool>();

        story = new Story(inkJSONAsset.text);

        choicesBox.gameObject.SetActive(false);
        RunStory();
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
    
    
    public void RunStory()
    {
        if (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();

            if (story.currentChoices.Count > 0)
            {
                for (int i = 0; i < story.currentChoices.Count; i++)
                {
                    Choice choice = story.currentChoices[i];
                    Button button = CreateChoiceView(choice.text.Trim());
                    // Tell the button what to do when we press it
                    button.onClick.AddListener(delegate {
                        OnClickChoiceButton(choice);
                    });
                }
                choicesBox.gameObject.SetActive(true);
            } else
            {
                var speakertag = story.currentTags.Find(x => x.StartsWith("speaker: ", StringComparison.Ordinal));
                Speaker speaker = speakertag == "speaker: parent" ? Speaker.parent : Speaker.child;
                StartCoroutine(TypewriterText(tmpTextPrefab,
                    text, speaker));
            }            
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RemoveChoices();
        RunStory();
    }

    void RemoveChoices()
    {
        int childCount = choicesBox.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choicesBox.transform.GetChild(i).gameObject);
        }
        choicesBox.gameObject.SetActive(false);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicesBox.transform, false);

        // Gets the text from the button prefab
        TMPro.TMP_Text choiceText = choice.GetComponentInChildren<TMPro.TMP_Text>();
        choiceText.text = text;

        return choice;
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
                /*AudioSource src = Instantiate(audioPrefab.gameObject).GetComponent<AudioSource>();
                float varience = .04f;
                src.pitch += UnityEngine.Random.value * varience - varience * .5f;
                src.volume /= j;
                src.PlayOneShot(text_sounds[(int)speaker]);
                StartCoroutine(KillAudio(src));*/
                
                yield return new WaitForSeconds(config.inter_char_time);
            }

            text.maxVisibleCharacters++;
        }
        yield return new WaitForSeconds(config.inter_spoken_wait_time);
        RunStory();

    }
}
