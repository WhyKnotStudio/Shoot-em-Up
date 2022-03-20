using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Movement variable
    [SerializeField] private float m_movementSpeed = 10f;

    // Shoot variables
    [SerializeField] private Transform m_shootingPoint = null;
    [SerializeField] private Projectile m_projectile = null;
    [SerializeField] private float m_shootingRate = 0.1f;

    private float m_currentShootInterval = 0f;

    private void Update()
    {
        // Player Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector2.up * this.m_movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector2.down * this.m_movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector2.left * this.m_movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector2.right * this.m_movementSpeed * Time.deltaTime);
        }

        // Shoot
        if (this.m_currentShootInterval > 0f)
        {
            this.m_currentShootInterval -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && this.m_currentShootInterval <= 0)
        {
            this.Shoot();
        }
    }

    private void Shoot()
    {
        this.m_currentShootInterval = this.m_shootingRate;
        Instantiate(this.m_projectile.gameObject, this.m_shootingPoint.position, Quaternion.identity);
    }
}
