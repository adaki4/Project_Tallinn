using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public void Die() {
        Destroy(gameObject);
    }
}