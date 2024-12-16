using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarFacingCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        //HpBarを常にカメラの方向に向ける
        LookHpBarToCamera();
    }

    /// <summary>
    /// HpBarを常にカメラの方向に向ける  
    /// </summary>正対
    private void LookHpBarToCamera()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
