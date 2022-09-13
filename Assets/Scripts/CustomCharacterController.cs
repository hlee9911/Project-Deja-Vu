using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{

    [SerializeField] float speed = 2.0f;
    [SerializeField] float gravity = -9.8f;

    [SerializeField] Vector3 wind_velocity = Vector3.zero;
    [SerializeField] bool invert_controls = false;

    [Header("Jump Parameters")]
    [SerializeField] bool allow_jump = true;
    [SerializeField] bool allow_double_jump = false;
    [SerializeField] float jump_speed = 2.0f;
    [SerializeField] float coyote_time = 0.3f;
    [SerializeField] float jump_buffer = 0.2f;

    

    //vertical velocity
    float vertical_speed;

    float coyote_timer = 0.0f;
    float jump_timer = 0.0f;

    bool first_jump = false;

    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();

       // Vector3 rotation_axis = (transform.forward * Input.GetAxisRaw("Horizontal") + transform.right * Input.GetAxisRaw("Vertical"));

        //transform.Rotate(rotation_axis.normalized * angularVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 end_pos = Vector3.zero;

        //////////////
        // Movement //
        //////////////
        if (Input.GetAxisRaw("Horizontal") < 0)
            end_pos += (!invert_controls ?  -transform.right : transform.right) * speed;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            end_pos += (!invert_controls ? transform.right : -transform.right) * speed;

        if (Input.GetAxisRaw("Vertical") < 0)
            end_pos += (!invert_controls ? -transform.forward : transform.forward) * speed;
        else if (Input.GetAxisRaw("Vertical") > 0)
            end_pos += (!invert_controls ? transform.forward : -transform.forward) * speed;

        //////////////////////
        // Jump and Gravity //
        //////////////////////


        if (controller.isGrounded)
        {
            first_jump = false;
            coyote_timer = coyote_time;
            vertical_speed = 0; 
        }
        if (allow_double_jump && first_jump && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_speed = jump_speed;
            first_jump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
            jump_timer = jump_buffer;

        // Jump 
        if (allow_jump && !first_jump && coyote_timer > 0.0f && jump_timer > 0.0f)
        {
            first_jump = true;
            coyote_timer = 0.0f;
            jump_timer = 0.0f;
            vertical_speed = jump_speed;
        }

        vertical_speed += gravity * Time.deltaTime;
        end_pos += Vector3.up * vertical_speed;

        coyote_timer -= Time.deltaTime;
        jump_timer -= Time.deltaTime;

        end_pos += wind_velocity;

        controller.Move(end_pos * Time.deltaTime);
    }
}









