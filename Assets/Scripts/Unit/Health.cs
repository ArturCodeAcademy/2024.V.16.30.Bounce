using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> HealthChanged;
    public event Action<int> HealthReduced;
    public event Action<int> HealthIncreased;
    public event Action<int> HealthEnded;

    [field: SerializeField, Min(1)]
    public int MaxHealth { get; private set; } = 5;
    public int CurrentHealth { get; private set; }
    
    private void Awake()
    {
		CurrentHealth = MaxHealth;
	}

    public bool Hit()
    {
        if (CurrentHealth <= 0)
            return false;

        CurrentHealth--;
        HealthChanged?.Invoke(CurrentHealth);
        HealthReduced?.Invoke(CurrentHealth);

        if (CurrentHealth == 0)
			HealthEnded?.Invoke(CurrentHealth);

        return true;
    }

    public bool Heal()
    {
		if (CurrentHealth >= MaxHealth)
			return false;

		CurrentHealth++;
		HealthChanged?.Invoke(CurrentHealth);
		HealthIncreased?.Invoke(CurrentHealth);

        return true;
	}
}
