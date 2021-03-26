using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject gameDoors;
    [SerializeField] GameObject tutorialDoors;
    [SerializeField] GameObject player;
    [SerializeField] GameObject menu;

    public void PlayTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameDoors.SetActive(false);
        tutorialDoors.SetActive(true);
        player.SetActive(true);
        menu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        gameDoors.SetActive(true);
        tutorialDoors.SetActive(false);
        player.SetActive(true);
        menu.SetActive(false);
    }
}
