using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int currentHealth = 0;

    public int CurrentHealth => currentHealth;

    public UnityEvent onGainHealth;
    public UnityEvent onLoseHealth;
    public UnityEvent onDeath;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        onLoseHealth?.Invoke();

        if(currentHealth <= 0)
        {
            //Destroy(this.gameObject);
            onDeath?.Invoke();
        }
    }

    public void GainHealth(int healthAmount)
    {
      
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        onGainHealth?.Invoke();
    }
}
