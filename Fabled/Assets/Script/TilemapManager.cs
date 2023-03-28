using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{

    public Tilemap interactableMap;
    [SerializeField] Tile interactableTile;
    public static TilemapManager instance;
    [SerializeField] Tile intereactedtile;
    [SerializeField] Tile planted;
    public TileBase tile;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public bool interactable(Vector3Int position)
    {

       tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable" || tile.name == "Plot")
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }
        else
        {
            return false;
        }

    }

    public TileBase getTile(Vector3Int position)
    {
        return interactableMap.GetTile(position);
    }

    public void setInteracted(Vector3Int position, GameObject plant)
    {
        
        if (tile.name == "Plot")
        {
            
            Instantiate(plant,interactableMap.GetCellCenterWorld(position), Quaternion.identity);
            interactableMap.SetTile(position, planted);
        }

    }

    public void setInteracted(Vector3Int position)
    {


        if (tile.name == "Interactable")
        {
            interactableMap.SetTile(position, intereactedtile);
        }
      

    }
    public void setInteracted(Vector3Int position, Tile tile)
    {

            interactableMap.SetTile(position, tile);
       

    }

 
}
