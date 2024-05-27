using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]
    private float speed = 7f;
    [Range(1, 10)]
    [SerializeField]
    private float lifeTime = 3f;

    private Rigidbody2D rd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    private void FixedUpdate() {
        rd.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        NPC npc = other.gameObject.GetComponentInParent<NPC>();
        if (npc != null) {
            Destroy(gameObject);
            npc.OnHit();
        }
    }
}
