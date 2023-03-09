using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCrops : MonoBehaviour
{
    public Plowing plowingScp;

    public GameObject[] plants;
    public SpriteRenderer signSprite;
    int currentNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch(int cropNum)
    {
        currentNum += cropNum;

        if (currentNum < 0)
        {
            currentNum = plants.Length -1;
        }
        else if (currentNum > plants.Length -1)
        {
            currentNum = 0;
        }

        signSprite.sprite = plants[currentNum].GetComponent<SpriteRenderer>().sprite;
        plowingScp.plant = plants[currentNum];
    }

}
