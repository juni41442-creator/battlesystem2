using UnityEngine;

public class Player : Entity
{
    private void Start()
    {
        base.Start();        
    }

    public PlayerData playerData;
    private int Money;   
    public int Getmoney() => Money;    
    public int SetMoney(int value) => Money = value;

    //업그레이드 비용이 레벨업 마다 증가하게 만들고 싶다. =>  현재 래벨
    const int HealPrice = 30;
    const int UpgradeHpPrice = 50;
    const int UpgradeATKPrice = 100;

    public void SavePlayerData()
    {
        playerData.MONEY = Getmoney();
        playerData.HP = GetHP();
        playerData.ATK = GetAttackPower();
        SaveSystem.Save(playerData);
    }

    //저장된 데이터를 불러 오시겠습니까? yes,No
   

    public void LoadPlayerData()
    {
        //저장되어 있는 데이터가 있나요?

        if (PlayerPrefs.HasKey("PLAYER") == false) return;        

        playerData = SaveSystem.Load();

        SetMoney(playerData.MONEY);
        SetHP(playerData.HP);
        SetAttackPower(playerData.ATK);
    }
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
