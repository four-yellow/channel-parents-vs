using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class PositionManager : MonoBehaviour
{

    private GameObject player;

    private Animator player_animator;

    private GameObject parent;

    private Animator parent_animator;

    private void Start()
    {

        player = GameObject.Find("Player");
        player_animator = player.GetComponent(typeof(Animator)) as Animator;

        parent = GameObject.Find("Parent");
        parent_animator = player.GetComponent(typeof(Animator)) as Animator;

        Assert.IsNotNull(player);
        Assert.IsNotNull(player_animator);
        Assert.IsNotNull(parent);
        Assert.IsNotNull(parent_animator);

    }

    //In another world, I would have made scriptable objects for the 
    //positions, but there aren't that many scenes, and we don't
    //have that much time 

    public void setTheScene(int settingNumber) //Yep, reeeeeeal ugly
    {
        //Zero out positions in world-space. For some reason I can't understand,
        //This is the easy way of doing it in Unity. 
        Vector3 player_zero = new Vector3(-player.transform.position.x, 
                                         -player.transform.position.y,    
                                         -player.transform.position.z);

        Vector3 parent_zero = new Vector3(-parent.transform.position.x,
                                         -parent.transform.position.y,
                                         -parent.transform.position.z);

        player.transform.position += player_zero;
        parent.transform.position += parent_zero;
        Vector3 player_pos;
        Vector3 parent_pos;
        switch (settingNumber)
        {
            case 1: //First icecream-scene

                parent_pos = new Vector3(1.73f, -2.78f, 0f);
                player_pos = new Vector3(-13.3f, -2.9f, 0f);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;
        }

    }

}
