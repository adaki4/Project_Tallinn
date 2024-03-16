using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    [SerializeField] //move to game manager
    // GameObject _player;
    // PlayerInput _playerInput;
    // PlayerMovement _playerMovement;
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
        SceneManager.LoadScene("PlayScene"); //maybe instead of working directly with unity scene manager we can create a script that manages the 
        //loading and unloading and everything
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
