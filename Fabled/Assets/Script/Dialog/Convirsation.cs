using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct sentence
{
    public string[] sentences;
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

    public GameObject buyButton;
    public GameObject returnutton;

    [SerializeField]bool volk;



    public GameObject shopPanel;
   
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
        if (!talked)
        {
            dialog.sentences = differentConvi[0].sentences;
            talked = true;
        }
        else
        {

            if (!volk)
            {
                dialog.answerNedded = true;
                dialog.sentences = differentConvi[1].sentences;

            }
            
        }
        dialog.DialogSong = music;
        dialog.PersonAnim = characterAnim;
        dialog.character = characterModel;
        dialog.PersonTalk = talkSound;

        dialog.shopPanel = shopPanel;

        dialog.index = 0;

       

        StartCoroutine(dialog.Type());

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "Player")
        {
            if(!volk)
            startConvi();
        }
    }

    public void returnFromShop()
    {
        dialog.returnFromShop();
    }
}
