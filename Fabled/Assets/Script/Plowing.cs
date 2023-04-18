using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plowing : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;

    private Vector3Int previousMousePos = new Vector3Int();
    Tilemap tilemap;
    [SerializeField] Tile hoverTile;
    [SerializeField] Tilemap tileMapHover;
    [SerializeField] float plowingTime;

    ItemScript currentItem;

    Animator anim;

    Equipment tools;

    [SerializeField] AudioClip plowingSound;
    [SerializeField] AudioClip plantingSound;


    private void Start()
    {
        tilemap = TilemapManager.instance.interactableMap;
        anim = GetComponent<Animator>();
        tools = GetComponent<Equipment>();
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


        if (Input.GetMouseButtonDown(0) && distance <= 3 && PlayerMovement.currentPlayerState == playerState.idle && GameManager.Instance.state == gameState.playing)
        {
            Vector3Int position = GetMousePosition();

            if(TilemapManager.instance.getTile(position) != null)
            {
                if (TilemapManager.instance.getTile(position).name == "Interactable" && tools.tool.actionType == ActionType.plow && tools.tool.type == ItemType.tool)
                {
                    StartCoroutine(plowing());

                }
                else if (TilemapManager.instance.getTile(position).name == "Plot" && tools.tool.actionType != ActionType.plow && tools.tool.type != ItemType.tool)
                {
                    currentItem = inventory.GetSelectedItem(false);

                    if (currentItem != null)
                    {

                        if (currentItem.type == ItemType.seed)
                        {
                            currentItem = inventory.GetSelectedItem(true);
                            StartCoroutine(Plant());
                        }
                    }
                    
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
            AudioManager.playSound(plowingSound, 1);
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
            AudioManager.playSound(plantingSound,1f);

                    PlayerMovement.currentPlayerState = playerState.planting;
                    anim.SetTrigger("Planting");
                    TilemapManager.instance.setInteracted(position, currentItem.plant);

                }
        
        yield return new WaitForSeconds(plowingTime);
       
     
        PlayerMovement.currentPlayerState = playerState.idle;
    }

 

}
