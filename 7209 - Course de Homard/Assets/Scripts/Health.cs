using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int currentHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Enemy took " + damageAmount + " damage!");

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GainHealth(int healthAmount)
    {
        currentHealth += healthAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
