using UnityEngine;

public class Melee : Weapon {
    
    RaycastHit2D[] hits;
    public override void Attack() {

        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            NPC npc = hits[i].collider.gameObject.GetComponent<NPC>();

            if (npc != null) {
                npc.OnHit();
            }
        }
    }
    
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

}