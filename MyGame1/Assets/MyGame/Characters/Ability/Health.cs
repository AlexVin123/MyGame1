using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public UnityAction<float,float> ChangedHealt;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    public void Init(ICharacterConfig parameters)
    {
        if (parameters != null)
        {
            if (float.TryParse(parameters.GetValue(TypeParameter.MaxHealth), out float result))
                _maxHealth = result;
            else
                throw new System.ArgumentException("Конвертация не возможна, измените параметер на float");

        }

        _health = _maxHealth;
    }

    public void Heal(float value)
    {
        if (_health + value > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += value;
        }

        ChangedHealt?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_health > damage)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
        }

        ChangedHealt?.Invoke(_health, _maxHealth);
    }
}
