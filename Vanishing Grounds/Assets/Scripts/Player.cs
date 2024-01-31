using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public float speed = 3.0f;
    public float boostedSpeed = 6.0f;
    private float currentSpeed;

    public GameObject[] platforms;
    public GameObject randomPlatform;

    private Text scoreText;
    private int score = 0;

     void Start()
    {
        currentSpeed = speed;

        FindText();
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
            currentSpeed = boostedSpeed;
        } 
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            currentSpeed = speed;
        } 

        if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * currentSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left* currentSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position += Vector3.up * currentSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.down* currentSpeed * Time.deltaTime;
        }

        platforms = GameObject.FindGameObjectsWithTag("Platform");
        int randomIndex = Random.Range(0, platforms.Length);
        randomPlatform = platforms[randomIndex];

        // If player falls into the space destroy it and restart the game 
        RaycastHit2D hit_player = Physics2D.Raycast(transform.position, Vector2.down, 0.1f , ~LayerMask.GetMask("Player"));
        if (hit_player.collider == null || hit_player.collider.gameObject == null){
            Destroy(gameObject);
            SceneManager.LoadScene("GamePlay");
        }
    }

     void LateUpdate()
    {
        // Destroy a random ground when enter/space is pressed 
        // Increase the score as grounds are vanishing
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (randomPlatform != null)
            {
                Destroy(randomPlatform);
                IncreaseScore();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the player when colliding with enemy
            Destroy(gameObject);
            SceneManager.LoadScene("GamePlay");
        }
    }
    
    void FindText()
    {
        // Find the Text component in the scene by its tag
        GameObject textObject = GameObject.FindWithTag("Score");

        if (textObject != null)
        {
            scoreText = textObject.GetComponent<Text>();

            // Set the initial text value
            scoreText.text = score.ToString();
        }
    }

    void IncreaseScore()
    {
        score++;

        // Update the Text component with the new score value
        if (scoreText != null)
        {
            scoreText.text = score.ToString();

            // Restart the game when the score is 64
            if (score == 64)
            {
                SceneManager.LoadScene("GamePlay");
            }
        }
    }
}
  
