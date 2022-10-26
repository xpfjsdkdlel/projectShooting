using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private int currentHP;
    public int CHP
    {
        set 
        {
            GameManager.Inst.ChangeHeart(CHP < value, value);
            currentHP = value; 
        }
        get { return currentHP; }
    }
    public bool isAlive;
    [SerializeField]
    private int MaxHP;
    public int MHP
    {
        get { return MaxHP; }
        set { MaxHP = value; }
    }
    public void InitChar()
    {
        CHP = MHP;
        isAlive = true;
    }
    public void TakeDamage(int damage)
    {
        if(isAlive)
        {
            CHP -= damage;
            if(CHP <= 0)
            {
                isAlive = false;
            }
        }
    }
    public void TakeHealing()
    {
        if(CHP < 5)
        {
            CHP++;
        }
    }
    private void OnDie()
    {

    }
}
