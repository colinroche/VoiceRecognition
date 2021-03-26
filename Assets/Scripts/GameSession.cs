﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject menuPersists;
    [SerializeField] GameObject objectPersists;
    [SerializeField] GameObject end;
    [SerializeField] GameObject player;

    [SerializeField] Text playerPrompt;

    private int scene;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGameSession()
    {
        Destroy(menuPersists);
        Destroy(objectPersists);
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        end.SetActive(true);
    }

    public void OpenDoor(string word)
    {
        playerPrompt.text = word;
    }
    
    void Update()
    {
        
    }


}
