using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected int indexOnScene;

    [SerializeField] protected ParticleSystem onHitParticle;

    protected float currentHealth;

    protected bool isDead;

    protected void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void ModifyHealth(float healthModified)
    {
        if (isDead)
        {
            return;
        }
        currentHealth += healthModified;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUIBar(currentHealth / maxHealth);
        onHitParticle.Play();
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public virtual void UpdateHealthUIBar(float percentageAmount)
    {

    }

    public virtual void Die()
    {
        isDead = true;
    }
}
