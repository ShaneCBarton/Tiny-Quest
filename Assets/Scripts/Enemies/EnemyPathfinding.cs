using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2f;

    private Rigidbody2D m_rigidbody;
    private Vector2 m_movementDirection;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_rigidbody.MovePosition(m_rigidbody.position + m_movementDirection * (m_moveSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// This function will take a direction to move our enemy in. 
    /// </summary>
    /// <param name="targetPosition"></param>
    public void MoveTo(Vector2 targetPosition)
    {
        m_movementDirection = targetPosition;
    }
    
}
