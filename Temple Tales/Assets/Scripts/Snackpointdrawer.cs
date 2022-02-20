using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Snackpointdrawer : MonoBehaviour
{
    public GameObject p0;
    public GameObject p1;

    public float snackpointDistance = 0.5f;
    public GameObject snackpointPrefab;


    LineRenderer lineRenderer;




    public void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

    }

    private void Update()
    {
        DrawLine();
    }

    public void DrawLine()
    {

        lineRenderer.SetPosition(0, p0.transform.position);
        lineRenderer.SetPosition(1, p1.transform.position);


    }


    public void CreateSnackpoints()
    {
        float distance = Vector3.Distance(p1.transform.position, p0.transform.position);

        Vector3 vectorUnit = (p1.transform.position - p0.transform.position).normalized;


        int distanceMultiplyer = 0;
        while (distance > 0)
        {
            Vector3 shorterVector = p0.transform.position + vectorUnit * (snackpointDistance * distanceMultiplyer);

            distanceMultiplyer += 1;

            Instantiate<GameObject>(snackpointPrefab, shorterVector, snackpointPrefab.transform.rotation);
            distance -= snackpointDistance;
        }




    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(p0.transform.position, 0.5f);

    }
}
