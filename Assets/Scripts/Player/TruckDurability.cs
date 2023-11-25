public class TruckDurability : Health
{
    public delegate void TruckCrashedDelegate();
    public event TruckCrashedDelegate TruckCrashed;

    public override void TakeDamage()
    {
        CurrentHealth--;

        if (CurrentHealth <= 0)        
            TruckCrashed();        
    }

    public void Repair()
    {
        CurrentHealth = MaxHealth;
    }
}
