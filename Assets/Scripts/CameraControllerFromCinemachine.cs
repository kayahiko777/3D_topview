using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraControllerFromCinemachine : MonoBehaviour
{
    [Header("追跡するゲームオブジェクト")]
    public GameObject targetObj;

    [SerializeField]
    private float cameraRotateSpeed = 80.0f; // カメラの回転速度

    [SerializeField]
    private float maxLimit = 45.0f; // X 軸方向の最大可動範囲
    [SerializeField]
    private float minLimit = 25.0f;  // X 軸方向の最小可動範囲
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            // カメラの回転
            RotateCamera();
        }
    }

    /// <summary>
    /// targetObj を軸にしたカメラの公転回転
    /// </summary>
    private void RotateCamera()
    {
        // マウスの入力値を取得
        float x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse Y");
        // カメラを追従対象の周囲を公転回転させる
        transform.RotateAround(targetObj.transform.position, Vector3.up, x * Time.deltaTime * cameraRotateSpeed);
        //カメラの回転情報の初期値をセット
        var localAngle = transform.localEulerAngles;
        // X 軸の回転情報をセット
        localAngle.x += z;
        // X 軸を稼働範囲内に収まるように制御
        if (localAngle.x >maxLimit)
        {
            localAngle.x = maxLimit;
        }

        if (localAngle.x < minLimit) 
        {
            localAngle.x = minLimit; 
        }
        // カメラの回転
        transform.localEulerAngles = localAngle;
    }
}
