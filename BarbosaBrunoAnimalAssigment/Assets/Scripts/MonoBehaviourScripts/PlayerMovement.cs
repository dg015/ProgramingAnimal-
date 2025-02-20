using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    float horizontalInput;
    float verticalInput;
    [SerializeField] private Transform orientation;
    Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        //get the inputs 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //set the direction based on the orientation object multiplying foward and right so that it can walk on the x and z axis
        //no y otherwise it would fly
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //add force so it walks
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
    }


}
