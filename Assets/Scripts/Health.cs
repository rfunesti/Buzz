using UnityEngine;


public class Health : MonoBehaviour
{
    public int healthAmount = 3;

    public void TakeDamage(int amount)
    {
        //Debug.Log($"in TakeDamage function");
        healthAmount -= amount;
        GameFeel.AddCameraShake(0.1f);
        if (healthAmount <= 0)
        {
            GameManager.instance.Restart();
        }
    }

    public void HealDamage(int amount)
    {
        //Debug.Log($"in HealDamage function");
        
        if (healthAmount < 3 && healthAmount > 0)
        {
            healthAmount += amount;
        }
    }

    public static void TryHealTarget(GameObject target, int amount)
    {
        Health targetHealth = target.GetComponent<Health>();
        //Debug.Log($"in TryHealDamage function");       
        if (targetHealth)
        {
            targetHealth.HealDamage(amount);
        }
        if (!targetHealth)
        {
            Debug.Log("no targetHealth component");
        }
    }

    public static void TryDamageTarget(GameObject target, int damageAmount)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth)
        {
            //Debug.Log("targetHealth");
            targetHealth.TakeDamage(damageAmount);
        }
        if (!targetHealth)
        {
            //Debug.Log("no targetHealth component");
        }
    }

}
