using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material m_whiteFlash;
    [SerializeField] private float m_restoreDefaultMaterialTime = .1f;

    private Material m_defaultMaterial;
    private SpriteRenderer m_spriteRenderer;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_defaultMaterial = m_spriteRenderer.material;
    }

    public float GetRestoreMaterialTime() { return m_restoreDefaultMaterialTime; }

    /// <summary>
    /// This coroutine will flash a white material on the game object briefly and then return it to default.
    /// Used as visual feedback.
    /// </summary>
    /// <returns></returns>
    public IEnumerator FlashRoutine()
    {
        m_spriteRenderer.material = m_whiteFlash;
        yield return new WaitForSeconds(m_restoreDefaultMaterialTime);
        m_spriteRenderer.material = m_defaultMaterial;
    }
}
