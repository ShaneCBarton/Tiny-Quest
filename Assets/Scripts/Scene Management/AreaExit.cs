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
            SceneManagement.Instance.SetTransitionName(m_transitionName);

            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }
    
    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(m_sceneToLoad);
    }
}
