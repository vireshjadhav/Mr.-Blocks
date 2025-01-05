using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput, verticalInput;
    public float speed = 5f;


    public LevelManager levelManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager == null )
        {
            Debug.LogError("SoundManager not found in the scene");
        }
    }



    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log($"horizontal: {horizontalInput}, vertical: {verticalInput} ");
    }

    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(gameObject.name + "Collidedd with: " + other.gameObject.name);
            PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void PlayerDied()
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    private void LevelComplete()
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}
