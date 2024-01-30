using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    private ParticleSystem m_ps;

    private void Awake()
    {
        m_ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (m_ps != null && !m_ps.IsAlive())
        {
            DestroySelf();
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
