using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return m_facingLeft; } set { m_facingLeft = value; } }

    [SerializeField] float m_moveSpeed = 1f;

    private PlayerControls m_playerControls;
    private Vector2 m_movement;
    private Rigidbody2D m_rigidbody;
    private Animator m_myAnimator;

    private bool m_facingLeft = false;

    private void Awake()
    {
        m_playerControls = new PlayerControls();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_myAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        m_playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        PlayerFacingDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// This function reads an input value from the input system, sets the movement vector and then 
    /// relays information to the animator to control animations states.
    /// </summary>
    private void PlayerInput()
    {
        m_movement = m_playerControls.Movement.Move.ReadValue<Vector2>();
        m_myAnimator.SetFloat("MoveX", m_movement.x);
        m_myAnimator.SetFloat("MoveY", m_movement.y);
    }

    /// <summary>
    /// This function moves the rigidbody's position by the players input movement vector 
    /// multiplied by a serialized move speed.
    /// </summary>
    private void Move()
    {
        Vector2 position = m_rigidbody.position + m_movement * (m_moveSpeed * Time.fixedDeltaTime);
        m_rigidbody.MovePosition(position);
    }

    /// <summary>
    /// This funciton will check the players facing similar to sword.cs
    /// Then we will set our FacingLeft property accordingly.
    /// </summary>
    private void PlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            FacingLeft = true;
        }
        else
        {
            FacingLeft = false;
        }
    }

}