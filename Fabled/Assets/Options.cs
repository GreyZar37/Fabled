using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    public Slider SFX;
    public Slider Music;

    public Animator optionAnim;
    public Animator fadeScreen;

    public AudioClip pop;
    public AudioClip highligt;


    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.sfxSource.volume = SFX.value;
        AudioManager.musicSource.volume = Music.value;
        optionAnim.SetBool("Slide", isOpen);

    }

    public void openOptions()
    {
        if (isOpen)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;

        }
    }

    public IEnumerator playGame()
    {
        fadeScreen.SetBool("Fade", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void startGame()
    {
        StartCoroutine(playGame());
    }
    public void quitGame()
    {
        StartCoroutine(quitingGame());
    }
    public IEnumerator quitingGame()
    {
        fadeScreen.SetBool("Fade", true);
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    public void playSound()
    {
        AudioManager.playSound(pop, 1f);
    }
    public void hightLigt()
    {
        AudioManager.playSound(highligt, 1f);

    }
}
