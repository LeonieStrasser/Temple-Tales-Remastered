using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Floats")]
    [Space(10f)]
    public float attackRadius;
    private float timer;
    public float Attackcooldown;

    [Space(10f)]
    
    private bool startTimer = false;
    private bool updateTime;
    private bool attackAgain = true;

    [Header("Bools")]
    [Space(10f)]
    public LayerMask enemyLayer;
    
    [Header("VFX's")]
    [Space(10f)]
    public ParticleSystem playerAttack;


    private void Start()
    {
             
    }

    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {

            playerAttack.Play();

            Collider[] enemyColliders = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);
            foreach (var enemyCollider in enemyColliders)
            {
                enemyCollider.gameObject.GetComponent<EnemyController>().SupressMovement = true;
               
            }

            if (Physics.CheckSphere(transform.position, attackRadius, enemyLayer) && attackAgain == true)
            {
                updateTime = true;
                startTimer = true;
                attackAgain = false;
            }

        }

        #region Attack Timer
        if(startTimer == true)
        {
            if (updateTime == true)
            {
                timer = Time.time + Attackcooldown;
                updateTime = false;
            }
            
            if(timer < Time.time)
            {
                startTimer = false;

                attackAgain = true;
            }

        }
        #endregion

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

}
