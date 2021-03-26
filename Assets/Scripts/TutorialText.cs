using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField] Text tutorialPrompt;

    void Start()
    {
        FillText("Say the phrase 'Voice Controls' to check the inputs for speech");
    }

    public void FillText(string word)
    {
        tutorialPrompt.text = word;
    }
}
