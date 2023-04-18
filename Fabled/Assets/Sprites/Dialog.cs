using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;

    public string[] sentences;
    public int index;

    public float typingSpeed;

    public AudioClip[] wolfSpeak;
    public AudioClip pop;

    public Button continuebutton;
   
    public GameObject DialogPanel;
    public GameObject HotBar;

    public AudioClip DialogSong;
    public AudioClip lastSong;

    public AudioClip pageFLip;


    public Animator wolfAnim;

    public bool talking;

    public bool answerNedded;

    public Button[] buttons;
    public Button resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.playSound(wolfSpeak, 1);
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {

        if (talking)
        {
            HotBar.SetActive(false);
            DialogPanel.SetActive(true);
        }

        else {
            HotBar.SetActive(true);
            DialogPanel.SetActive(false);
        }

     

    }
    public IEnumerator Type()
    {
        if (!answerNedded)
        {
            resumeButton.gameObject.SetActive(true);
        }
        else
        {
            waitingForAnswer_();
            resumeButton.gameObject.SetActive(false);

        }
        wolfAnim.SetTrigger("Think");

        if (talking == false)
        {
            lastSong = AudioManager.musicSource.clip;
            AudioManager.musicSource.clip = DialogSong;
            AudioManager.musicSource.Play();
            GameManager.Instance.state = gameState.paused;

        }
        talking = true;
        
     

        foreach (var letter in sentences[index].ToCharArray())
        {
            AudioManager.playSound(pop, .2f);

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

  
    public void nextSentence()
    {
        AudioManager.playSound(pageFLip, 1f);
     

        if (index < sentences.Length-1)
        {
            AudioManager.playSound(wolfSpeak, 1);
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            talking = false;
            AudioManager.musicSource.clip = lastSong;
            AudioManager.musicSource.Play();
            GameManager.Instance.state = gameState.playing;

        }
    }

    public void waitingForAnswer_()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }

    public void answered()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }
}
