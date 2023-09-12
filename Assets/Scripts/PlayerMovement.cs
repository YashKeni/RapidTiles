using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 20f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 10f;
    Vector2 rawInput;


    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minX, maxX);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minY, maxY);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
