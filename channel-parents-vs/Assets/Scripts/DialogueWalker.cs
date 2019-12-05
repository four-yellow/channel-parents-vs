using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.Assertions;
using UnityEngine.Playables;
using UnityEditorInternal;
using System.Diagnostics;

[CreateAssetMenu(menuName = "dialogue config")]
public class DiagloueConfig : ScriptableObject
{
    [SerializeField] public float inter_spoken_wait_time = .1f;
    [SerializeField] public float inter_char_time = .05f;
    [SerializeField] public float scene_fade_duration = 1.5f;
    [SerializeField] public float scene_fade_pause = 1f;
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

    [SerializeField] private TMPro.TMP_Text enterIndicator;

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

    private GameObject friend;

    private Animator friend_animator;

    private string current_text;

    private bool scene_was_faded = false;

    private bool enterDown = false;

    private bool enterUp = true;

    private bool anyKey = false;

    private bool printing = false;

    private bool choicesAvailable = false;
    private bool doorsActive = false;

    private void Start()
    {
        state = new Dictionary<Flag, bool>();

        story = new Story(inkJSONAsset.text);

        choicesBox.gameObject.SetActive(false);

        timeline = GameObject.Find("TimelineParkDay");

        timeline_director = timeline.GetComponent(typeof(PlayableDirector)) as PlayableDirector;

        player = GameObject.Find("Player");

        player_animator = player.GetComponent(typeof(Animator)) as Animator;

        player_controller = player.GetComponent(typeof(PlayerInputController)) as PlayerInputController;

        parent = GameObject.Find("Parent");

        parent_animator = parent.GetComponent(typeof(Animator)) as Animator;

        friend = GameObject.Find("Friend");

        friend_animator = friend.GetComponent(typeof(Animator)) as Animator;


        Assert.IsNotNull(timeline);
        Assert.IsNotNull(timeline_director);
        Assert.IsNotNull(player);
        Assert.IsNotNull(player_controller);
        Assert.IsNotNull(player_animator);
        Assert.IsNotNull(parent);
        Assert.IsNotNull(parent_animator);
        Assert.IsNotNull(friend);
        Assert.IsNotNull(friend_animator);
        player_controller.canMove = false;

        RunStory();
    }
    
    private void switchTimelineObject(int newTimeline)
    {
        switch (newTimeline)
        {
            case 1: //Forgive me 
                timeline = GameObject.Find("TimelineParkDay");
                break;

            case 2:
                timeline = GameObject.Find("TimelineBedroomOne");
                break;

            case 3:
                timeline = GameObject.Find("TimelineAboutComputer");
                break;

            case 4:
                timeline = GameObject.Find("TimelineDinnerOne");
                break;

            case 5:
                timeline = GameObject.Find("TimelineSickDay");
                break;

            case 6:
                timeline = GameObject.Find("TimelineDinnerTwo");
                break;

            case 7:
                timeline = GameObject.Find("TimelineVirtualOne");
                break;

            case 8:
                timeline = GameObject.Find("TimelineVirtualTwo");
                break;
        }

        timeline_director = timeline.GetComponent(typeof(PlayableDirector)) as PlayableDirector;
        Assert.IsNotNull(timeline);
        Assert.IsNotNull(timeline_director);
    }

    private void setTimelineFrame(int seconds)
    {
        timeline_director.time = seconds;
        //timeline_director.Evaluate();
    }

    private void setPoses(string anim)
    {
        switch (anim)
        {

            case "animation: parent_stand":
                parent_animator.SetBool("is_sitting", false);
                break;

            case "animation: child_stand_right":
                player_animator.SetBool("is_sitting", false);
                player_animator.SetBool("is_sleeping", false);
                player_animator.SetBool("is_dining", false);
                break;
        }
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && enterUp)
        {
            enterDown = true;
            enterUp = false;
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            enterDown = false;
            enterUp = true;
        }

        if (enterDown && !printing && !scene_was_faded)
        {
            enterDown = false;
            RunStory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndTheGame();
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

        foreach (UnityEngine.AnimatorControllerParameter parameter in friend_animator.parameters)
        {
            if (parameter.type == UnityEngine.AnimatorControllerParameterType.Bool)
            {
                friend_animator.SetBool(parameter.name, false);
            }
        }

        player_animator.Update(0);
        parent_animator.Update(0);
        friend_animator.Update(0);
    }

    string getTagWithKey(string key)
    {
        string found_tag = story.currentTags.Find(x => x.StartsWith(key, StringComparison.Ordinal));
        return (found_tag == null) ? found_tag : found_tag.Split(' ')[1];
    }
    
    void blipChildIntoExistence()
    {
        Vector3 player_zero = new Vector3(-player.transform.position.x,
                                 -player.transform.position.y,
                                 -player.transform.position.z);

        player.transform.position += player_zero;
        player_animator.SetBool("is_virtual", true);
        Vector3 player_pos = new Vector3(3.24f, -3.31f, 0);
        player.transform.position += player_pos;
        player.transform.localScale = (player_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(5, 5, 1);
    }

    void blipFriendIntoExistence()
    {
        Vector3 friend_zero = new Vector3(-friend.transform.position.x,
                                 -friend.transform.position.y,
                                 -friend.transform.position.z);

        friend.transform.position += friend_zero;
        Vector3 friend_pos = new Vector3(0.05f, -3.31f, 0);
        friend.transform.position += friend_pos;
        friend.transform.localScale = (friend_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(4, 4, 1);
    }

    void unblipFriendFromExistence()
    {
        Vector3 friend_pos = new Vector3(100f, 100f, 0);
        friend.transform.position += friend_pos;
        friend.transform.localScale = new Vector3(1, 1, 1);
    }

    public void RunStory()
    {
        //StackTrace st = new StackTrace();
        //UnityEngine.Debug.Log(st.GetFrame(1).GetMethod().Name);
        print("runstory called");
        print(story.canContinue);
        print(story.currentErrors);

        // story.canContinue is false if choice needs to be made
        if (story.canContinue || scene_was_faded)
        {
            string text = current_text;
            print(scene_was_faded);
            if (scene_was_faded)
            {
                scene_was_faded = false;
            }
            else
            {
                text = story.Continue();
                current_text = text;
                string sceneTag = getTagWithKey("location");
                UnityEngine.Debug.Log(current_text);
                UnityEngine.Debug.Log(sceneTag);
                if (sceneTag != null)
                {
                    scene_was_faded = true;
                    // start of new scene
                    print("started fade");
                    StartCoroutine(backgroundManager.FadeScene(config.scene_fade_duration, config.scene_fade_pause, sceneTag, this.loadNewScene, this.RunStory));
                    return;
                }
            }
            // This removes any white space from the text.
            text = text.Trim();
            
            scene_was_faded = false;
            var animation = story.currentTags.Find(x => x.StartsWith("animation: ", StringComparison.Ordinal));
            string timeline_time = getTagWithKey("timeline:");
            string timeline_set = getTagWithKey("timelineset:");
            string switch_timeline = getTagWithKey("switch:");
            string cblip = story.currentTags.Find(x => x.StartsWith("cblip", StringComparison.Ordinal));
            string fblip = story.currentTags.Find(x => x.StartsWith("fblip", StringComparison.Ordinal));
            string funblip = story.currentTags.Find(x => x.StartsWith("funblip", StringComparison.Ordinal));

            if (cblip != null)
            {
                blipChildIntoExistence();
            }

            if (fblip != null)
            {
                blipFriendIntoExistence();
            }

            if(funblip != null)
            {
                unblipFriendFromExistence();
            }

            if (timeline_time != null) {
                //TODO: Make this safer
                //UNDO: Fuck that
                seconds_left = int.Parse(timeline_time.Substring(0, timeline_time.Length));
            }


            if (timeline_set != null)
            {
                setTimelineFrame(int.Parse(timeline_set.Substring(0, timeline_set.Length)));
            }

            if (switch_timeline != null)
            {
                switchTimelineObject(int.Parse(switch_timeline.Substring(0, switch_timeline.Length)));
            }

            if (animation != null)
            {
                setPoses(animation);
            }

            if (story.currentChoices.Count > 0)
            {
                choicesAvailable = true;
                enterIndicator.gameObject.SetActive(false);
                //DisplayChoices();
            }else
            {
                enterIndicator.gameObject.SetActive(true);
            }
            var speakertag = story.currentTags.Find(x => x.StartsWith("speaker: ", StringComparison.Ordinal));
            Speaker speaker = speakertag == "speaker: parent" ? Speaker.parent :
                                speakertag == "speaker: parent_thoughts" ? Speaker.parent :
                                speakertag == "speaker: friend_chat" ? Speaker.friend :
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

    void EndTheGame()
    {
        // Called by pressing the escape key for now
        // End Game Here

    }

    void DisplayChoices()
    {
        if (doorsActive)
        {
            player_controller.canDoor = true;
            player_controller.canMove = true;
        }
        else if (story.currentTags.Contains("door"))
        {
            doorsActive = true;
            player_controller.canDoor = true;
            player_controller.canMove = true;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                String text = story.currentChoices[i].text.Trim();
                String pos = story.currentTags.Find(x => x.StartsWith("door"+(i+1)+"pos", StringComparison.Ordinal));
                float xpos = float.Parse(pos.Remove(pos.IndexOf(',')).Substring(pos.IndexOf('(')+1));
                float ypos = float.Parse(pos.Remove(pos.IndexOf(')')).Substring(pos.IndexOf(',')+1));

                GameObject door = CreateDoorObject(text, xpos, ypos, i);
            }
        }
        else
        {
            Button firstbutton = null;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
                if (i == 0)
                {
                    firstbutton = button;
                }
            }
            choicesBox.gameObject.SetActive(true);
            firstbutton.Select();
        }
    }

    void loadNewScene()
    {
        /*
        Vector3 far = new Vector3(50, 50, 50);
        Vector3 scale = new Vector3(1, 1, 1);
        player.transform.position += far;
        parent.transform.position += far;
        friend.transform.position += far;
        player.transform.localScale = scale;
        parent.transform.localScale = scale;
        friend.transform.localScale = scale;
        */
        resetParameters();
        string setting_number = getTagWithKey("setting:");
        if (setting_number != null)
        {
            positionsManager.setTheScene(int.Parse(setting_number.Substring(0, setting_number.Length)));
        }
        tmpTextPrefab.text = "";
        doorsActive = false;
        choicesAvailable = false;
        player_controller.canDoor = false;
        player_controller.canMove = false;
    }

    void RemoveChoices()
    {
        choicesAvailable = false;
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
        player_controller.canDoor = false;
        print("chose door at index:");
        print(index);
        story.ChooseChoiceIndex(index);
        choicesAvailable = false;
        RunStory();
    }

    IEnumerator KillAudio(AudioSource audioSource)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(audioSource.gameObject);
    }

    IEnumerator TypewriterText(TMPro.TMP_Text text, string line, Speaker speaker)
    {
        printing = true;
        text.text = "";
        if (speaker == Speaker.parent)
        {
            //text.color = new Color(0.5583683f, 1f, 0.5424528f);
            text.color = new Color(1f, 0.9144362f, 0.8160377f);
        }else if (speaker == Speaker.friend)
        {
            text.color = new Color(82f/255f, 164f/255f, 1f);
            //text.color = Color.cyan;
        } else
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
                if(enterDown)
                {
                    printing = false;
                    enterDown = false;
                    text.text = line;
                    text.maxVisibleCharacters = line.Length;
                    if (choicesAvailable)
                    {
                        DisplayChoices();
                    }
                    yield break;
                }

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
        }
        printing = false;
        if (choicesAvailable)
        {
            DisplayChoices();
        }

    }
}
