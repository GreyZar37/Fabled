using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money;
    public int XP;
    public int level;

    public TextMeshProUGUI playerMoneyText;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text = "$" + money.ToString();

    }
}
