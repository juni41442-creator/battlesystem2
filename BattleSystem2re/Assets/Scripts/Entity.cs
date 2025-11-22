using UnityEngine;

public class Entity : MonoBehaviour
{
    //정수 형식으로 HealthPoint AttackPower
    //접근 지정자 private, public, protected 하나를 선택해서 선언을 하세요.
    //private : Enemy class 개인적인 것. 다른 클래스에서 사용을 못하게 해주세요.
    //public : 다른 클래스에서 사용 가능하게 해주세요.
    //protected : Enemy class 와 상속받은 자식 클래스에서만 사용 가능하게 해주세요.

    // AttackPower 외부에서 사용할 수 있게 만들어야 합니다.

    [SerializeField] private int HealthPoint;
    [SerializeField] private int MaxHealthPoint;
    [SerializeField] private int AttackPower;
    [SerializeField] Animator animator;

    bool IsDeath;
    public bool IsEnemy; // 적인지 아닌지 구분하기 위한 변수
    public bool CheckIsDeath() => IsDeath;
    public int GetHP() =>  HealthPoint; //아래와 같음.
    public int GetMaxHP() => MaxHealthPoint;
    public int GetAttackPower() { return AttackPower; }
    public void SetHP(int value) => HealthPoint = value; 
    public void SetMaxHP(int value) => MaxHealthPoint = value;
    public void SetAttackPower(int value) { AttackPower = value; }

    private void Start()
    {
        IsDeath = false;       
        HealthPoint = MaxHealthPoint;
    }
    public void Damage(Entity attacker)
    {
        if (IsDeath) { return; }    //죽었으면 아래 코드 실행하지 마세요.
            
        //공격자의 공격력으로부터 자신의 체력을 감소시킨다.
        int attackerPower = attacker.GetAttackPower(); // 예시 공격력

        HealthPoint = HealthPoint - attackerPower;
        animator.SetTrigger("Hurt");

        //Move enemyMove = attacker.GetComponent<Move>();
        //if ( enemyMove != null) 
        // {
        //   enemyMove.Stop();
        // }        

        if(attacker.TryGetComponent<Move>(out var enemyMove))   // 위 두줄을 한줄로 줄임. 공격 대상자가 Move.cs 가지고 있으면 실행.
        {
            enemyMove.Stop();
            enemyMove.KnockBack();
        }

        if (HealthPoint <= 0){ Dead(); }
    }

    protected virtual void Dead()
    {
        IsDeath = true;
        animator.SetTrigger("Death");
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Entity>(out var entity))  // 충돌한 대상이 Enity 있으면 실행하라.
        {
            //시체랑은 충돌을 안하게 해주세요.
            //내가 Enemy일때, 다른 Enemy와 충돌했을 때, 서로 데미지를 주고 받지 않게 해주세요.
           // if(IsEnemy && entity.IsEnemy)
           // {
            //    return;
           // }
            if (entity.CheckIsDeath() == false)
            {
                Damage(entity);
            }
        }
    }
}