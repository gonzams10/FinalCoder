using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] Transform[] patrolPoints;
    int currentTarget = 0;
    [SerializeField] private float changeTargetDistance;

    private void Update()
    {
        if (MoveToTarget())
        {
            currentTarget = GetNextPointTarget();
        }
    }


    private bool MoveToTarget()
    {

        Vector3 distanteVector = patrolPoints[currentTarget].position - transform.position;


        if (distanteVector.magnitude < changeTargetDistance)
        {
            return true;
        }

        Vector3 velocityVector = distanteVector.normalized;
        transform.position += velocityVector * moveSpeed * Time.deltaTime;

        return false;

    }

    private int GetNextPointTarget()
    {

        currentTarget++;
        if (currentTarget >= patrolPoints.Length)
        {
            currentTarget = 0;
        }

        return currentTarget;
    }

}
