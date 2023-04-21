using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Discription : MonoBehaviour
{
    public Transform DiscriptionBox;

    public Vector3 offset;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI growingTimeText;
    public Image Icon;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        DiscriptionBox.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, mousePos.z + offset.z);
    }
}
