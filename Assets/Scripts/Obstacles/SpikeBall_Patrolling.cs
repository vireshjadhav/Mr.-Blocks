using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Patrolling : MonoBehaviour
{
    public float rotateAngle = 90f;
    public float patrolSpeed = 1.0f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    private void Start()
    {
        SetTargetPoints();
    }

    private void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotateAngle * Time.deltaTime);
    }

    private void SetTargetPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);

        if(transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
}