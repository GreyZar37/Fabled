using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public InventoryManager inventory;
    [SerializeField] GameObject plowingTool;

    public ItemScript tool;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         tool = inventory.GetSelectedItem(false);

        if (tool != false)
        {
            plowingTool.SetActive(tool.actionType == ActionType.plow && tool.type == ItemType.tool);
        }
        else
        {
            plowingTool.SetActive(false);
        }
    }
}
