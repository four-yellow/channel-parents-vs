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
        parent_animator = parent.GetComponent(typeof(Animator)) as Animator;

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
                parent_animator.SetBool("is_sitting", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

            case 2: //Setting up the PC scene 
                parent_pos = new Vector3(20f, 20f, 0f);
                player_pos = new Vector3(-5.11f, -1.73f, 0f);
                player_animator.SetBool("is_sleeping", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

            case 3: //Parent walks in on sleeping kid
                parent_pos = new Vector3(8.52f, -1.18f, 0f);
                player_pos = new Vector3(-5.11f, -1.73f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player_animator.SetBool("is_sleeping", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

            case 4: //Parent and kid set up computer
                parent_pos = new Vector3(1.84f, -1.18f, 0f);
                player_pos = new Vector3(-1.27f, -1.99f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

            case 5: //Parent checking up on kid
                parent_pos = new Vector3(8.52f, -1.18f, 0f);
                player_pos = new Vector3(-1.27f, -1.99f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player_animator.SetBool("pointing_right", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

            case 6: //Timeskip. First dinner. 
                player_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(-4.28f, -2.28f, 0f);
                parent_animator.SetBool("is_dining", true);
                player.transform.position += player_pos;
                parent.transform.position += parent_pos;
                break;

        }

        player_animator.Update(0);
        parent_animator.Update(0);

    }

}
