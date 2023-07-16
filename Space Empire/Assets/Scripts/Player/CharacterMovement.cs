using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    private float currentSpeed = 0f;
    private bool isSprint;
    private bool isMoving;

    [Header("Controls")]
    public InputAction move;    
    public InputAction sprint;

    private Rigidbody2D _rb2d;
    private Animator _anim;
    private Vector2 smoothedMoveInput;
    private Vector2 moveInputSmoothVelocity;
    private Vector2 direction;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        sprint.started += context => isSprint = true;
        sprint.performed += context => isSprint = true;
        sprint.canceled += context => isSprint = false;
    }

    private void Update()
    {
        AnimateWalk();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        PlayerLookCursor();
    }

    private void OnEnable()
    {
        move.Enable();
        sprint.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        sprint.Disable();
    }
    void AnimateWalk()
    {
        if (Math.Abs(_rb2d.velocity.x) > 0.1f || Math.Abs(_rb2d.velocity.y) > 0.1f)
        {
            isMoving = true;
            _anim.SetBool("walking", isMoving);
        }
        else
        {
            isMoving = false;
            _anim.SetBool("walking", isMoving);
        }
    }
    private void PlayerLookCursor()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;   

    }
    private void SetPlayerVelocity()
    {
        smoothedMoveInput = Vector2.SmoothDamp(
                    smoothedMoveInput,
                    move.ReadValue<Vector2>(),
                    ref moveInputSmoothVelocity,
                    0.1f);

        if (isSprint)
        {
            currentSpeed = moveSpeed * 2.3f;
        }
        else 
        {
            currentSpeed = moveSpeed;
        }
        _rb2d.velocity = smoothedMoveInput * currentSpeed;

    }

}
