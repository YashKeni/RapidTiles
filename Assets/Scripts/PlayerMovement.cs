using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Clamps")]
    [SerializeField] float minX = -9f;
    [SerializeField] float maxX = 9f;
    [SerializeField] float minY = -4.75f;
    [SerializeField] float maxY = 3f;

    [Header("Joystick")]
    [SerializeField] FloatingJoystick joystick;

    Vector2 rawInput;
    Vector2 joystickVec;
    Rigidbody2D myRigidBody2D;


    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        joystickVec = new Vector2(joystick.Horizontal, joystick.Vertical);
    }

    private void Move()
    {
        // myRigidBody2D.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);

        Vector3 delta = joystickVec * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minX, maxX);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minY, maxY);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        joystickVec = value.Get<Vector2>();
    }
}
