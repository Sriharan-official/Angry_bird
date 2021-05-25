using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health = 4f;
    public static int enemiesalive = 0;
    public GameObject effects;
    private void Start()
    {
        enemiesalive ++;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > health) 
        {
            Die();
            
        }
    }

    void Die()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
        enemiesalive --;
        if(enemiesalive <= 0)
        {

            FindObjectOfType<Ball>().load();
            
        }

         Destroy(gameObject);
    }

    
}
