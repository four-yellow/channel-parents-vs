using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;



public enum Flag { obeyed, playing0, playing1, playing2 , pull_slot_machine};

public enum Speaker { child, parent };

[System.Serializable]
public struct TextLine
{
    public Flag[] required;

    public Speaker speaker;

    [TextArea]
    public string text;

}

[System.Serializable]
public struct Choice {

    public GameObject doorObject;
    public string doorText;
    public Level dest;
    public TextLine[] closingDialogue;
    public Flag[] required;
    public Flag[] set_true;
    public Flag[] set_false;
}

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    public UnityEvent on_enter;
    public UnityEvent on_exit;
    public TextLine[] openingDialogue;
    public Choice[] choices;
} 
