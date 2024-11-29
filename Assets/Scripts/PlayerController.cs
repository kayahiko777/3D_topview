using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    private Vector2 lookDirection = new Vector2(1, 0);

    private PlayerAnimation playerAnim;
    [SerializeField]
    private float moveSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        // if (TryGetComponent(out rb) == false)
        // {
        // Debug.Log("rb���擾�ł��Ȃ�");
        // }
        TryGetComponent(out playerAnim);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (playerAnim)
        {    //  <=  ���� if ���͂Ȃ�̂��߂ɂ���̂��A�l���Ă݂Ă��������B
            // �ړ���������ƈړ��A�j���̓���
            SyncMoveAnimation();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1,0,1)).normalized;

        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;

        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    /// <summary>
    /// �ړ���������ƈړ��A�j���̓���
    /// </summary>
    private void SyncMoveAnimation()
    {
        // �ړ����Ă���ꍇ
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            // �ړ����Ă�������̏����Z�b�g
            lookDirection.Set(horizontal, vertical);

            // ���K��
            lookDirection.Normalize();

            // �ҋ@�A�j������ړ��A�j���֑J��
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, lookDirection.sqrMagnitude);

            Debug.Log("�ړ��A�j���Đ� : " + lookDirection.sqrMagnitude);
        }
        else
        {
            // �ړ����Ă��Ȃ��ꍇ�A�ړ��A�j�������ҋ@�A�j���֑J��
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, 0);
            Debug.Log("��~");
        }
    }
}
