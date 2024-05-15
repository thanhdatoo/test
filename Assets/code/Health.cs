﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public UnityEvent onDeath;
    public Animator anim;
    public GameObject gameOverCanvas;
    public float maxFallHeight = -8f;
    public int maxHealingCount;
    public int currentHealingCount = 0;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void FixedUpdate()
    {
        if (transform.position.y < maxFallHeight)
        {
            currentHealth = 0;
            Die();

        }
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void Update()
    {

        Recover();  
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < maxHealth) 
        {
            anim.SetTrigger("isHurt");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    public void HealRandom()
    {
        int minValue = 0;
        int maxValue = 20;
        // Sinh một giá trị ngẫu nhiên trong phạm vi đã cho
        int healAmount = Random.Range(minValue, maxValue);

        // Hồi máu cho đối tượng
        currentHealth += healAmount;

        // Đảm bảo không vượt quá máu tối đa
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    //hồi máu
    public void Recover()
    {
        maxHealingCount = enemyHealth.totalDeathCount;
        if (currentHealingCount < maxHealingCount)
        {
            if (Input.GetKeyDown("c"))
            {
                if (currentHealth < maxHealth)
                {
                    HealRandom();
                    anim.SetTrigger("Recover");
                }
                currentHealingCount++;
                healthBar.UpdateHealth(currentHealth, maxHealth);
            }
        }
    }
    public void Die()
    {
        onDeath.Invoke();
        anim.SetTrigger("Isdead");
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian
    }

}