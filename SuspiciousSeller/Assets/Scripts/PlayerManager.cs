using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region references
    [SerializeField]
    public GameObject player;
    public PlayerInput playerInput {get; set;}
    public PlayerMovement playerMovement {get; set;}
    #endregion
    #region methods
    #endregion
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerInput = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
