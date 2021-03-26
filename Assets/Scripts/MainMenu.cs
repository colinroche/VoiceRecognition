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
    [SerializeField] GameObject tutorialCanvas;

    public void PlayTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        tutorialCanvas.SetActive(true);
        gameDoors.SetActive(false);
        tutorialDoors.SetActive(true);
        player.SetActive(true);
        menu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //tutorialCanvas.SetActive(false);
        gameDoors.SetActive(true);
        tutorialDoors.SetActive(false);
        player.SetActive(true);
        menu.SetActive(false);
    }
}
