using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentUI : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PersistentUI");

        if (objs.Length > 2)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
