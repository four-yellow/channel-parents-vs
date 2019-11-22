﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.Assertions;
using UnityEngine.Playables;
using UnityEditorInternal;

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
    
    [SerializeField] private DiagloueConfig config;

    [SerializeField] private AudioClip[] text_sounds;

    [SerializeField] private AudioSource audioPrefab;

    [SerializeField] private TextAsset inkJSONAsset;

    [SerializeField] private Button buttonPrefab;

    [SerializeField] private GameObject doorPrefab;

    [SerializeField] private VerticalLayoutGroup choicesBox;

    [SerializeField] private Animator childAnimator;

    [SerializeField] private Animator parentAnimator;

    [SerializeField] private BackgroundManager backgroundManager;

    [SerializeField] private PositionManager positionsManager;



    public Story story;

    public Dictionary<Flag, bool> state;

    private GameObject timeline;

    private PlayableDirector timeline_director;

    private double seconds_left;

    private GameObject player;

    private Animator player_animator;

    private PlayerInputController player_controller;

    private GameObject parent;

    private Animator parent_animator;

    private void Start()
    {
        state = new Dictionary<Flag, bool>();

        story = new Story(inkJSONAsset.text);

        choicesBox.gameObject.SetActive(false);

        timeline = GameObject.Find("Timeline");

        timeline_director = timeline.GetComponent(typeof(PlayableDirector)) as PlayableDirector;

        player = GameObject.Find("Player");

        player_animator = player.GetComponent(typeof(Animator)) as Animator;

        player_controller = player.GetComponent(typeof(PlayerInputController)) as PlayerInputController;

        parent = GameObject.Find("Parent");

        parent_animator = parent.GetComponent(typeof(Animator)) as Animator;

        Assert.IsNotNull(timeline);
        Assert.IsNotNull(timeline_director);
        Assert.IsNotNull(player);
        Assert.IsNotNull(player_controller);
        Assert.IsNotNull(player_animator);
        Assert.IsNotNull(parent);
        Assert.IsNotNull(parent_animator);
        player_controller.canMove = false;

        RunStory();
    }

    private void LateUpdate()
    {
        if (seconds_left > 0)
        {
            if (seconds_left < Time.deltaTime)
            {
                timeline_director.time += seconds_left;
                seconds_left = 0;
            } else {
                timeline_director.time += Time.deltaTime;
                seconds_left -= Time.deltaTime;
            }
            timeline_director.Evaluate();
        }
    }

    void resetParameters()
    {
        foreach (UnityEngine.AnimatorControllerParameter parameter in player_animator.parameters)
        {
            if (parameter.type == UnityEngine.AnimatorControllerParameterType.Bool){
                player_animator.SetBool(parameter.name, false);
            }
               
        }

        foreach (UnityEngine.AnimatorControllerParameter parameter in parent_animator.parameters)
        {
            if (parameter.type == UnityEngine.AnimatorControllerParameterType.Bool)
            {
                parent_animator.SetBool(parameter.name, false);
            }

        }
    }
        string getTagWithKey(string key)
    {
        string found_tag = story.currentTags.Find(x => x.StartsWith(key, StringComparison.Ordinal));
        if (found_tag == null)
        {
            return found_tag;
        }
        else
        {
            return found_tag.Split(' ')[1];
        }
    }
    
    public void RunStory()
    {
        if (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();

            string sceneTag = getTagWithKey("location");
            if (sceneTag != null)
            {
                // start of new scene
                resetParameters();
                string setting_number = getTagWithKey("setting:");
                if (setting_number != null) {
                    positionsManager.setTheScene(int.Parse(setting_number.Substring(0, setting_number.Length)));
                }
                StartCoroutine(backgroundManager.FadeScene(1.5f, sceneTag, this.RunStory));
                //return;
            }

            var parent_stand = story.currentTags.Find(x => x.StartsWith("animation: ", StringComparison.Ordinal));
            string timeline_time = getTagWithKey("timeline:");
            if (timeline_time != null) {
                //TODO: Make this safer
                seconds_left = int.Parse(timeline_time.Substring(0, timeline_time.Length));
            }

            if (parent_stand == "animation: parent_stand")
            {
                parent_animator.SetBool("is_sitting", false);
            }

            if (story.currentChoices.Count > 0)
            {
                DisplayChoices();
            }
            var speakertag = story.currentTags.Find(x => x.StartsWith("speaker: ", StringComparison.Ordinal));
            Speaker speaker = speakertag == "speaker: parent" ? Speaker.parent :
                                speakertag == "speaker: parent_thoughts" ? Speaker.parent :
                                Speaker.child;
            StartCoroutine(TypewriterText(tmpTextPrefab,
                text, speaker));
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RemoveChoices();
        RunStory();
    }

    void DisplayChoices()
    {
        if (story.currentTags.Contains("door"))
        {
            foreach (var t in story.currentTags)
            {
                print(t);
            }
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                
                String text = story.currentChoices[i].text.Trim();
                String pos = story.currentTags.Find(x => x.StartsWith("door"+(i+1)+"pos", StringComparison.Ordinal));
                print(pos);
                print(pos.Remove(pos.IndexOf(',')).Substring(pos.IndexOf('(')));
                float xpos = float.Parse(pos.Remove(pos.IndexOf(',')).Substring(pos.IndexOf('(')+1));
                float ypos = float.Parse(pos.Remove(pos.IndexOf(')')).Substring(pos.IndexOf(',')+1));

                GameObject door = CreateDoorObject(text, xpos, ypos, i);
            }
            player_controller.canMove = true;
        }
        else
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
        }
    }

    void loadNewScene()
    {
        String sceneTag = getTagWithKey("Scene");
    }

    void RemoveChoices()
    {
        int childCount = choicesBox.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(choicesBox.transform.GetChild(i).gameObject);
        }
        choicesBox.gameObject.SetActive(false);
    }

    GameObject CreateDoorObject(string text, float x, float y, int choiceIndex)
    {
        GameObject door = Instantiate(doorPrefab);
        door.transform.position = new Vector3(x, y, 0);
        door.GetComponentInChildren<TMPro.TMP_Text>().text = text;
        door.GetComponent<DoorScript>().choiceIndex = choiceIndex;
        return door;
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

    public void chooseDoor(int index)
    {
        story.ChooseChoiceIndex(index);        
        RunStory();
    }

    IEnumerator KillAudio(AudioSource audioSource)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(audioSource.gameObject);
    }

    IEnumerator TypewriterText(TMPro.TMP_Text text, string line,Speaker speaker)
    {
        text.text = "";
        if (speaker == Speaker.parent)
        {
            //text.color = new Color(0.5583683f, 1f, 0.5424528f);
            text.color = new Color(1f, 0.9144362f, 0.8160377f);
        }else
        {
            //text.color = new Color(0.5411765f, 1f, 0.9965637f);
            text.color = new Color(1f, 0.6704713f, 0.5424528f);
        }
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
