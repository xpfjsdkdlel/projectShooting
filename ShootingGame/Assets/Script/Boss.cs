using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    BS_MoveToAppear,
    BS_Phase01,
}
public class Boss : MonoBehaviour
{
    [SerializeField]
    private float bossAppearPoint = 2.5f;
    private BossState bossState = BossState.BS_MoveToAppear;
    private Movement2D movement;
    private BossWeapon weapon;

    private Vector3 startPos = new Vector3(0f, 7f, 0f);

    private void Awake()
    {
        movement = GetComponent<Movement2D>();
        weapon = GetComponent<BossWeapon>();
    }

    public void Init()
    {
        transform.position = startPos;
        gameObject.SetActive(true);
        ChangeState(BossState.BS_MoveToAppear);
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator BS_MoveToAppear()
    {
        movement.MoveTo(Vector3.down);
        while (true)
        {
            if (transform.position.y <= bossAppearPoint)
            {
                movement.MoveTo(Vector3.zero);
            }
            yield return null;
        }
    }
    private IEnumerator BS_Phase01()
    {
        while(true)
        {
            weapon.StartFiring(AttackType.AT_CircleFire);
            yield return null;
        }
    }
}