using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 3.0f;

    private Rigidbody rb;

    private float moveX;
    private float moveZ;
    // Start is called before the first frame update
    void Start()
    {
        // ���̃X�N���v�g�̃A�^�b�`���Ă���Q�[���I�u�W�F�N�g�ɑ΂��āATryGetComponent ���\�b�h�����s���A
        // Rigidbody �R���|�[�l���g�̎擾���ł����ꍇ�ɂ́ARigidbody �R���|�[�l���g�̏��� rb �ϐ��ɑ������
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[���͂����m���A���ꂼ��̕ϐ��ɒl��������B���̒l�� Move ���\�b�h���ŗ��p����
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }
    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // ���͕������x�N�g�������Đ��K��
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // TODO �ړ����Ă���ꍇ�A�ړ������ɃL�����̌�����������
        // Rigidbody �� velocity �̒l�� normalized �����l���AVector3.zero(0, 0, 0) �ł͂Ȃ��ꍇ
        //  => �܂�A�u�ړ����Ă���ꍇ�v�Ƃ��ĉ��߂ł���
        if (moveDirection != Vector3.zero)
        {
            // ���͕�����������]���v�Z
            // ���̃X�N���v�g�̃A�^�b�`���Ă���Q�[���I�u�W�F�N�g(�v���C���[)�� Transform �� Rotation �̒l�ɑ΂���
            // Rigidbody �� velocity �̒l�� normalized �����l���ALookRotation ���\�b�h�𗘗p���Ċp�x�̒l(Quaternion)�Ƃ��ĕϊ����A�����������
            //  => �܂�A�u�ړ������ɃL�����̌��������킹��v�Ƃ��ĉ��߂ł���
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);

            rb.MoveRotation(newRotation);
        }

        // �ړ��x�N�g�����v�Z
        Vector3 movement = moveDirection * moveSpeed;
        // �ړ��x�N�g���� Rigidbody �ɓK�p
        // Rigidbody �� Velocity(���x)�̒l���X�V���āA�������Z�ɂ���ăv���C���[�̈ړ����s��
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // TODO �ړ����~�̃A�j���[�V�����̓���
    }
}
