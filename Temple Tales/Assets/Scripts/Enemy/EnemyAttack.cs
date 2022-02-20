using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    [Header("Floats")]
    [Space(10f)]
    private float timer;
    public float enemyAttackCooldown;
    public float radius;
    [Space(10f)]
    public float enemyAttackVFXDuration;

    public LayerMask player;

    [Header("Bools")]
    [Space(10f)]
    private bool attackNow = true;

    private bool refreshTimer;
    private bool startTimer;

    [Header("Assignements")]
    [Space(10f)]
    private Health HP;

    [Header("VFX's")]
    [Space(10f)]

    public GameObject enemyAttack;

    void Start()
    {
        HP = FindObjectOfType<Health>();
    }

    void Update()
    {
        if (Physics.CheckSphere(transform.position, radius, player) && attackNow == true)
        {
            
            Attack();

        }

        #region Enemy Attack Timer
        if (startTimer == true)
        {
            if(refreshTimer == true)
            {

                timer = Time.time + enemyAttackCooldown;
                refreshTimer = false;

            }

            if(timer < Time.time)
            {

                attackNow = true;
                startTimer = false;

            }

        }

        #endregion

    }

    private void Attack()
    { 
        attackNow = false;
        startTimer = true;
        refreshTimer = true;     

        HP.health--;

        StartCoroutine(EnemyAttackVFX());

    }

    IEnumerator EnemyAttackVFX()
    {

        enemyAttack.SetActive(true);

        yield return new WaitForSeconds(enemyAttackVFXDuration);

        enemyAttack.SetActive(false);

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, radius);

    }

}
