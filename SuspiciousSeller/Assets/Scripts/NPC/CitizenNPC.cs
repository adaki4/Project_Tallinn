using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenNPC : NPC
// all objects of CitizenNPCs class have health set to 1
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] spriteArray;

    new void Start() {
        base.Start();
        health = 1;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
    }
}