using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    [Header("Values")]
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;

    public GameObject playerObject;
    public Transform groundCheck;

    public LayerMask groundMask;
    

    bool isGrounded;

    

    

    Vector3 velocity;


    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
