using UnityEngine;

public class Jump : AbilityRB
{
    [SerializeField] private float _forge;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {
            if (float.TryParse(parameters.GetValue(TypeParameter.ForgeJump), out float result))
                _forge = result;
            else
                throw new System.FormatException("����������� �� ��������, �������� ��������� �� float");
        }
    }

    public override void Perform()
    {
        Rigidbody.AddForce(new Vector2(0f, 1 * _forge), ForceMode2D.Impulse);
    }
}
