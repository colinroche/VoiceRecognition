using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persists : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
