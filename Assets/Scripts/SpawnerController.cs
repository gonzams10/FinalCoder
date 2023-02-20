using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private EnemyController[] m_spiderPrefabs;
    [SerializeField] private Transform[] m_spiderWaypoints;
    [SerializeField] private int m_amountToInstantiate;

    private Queue<EnemyController> m_spawnedSkullTullas;
  


    private void Awake()
    {
        for (int i = 0; i < m_amountToInstantiate; i++)
        {
            SpawnSpider();
        }
    }

    private void Update()
    {
          
    }




    private void SpawnSpider()
    {
        var l_spawnPosition = GetRandomWayPoint().position;
        var l_chosenSpider = ChooseSpider();
        var l_currSpider = Instantiate(l_chosenSpider, l_spawnPosition, Quaternion.identity);
        l_chosenSpider.RecieveWaypoints(m_spiderWaypoints);
       
    }

    private EnemyController ChooseSpider()
    {

        var l_chosenSpider = Random.Range(0, m_spiderPrefabs.Length);
        return m_spiderPrefabs[l_chosenSpider];


    }



    private Transform GetRandomWayPoint()
    {
        var l_chosenWaypoint = Random.Range(0, m_spiderWaypoints.Length);
        return m_spiderWaypoints[l_chosenWaypoint];

    }

}
