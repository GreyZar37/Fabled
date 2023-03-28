using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plowing : MonoBehaviour
{
    Inventory inventory;

    private Vector3Int previousMousePos = new Vector3Int();
    Tilemap tilemap;
    [SerializeField] Tile hoverTile;
    [SerializeField] Tilemap tileMapHover;
    [SerializeField] float plowingTime;
    int seeds;

    Animator anim;

    public GameObject plant;
    private void Start()
    {
        inventory = GetComponent<Inventory>();
        tilemap = TilemapManager.instance.interactableMap;
        anim = GetComponent<Animator>();
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


        if (Input.GetMouseButtonDown(0) && distance <= 1 && PlayerMovement.currentPlayerState == playerState.idle)
        {
            Vector3Int position = GetMousePosition();

            if(TilemapManager.instance.getTile(position).name != null)
            {
                if (TilemapManager.instance.getTile(position).name == "Interactable")
                {
                    StartCoroutine(plowing());

                }
                else if (TilemapManager.instance.getTile(position).name == "Plot")
                {
                    StartCoroutine(Plant());
                }
            }
            
        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tilemap.WorldToCell(mouseWorldPos);
    }

    IEnumerator plowing()
    {
        Vector3Int position = GetMousePosition();


        if (TilemapManager.instance.interactable(position))
        {
            PlayerMovement.currentPlayerState = playerState.plowing;
            anim.SetTrigger("Plowing");
            TilemapManager.instance.setInteracted(position);
        }

        yield return new WaitForSeconds(plowingTime);
        PlayerMovement.currentPlayerState = playerState.idle;
    }

    IEnumerator Plant()
    {
        Vector3Int position = GetMousePosition();

        if (TilemapManager.instance.interactable(position))
        {
           seeds = PlantIt(plant.GetComponent<PlantStateManager>());

            if(seeds > 0)
            {
                PlayerMovement.currentPlayerState = playerState.planting;
                anim.SetTrigger("Planting");
                TilemapManager.instance.setInteracted(position, plant);
            }
        }

        yield return new WaitForSeconds(plowingTime);
        if(seeds > 0)
        {
            PlayerMovement.currentPlayerState = playerState.idle;
        }
        inventory.refreashUI();
    }

    public int PlantIt(PlantStateManager plant)
    {
        switch (plant.seeds)
        {
            case seedsNeeded.pumpkingsSeeds:
                if (inventory.pumpkinsSeeds > 0)
                {
                    inventory.pumpkinsSeeds--;
                    return inventory.pumpkinsSeeds + 1;
                }
                break;
            case seedsNeeded.carrotsSeeds:
                if (inventory.carrotsSeeds > 0)
                {
                    inventory.carrotsSeeds--;
                    return inventory.carrotsSeeds + 1;

                }


                break;
            case seedsNeeded.wheatSeeds:
                if (inventory.wheatSeeds > 0)
                {
                    inventory.wheatSeeds--;
                    return inventory.wheatSeeds + 1;

                }

                break;
            case seedsNeeded.eggPlantSeeds:
                if (inventory.eggPlantSeeds > 0)
                {
                    inventory.eggPlantSeeds--;
                    return inventory.eggPlantSeeds +1 ;
                }

                break;
            case seedsNeeded.potatoesSeeds:
                if (inventory.potatoesSeeds > 0)
                {
                    inventory.potatoesSeeds--;
                    return inventory.potatoesSeeds + 1;
                }
                break;


        }
        return 0;
    }
}
