using UnityEngine;

public  class Market : MonoBehaviour
{

    public GameObject shopPanel;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shopPanel.SetActive(false);
    }



    

}
