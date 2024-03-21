using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private PlayerManager playerManager;
    #endregion

    #region methods
    public void LoadScene(string sceneName) //return value? error if not found?
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PauseScene()
    {
        playerManager.PlayerInput.enabled = false;
        playerManager.PlayerMovement.enabled = false;
        _resumeButton.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void ResumeScene()
    {
        playerManager.PlayerInput.enabled = true;
        playerManager.PlayerMovement.enabled = true;
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void NewGame()
    {
        this.LoadScene("PlayScene");
    }
    #endregion
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
