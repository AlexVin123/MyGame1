using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbilityRB
{
    private float _forge;

    public override void Init(DataBase dataPlayer)
    {
        base.Init(dataPlayer);
        _forge = float.Parse(dataPlayer.GetParameter(TypeParameter.ForgeJump));
    }

    public void StartJump()
    {

        Rigidbody.AddForce(new Vector2(0f, 1 * _forge), ForceMode2D.Impulse);
    }
}
