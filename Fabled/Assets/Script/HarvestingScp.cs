using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HarvestingScp : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public ItemScript[] itemsToPickUp;

    public GameObject currentPlant;

    public Texture2D slectedtCursor;

    Tilemap tilemap;

    Animator anim;

    [SerializeField] float harvestingTime;

    Vector3 mousePos;
    Vector2 mousePos2D;

    [SerializeField] Tile intereactedtile;

    [SerializeField] AudioClip harvestingSound;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = TilemapManager.instance.interactableMap;

        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);


        if (hit.transform != null)
        {
            if(hit.transform.GetComponent<PlantStateManager>() != null)
            {
                if (hit.transform.tag == "Plant" && hit.transform.GetComponent<PlantStateManager>().fullyGorwn && distance <= (3 * UpgradeShop.instance.longerCropReachMultiplier))
                {

                    currentPlant = hit.transform.gameObject;
                    PlantStateManager plantstats = currentPlant.GetComponent<PlantStateManager>();

                    Cursor_.currentCursor = slectedtCursor;
                    if (Input.GetMouseButtonDown(1) && PlayerMovement.currentPlayerState == playerState.idle)
                    {
                        StartCoroutine(harvesting(hit, plantstats));
                        Cursor_.currentCursor = Cursor_.normalCursor;

                    }
                }
            }
            
            else
            {
                currentPlant = null;
                Cursor_.currentCursor = Cursor_.normalCursor;
            }

        




        }

        IEnumerator harvesting(RaycastHit2D hit, PlantStateManager plantstats)
        {
            Vector3Int plantPos = GetMousePosition();
            TilemapManager.instance.setInteracted(plantPos, intereactedtile);
            PlayerMovement.currentPlayerState = playerState.harvesting;

            AudioManager.playSound(harvestingSound, 1f);
            anim.SetTrigger("Harvesting");

            pickupItem(plantstats.id);
            Destroy(hit.transform.gameObject);
            yield return new WaitForSeconds(harvestingTime);
            PlayerMovement.currentPlayerState = playerState.idle;

        }
    }
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tilemap.WorldToCell(mouseWorldPos);
    }



    public void pickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        
        if(result == true)
        {

        }
        else
        {

        }
    }
}
