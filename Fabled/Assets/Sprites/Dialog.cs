using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;

    public string[] sentences;
    int index;

    public float typingSpeed;

    public AudioClip[] wolfSpeak;
    public AudioClip pop;

    public Button continuebutton;
    public GameObject DialogPanel;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.playSound(wolfSpeak, 1);
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continuebutton.enabled = true;
        }
        else
        {
            continuebutton.enabled = false;

        }

    }
    IEnumerator Type()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            AudioManager.playSound(pop, .2f);

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

  
    public void nextSentence()
    {
        continuebutton.enabled = false;

        if (index < sentences.Length-1)
        {
            AudioManager.playSound(wolfSpeak, 1);
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            DialogPanel.SetActive(false);
            textDisplay.text = "";
            continuebutton.enabled = false;
        }
    }
}
