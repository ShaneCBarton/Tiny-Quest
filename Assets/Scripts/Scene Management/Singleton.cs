using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T m_instance;

    public static T Instance { get { return m_instance; } }

    protected virtual void Awake()
    {
        if (m_instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = (T)this;
        }

        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
