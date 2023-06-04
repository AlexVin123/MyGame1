using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbilityRB
{
    [SerializeField] private float _forge;

    public override void Init(ICharacterParameters parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {
            if (float.TryParse(parameters.GetValue(TypeParameter.ForgeJump), out float result))
                _forge = result;
            else
                throw new System.FormatException("Конвертация не возможна, измените параметер на float");
        }
    }

    public override void Perform()
    {
        Rigidbody.AddForce(new Vector2(0f, 1 * _forge), ForceMode2D.Impulse);
    }
}
