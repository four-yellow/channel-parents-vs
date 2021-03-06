﻿using UnityEngine;

public class PositionManager : MonoBehaviour
{

    private GameObject player;

    private Animator player_animator;

    private GameObject parent;

    private Animator parent_animator;

    private GameObject friend;

    private Animator friend_animator;

    private GameObject icecream;
    private void Start()
    {

        player = GameObject.Find("Player");
        player_animator = player.GetComponent(typeof(Animator)) as Animator;

        parent = GameObject.Find("Parent");
        parent_animator = parent.GetComponent(typeof(Animator)) as Animator;

        friend = GameObject.Find("Friend");
        friend_animator = friend.GetComponent(typeof(Animator)) as Animator;

        icecream = GameObject.Find("IcecreamMan");

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

        Vector3 icecream_zero = new Vector3(-icecream.transform.position.x,
                                        -icecream.transform.position.y,
                                        -icecream.transform.position.z);

        Vector3 scale = new Vector3(1, 1, 1);

        player.transform.localScale = scale;
        parent.transform.localScale = scale;
        friend.transform.localScale = scale;
        icecream.transform.localScale = scale;
        player.transform.position += player_zero;
        parent.transform.position += parent_zero;
        friend.transform.position += friend_zero;
        icecream.transform.position += icecream_zero;

        Vector3 player_pos = new Vector3();
        Vector3 parent_pos = new Vector3();
        Vector3 friend_pos = new Vector3();
        Vector3 icecream_pos = new Vector3(50f, 50f, 50f);

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
                friend_animator.SetInteger("grown_up", 1);
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
                parent_animator.SetBool("pointing_left", true);
                break;

            case 8: //Second dinner. 
                player_animator.SetInteger("grown_up", 1);
                friend_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(-4.28f, -2.28f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_dining", true);
                break;

            case 9: //Virtual Two, before fade in
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(50f, 50f, 0f);
                friend_animator.SetBool("is_virtual", true);
                player.transform.localScale = new Vector3(5, 5, 1);
                player_animator.SetBool("is_virtual", true);
                break;

            case 10: //Neutral standing position
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(0.05f, -3.31f, 0);
                player.transform.localScale = (player_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(5, 5, 1);
                friend.transform.localScale = (friend_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(4, 4, 1);
                player_animator.SetBool("is_virtual", true);
                friend_animator.SetBool("is_virtual", true);
                break;

            case 11: //Virtual Three
                player_animator.SetInteger("grown_up", 1);
                friend_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(50f, 50f, 0f);
                friend_pos = new Vector3(0.05f, -3.31f, 0);
                friend.transform.localScale = new Vector3(4, 4, 1);
                player_animator.SetBool("is_virtual", true);
                friend_animator.SetBool("is_virtual", true);
                break;

            case 12: //Virtual One
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(50f, 50f, 0f);
                player.transform.localScale = (player_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(5, 5, 1);
                friend.transform.localScale = (friend_animator.GetInteger("grown_up") == 0) ? new Vector3(8, 8, 1) : new Vector3(4, 4, 1);
                player_animator.SetBool("is_virtual", true);
                friend_animator.SetBool("is_virtual", true);
                break;

            case 13: //Too much game
                player_animator.SetInteger("grown_up", 1);
                friend_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(5.60f, -2.2f, 0f);
                player_pos = new Vector3(0f, -2.2f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("pointing_left", true);
                player_animator.SetBool("pointing_right", true);
                parent_animator.SetBool("night", true);
                player_animator.SetBool("night", true);
                break;

            case 14: //Third Dinner
                player_animator.SetInteger("grown_up", 1);
                friend_animator.SetInteger("grown_up", 1);
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(-4.28f, -2.28f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_dining", true);
                break;

            case 15: //Man behind the tree
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(2.37f, -2.66f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                player_animator.SetBool("pointing_right", true);
                player_animator.SetBool("night", true);
                break;

            case 16: //Abandoned friend
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(3.24f, -3.31f, 0);
                friend_pos = new Vector3(50f, 50f, 0f);
                player.transform.localScale = new Vector3(5, 5, 1);
                player_animator.SetBool("is_virtual", true);
                break;

            case 17: //Met with friend
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(-11.3f, -2.66f, 0f);
                friend_pos = new Vector3(5.32f, -2.66f, 0f);
                player_animator.SetBool("pointing_right", true);
                player_animator.SetBool("night", true);
                friend_animator.SetBool("pointing_left", true);
                friend_animator.SetBool("night", true);
                break;

            case 18: //Epilogue with friend
                parent_pos = new Vector3(50f, 50f, 0f);
                player_pos = new Vector3(50f, 50f, 0f);
                friend_pos = new Vector3(-8.36f, -2.8f, 0f);
                player_animator.SetBool("pointing_left", true);
                friend_animator.SetBool("pointing_right", true);
                parent_animator.SetBool("is_sitting", true);
                break;

            case 19: //Sad dinner
                parent_pos = new Vector3(4.76f, -2.11f, 0f);
                player_pos = new Vector3(50f, 50f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                parent_animator.SetBool("is_dining", true);
                break;

            case 20: //Missed oppurtunity
                parent_pos = new Vector3(30f, 20f, 0f);
                player_pos = new Vector3(1.12f, -1.31f, 0f);
                friend_pos = new Vector3(50f, 50f, 0f);
                player_animator.SetBool("night", true);
                player_animator.SetBool("pointing_left", true);
                break;
        }

        player.transform.position += player_pos;
        parent.transform.position += parent_pos;
        friend.transform.position += friend_pos;
        icecream.transform.position += icecream_pos;
        player_animator.Update(0);
        parent_animator.Update(0);
        friend_animator.Update(0);

    }

}
