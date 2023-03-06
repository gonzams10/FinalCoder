using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    /*
    [SerializeField] private TMP_Text m_characterNameDisplay;
    [SerializeField] private TMP_InputField m_inputField;
    */



    [SerializeField] private float m_maxHealth;
    private float m_currentHealth;

    [SerializeField] private Button m_damageButton;
    [SerializeField] private Button m_healButton;
    [SerializeField] private Sprite m_healthySprite, m_damageSprite;
    [SerializeField] private Image m_healthMether;

    private void Awake()
    {
        UpDateHealthBar(m_currentHealth);

        m_currentHealth = m_maxHealth;
        m_damageButton.onClick.AddListener(DamageButtonHandler);     
        m_healButton.onClick.AddListener(HealButtonHandler);
    }

    private void DamageButtonHandler() 
    {
        m_currentHealth--;
        if (m_currentHealth < 0)
        {
            m_currentHealth = 0;
        }
        UpDateHealthBar(m_currentHealth);

    }

    private void HealButtonHandler() 
    {
        m_currentHealth++;

        if (m_currentHealth> m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }
        UpDateHealthBar(m_currentHealth);

    }

    private void UpDateHealthBar(float p_currentHealth) 
    {
        var l_isHealthy = m_currentHealth >= m_maxHealth/2;
        var l_currentHealthPercentage = m_currentHealth / m_maxHealth;

        m_healthMether.sprite = l_isHealthy ? m_healthySprite : m_damageSprite;
        var l_currColor = m_healthMether.color;
        l_currColor.a = l_currentHealthPercentage;
        m_healthMether.color = l_currColor;

        



    }



    /*
    private void Awake()
    {
        m_inputField.onValueChanged.AddListener(OnValueChangedHandler);
    }

    private void OnValueChangedHandler(string p_newName) 
    {
   
        m_characterNameDisplay.text = p_newName;
        m_characterNameDisplay.fontStyle = FontStyles.Bold;
        m_characterNameDisplay.color = Color.blue;
    }
    */
}
