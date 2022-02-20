using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerNew : MonoBehaviour
{

    /*/-------------------------------------------------------------/*/

    [Header("Health Regeneration")]
    [Space(10f)]
    [HideInInspector]
    public int PointsNeededForHealth;
    [HideInInspector]
    public int HowManyPointsForHP;

    /*/-------------------------------------------------------------/*/
    
    [HideInInspector]
    public PlayerMovement PM;
    [HideInInspector]
    public float MS;

    [Header("MSUP")]
    [Space(10f)]
    public GameObject MSUP_VFX;
    public GameObject MSUP_Icon;

    public int MSUP_Strength;
    public int MSUP_Duration;

    /*/-------------------------------------------------------------/*/

    [Header("Snackpoints")]
    [Space(10f)]
    public int snackpoints;
    public TMP_Text displayScore;
    public int highscore;
    string highscoreKey;

    [Tooltip("Highscore Text component which activates in the end screen.")]
    public TextMeshProUGUI highscorePoints;
    public GameObject highscoreSprite;

    /*/-------------------------------------------------------------/*/

    private bool hasKey;
    [Header("Key")]
    [Space(10f)]
    public GameObject KeySprite;

    /*/-------------------------------------------------------------/*/

    [Header("Canvases")]
    [Space(10f)]

    public GameObject gameOverCanvas;
    public GameObject freeLookCamera;
    [Space(10f)]
    public GameObject pauseMenu;

    /*/-------------------------------------------------------------/*/

    [SerializeField] private int timeLeft = 20;
    private bool takeAway = true;
    private bool endScreenTimer;

    public Health health;

    [Header("Timer")]
    [Space(10f)]
    public TMP_Text timeDisplay;

    [HideInInspector]
    public int timeValueMultiplier;

    [HideInInspector]
    public bool playerWon = false;
    [HideInInspector]
    public bool inPauseMenu = false;

    /*/-------------------------------------------------------------/*/



    /*/-------------------------------------------------------------/*/

    void Start()
    {
        timeDisplay.text = timeLeft.ToString();
        displayScore.text = snackpoints.ToString();

        PM = FindObjectOfType<PlayerMovement>();
        MS = FindObjectOfType<PlayerMovement>().speed;
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);

    }

    
    void Update()
    {
        #region Timer
        if (timeLeft > 0 && takeAway == true)
        {
            if (timeLeft != 0)
            {
                StartCoroutine(TimerTake());
            }        
        }

        if(playerWon == true && endScreenTimer == false)
        {

        }

        if(timeLeft == 0 && playerWon == true)
        {
            HighscoreCheck();
        }
        if (timeLeft <= 0 && gameOverCanvas != enabled)
        {
            Debug.Log("Zeit abgelaufen!");
            GameOver();
        }
        #endregion

        #region Input Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseMenu();
        }
        #endregion Input Pause
    }

    #region Key
    public void Key()
    {

        if(hasKey == true)
        {
            //Open Final Door
        }
        else
        {
            KeySprite.SetActive(true);
            hasKey = true;
        }

    }
    #endregion Key

    #region Snackpoints
    public void UpdateSnackPoints()
    {
        displayScore.text = snackpoints.ToString();
    }
    #endregion Snackpoints

    #region Treasure
    public void Treasure()
    {
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/Treasure");
        snackpoints += 1000;

        UpdateSnackPoints();
    }
    #endregion Treasure

    #region MSUP
    public void MSUP()
    {

        PM.speed = MS + MSUP_Strength;

        MSUP_VFX.SetActive(true);

        MSUP_Icon.SetActive(true);

        StartCoroutine(MSUP_Length());
    }
    #endregion MSUP

    #region Update HP
    public void HPUpdate()
    {
        HowManyPointsForHP = PointsNeededForHealth;

    }
    #endregion Update HP

    #region Check Highscore
    void HighscoreCheck()
    {
        highscorePoints.text = highscore.ToString();

        if (snackpoints > highscore)
        {
            PlayerPrefs.SetInt(highscoreKey, snackpoints);

            PlayerPrefs.Save();
            highscoreSprite.SetActive(true);
        }
    }
    #endregion Check Highscore

    #region Game Over
    public void GameOver()
    {

        gameOverCanvas.SetActive(true);

        freeLookCamera.SetActive(false);

        PM.enabled = false;

    }
    #endregion Game Over

    #region Pause Menu

    public void PauseMenu()
    {
        if (inPauseMenu == true)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    #endregion Pause Menu

    #region Coroutines 
    IEnumerator MSUP_Length()
    {

        yield return new WaitForSeconds(MSUP_Duration);

        PM.speed = MS;


        MSUP_VFX.SetActive(false);

        MSUP_Icon.SetActive(false);

    }

    IEnumerator TimerTake()
    {
        takeAway = false;
        yield return new WaitForSeconds(1f);
        timeLeft--;

        timeDisplay.text = timeLeft.ToString();

        takeAway = true;
    }

    IEnumerator TimerEndScreen()
    {
        endScreenTimer = true;

        yield return new WaitForSeconds(0.0005f);

        timeLeft--;
        snackpoints += timeLeft * timeValueMultiplier;
        endScreenTimer = false;

    }
    #endregion Coroutine

}
