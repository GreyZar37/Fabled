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

    bool talked;
    bool waitingForAnswer;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startConvi()
    {
        dialog.index = 0;
        dialog.sentences = differentConvi[0].sentences;
        dialog.StartCoroutine(dialog.Type());
        dialog.answerNedded = differentConvi[0].answerNeeded;
    }

    public void Answered(int conviNumb)
    {
        dialog.index = 0;
        dialog.sentences = differentConvi[conviNumb].sentences;
        dialog.StartCoroutine(dialog.Type());
     

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "Player")
        {
            startConvi();
        }
    }
}
