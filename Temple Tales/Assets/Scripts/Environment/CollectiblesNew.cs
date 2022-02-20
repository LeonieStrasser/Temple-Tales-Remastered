using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesNew : MonoBehaviour
{

    [HideInInspector]
    public GameManagerNew gms;



    enum collectible { MSUP, Treasure, Key,}
    [SerializeField] collectible thisItem;

    private int whatCollectible;

    void Start()
    {

        gms = FindObjectOfType<GameManagerNew>();

        IdentifyItem(thisItem);
    }

    collectible IdentifyItem (collectible DT)
    {
        if(DT == collectible.MSUP)
        {
            whatCollectible = 0;
        }

        if (DT == collectible.Treasure)
        {
            whatCollectible = 1;
        }

        if (DT == collectible.Key)
        {
            whatCollectible = 2;
        }

        return DT;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {

            if(whatCollectible == 0) //MSUP
            {
                gms.MSUP();
                gameObject.SetActive(false);
            }

            else if (whatCollectible == 1) // Treasure
            {
                gms.Treasure();
                gameObject.SetActive(false);
            }

            else if (whatCollectible == 2) // Key
            {
                gms.Key();
                gameObject.SetActive(false);
            }

        }
        
    }

}
