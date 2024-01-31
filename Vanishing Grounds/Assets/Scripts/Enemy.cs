using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player; 
    public float speed = 1.0f;

     void Start()
    {
        // Find the player GameObject and get its reference
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()  
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector2 direction = player.transform.position - transform.position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Move the enemy towards the player
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // Destroy the enemy when it falls into space
        RaycastHit2D hit_enemy = Physics2D.Raycast(transform.position, Vector2.down, 0.1f , ~LayerMask.GetMask("Enemy"));
        if (hit_enemy.collider == null){
             Destroy(gameObject);
        }
    }
}

