using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability:MonoBehaviour
{
    [SerializeField] private TypeAbility _typeAbility;

    public TypeAbility TypeAbility => _typeAbility;
    public abstract void Init(ICharacterConfig parameters);

    public virtual void Perform() { }

    public virtual void Perform(float directionX) { }

    public virtual void Perform(Vector2 direction) { }

}
