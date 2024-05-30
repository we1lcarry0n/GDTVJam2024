using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected int indexOnScene;

    [SerializeField] protected ParticleSystem onHitParticle;
    [SerializeField] protected GameObject damageText;
    [SerializeField] protected GameObject healthText;
    [SerializeField] protected ParticleSystem healParticles;

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
        if (healthModified == 0)
        {
            return;
        }

        currentHealth += healthModified;

        if (healthModified > 0)
        {
            PlayHealText(healthModified);
        }
        if (healthModified < 0) 
        {
            PlayDamagetext(healthModified);
            onHitParticle.Play();
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUIBar(currentHealth / maxHealth);
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

    public float GetHealthCurrent()
    {
        return currentHealth;
    }

    public float GetHealthMax()
    {
        return maxHealth;
    }

    public void IncreaseMaxHP(float amount)
    {
        maxHealth += amount;
        ModifyHealth(amount);
    }

    public void HealForPercentageAmount(float percentageAmount)
    {
        float toHeal = maxHealth * percentageAmount;
        ModifyHealth(toHeal);
    }

    protected void PlayDamagetext(float DamageAmount)
    {
        damageText.SetActive(true);
        damageText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DamageAmount.ToString();
        damageText.GetComponent<Animation>().Play();
    }

    protected void PlayHealText(float HealAmount)
    {
        healthText.SetActive(true);
        healthText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = HealAmount.ToString();
        healthText.GetComponent<Animation>().Play();
        healParticles.Play();
    }
}
