using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneDoor : MonoBehaviour
{
    #region references
    [SerializeField]
    private string _loadThisScene;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) {
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
        ScenesManager.instance.LoadScene(_loadThisScene); 
    }
    #endregion
}
