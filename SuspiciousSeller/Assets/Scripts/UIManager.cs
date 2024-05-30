using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField] 
    private TMP_Text moneyText;
    [SerializeField]
    private GameObject youWonText;

    public static UIManager instance;
    
    public void PauseScene()
    {
        GameManager.instance.PausePlay();
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ResumeScene()
    {
        GameManager.instance.ResumePlay();  
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void NewGame()
    {
        ScenesManager.instance.LoadIntro();
    } 
    public void EndGame()
    {
        pauseButton.SetActive(false);
        youWonText.SetActive(true);
    }
    public void UpdateHUD(int money) 
    {
        moneyText.SetText(money.ToString());
    }

    private void OnDisable()
    {
        youWonText.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        moneyText.enabled = false;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        moneyText.SetText("0");
        youWonText.SetActive(false);

    }


}
