using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 1f;

    private PlayerControls m_playerControls;
    private Vector2 m_movement;
    private Rigidbody2D m_Rigidbody;
    private Animator m_myAnimator;

    private void Awake()
    {
        m_playerControls = new PlayerControls();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_myAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        m_playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        m_movement = m_playerControls.Movement.Move.ReadValue<Vector2>();
        m_myAnimator.SetFloat("MoveX", m_movement.x);
        m_myAnimator.SetFloat("MoveY", m_movement.y);
    }

    private void Move()
    {
        Vector2 position = m_Rigidbody.position + m_movement * (m_moveSpeed * Time.fixedDeltaTime);
        m_Rigidbody.MovePosition(position);
    }

}
