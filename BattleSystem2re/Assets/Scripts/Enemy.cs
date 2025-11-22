using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Enemy : Entity
{
    protected override void Dead()
    {
        Debug.Log("Enemy¿« ªÁ∏¡");
        base.Dead();
    }

}
