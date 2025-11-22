using UnityEngine;

public class Player : Entity
{
    protected override void Dead()
    {
        Debug.Log("Player¿« ªÁ∏¡");
        base.Dead();
    }
}
