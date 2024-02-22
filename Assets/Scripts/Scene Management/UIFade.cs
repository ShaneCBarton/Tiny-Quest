using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image m_fadeScreen;
    [SerializeField] private float m_fadeSpeed;

    private IEnumerator m_fadeRoutine;

    public void FadeToBlack()
    {
        if (m_fadeRoutine != null)
        {
            StopCoroutine(m_fadeRoutine);
        }

        m_fadeRoutine = FadeRoutine(1);
        StartCoroutine(m_fadeRoutine);
    }

    public void FadeToClear()
    {
        if (m_fadeRoutine != null)
        {
            StopCoroutine(m_fadeRoutine);
        }

        m_fadeRoutine = FadeRoutine(0);
        StartCoroutine(m_fadeRoutine);
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(m_fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(m_fadeScreen.color.a, targetAlpha , m_fadeSpeed * Time.deltaTime);
            m_fadeScreen.color = new Color(m_fadeScreen.color.r, m_fadeScreen.color.g, m_fadeScreen.color.b, alpha);

            yield return null;
        }
    }
}
