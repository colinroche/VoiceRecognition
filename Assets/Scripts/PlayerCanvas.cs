using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
   private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}