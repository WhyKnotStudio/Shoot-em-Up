using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed = 5f;
    [SerializeField] private Vector2 m_screenBoundPercentage = new Vector2(1.1f, 1.1f); // can do a gizmo to draw bound, use to adjust bound of enemy space

    private Vector2 m_enemyScreenBound = Vector2.zero;

    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Awake()
    {
        float screenBoundX = Screen.width * this.m_screenBoundPercentage.x;
        float screenBoundY = Screen.height * this.m_screenBoundPercentage.y;
        Vector3 adjustedScreenBound = new Vector3(screenBoundX, screenBoundY, 0f);

        this.m_enemyScreenBound = Camera.main.ScreenToWorldPoint(adjustedScreenBound);

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z + 180);
    }

    private void Update()
    {
        // Constantly moving down
        this.transform.Translate(Vector2.up * this.m_movementSpeed * Time.deltaTime);

        this.OutOfScreenDestroy();
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Function

    private void OutOfScreenDestroy()
    {
        if (this.transform.position.y <= -this.m_enemyScreenBound.y)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion Function

    //======================================================================================================================================================================================================================
}