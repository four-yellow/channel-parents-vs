using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;



public enum Flag { obeyed, playing0, playing1, playing2 , pull_slot_machine};

public enum Speaker : int { the_void, player, clerk}

[System.Serializable]
public struct Line
{
    public Flag[] required;

    public Speaker speaker;

    [TextArea]
    public string text;

}

[System.Serializable]
public struct Choice {

    public string choice;
    public CurrentText dest;
    public Flag[] required;
    public Flag[] set_true;
    public Flag[] set_false;
}

[CreateAssetMenu(menuName = "Text")]
public class CurrentText : ScriptableObject
{
    public UnityEvent on_enter;
    public UnityEvent on_exit;
    public Line[] spoken;
    public Choice[] choices;

} 
