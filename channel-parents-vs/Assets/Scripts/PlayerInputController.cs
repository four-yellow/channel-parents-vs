using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.Assertions;

public class PlayerInputController : MonoBehaviour
{
    public bool canMove = true;

    public float speed = 5.0f;

    private GameObject currentDoor;

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

        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("is_walking", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.UpArrow) && currentDoor != null)
        {

        }

        animator.Update(0);
        this.gameObject.transform.Translate(translate_by);
        translate_by = Vector3.zero;
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
