using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarFacingCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        //HpBar‚ğí‚ÉƒJƒƒ‰‚Ì•ûŒü‚ÉŒü‚¯‚é
        LookHpBarToCamera();
    }

    /// <summary>
    /// HpBar‚ğí‚ÉƒJƒƒ‰‚Ì•ûŒü‚ÉŒü‚¯‚é  
    /// </summary>³‘Î
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
