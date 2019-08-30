using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    // Member Variables
    public float jumpHeight = 5f; // How high the Character Jumps
    public float climbSpeed = 100f; // How fast the Character Climbs
    public float moveSpeed = 5f; // How fast the Character moves

    private CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        // Gather components at the start of the game to save processing    (Cache-ing)
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         *  ---Unity Tip
         *  Input.GetAxis - 
         *  Input.GetAxisRaw - 
         */

        // Temporary Variables
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");

        if (isJumping)
        {
            controller.Jump(jumpHeight);
        }

        controller.Climb(vertical * climbSpeed);

        print("Horizontal: " + horizontal);
        print("Vertical: " + vertical);

        controller.Move(horizontal * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Detect hitting item
        if (col.gameObject.tag == "Item")
        {
            //Add 1 to score
            //--Play chime sound
            //Destroy item
            Destroy(col.gameObject);
        }

    }
}
