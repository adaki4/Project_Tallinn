using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDoor : MonoBehaviour
{
    #region references
    private bool _enterAllowed = false;
    [SerializeField]
    private string _loadThisScene;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<MerchantDoor>()) {
            _loadThisScene = "StoreScene";
            _enterAllowed = true;
            Debug.Log("entered door");

        }
        else if (collision.GetComponent<PlaySceneDoor>()) {
            _loadThisScene = "PlayScene";
            _enterAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlaySceneDoor>() || collision.GetComponent<MerchantDoor>())
        {
            _enterAllowed = false;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_enterAllowed) {
            SceneManager.LoadScene(_loadThisScene);
        }
    }
}
