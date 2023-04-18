using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour
{
    [Range(0, 9)]
    public int mySliderFloat;

    public Sprite[] energyLeft;
    public Image energyBarRend;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        energyBarRend.sprite = energyLeft[mySliderFloat];
    }
}
