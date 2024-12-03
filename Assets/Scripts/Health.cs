using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    private int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        // Hp �̏�����
        InitiaHealth(maxHp);
    }

    public void InitiaHealth(int initialHp)
    {
        maxHp = initialHp;
        currentHp = maxHp;
    }

    /// <summary>
    /// �_���[�W�p
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);
        // Hp �̌v�Z�Ɛ����m�F
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �񕜗p
    /// </summary>
    /// <param name="recoveryPoint"></param>
    public void Heal(int recoveryPoint)
    {
        currentHp = Mathf.Min(currentHp + recoveryPoint, maxHp);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
