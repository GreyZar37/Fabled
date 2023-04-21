using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public enum ItemType
{
    tool, crop, buildingBlock, seed
}

public enum ActionType
{
    plow, harvest, waterring, seed
}


[CreateAssetMenu (menuName = "Scriptable object/Item")]
public class ItemScript : ScriptableObject
{
   
 


    [Header("Gameplay")]
    public ItemType type;
    public ActionType actionType;
    public GameObject plant;
    public int Sellvalue;
    public int BuyValue;
    public int growTimer;

    public string cropName;
    public Vector2 randomAmount;

    public Vector2Int range = new Vector2Int(5, 4);
    [Header("UI")]
    public bool stackable = true;


    [Header("All")]
    public Sprite Image;
}
