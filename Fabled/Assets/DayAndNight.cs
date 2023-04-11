using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayAndNight : MonoBehaviour
{
    public GameObject Arrow;
    public Light2D Light;

    float currentTime;
    int day;

    public Color nightColor;
    public Color dayColor;



    //This is in minutes
    public float wholeDay = 2;

    const float minutesToDegrees = 360 / 60;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = wholeDay *60;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;


        Arrow.transform.rotation = Quaternion.Euler(0, 0, (currentTime * minutesToDegrees) / wholeDay) ;

        Light.color = Color.Lerp(dayColor, nightColor, Mathf.PingPong(Time.time/(wholeDay*30), 1));

        if (currentTime < 0)
        {
            currentTime = wholeDay * 60;
            day++;
        }
    }
}
