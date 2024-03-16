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
    private PlayerManager playerManager;

    #endregion
    #region methods
    public void loadScene(string sceneName) //return value? error if not found?
    {
        SceneManager.LoadScene(sceneName);
    }
    public void pauseScene()
    {
        playerManager.playerInput.enabled = false;
        playerManager.playerMovement.enabled = false;
        _resumeButton.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void resumeScene()
    {
        playerManager.playerInput.enabled = true;
        playerManager.playerMovement.enabled = true;
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void newGame()
    {
        loadScene("PlayScene");
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
