using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSpawner : MonoBehaviour
{
    public GameObject[] Crops;

    public Collider2D[] spots;

    public List<GameObject> cropsSpawned = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCrop", 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCrop()
    {
        for (int i = 0; i < cropsSpawned.Count; i++)
        {
            if (cropsSpawned[i] == null)
            {
                cropsSpawned.Remove(cropsSpawned[i]);
            }
        }


        if(cropsSpawned.Count < 10)
        {
            Vector2 randomPos = giveRandomPos();
            cropsSpawned.Add(Instantiate(giveRandomCrop(), new Vector2(randomPos.x, randomPos.y), Quaternion.identity));
        }
    }

    GameObject giveRandomCrop()
    {
        float randomNum = Random.Range(0, 101);

        if(randomNum > 30)
        {
            return Crops[0];
        }
        else if(randomNum > 10 && randomNum <= 30)
        {
            return Crops[1];

        }
        else if (randomNum > 1 && randomNum <= 10)
        {
            return Crops[2];
        }
        else if (randomNum >= 0 && randomNum <= 1)
        {
            return Crops[3];
        }
        else
        {
            return Crops[0];
        }
    }

    Vector2 giveRandomPos()
    {
        return GetRandomPointInBounds(spots[Random.Range(0, spots.Length)].bounds);
    }

    public Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        Vector2 randomBounds = bounds.center;
        randomBounds.x += Random.Range(-bounds.extents.x, bounds.extents.x);
        randomBounds.y += Random.Range(-bounds.extents.y, bounds.extents.y);
        return randomBounds;
    }
}
