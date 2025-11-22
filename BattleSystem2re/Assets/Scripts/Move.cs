using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 컴퓨터야 움직여줘
    // 방향
    // 속도    
    //Vector2 dir2 =new Vector2 { 0.1f, 0.1f };
    //Vector3 dir3 = new Vector3 { 0.1f, 0.1f, 0.0f };
    [SerializeField] int direction = 1;
    [SerializeField] float speed = 10f;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    // rigid는 MOVE클래스가 부착되어 있는 오브젝트에서 가져와라.
    }
    private void Start()
    {
        rigid.linearVelocityX = direction * speed;
    }

    public void Stop()  // 부딪혔을때
    {
       // rigid.linearVelocityX = 0;
       // rigid.linearVelocityY = 0;
        rigid.linearVelocity = Vector2.zero;
    }

    public void KnockBack()
    {       
        int knockDirection = direction * (-1);  // 방향
        float KnockbackPower = 10f;
        float KnockbackPowerY = 10f;
        rigid.AddForceY(KnockbackPowerY , ForceMode2D.Impulse);
        rigid.AddForceX(KnockbackPower * knockDirection, ForceMode2D.Impulse);
        StartCoroutine(KnockBackLogic());
        //넉백을 받으면 반대 방향으로 날아간다.
        //넉백 후 일정 시간 뒤에 다시 멈췄다가.
    }

    IEnumerator KnockBackLogic()
    {
        yield return new WaitForSeconds(0.1f);
        Stop();
        yield return new WaitForSeconds(0.3f);
        rigid.linearVelocityX = direction * speed;
    }

}
