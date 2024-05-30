using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    [SerializeField]
    protected GameObject[] clothesList;

    [SerializeField]
    protected int health;
    //On death NPC despawns and drops assigned clothghes and is removed from list of all NPCs
    public void OnHit() {
        health--;
        if (health == 0) {
            Destroy(gameObject);
            SpawnRandomClothes();
            GameManager.instance.npcList.Remove(this);
        }
    }
    // At start add this NPC to list of NPCs
    protected void Start() {
        GameManager.instance.npcList.Add(this);
    }

    protected void SpawnRandomClothes() {
        GameObject clothes = clothesList[Random.Range(0, clothesList.Length)];
        Instantiate(clothes, transform.position, Quaternion.identity);

    }

}