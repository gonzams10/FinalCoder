using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesafioCanvasCon : MonoBehaviour
{

    private float RunButtonMoveSpeed = 10;
    [SerializeField] private CharacterCon characterCon;
    [SerializeField] private Button m_RunButton;
    [SerializeField] private TMP_Text m_Text;
    private float _currentTime;
    private float freezeTime = 4f;
    private float SkillFreezeTime = 4f;

    private void Awake()
    {
        _currentTime = Time.time;

        m_RunButton.onClick.AddListener(m_RunButtonHandler);
    }

    private void Update()
    {
        m_Text.text = "Elapsed Time: " +  Time.time.ToString();
       _currentTime = Time.time;

     
    }

    private void m_RunButtonHandler()
    {

        if (_currentTime >= freezeTime)
        {
            characterCon.moveSpeed = RunButtonMoveSpeed;
            freezeTime = _currentTime + 4f;
        }
       


        


    }

   

}
