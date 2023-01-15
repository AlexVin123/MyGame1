using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    private ForgeJump _forge;

    public Jump(DataBasePlayer dataBasePlayer, Rigidbody2D rb) : base(dataBasePlayer, rb)
    {
    }

    public override void SetParameter()
    {
        _forge = (ForgeJump)DataBasePlayer.GetParameter(ParametersPlayer.JumpForge);
    }

    public void StartJump(DefenitionCollisions defenitionCollisions)
    {

        Rigidbody2D.AddForce(new Vector2(0f, 1 * _forge.Value), ForceMode2D.Impulse);
    }
}
