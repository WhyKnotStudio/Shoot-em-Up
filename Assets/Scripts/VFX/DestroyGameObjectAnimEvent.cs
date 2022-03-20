using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectAnimEvent : MonoBehaviour
{
    private void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
