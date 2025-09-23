using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10;
    private Vector2 m_Move;
    private float rotateSpeed = 10;
    private Vector2 m_Look;
    private Vector2 m_Rotate;
    public HealthnessBar hb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(m_Move);
        Look(m_Look);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        float scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotate.y += rotate.x * scaledRotateSpeed;
        m_Rotate.x = Mathf.Clamp(m_Rotate.x - rotate.y * scaledRotateSpeed, -45, 45);
        transform.localEulerAngles = m_Rotate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            hb.TakeDamage();
        }
    }
}
