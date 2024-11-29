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
        // Debug.Log("rbが取得できない");
        // }
        TryGetComponent(out playerAnim);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (playerAnim)
        {    //  <=  この if 文はなんのためにあるのか、考えてみてください。
            // 移動する方向と移動アニメの同期
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
    /// 移動する方向と移動アニメの同期
    /// </summary>
    private void SyncMoveAnimation()
    {
        // 移動している場合
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            // 移動している方向の情報をセット
            lookDirection.Set(horizontal, vertical);

            // 正規化
            lookDirection.Normalize();

            // 待機アニメから移動アニメへ遷移
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, lookDirection.sqrMagnitude);

            Debug.Log("移動アニメ再生 : " + lookDirection.sqrMagnitude);
        }
        else
        {
            // 移動していない場合、移動アニメからら待機アニメへ遷移
            playerAnim.ChangeAnimationFromFloat(PlayerAnimationState.Speed, 0);
            Debug.Log("停止");
        }
    }
}
