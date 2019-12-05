using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.Assertions;

public class PlayerInputController : MonoBehaviour
{
    public bool canMove = false;
    public bool canDoor = false;

    public float speed = 5.0f;

    public int currentDoor;

    private Animator animator;

    private Vector3 translate_by;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Assert.IsNotNull(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if (this.transform.position.x < -5)
        {
            currentDoor = 0;
        }
        else if (this.transform.position.x > 5)
        {
            currentDoor = 1;
        }
        else
        {
            currentDoor = -1;
        }

        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("is_walking", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -8)
        {
            if (!animator.GetBool("is_sleeping"))
            {
                translate_by = Vector3.left * speed * Time.deltaTime;
                //this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                animator.SetBool("is_walking", true);
                animator.SetBool("pointing_left", true);
                animator.SetBool("pointing_right", false);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 8)
        {
            if (!animator.GetBool("is_sleeping"))
            {
                translate_by = Vector3.right * speed * Time.deltaTime;
                //this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                animator.SetBool("is_walking", true);
                animator.SetBool("pointing_left", false);
                animator.SetBool("pointing_right", true);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) && currentDoor != -1 && canDoor)
        {
            GameObject.Find("DialogueWalkerObject").GetComponent<DialogueWalker>().chooseDoor(currentDoor);
            currentDoor = -1;
            canDoor = false;
        }

        animator.Update(0);
        this.gameObject.transform.Translate(translate_by);
        translate_by = Vector3.zero;
    }

}
