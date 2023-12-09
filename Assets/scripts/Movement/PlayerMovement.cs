//Dit script zorgt er voor dat de speler kan bewegen, springe, sprinten, en meer!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float sprintMultiplier;
    public float sprintSpeed;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask CanBePickedUp;
    bool grounded;
    bool grounded1;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void Update()
    {
        //Check of hij op de grond staat, dan kan je springen en normaal lopen namelijk, anders niet
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); //Hier checkt hij of hij op grond staat
        grounded1 = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, CanBePickedUp); //Physics object tellen ook, dus dat checken we hier

        MyInput(); //Hier krijg je de input, dus of de speler heeft geklikt op bewegingstoetsen op zijn of haar toetsenbord
        speedControl(); //Hier er voor zorgen dat je niet oneindig veel sneller kan rennen

        //Zorg er voor dat in de lucht er weerstand is
        if (grounded || grounded1){
            rb.drag = groundDrag;
        }
        else{
            rb.drag = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {
            sprintSpeed = sprintMultiplier; //Sprint-functionaliteiten
        } else {
            sprintSpeed = 1f;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(); //Beweeg de speler
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Pak de horizontale en verticale inputs, dus W, A, S, D bijvoorbeeld
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if((Input.GetKey(jumpKey) && grounded && readyToJump) || (Input.GetKey(jumpKey) && grounded1 && readyToJump)) //Als je kan springen en springt, dan spring je
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    //Hieronder functions die uitgelegd zijn wanneer ze worden gecalled in de bovenstaande code

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded || grounded1)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * sprintSpeed, ForceMode.Force);

        //in air
        else if(!grounded || !grounded1)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier * sprintSpeed, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > (moveSpeed * sprintSpeed))
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed * sprintSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
