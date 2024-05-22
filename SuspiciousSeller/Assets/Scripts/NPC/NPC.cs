using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class NPC : MonoBehaviour {

    public void Die() {
        Destroy(gameObject);
    }

    private void Start() {
        GameManager.instance.npcList.Add(this);
    }

}