using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    [SerializeField] private float m_maxGameTime = 60;
    [SerializeField] private int m_maxLifes = 3;
    [SerializeField] private bool m_keepAlive = false;
    [SerializeField] private TextUI m_scoreUI;
    [SerializeField] private TextUI m_timerUI;
    [SerializeField] private TextUI m_livesUI; 
    [SerializeField] private string _EndSceneName = "End";
    [SerializeField] private string _WonSceneName = "Won";
    private int m_score;
    private int m_lives; 
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

    private void Start()
    {
        StartGame();
    }

    // Start is called before the first frame update
    public void UpdateScore(int value)
    {
        m_score += value;
        m_scoreUI.UpdateUI(m_score);
    }

    public void UpdateLives(int value)
    {
        m_lives += value;
        if (m_lives <= 0)
        {
            GameEnds();
        }
        m_livesUI.UpdateUI(m_lives);
    }

    public void StartGame()
    {
        ResetGame();
        StartCoroutine(CountDown());
    }
    public void ResetGame()
    {
        m_timer = m_maxGameTime;
        m_lives = m_maxLifes;
        m_score = 0;
        m_scoreUI.UpdateUI(m_score);
        m_timerUI.UpdateUI(m_timer);
        m_livesUI.UpdateUI(m_lives);
    }

    public void GameEnds()
    {
        StopCoroutine(CountDown());
        SceneSwaper.LoadScene(_EndSceneName);
    }


    public void GameWon()
    {
        PlayerPrefs.SetInt("HighScore", m_score);
        SceneSwaper.LoadScene(_WonSceneName);
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
