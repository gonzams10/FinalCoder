using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Transform _player;
    [SerializeField] private EnemyType _enemyType;



    public float changeTargetDistance;
    public Transform[] patrolPoints;
    int currentTarget = 0;
    private float _currentTime;
    [SerializeField] private float timeToMove = 2f;
    [SerializeField] private Transform eyes;

    enum EnemyType
    {
        EnemyStatic,
        enemyPatrol,
        enemy3,

    }




    void Update()
    {
      
        EnemyTypeMove();
        EnemyVision();
    }

    private void LookAtPLayer(Transform lookAt)
    {
        transform.LookAt(lookAt.position);
    }


    private bool MoveToTarget()
    {

        Vector3 distanteVector = patrolPoints[currentTarget].position - transform.position;
        LookAtPLayer(patrolPoints[currentTarget]);

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

    private void EnemyTypeMove()
    {
        switch (_enemyType)
        {
            case EnemyType.EnemyStatic:
                break;


            case EnemyType.enemyPatrol:

                if (MoveToTarget())
                {

                    currentTarget = GetNextPointTarget();
                }
                break;

            case EnemyType.enemy3:

                _currentTime += Time.deltaTime * 1;

                if (_currentTime >= timeToMove)
                {

                    if (MoveToTarget())
                    {

                        currentTarget = GetNextPointTarget();
                    }
                    _currentTime = 0;

                }


                break;
            default:
                break;
        }

    }

    private void EnemyVision() 
    {
        RaycastHit hit;
        Ray ray = new Ray(eyes.position, eyes.forward);
        //Debug.DrawRay(ray.origin, ray.direction * 50f);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);
            Debug.Log(message: "Distancia: " + hit.distance);
            Debug.Log(message: "punto: " + hit.point);

        }

    }
}
