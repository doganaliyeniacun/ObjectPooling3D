using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxX = 3f;        

    private Vector2 inputValue;
    private float startPos;

    private void Awake()
    {
        startPos = transform.position.x;
    }

    private void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void OnMove(InputValue input)
    {
        inputValue = input.Get<Vector2>();

        Direction();
    }

    private void Direction()
    {
        if (inputValue.x == 0)
        {
            return;
        }

        Vector3 movement = new Vector3(inputValue.x > 0 ? startPos + maxX * 2 : startPos - maxX * 2, transform.position.y, transform.position.z);
        
        if (startPos != transform.position.x)
        {
            movement = new Vector3(startPos, transform.position.y, transform.position.z);
        }
        
        rb.MovePosition(movement);
    }
}
