using UnityEngine;

public class UpdatePerformVector2State : State
{
    [SerializeField] private Vector2 _vector;

    private void Update()
    {
        Enemy.PerformAbility(Ability, _vector);
    }
}
