using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    public static GameManager instance;
    public PlayerManager playerManager;
    public UIManager uiManager;
    #endregion

    #region methods
    #endregion
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        playerManager.player = GameObject.Find("Player");
        SceneManager.LoadScene("PlayScene"); //maybe instead of working directly with unity scene manager we can create a script that manages the
        //loading and unloading and everything
    }

    // Update is called once per frame
    void Update()
    {

    }
}
