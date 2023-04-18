using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct sentence
{
    public string[] sentences;
    public bool answerNeeded;


}
public class Convirsation : MonoBehaviour
{
    public sentence[] differentConvi;
    public Dialog dialog;

    public AudioClip[] talkSound;

    public AudioClip music;


    public Animator characterAnim;

    public GameObject characterModel;

    bool talked;
    bool waitingForAnswer;

    [SerializeField]bool volk;
    // Start is called before the first frame update
  
   
    private void Start()
    {
        if (volk)
        {
            startConvi();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startConvi()
    {
        dialog.DialogSong = music;
        dialog.PersonAnim = characterAnim;
        dialog.character = characterModel;
        dialog.PersonTalk = talkSound;


        dialog.index = 0;
        dialog.sentences = differentConvi[0].sentences;
        dialog.answerNedded = differentConvi[0].answerNeeded;
        StartCoroutine(dialog.Type());

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "Player")
        {
            startConvi();
        }
    }
}
