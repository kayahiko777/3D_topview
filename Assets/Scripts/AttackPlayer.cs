using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private PlayerAnimation playerAnim;

    [SerializeField]
    private int attackPower;

    [SerializeField]
    private CapsuleCollider capsuleCol; //�@����̃Q�[���I�u�W�F�N�g���A�T�C�����A�R���C�_�[�̏���o�^����
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
    /// AnimationEvent ������s
    /// �R���C�_�[�̃I���I�t�؂�ւ�
    /// </summary>
    /// <param name="switchIndex"></param>
    private void SwitchWeaponCollider(int switchIndex)
    {
        // �R���C�_�[�̃I���I�t�؂�ւ�
        capsuleCol.enabled = switchIndex == 0 ?true : false;

        Debug.Log(capsuleCol.enabled);
    }

    // ����̃R���C�_�[�ɂ��N������
    private void OnTriggerEnter(Collider other)
    {
        // ����ɃR���C�_�[���A�^�b�`����Ă��Ȃ��ꍇ�ɂ́A���̔��菈�����s��Ȃ�
        if (!capsuleCol.enabled)
        {
            return;
        }

        // ����̃R���C�_�[���A�ʂ̃R���C�_�[�ɐN�������Ƃ�
�@�@�@�@// ���̃R���C�_�[�̃Q�[���I�u�W�F�N�g�� Health �X�N���v�g���A�^�b�`����Ă���� = ���Ȃ킿�A�G�̃Q�[���I�u�W�F�N�g�Ȃ�
        if (other.gameObject.TryGetComponent(out Health health))
        {
            // �G�� Hp ������������
            health.TakeDamage(-attackPower);

            Debug.Log("�U���q�b�g");
        }
       
    }
}
