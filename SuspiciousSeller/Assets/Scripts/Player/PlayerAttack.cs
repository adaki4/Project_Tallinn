using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    //cooldown ->coroutine?
    //_
    private LongRangeWeapon _longRangeWeapon;
    private Melee _meleeWeapon;
    [SerializeField]
    private bool _isCurrentlyMelee;
    
    public bool Attack()
    {
        if (_isCurrentlyMelee) {
            _meleeWeapon.Attack();
        }
        else {
            _longRangeWeapon.Attack();
        }
        return false;
    }
    public void SwitchAttackType(){
        _isCurrentlyMelee = !_isCurrentlyMelee;
    }
    void Start() {
        _meleeWeapon = GetComponent<Melee>();
        _longRangeWeapon = GetComponent<LongRangeWeapon>();
    }
    
}
