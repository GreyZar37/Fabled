using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;

    public string[] sentences;
    public int index;

    public float typingSpeed;

    public AudioClip[] PersonTalk;
    public AudioClip pop;

    public Button continuebutton;

    public GameObject DialogPanel;
    public GameObject HotBar;

    public AudioClip DialogSong;
    public AudioClip lastSong;

    public AudioClip pageFLip;


    public Animator PersonAnim;

    public bool talking;

    public bool answerNedded;

    public Button buyButton;
    public Button returnButton;

    public Button resumeButton;

    public GameObject character;




    public GameObject shopPanel;
    public GameObject PlayerStats;
    public GameObject PlayerInventory;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (!talking)
        {
            HotBar.SetActive(true);
            DialogPanel.SetActive(false);
        }

       

        if (textDisplay.text != sentences[index])
        {
            resumeButton.interactable = false;
            buyButton.interactable = false;
            returnButton.interactable = false;

        }
        else
        {
            resumeButton.interactable = true;
            buyButton.interactable = true;
            returnButton.interactable = true;

        }


    }
    public IEnumerator Type()
    {
        AudioManager.playSound(PersonTalk, 1);
        HotBar.SetActive(false);


        character.SetActive(true);

        PersonAnim.SetTrigger("Think");

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


        if (index < sentences.Length - 1)
        {
            if (index >= sentences.Length - 2 && answerNedded)
            {
                resumeButton.gameObject.SetActive(false);
                buyButton.gameObject.SetActive(true);
                returnButton.gameObject.SetActive(true);
            }

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
            character.SetActive(false);

        }
    }

    public void openShop()
    {
        shopPanel.SetActive(true);
        PlayerStats.SetActive(false);
        HotBar.SetActive(true);

        PlayerInventory.SetActive(true);
        buyButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        textDisplay.text = "";

        answerNedded = false;
        DialogPanel.SetActive(false);

    }

    public void returnFromShop()
    {
        resumeButton.gameObject.SetActive(true);
        buyButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        shopPanel.SetActive(false);
        PlayerStats.SetActive(true);
        PlayerInventory.SetActive(false);

        answerNedded = false;

        textDisplay.text = "";
        talking = false;
        AudioManager.musicSource.clip = lastSong;
        AudioManager.musicSource.Play();
        GameManager.Instance.state = gameState.playing;
        character.SetActive(false);
    }
}
