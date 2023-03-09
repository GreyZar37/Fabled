using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plowing : MonoBehaviour
{
    private Vector3Int previousMousePos = new Vector3Int();
    Tilemap tilemap;
    [SerializeField] Tile hoverTile;
    [SerializeField] Tilemap tileMapHover;

    public GameObject plant;
    private void Start()
    {
        tilemap = TilemapManager.instance.interactableMap;
    }

    private void Update()
    {
        Vector3Int mousePos = GetMousePosition();
     
        if (!mousePos.Equals(previousMousePos))
        {
            tileMapHover.SetTile(previousMousePos, null); // Remove old hoverTile
            tileMapHover.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);


        if (Input.GetMouseButtonDown(0) && distance <= 1)
        {
            Vector3Int position = GetMousePosition();


            if (TilemapManager.instance.interactable(position))
            {

                    TilemapManager.instance.setInteracted(position, plant);
            }
           

           

        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tilemap.WorldToCell(mouseWorldPos);
    }
}
