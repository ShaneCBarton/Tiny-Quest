using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool GettingKnockedBack {  get; private set; }

    [SerializeField] private float m_knockbackTime = .2f;

    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// This function takes the direction of the opposing objects transform and knocks back the current transform away.
    /// </summary>
    /// <param name="damageSource">Source of damage</param>
    /// <param name="knockbackThrust">Knockback amount multiplier</param>
    public void GetKnockedBack(Transform damageSource, float knockbackThrust)
    {
        GettingKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockbackThrust * m_rigidbody.mass;
        m_rigidbody.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockbackRoutine());
    }

    /// <summary>
    /// This coroutine will ensure that entities are only knocked back briefly and not indefinitely. 
    /// </summary>
    private IEnumerator KnockbackRoutine()
    {
        yield return new WaitForSeconds(m_knockbackTime);
        m_rigidbody.velocity = Vector2.zero;
        GettingKnockedBack = false;

    }
}
