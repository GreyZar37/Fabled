using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingScp : MonoBehaviour
{
    public GameObject currentPlant;

    public Texture2D slectedtCursor;

    public Inventory inv;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if(hit == true)
        {
            if(hit.transform.tag == "Plant" && hit.transform.GetComponent<PlantStateManager>().fullyGorwn)
            {
                currentPlant = hit.transform.gameObject;
                PlantStateManager plantstats = currentPlant.GetComponent<PlantStateManager>();

                Cursor_.currentCursor = slectedtCursor;
                if (Input.GetMouseButtonDown(1))
                {
                  inv.addCrop(plantstats.CropName, plantstats.amount);
                   Destroy(hit.transform.gameObject);

                }
            }
            if (hit.transform.tag == "Sign")
            {
                if (Input.GetMouseButtonDown(1))
                {
                    hit.transform.gameObject.GetComponent<SwitchCrops>().Switch(-1);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.gameObject.GetComponent<SwitchCrops>().Switch(1);
                }
            }

        }
        else
        {
            currentPlant = null;
            Cursor_.currentCursor = Cursor_.normalCursor;
        }



    }
}
