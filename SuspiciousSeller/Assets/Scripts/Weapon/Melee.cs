using UnityEngine;

public class Melee : Weapon {
    
    RaycastHit2D[] hits;
    Vector3 relativeAttackTransformPosition;

    public override void Attack() {

        hits = Physics2D.CircleCastAll(relativeAttackTransformPosition, attackRange, transform.right, 0, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            NPC npc = hits[i].collider.gameObject.GetComponent<NPC>();

            if (npc != null) {
                npc.Die();
            }
        }
    }
    
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(relativeAttackTransformPosition, attackRange);
    }

    void Start() {
    }

    void Update() {
        relativeAttackTransformPosition = attackTransform.position;
        if (!PlayerManager.instance.PlayerMovement.isGoingRight) {relativeAttackTransformPosition.x -= attackTransform.localPosition.x;}
    }
}