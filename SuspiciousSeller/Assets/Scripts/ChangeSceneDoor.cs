using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDoor : MonoBehaviour
{
    #region references
    [SerializeField]
    private string _loadThisScene;
    [SerializeField]
    private bool _canEnterDoor;

    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) {
        if (_canEnterDoor) {
            if (collision.GetComponent<MerchantDoor>()) {
                _loadThisScene = "StoreScene";
                //Debug.Log("entered door to StoreScene");

            }
            else if (collision.GetComponent<PlayScene1Door>()) {
                _loadThisScene = "PlayScene1";
                //Debug.Log("entered door to PlayScene1");
            }
            else if (collision.GetComponent<PlayScene2Door>()) {
                _loadThisScene = "PlayScene2";
                //Debug.Log("entered door to PlayScene2");
            }
            _canEnterDoor = false;
            ScenesManager.instance.LoadScene(_loadThisScene);
        }
        // PlayerManager.instance.PlayerMovement.MoveInstantly(collision.gameObject.transform.position);
    }
    private void OnTriggerExit2D(Collider2D other) {
        _canEnterDoor = true;
    }
    void Start() {
        _canEnterDoor = true;
    }

    #endregion
}
