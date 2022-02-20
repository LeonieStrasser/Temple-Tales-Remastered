using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [Header("Floats")]
    [Space(10f)]
    float SupressTime;
    public float StunTime;

    public float lookRadius = 10f;

    public float SpeedStop;
    public float SpeedNormal = 13f;

    Transform target;
    NavMeshAgent agent;
   // [HideInInspector]
    public bool SupressMovement;

    [Header("VFX")]
    [Space(10f)]
    public ParticleSystem VFXStunOverHead;
    public ParticleSystem VFXStunSparks;

    [Header("Starting Point")]
    [Space(10f)]
    public Transform StartPoint;

    [HideInInspector]
    public bool Hunting = false;

  
    //---Fmod
    //FMOD.Studio.EventInstance enemyStunnedSound;
    //FMOD.Studio.PLAYBACK_STATE enemyStunnedSoundState;
    Transform fTransform;
    Rigidbody fRigidBody;

    float playEnemyStunned = 0;
    public float LookRadiusDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        return distance;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        //FMOD
        //enemyStunnedSound = FMODUnity.RuntimeManager.CreateInstance("event:/Enemy/EnemyStunned2");
        fTransform = GetComponent<Transform>();
        fRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //FMOD
        //enemyStunnedSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(fTransform, fRigidBody));
        //enemyStunnedSound.getPlaybackState(out enemyStunnedSoundState);

        if(SupressMovement)
        {
            VFXStunOverHead.Play();
            VFXStunSparks.Play();

            //FMOD
            //if (playEnemyStunned <= SupressTime)
            //{
            //    if (enemyStunnedSoundState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            //    {
            //        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
            //        enemyStunnedSound.start();
            //        //Debug.Log("CUANTOS FANTASMAS MAREADOS?!!");
            //    }
            //}
            
            SupressTime += Time.deltaTime;
            if (SupressTime >= StunTime)
            {
                SupressTime = 0f;
                VFXStunOverHead.Clear();
                VFXStunOverHead.Stop();


                VFXStunSparks.Clear();
                VFXStunSparks.Stop();
                SupressMovement = false;
                //FMOD
                //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
            }
        }

        if (distance <= lookRadius && !SupressMovement)
        {
            agent.SetDestination(target.position);

            Hunting = true;

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                FaceTarget();
            }
        }

        if(distance >= lookRadius && !SupressMovement)
        {
            Vector3 PathToStartPoint = (StartPoint.position);
            agent.SetDestination(PathToStartPoint);

            Hunting = false;

        }


        if (distance <= 1.0f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
