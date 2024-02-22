using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string m_sceneToLoad;
    [SerializeField] private string m_transitionName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene(m_sceneToLoad);
            SceneManagement.Instance.SetTransitionName(m_transitionName);
        }
    }
    

}
