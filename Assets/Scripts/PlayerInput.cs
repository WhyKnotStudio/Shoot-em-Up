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
        // Enter Player Movement and Shooting here
    }

    private void Shoot()
    {
        this.m_currentShootInterval = this.m_shootingRate;
        Instantiate(this.m_projectile.gameObject, this.m_shootingPoint.position, Quaternion.identity);
    }
}
