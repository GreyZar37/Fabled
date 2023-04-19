using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayAndNight : MonoBehaviour
{
    public GameObject Arrow;
    public Light2D Light;
    public Light2D flashLight;


    float currentTime;
    int day = 1;

    public Color nightColor;
    public Color dayColor;

    public bool raining;
    bool songChanged;

    //This is in minutes
    public float wholeDay = 4;

    const float minutesToDegrees = 360 / 60;

    public ParticleSystem rain;

    public AudioClip RainSong;
    AudioClip lastSong;

    public static DayAndNight Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
           currentTime = wholeDay *60;

        Light.color = dayColor;
        flashLight.color = nightColor;
    }

    // Update is called once per frame
    void Update()
    {
       
            currentTime -= Time.deltaTime;
           
            Arrow.transform.rotation = Quaternion.Euler(0, 0, (currentTime * minutesToDegrees) / wholeDay);

            Light.color = Color.Lerp(dayColor, nightColor, Mathf.PingPong(Time.time / (wholeDay * 30), 1));
            flashLight.color = Color.Lerp(nightColor, dayColor, Mathf.PingPong(Time.time / (wholeDay * 30), 1));

            if (currentTime < 0)
            {
                currentTime = wholeDay * 60;
                day++;
            }

            if (raining == false && day % 3 == 0)
            {
                raining = true;
                rain.Play();
                lastSong = AudioManager.musicSource.clip;
                AudioManager.musicSource.clip = RainSong;
                AudioManager.musicSource.Play();

                songChanged = true;
            }
            else if (raining == true && songChanged == true && day % 3 != 0)
            {
                AudioManager.musicSource.clip = lastSong;
                AudioManager.musicSource.Play();
                raining = false;
                rain.Stop();
                songChanged = false;
            }

       



        
    }
}
