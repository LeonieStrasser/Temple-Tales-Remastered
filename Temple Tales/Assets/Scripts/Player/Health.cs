using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [HideInInspector]
    public GameManagerNew GMN;

    private void Start()
    {
        GMN = FindObjectOfType<GameManagerNew>();
    }

    void Update()
    {

        /*if (health < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (health < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (health < 3)
        {
            Destroy(hearts[2].gameObject);
        }*/


        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if(health <= 0)
        {
            GMN.GameOver();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }                                                          
    }
}

