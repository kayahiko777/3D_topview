using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�p�̃L�����N�^�[�̃A�j���̎��
/// </summary>
public enum PlayerAnimationState
{
    Attack,
    Down,
    Damage,
    Jump,
    Speed,
    Idle,
    Clear
}


public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(out anim))
        {
            Debug.Log("Animator ���擾�o���܂���");
        }
    }

    /// <summary>
    /// �ړ��A�j���Ƒ��x�̓���
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="speed"></param>
    public void ChangeAnimationFromFloat(PlayerAnimationState nextAnimState, float speed)
    {

        // Locomotion �� parameter �Ƀ`�F�b�N������ Speed �� parameter �ƘA��������
        anim.SetFloat(nextAnimState.ToString(), speed);
    }


    /// <summary>
    /// Bool �p�����[�^�̃A�j���̍Đ��ƒ�~
    /// </summary>
    /// <param name="nextAnimState"></param>
    /// <param name="isChange"></param>

    public void ChangeAnimationBool(PlayerAnimationState nextAnimState, bool isChange)
    {
        anim.SetBool(nextAnimState.ToString(), isChange);
    }

    /// <summary>
    /// Trigger �^�̃p�����[�^�̃A�j���̍Đ�
    /// �A���U���E�W�����v�Ȃ�
    /// </summary>
    /// <param name="nextAnimState"></param>
    public void ChangeAnimationFromTrigger(PlayerAnimationState nextAnimState)
    {
        anim.SetTrigger(nextAnimState.ToString());
    }

    /// <summary>
    /// Animator �R���|�[�l���g�̎擾�p
    /// </summary>
    /// <returns></returns>
    public Animator GetAnimator()
    {
        return anim;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
