using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarFacingCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        //HpBar����ɃJ�����̕����Ɍ�����
        LookHpBarToCamera();
    }

    /// <summary>
    /// HpBar����ɃJ�����̕����Ɍ�����  
    /// </summary>����
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
