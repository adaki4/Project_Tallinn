using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    //cooldown ->coroutine?
    //_
    private LongRangeWeapon longRangeWeapon;
    private Melee meleeWeapon;
    private SpriteRenderer weaponSpriteRenderer;
    [SerializeField]
    private bool isCurrentlyMelee;

    public bool Attack()
    {
        if (isCurrentlyMelee) {
            meleeWeapon.Attack();
        }
        else {
            longRangeWeapon.Attack();
        }
        return false;
    }
    public void SwitchAttackType(){
        isCurrentlyMelee = !isCurrentlyMelee;
        if (isCurrentlyMelee) {
            longRangeWeapon.attackAnimation.Stop();
            weaponSpriteRenderer.sprite = meleeWeapon.sprite;
        }
        else {
            longRangeWeapon.attackAnimation.transform.rotation = Quaternion.identity;
            meleeWeapon.attackAnimation.Stop();
            weaponSpriteRenderer.sprite = longRangeWeapon.sprite;
        }
    }
    void Start() {
        meleeWeapon = GetComponent<Melee>();
        longRangeWeapon = GetComponent<LongRangeWeapon>();
        weaponSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
    }

}
