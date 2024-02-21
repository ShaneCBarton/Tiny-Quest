//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Parallax : MonoBehaviour
//{
//    [SerializeField] private float m_parallaxOffset = -0.15f;

//    private Camera m_camera;
//    private Vector2 m_startPosition;
//    private Vector2 m_travel => (Vector2)m_camera.transform.position - m_startPosition;

//    private void Awake()
//    {
//        m_camera = Camera.main;
//    }

//    private void Start()
//    {
//        m_startPosition = transform.position;
//    }

//    private void FixedUpdate()
//    {
//        transform.position = m_startPosition + m_travel * m_parallaxOffset;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxOffset = -0.15f;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.position = cam.transform.position * parallaxOffset;
    }
}
