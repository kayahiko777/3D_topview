using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;

    private PlayerAnimation playerAnim;

    [SerializeField, Header("�ڒn����")]
    private bool isGrounded;

    [SerializeField, Header("�W�����v��")]
    private float jumpPower;

    [SerializeField,Header("�n�ʔ���p���C���[")]
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        // �A�j���p�̃R���|�[�l���g�̎擾
        TryGetComponent(out playerAnim);

        // TODO �W�����v�͂��O���̃N���X�̏�񂩂�ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        // Linecast�ŃL�����̑����ɒn�ʂ����邩����  �n�ʂ�����Ƃ���True��Ԃ�
        isGrounded = Physics.Linecast(transform.position + transform.up * 1,transform.position - transform.up * 0.3f,groundLayer);

        if (!isGrounded)
        {
            return;
        }

        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("�W�����v");
            Jump();
        }
    }

    /// <summary>
    /// �W�����v        
    /// </summary>
    private void Jump()
    {
        // TODO �A�j������
        playerAnim.ChangeAnimationFromTrigger(PlayerAnimationState.Jump);

        rb.AddForce(Vector3.up * jumpPower);
    }
}
