using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public float CharacterLife=100;
    public float CharacterMoveSpeed = 4f;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance= this; 
        }
    }
}
