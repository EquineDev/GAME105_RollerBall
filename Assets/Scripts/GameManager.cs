using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    [SerializeField] private float m_maxGameTime = 60;
    [SerializeField] private bool m_keepAlive = false;
    [SerializeField] private TextUI m_scoreUI;
    [SerializeField] private TextUI m_timerUI;
    private int m_score;
    private float m_timer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (m_keepAlive)
            {
                DontDestroyOnLoad(this);
            }
      
        }
        else
        {
            Destroy(this);
             
        }
        
    }

    // Start is called before the first frame update
    public void UpdateScore(int value)
    {
        m_score += value;
        m_scoreUI.UpdateUI(m_score);
    }

    public void StartGame()
    {
        ResetGame();
        StartCoroutine(CountDown());
    }
    public void ResetGame()
    {
        m_timer = m_maxGameTime;
        m_score = 0;
    }

    public void GameEnds()
    {
        StopCoroutine(CountDown());
        
    }


    IEnumerator CountDown()
    {
        while (m_timer > 0)
        {
            m_timer--;
            yield return new WaitForSeconds(1f);
            m_timerUI.UpdateUI(m_timer);
        }
        m_timer = 0;
        m_timerUI.UpdateUI(m_timer);
        GameEnds();
    }
    
    
}
