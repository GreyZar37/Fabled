using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public struct itemNeed
{
    public string itemNedded;
    public int amount;
}
[System.Serializable]
public struct mission
{
    public string[] dialogText;
    public int moneyNedded;
    public itemNeed[] item;

}

public class WolfMission : MonoBehaviour
{
    public Transform player;

    public TextMeshPro moneyNeedText;

    public Dialog dialog;

    public mission[] missions;
    public AudioSource guitar;

    int missionNumb;

    public Animator volkAnim;

    public GameObject missionBouble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyNeedText.text = "$"+ missions[missionNumb].moneyNedded.ToString();
        volkAnim.SetBool("Playing", DayAndNight.Instance.raining);


        if(GameManager.Instance.state == gameState.paused)
        {
            missionBouble.SetActive(false);
        }
        else if (!DayAndNight.Instance.raining && GameManager.Instance.state != gameState.paused)
        {
            missionBouble.SetActive(true);
            AudioManager.musicSource.volume = 1;
            guitar.mute = true;
        }


        if (DayAndNight.Instance.raining)
        {
            missionBouble.SetActive(false);
            guitar.mute = false;
            if (Vector2.Distance(transform.position, player.position) <= guitar.minDistance)
            {
                AudioManager.musicSource.volume = 0;
            }
            else
            {
                AudioManager.musicSource.volume = 1;

            }
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.money > missions[missionNumb].moneyNedded && !DayAndNight.Instance.raining)
        {
            dialog.index = 0;
            dialog.sentences = missions[missionNumb].dialogText;
            dialog.StartCoroutine(dialog.Type());
            GameManager.Instance.money -= missions[missionNumb].moneyNedded;
            missionNumb++;
        }
    }
}
