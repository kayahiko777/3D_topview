using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// <param name="amount"></param>
    public void ChangeAnimationFromFloat(PlayerAnimationState nextAnimState, float amount)
    {

        // Locomotion �� parameter �Ƀ`�F�b�N������ Speed �� parameter �ƘA��������
        anim.SetFloat(nextAnimState.ToString(), amount);
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
