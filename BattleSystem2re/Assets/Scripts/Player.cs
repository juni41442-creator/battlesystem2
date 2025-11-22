using UnityEngine;

public class Player : Entity
{
    private int Money;   
    public int Getmoney() => Money;
    
    public int SetMoney(int value) => Money = value;

    //업그레이드 비용이 레벨업 마다 증가하게 만들고 싶다. =>  현재 래벨
    const int HealPrice = 30;
    const int UpgradeHpPrice = 50;
    const int UpgradeATKPrice = 100;
    protected override void Dead()
    {
        base.Dead();
        Debug.Log("Player의 사망");              
    }

    private bool CanBuy(int price)
    {
        if (Money < price)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void UpgradeHP(int amount)
    {
        if (CanBuy(UpgradeHpPrice) == false) return;

       SetMaxHP(GetMaxHP() + amount);

        Money = Money - UpgradeHpPrice;
    }

    public void HealHP(int amount)
    {
        if (CanBuy(HealPrice) == false) return;

        int healamount = GetHP() + amount;
        if (healamount > GetMaxHP())
        {
            healamount = GetMaxHP();
        }
        SetHP(healamount);

        Money = Money - HealPrice;
    }

    public void UpgradeATK(int amount)
    {
        if (CanBuy(UpgradeATKPrice) == false) return;

        SetAttackPower(GetAttackPower() + amount );

        Money = Money - UpgradeATKPrice;
    }
}
