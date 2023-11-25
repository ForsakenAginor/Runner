using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    protected int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if (_currentHealth == value)
                return;

            _currentHealth = value;

            if (HealthChange != null)
                HealthChange(_currentHealth);
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public delegate void HealthChangeDelegate(int value);

    public event HealthChangeDelegate HealthChange;

    public abstract void TakeDamage();
}
