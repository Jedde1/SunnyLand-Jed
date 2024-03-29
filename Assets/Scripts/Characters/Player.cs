﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    // Member Variables
    public float jumpHeight = 5f; // How high the Character Jumps
    public float climbSpeed = 100f; // How fast the Character Climbs
    public float moveSpeed = 5f; // How fast the Character moves
    public float portalDistance = 1f; // How far from the Portal the player needs to be to press Up & Interact

    private CharacterController2D controller;
    private Transform currentPortal; //Reference to current portal

    // Start is called before the first frame update
    void Start()
    {
        // Gather components at the start of the game to save processing    (Cache-ing)
        controller = GetComponent<CharacterController2D>();
    }

    private void OnDrawGizmos()
    {
        //If player is over a portal (trigger)
        if (currentPortal != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(currentPortal.position, portalDistance);
        }
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

        //move horizontally
        controller.Move(horizontal * moveSpeed);

        //if overa portal
        if (currentPortal != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentPortal.SendMessage("Interact");
                {
                    //Get distance between player and portal
                    float distance = Vector2.Distance(transform.position, currentPortal.position);
                    if (distance < portalDistance)
                    {
                        print("Player is within Interacterable Distance");
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Detect hitting item
        if (col.gameObject.tag == "Item")
        {
            //Add 1 to score\
            GameManager.Instance.AddScore(1);
            //--Play chime sound
            //Destroy item
            Destroy(col.gameObject);
        }
        //Dectect hitting portal
        if (col.CompareTag("portal"))
        {
            //Store the current portal
            currentPortal = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Detect hitting portal
        if (col.CompareTag("portal"))
        {
            //Store the current portal
            currentPortal = null;
        }
    }

}
