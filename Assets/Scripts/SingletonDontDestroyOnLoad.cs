using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        SingletonDontDestroyOnLoad[] sameTypeObjects = FindObjectsOfType<SingletonDontDestroyOnLoad>();

        if (sameTypeObjects.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
