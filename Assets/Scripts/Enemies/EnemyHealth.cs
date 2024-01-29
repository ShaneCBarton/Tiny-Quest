using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int m_startingHealth = 3;

    private int m_currentHealth;

    private void Start()
    {
        m_currentHealth = m_startingHealth;
    }

    /// <summary>
    /// This function will decrease current health based on the passed in paramater.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        m_currentHealth -= damage;
        DetectDeath();
    }

    /// <summary>
    /// This function checks the current health and then destroys the object if the health has run out.
    /// </summary>
    private void DetectDeath()
    {
        if (m_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
