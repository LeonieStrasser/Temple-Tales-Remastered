using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettingsNew : MonoBehaviour
{

    private GameManagerNew gms;



    public void Start()
    {
        gms = FindObjectOfType<GameManagerNew>();


        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;



    }

}
