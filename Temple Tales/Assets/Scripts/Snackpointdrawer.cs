using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Snackpointdrawer : MonoBehaviour
{
    [Header("Snackpoint Values")]
    [Tooltip("Hier kommt der Abstand des Spacings zwischen den Snackpoint hin.")]
    public float snackpointDistance = 0.5f;


    [Space(10)]
    public GameObject p0;
    public GameObject p1;
    [Space(10)]

    private GameObject SnackpointParent;

    [HideInInspector]
    public GameObject snackpointPrefab;
    [HideInInspector]
    public GameObject SnackpointParentPrefab;


    LineRenderer lineRenderer;




    public void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        
    }

    private void Update()
    {
        DrawLine();

        if(SnackpointParent == null)
        {
            if (GameObject.FindGameObjectWithTag("SnackpointParent") != null)
            {
                SnackpointParent = GameObject.FindGameObjectWithTag("SnackpointParent");
            }
            
        }
    }

    public void DrawLine()
    {

        lineRenderer.SetPosition(0, p0.transform.position);
        lineRenderer.SetPosition(1, p1.transform.position);


    }


    public void CreateSnackpoints()
    {
        SnackpointParent = Instantiate<GameObject>(SnackpointParentPrefab, Vector3.zero, Quaternion.Euler(0f, 0f, 0f));

        float distance = Vector3.Distance(p1.transform.position, p0.transform.position);

        Vector3 vectorUnit = (p1.transform.position - p0.transform.position).normalized;


        int distanceMultiplyer = 0;
        while (distance > 0)
        {
            Vector3 shorterVector = p0.transform.position + vectorUnit * (snackpointDistance * distanceMultiplyer);

            distanceMultiplyer += 1;

            Instantiate<GameObject>(snackpointPrefab, shorterVector, snackpointPrefab.transform.rotation, SnackpointParent.transform);
            distance -= snackpointDistance;
        }




    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(p0.transform.position, 0.5f);

    }
}
