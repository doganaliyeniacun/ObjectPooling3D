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
        Direction();
    }

    public void OnMove(InputValue input)
    {
        inputValue = input.Get<Vector2>();
    }

    private void Direction()
    {
        if (inputValue.x == 0)
        {
            return;
        }

        float xPos = transform.position.x + inputValue.x * Time.deltaTime * speed;
        xPos = Mathf.Clamp(xPos, -maxX + startPos, maxX + startPos);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
