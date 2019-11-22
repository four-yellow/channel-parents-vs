using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite closedDoor;
    private SpriteRenderer sr;
    public int choiceIndex;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    public void setDoorOpen()
    {
        print("opening");
        sr.sprite = openDoor;
        GameObject.Find("DialogueWalkerObject").GetComponent<DialogueWalker>().chooseDoor(choiceIndex);
    }
    public void setDoorClosed()
    {
        sr.sprite = closedDoor;
    }
}
