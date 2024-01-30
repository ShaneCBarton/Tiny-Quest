using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour

{
    [SerializeField] private GameObject m_slashAnimPrefab;
    [SerializeField] private Transform m_slashAnimSpawnPoint;
    [SerializeField] private Transform m_weaponCollider;

    private PlayerControls m_playerControls;
    private Animator m_animator;
    private PlayerController m_playerController;
    private ActiveWeapon m_activeWeapon;

    private GameObject m_slashAnim;

    private void Awake()
    {
        m_playerController = GetComponentInParent<PlayerController>();
        m_activeWeapon = GetComponentInParent<ActiveWeapon>();
        m_playerControls = new PlayerControls();
        m_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        m_playerControls.Enable();
    }

    private void Start()
    {
        m_playerControls.Combat.Attack.started += _ => Attack();
    }
    private void Update()
    {
        MouseFollowWithOffset();
    }

    /// <summary>
    /// Activate attack animation and slash effect animation.
    /// </summary>
    private void Attack()
    {
        m_animator.SetTrigger("Attack");
        m_weaponCollider.gameObject.SetActive(true);

        m_slashAnim = Instantiate(m_slashAnimPrefab, m_slashAnimSpawnPoint.position, Quaternion.identity);
        m_slashAnim.transform.parent = this.transform.parent;
    }

    public void DoneAttackingAnimEvent()
    {
        m_weaponCollider.gameObject.SetActive(false);
    }


    /// <summary>
    /// This function will flip the animation depending on facing direction.
    /// </summary>
    public void SwingUpFlipAnimEvent()
    {
        m_slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (m_playerController.FacingLeft)
        {
            m_slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /// <summary>
    /// This function is essentially the same as SwingUpFlip but for the
    /// down swing. Maybe a cleaner way to do this without copying code.
    /// </summary>
    public void SwingDownFlipAnimEvent()
    {
        m_slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (m_playerController.FacingLeft)
        {
            m_slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /// <summary>
    /// This function tracks wether or not the mouse cursor is currently on the left or right of the player
    /// Then we use a math function to calculate an angle based on this mouse position
    /// and set a rotation to our active weapon. THis will make the weapon somewhat rotate towards the cursor
    /// as well as flip the weapon to either be left or right facing
    /// </summary>
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(m_playerController.transform.position);

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            m_activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            m_weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (mousePos.x > playerScreenPoint.x)
        {
            m_activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            m_weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
