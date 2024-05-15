using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesDamage : MonoBehaviour
{
    public Health playerHealth;
    public int damage = 20  ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(damage);
        }
    }
    
}
