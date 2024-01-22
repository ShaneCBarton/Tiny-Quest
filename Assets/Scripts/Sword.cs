using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls m_playerControls;
    private Animator m_animator;
    private PlayerController m_playerController;
    private ActiveWeapon m_activeWeapon;

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

    /// <summary>
    /// Activate sword animation
    /// </summary>
    private void Attack()
    {
        m_animator.SetTrigger("Attack");
    }

    private void Update()
    {
        MouseFollowWithOffset();
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

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            m_activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else if (mousePos.x > playerScreenPoint.x)
        {
            m_activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
