using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public float MovementSpeed = 20f;
    public float DiagonalLimiter = 0.7f;

    private Rigidbody2D _rigidbody2d;

    private float _horizMovement;

    private float _vertMovement;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizMovement = Input.GetAxis("Horizontal");
        _vertMovement = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_horizMovement != 0f && _vertMovement != 0f) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            _horizMovement *= DiagonalLimiter;
            _vertMovement *= DiagonalLimiter;
        }

        _rigidbody2d.velocity = new Vector2(_horizMovement * MovementSpeed, _vertMovement * MovementSpeed);
    }
}
