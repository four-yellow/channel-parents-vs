﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public bool canMove = true;

    public float speed = 5.0f;

    private GameObject currentDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && currentDoor != null)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("opened");
        DoorScript other = (DoorScript)collision.gameObject.GetComponent(typeof(DoorScript));
        other.setDoorOpen();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DoorScript other = (DoorScript)collision.gameObject.GetComponent(typeof(DoorScript));
        other.setDoorClosed();
    }
}
