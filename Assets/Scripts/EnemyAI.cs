using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    private State m_state;
    private EnemyPathfinding m_pathfinding;

    private void Awake()
    {
        m_pathfinding = GetComponent<EnemyPathfinding>();
        m_state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    /// <summary>
    /// This coroutine calls a function to generate a new direction and then calls a function
    /// from EnemyPathfinding script to move in that direction. Every 2 seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RoamingRoutine()
    {
        while (m_state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            m_pathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2);
        }
    }

    /// <summary>
    /// This function generates a new direction for an enemy to move in
    /// </summary>
    /// <returns>Direction as a Vector2</returns>
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
