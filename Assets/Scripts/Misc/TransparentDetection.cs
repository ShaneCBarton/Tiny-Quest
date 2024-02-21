using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float m_transparencyAmount = 0.8f;
    [SerializeField] private float m_fadeTime = 0.4f;

    private SpriteRenderer m_spriteRenderer;
    private Tilemap m_tilemap;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (m_spriteRenderer)
            {
                StartCoroutine(FadeRoutine(m_spriteRenderer, m_fadeTime, m_spriteRenderer.color.a, m_transparencyAmount));
            } 
            else if (m_tilemap)
            {
                StartCoroutine(FadeRoutine(m_tilemap, m_fadeTime, m_tilemap.color.a, m_transparencyAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (m_spriteRenderer)
            {
                StartCoroutine(FadeRoutine(m_spriteRenderer, m_fadeTime, m_spriteRenderer.color.a, 1f));
            }
            else if (m_tilemap)
            {
                StartCoroutine(FadeRoutine(m_tilemap, m_fadeTime, m_tilemap.color.a, 1f));
            }
        }
    }

    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newTransparency = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newTransparency);
            yield return null;
        }
    }

    private IEnumerator FadeRoutine(Tilemap tilemap, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newTransparency = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newTransparency);
            yield return null;
        }
    }
}
