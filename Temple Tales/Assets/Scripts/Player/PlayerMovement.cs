using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    [Header("Assignements")]
    [Space(10f)]
    public Transform cam;
    private PlayerMovement playerMovementScript;
    [Space(10f)]

    [Header("Floats")]
    [Space(10f)]
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Space(10f)]

    public float dashSpeed;
    public float dashTime;

    [Space(10f)]

    private float timer;
    public float dashCooldown;

    [Header("Bools")]
    [Space(10f)]

    private bool isDash;

    private bool dashReady = true;
    private bool updateTime;
    private bool dashTimer;

    [Space(10f)]

    [Header("Vectors")]
    [Space(10f)]
    public Vector3 moveDir;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerMovementScript = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        #region Direction.Magnitude
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
        #endregion

        #region Dash Timer 
        if (dashTimer == true)
        {

            if (updateTime == true)
            {
                timer = Time.time + dashCooldown;
                updateTime = false;
            }

            if (Time.time > timer)
            {
                dashReady = true;

                dashTimer = false;
            }

        }
        #endregion

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashReady == true)
        {

            dashTimer = true;
            updateTime = true;


            StartCoroutine(Dash());

        }

    }


    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime) //Dash movement 
        {
            playerMovementScript.controller.Move(playerMovementScript.moveDir * dashSpeed * Time.deltaTime);
            isDash = true;
            yield return null;

        }

    }

}
