using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    [SerializeField] //move to game manager
    GameObject _player;
    PlayerInput _playerInput;
    PlayerMovement _playerMovement;
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _pauseButton;
    public static UIManager Instance;

    #endregion
    #region methods
    public void loadScene(string sceneName) //return value? error if not found?
    {
        SceneManager.LoadScene(sceneName);
    }
    public void pauseScene()
    {
        _playerInput.enabled=false;
        _playerMovement.enabled=false;
        _resumeButton.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void resumeScene()
    {
        _playerInput.enabled = true;
        _playerMovement.enabled = true;
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void newGame()
    {
        loadScene("PlayScene");
    }
    #endregion
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
      _playerInput=_player.GetComponent<PlayerInput>();
      _playerMovement=_player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
