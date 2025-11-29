using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
public class Enemy : Entity
{
    Move move;

    public int RewardMoney = 10;
    [SerializeField] Player player;

    protected virtual void Start()
    {
        base.Start();
        player = Object.FindFirstObjectByType<Player>() ;
    }

    private void Awake()
    {
        move = GetComponent<Move>();
    }

    protected override void Dead()
    {
        Debug.Log("Enemy의 사망");
        base.Dead();
        move.Stop();
        //Destroy(gameObject);
        // 플레이어에게 RewardMoney 돈을 줘야 한다.
        // Player가 누구인가?

        player.SetMoney(player.Getmoney() + RewardMoney);
        
    }
}
