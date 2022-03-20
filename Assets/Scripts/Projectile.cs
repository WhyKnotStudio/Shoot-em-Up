using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private const int ENEMY_LAYER = 6;
    private const int SCORE_PER_HIT = 10;

    [SerializeField] private float m_movementSpeed = 15f;
    [SerializeField] private GameObject m_explosionVFX = null;

    private Vector2 m_projectileScreenBound = Vector2.zero;

    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Awake()
    {
        Vector3 screenBound = new Vector3(Screen.width, Screen.height, 0f);
        this.m_projectileScreenBound = Camera.main.ScreenToWorldPoint(screenBound);
    }

    private void Update()
    {
        // Constantly moving up
        this.transform.Translate(Vector2.up * this.m_movementSpeed * Time.deltaTime);

        this.OutOfScreenDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ENEMY_LAYER)
        {
            GameHandler.Instance.SetScore(GameHandler.Instance.GetCurrentScore() + SCORE_PER_HIT);

            Instantiate(this.m_explosionVFX, collision.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Function

    private void OutOfScreenDestroy()
    {
        if (this.transform.position.y >= this.m_projectileScreenBound.y)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion Function

    //======================================================================================================================================================================================================================
}