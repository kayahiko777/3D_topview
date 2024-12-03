using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private PlayerAnimation playerAnim;

    [SerializeField]
    private int attackPower;

    [SerializeField]
    private CapsuleCollider capsuleCol; //　武器のゲームオブジェクトをアサインし、コライダーの情報を登録する
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out playerAnim);

        capsuleCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& !playerAnim.GetAnimator().IsInTransition(0))
        {
            playerAnim.ChangeAnimationFromTrigger(PlayerAnimationState.Attack);
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, 0);
        }
    }


    /// <summary>
    /// AnimationEvent から実行
    /// コライダーのオンオフ切り替え
    /// </summary>
    /// <param name="switchIndex"></param>
    private void SwitchWeaponCollider(int switchIndex)
    {
        // コライダーのオンオフ切り替え
        capsuleCol.enabled = switchIndex == 0 ?true : false;

        Debug.Log(capsuleCol.enabled);
    }
}
