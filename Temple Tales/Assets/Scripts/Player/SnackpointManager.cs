using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackpointManager : MonoBehaviour
{

    private GameManagerNew gms;

    private void Start()
    {
        gms = FindObjectOfType<GameManagerNew>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Snackpoint")
        {
            gms.snackpoints++;

            gms.UpdateSnackPoints();

            Destroy(other.gameObject);

            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("numSnacks", gms.snackpoints);
            //FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Collectables/SnakPoint Chromatic", gameObject);
        }
    }

}
