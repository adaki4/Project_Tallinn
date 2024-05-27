using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField] 
    private TMP_Text _moneyText;

    public static UIManager instance;
    

    
   
    public void PauseScene()
    {
        Debug.Log("UI");
        GameManager.instance.PausePlay();
        _resumeButton.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void ResumeScene()
    {
        GameManager.instance.ResumePlay();  
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void NewGame()
    {
        //ScenesManager.instance.NewGame();
        ScenesManager.instance.LoadIntro();
    } 
    
    //update info about player (money, time etc) maybe adding money should work better with events? 
    public void UpdateHUD(int money) 
    {
        _moneyText.SetText(money.ToString());
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
        _moneyText.SetText("0");
    }


}
