using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int m_startingHealth = 3;
    [SerializeField] private int m_knockbackAmount = 5;

    private int m_currentHealth;
    private Knockback m_knocback;
    private Flash m_flash;

    private void Awake()
    {
        m_knocback = GetComponent<Knockback>();
        m_flash = GetComponent<Flash>();
    }

    private void Start()
    {
        m_currentHealth = m_startingHealth;
    }

    /// <summary>
    /// This function will decrease current health based on the passed in paramater as
    /// well as knock the enemy back. It also runs a coroutine that flashes the character 
    /// white as feedback.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        m_currentHealth -= damage;
        m_knocback.GetKnockedBack(PlayerController.Instance.transform, m_knockbackAmount);
        StartCoroutine(m_flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(m_flash.GetRestoreMaterialTime());
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
