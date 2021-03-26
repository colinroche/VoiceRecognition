using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;  // for stringbuilder
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;   // grammar recogniser
using UnityEngine.UI;


/*
 *  Uses English US in the settings - Keyboard (on the taskbar), Region, Preferred Language and Speech in Settings
 */

public class GrammarController : MonoBehaviour
{
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private GrammarRecognizer gr;

    [SerializeField] GameObject door_2;
    [SerializeField] GameObject door_3;
    [SerializeField] GameObject door_4;
    [SerializeField] GameObject door_5;
    [SerializeField] GameObject door_6;
    [SerializeField] GameObject door_7;
    [SerializeField] GameObject door_8;

    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject inputsControls;
    [SerializeField] GameObject voiceControls;
    [SerializeField] GameObject settingsOptions;

    [SerializeField] GameObject tutorialCanvas;

    private void Start()
    {
        actions.Add("left", Left);
        actions.Add("right", Right);

        actions.Add("forward", Forward);
        actions.Add("stop", Stop);
        

        actions.Add("mountains", Door1);
        actions.Add("house", Door2);
        actions.Add("flowers", Door3);
        actions.Add("sunrise", Door4);
        actions.Add("trees", Door5);
        actions.Add("cliffs", Door6);
        actions.Add("bay", DoorTutorial);

        actions.Add("pause", Pause);
        actions.Add("resume", Resume);
        actions.Add("input", InputControls);
        actions.Add("voice", VoiceControls);
        actions.Add("menu", ReturnMainMenu);

        actions.Add("game", StartGame);
        actions.Add("tutorial", StartTutorial);
        actions.Add("settings", Settings);

        /*actions.Add("leftTutorial", Prompt2);
        actions.Add("rightTutorial", Prompt3);
        actions.Add("forwardTutorial", Prompt4);
        actions.Add("stopTutorial", Prompt5);*/

        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, 
                                                "SimpleGrammar.xml"), 
                                    ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Recogniser running");
    }

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        Debug.Log("Recognised a phrase");
        // read the semantic meanings from the args passed in.
        SemanticMeaning[] meanings = args.semanticMeanings;
  
        // use foreach to get all the meanings.
        foreach(SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
            message.Append("Key: " + keyString + ", Value: " + valueString + " ");
            actions[valueString].Invoke();
        }
        // use a string builder to create the string and out put to the user
        Debug.Log(message);
    }

    private void Left()
    {
        //FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'RIGHT' TO TURN RIGHT");
        FindObjectOfType<PlayerController>().ChangeAngleLeft();
    }
    private void Right()
    {
        //FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'FORWARD' TO MOVE FORWARD");
        FindObjectOfType<PlayerController>().ChangeAngleRight();
    }

    private void Forward()
    {
        //FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'STOP' TO STOP");
        FindObjectOfType<PlayerController>().SetMovement();
    }
    private void Stop()
    {
        //FindObjectOfType<TutorialText>().FillText("GO TO THE PAINTING TO BE TOLD HOW TO OPEN THE DOOR");
        FindObjectOfType<PlayerController>().StopMovement();
    }

    // == Opens Doors == //
    private void DoorTutorial()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_8);
        playerCanvas.SetActive(false);
    }
    private void Door1()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_2);
        playerCanvas.SetActive(false);
    }
    private void Door2()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_3);
        playerCanvas.SetActive(false);
    }
    private void Door3()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_4);
        playerCanvas.SetActive(false);
    }
    private void Door4()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_5);
        playerCanvas.SetActive(false);
    }
    private void Door5()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_6);
        playerCanvas.SetActive(false);
    }
    private void Door6()
    {
        FindObjectOfType<PaintingBehaviour>().CheckDoor(door_7);
        playerCanvas.SetActive(false);
    }

    private void Pause()
    {
        FindObjectOfType<PauseMenu>().PauseGame();
    }
    private void Resume()
    {
        FindObjectOfType<PauseMenu>().ResumeGame();
        voiceControls.SetActive(false);
        inputsControls.SetActive(false);
        settingsOptions.SetActive(false);
    }
    private void InputControls()
    {
        FindObjectOfType<PauseMenu>().Settings();
        inputsControls.SetActive(true);
    }
    private void VoiceControls()
    {
        tutorialCanvas.SetActive(false);
        FindObjectOfType<PauseMenu>().Settings();
        voiceControls.SetActive(true);
    }
    private void ReturnMainMenu()
    {
        FindObjectOfType<PauseMenu>().QuitGame();
    }

    private void StartGame()
    {
        FindObjectOfType<MainMenu>().PlayGame();
    }
    private void StartTutorial()
    {
        FindObjectOfType<MainMenu>().PlayTutorial();
    }
    private void Settings()
    {
        settingsOptions.SetActive(true);
    }

  /*private void Prompt2()
    {
        FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'RIGHT' TO TURN RIGHT");
    }
    private void Prompt3()
    {
        FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'FORWARD' TO MOVE FORWARD");
    }
    private void Prompt4()
    {
        FindObjectOfType<TutorialText>().FillText("SAY THE WORD 'STOP' TO STOP");
    }
    private void Prompt5()
    {
        FindObjectOfType<TutorialText>().FillText("GO TO THE PAINTING TO BE TOLD HOW TO OPEN THE DOOR");
    }*/
    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }
}
