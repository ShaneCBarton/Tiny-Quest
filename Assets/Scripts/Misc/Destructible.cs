
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject m_destroyVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSource>())
        {
            Instantiate(m_destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
