using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;

    private PlayerAnimation playerAnim;

    [SerializeField, Header("接地判定")]
    private bool isGrounded;

    [SerializeField, Header("ジャンプ力")]
    private float jumpPower;

    [SerializeField,Header("地面判定用レイヤー")]
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        // アニメ用のコンポーネントの取得
        TryGetComponent(out playerAnim);

        // TODO ジャンプ力を外部のクラスの情報から設定
    }

    // Update is called once per frame
    void Update()
    {
        // Linecastでキャラの足元に地面があるか判定  地面があるときはTrueを返す
        isGrounded = Physics.Linecast(transform.position + transform.up * 1,transform.position - transform.up * 0.3f,groundLayer);

        if (!isGrounded)
        {
            return;
        }

        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("ジャンプ");
            Jump();
        }
    }

    /// <summary>
    /// ジャンプ        
    /// </summary>
    private void Jump()
    {
        // TODO アニメ処理
        playerAnim.ChangeAnimationFromTrigger(PlayerAnimationState.Jump);

        rb.AddForce(Vector3.up * jumpPower);
    }
}
