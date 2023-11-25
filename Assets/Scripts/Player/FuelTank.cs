using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : Health
{
    [SerializeField] private float _fuelSpendRatio;

    private void Start()
    {
        StartCoroutine(SpendFuel());
    }

    public delegate void OutOfFuelDelegate();
    public event OutOfFuelDelegate OutOfFuel;

    public void Refuel()
    {
        CurrentHealth = MaxHealth;
    }

    public override void TakeDamage()
    {
        CurrentHealth--;

        if (CurrentHealth <= 0)        
            OutOfFuel();        
    }

    private IEnumerator SpendFuel()
    {
        WaitForSeconds spendDelay = new WaitForSeconds(_fuelSpendRatio);
        bool isSpending = true;

        while(isSpending)
        {
            TakeDamage();
            yield return spendDelay;
        }
    }
}
