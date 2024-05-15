using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Slider EnemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
        EnemyHealth.maxValue = maxHealth;
        EnemyHealth.value = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        EnemyHealth.value = currentHealth;
        if(currentHealth <= 0) 
        {
            Die();
            Destroy(gameObject);
        }
    }
    void Die()
    {
        Debug.Log("Die");
    }
    public static int totalDeathCount = 0;

    private void OnDestroy()
    {

        totalDeathCount++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
