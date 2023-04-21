using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum gameState
{
    playing, paused, inInventory
}
public class GameManager : MonoBehaviour
{
    public gameState state;

    public static GameManager Instance;

    public int money;
    public int XP;
    public int level;

    public TextMeshProUGUI playerMoneyText;

    public GameObject Inventory;
    public GameObject ButtonInventory;

    public Discription box;
    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        playerMoneyText.text = "$" + money.ToString();

        if (Input.GetKeyDown(KeyCode.Tab) && GameManager.Instance.state != gameState.paused)
        {
            if (Inventory.activeInHierarchy)
            {
                Inventory.SetActive(false);
                state = gameState.playing;
                box.DiscriptionBox.gameObject.SetActive(false);
            }
            else
            {
                Inventory.SetActive(true);
                state = gameState.inInventory;

            }
        }
    }
}
