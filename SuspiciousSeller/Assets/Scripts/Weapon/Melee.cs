using UnityEngine;

public class Melee : Weapon {

    RaycastHit2D[] hits;
    public override void Attack() {
        if (Time.time > lastAttackedAt + fireRate) {
            attackAnimation.Play("Baseball");
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                NPC npc = hits[i].collider.gameObject.GetComponent<NPC>();

                if (npc != null) {
                    npc.OnHit();
                }
            }
            lastAttackedAt = Time.time;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

}