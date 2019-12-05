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

    private GameObject friend;

    private Animator friend_animator;
    private void Start()
    {

        player = GameObject.Find("Player");
        player_animator = player.GetComponent(typeof(Animator)) as Animator;

        parent = GameObject.Find("Parent");
        parent_animator = parent.GetComponent(typeof(Animator)) as Animator;

        friend = GameObject.Find("Friend");
        friend_animator = friend.GetComponent(typeof(Animator)) as Animator;

        Assert.IsNotNull(player);
        Assert.IsNotNull(player_animator);
        Assert.IsNotNull(parent);
        Assert.IsNotNull(parent_animator);
        Assert.IsNotNull(friend);
        Assert.IsNotNull(friend_animator);
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

        Vector3 friend_zero = new Vector3(-friend.transform.position.x,
                                        -friend.transform.position.y,
                                        -friend.transform.position.z);

        Vector3 scale = new Vector3(1, 1, 1);

        player.transform.localScale = scale;
        parent.transform.localScale = scale;
        friend.transform.localScale = scale;
        player.transform.position += player_zero;
        parent.transform.position += parent_zero;
        friend.transform.position += friend_zero;

        Vector3 player_pos = new Vector3();
        Vector3 parent_pos = new Vector3();
        Vector3 friend_pos = new Vector3();
        switch (settingNumber)
        {
            case 1: //First icecream-scene
                parent_pos = new Vector3(1.73f, -2.78f, 0f);
                player_pos = new Vector3(-13.3f, -2.9f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_sitting", true);
                break;

            case 2: //Setting up the PC scene 
                parent_pos = new Vector3(30f, 20f, 0f);
                player_pos = new Vector3(-5.11f, -1.73f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                player_animator.SetBool("is_sleeping", true);
                break;

            case 3: //Parent walks in on sleeping kid
                parent_pos = new Vector3(30f, -1.18f, 0f);
                player_pos = new Vector3(-5.11f, -1.73f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player_animator.SetBool("is_sleeping", true);
                break;

            case 4: //Parent and kid set up computer
                parent_pos = new Vector3(1.84f, -1.18f, 0f);
                player_pos = new Vector3(-1.27f, -1.99f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("pointing_left", true);
                break;

            case 5: //Parent checking up on kid
                parent_pos = new Vector3(15f, -1.18f, 0f);
                player_pos = new Vector3(0.1f, -1.77f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player_animator.SetBool("is_sitting", true);
                break;

            case 6: //Timeskip. First dinner. 
                player_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(-4.28f, -2.28f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_dining", true);
                break;

            case 7: //Sick day
                parent_pos = new Vector3(30f, 20f, 0f);
                player_pos = new Vector3(-5.11f, -1.73f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                player_animator.SetBool("is_sleeping", true);
                break;

            case 8: //Timeskip. Second dinner. 
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(-4.28f, -2.28f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_dining", true);
                break;

            case 9: //Virtual Two, before fade in
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(50f, 50f, 0f);
                player.transform.localScale = new Vector3(8, 8, 1);
                player_animator.SetBool("is_virtual", true);
                break;

            case 10: //Virtual Two, after fade in 
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(0.05f, -3.31f, 0);
                player.transform.localScale = new Vector3(8, 8, 1);
                friend.transform.localScale = new Vector3(8, 8, 1);
                player_animator.SetBool("is_virtual", true);
                break;

            case 11: //Virtual Three
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(50f, 50f, 0f);
                friend_pos = new Vector3(0.05f, -3.31f, 0);
                friend.transform.localScale = new Vector3(8, 8, 1);
                player_animator.SetBool("is_virtual", true);
                break;
        }

        player.transform.position += player_pos;
        parent.transform.position += parent_pos;
        friend.transform.position += friend_pos;
        player_animator.Update(0);
        parent_animator.Update(0);
        friend_animator.Update(0);

    }

}
