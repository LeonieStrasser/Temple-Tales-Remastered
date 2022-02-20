using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{

    [SerializeField]private GameObject[] keyLocations;
    [SerializeField] private GameObject[] wind_VFXs;

    [SerializeField] private GameObject[] owlStatues;

    [SerializeField] private GameObject[] treasureLocations;

    private int spawnLocation;

    [Tooltip("This describes the max number of different keys and treasures")]
    public int numberOfSpawns;

    public void Awake()
    {
        treasureLocations = GameObject.FindGameObjectsWithTag("Treasure");

        owlStatues = GameObject.FindGameObjectsWithTag("Owl");

        wind_VFXs = GameObject.FindGameObjectsWithTag("Wind VFX");

        keyLocations = GameObject.FindGameObjectsWithTag("Key");

    }

    public void Start()
    {

        spawnLocation = Random.Range(1, numberOfSpawns + 1);

        if(spawnLocation == 1)
        {
            
            foreach (GameObject obj in keyLocations)
            {
                obj.SetActive(false);
            }
            keyLocations[0].SetActive(true);

            foreach (GameObject obj in owlStatues)
            {
                obj.SetActive(false);
            }

            owlStatues[0].SetActive(true);

            foreach (GameObject obj in treasureLocations)
            {
                obj.SetActive(false);
            }
            treasureLocations[0].SetActive(true);

        }

        if (spawnLocation == 2)
        {
            foreach (GameObject obj in keyLocations)
            {
                obj.SetActive(false);
            }
            keyLocations[1].SetActive(true);

            foreach (GameObject obj in owlStatues)
            {
                obj.SetActive(false);
            }

            owlStatues[1].SetActive(true);

            foreach (GameObject obj in treasureLocations)
            {
                obj.SetActive(false);
            }
            treasureLocations[1].SetActive(true);

        }

        if (spawnLocation == 3)
        {
            foreach (GameObject obj in keyLocations)
            {
                obj.SetActive(false);
            }
            keyLocations[2].SetActive(true);

            foreach (GameObject obj in owlStatues)
            {
                obj.SetActive(false);
            }

            owlStatues[2].SetActive(true);

            foreach (GameObject obj in treasureLocations)
            {
                obj.SetActive(false);
            }
            treasureLocations[2].SetActive(true);

        }

        if (spawnLocation == 4)
        {
            foreach (GameObject obj in keyLocations)
            {
                obj.SetActive(false);
            }
            keyLocations[3].SetActive(true);

            foreach (GameObject obj in owlStatues)
            {
                obj.SetActive(false);
            }

            owlStatues[3].SetActive(true);

            foreach (GameObject obj in treasureLocations)
            {
                obj.SetActive(false);
            }
            treasureLocations[3].SetActive(true);

        }

    }

    public void windEffect()
    {
        if(spawnLocation == 1)
        {
            foreach (GameObject obj in wind_VFXs)
            {
                obj.SetActive(false);
            }
            wind_VFXs[0].SetActive(true);
        }

        if (spawnLocation == 2)
        {
            foreach (GameObject obj in wind_VFXs)
            {
                obj.SetActive(false);
            }
            wind_VFXs[1].SetActive(true);
        }

        if (spawnLocation == 3)
        {
            foreach (GameObject obj in wind_VFXs)
            {
                obj.SetActive(false);
            }
            wind_VFXs[2].SetActive(true);
        }

        if (spawnLocation == 4)
        {
            foreach (GameObject obj in wind_VFXs)
            {
                obj.SetActive(false);
            }
            wind_VFXs[3].SetActive(true);
        }
    }

}
