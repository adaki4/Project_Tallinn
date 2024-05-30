using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICredits : MonoBehaviour
{
    public void OnClickGoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
