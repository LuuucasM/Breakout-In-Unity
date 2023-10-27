using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public bool IsStuck = true;
    public float speed = 5.0f;
    public Vector3 current_velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStuck && Input.GetKeyDown(KeyCode.Space))
        {
            IsStuck = false;
            current_velocity.y += speed;
        }
        if (IsStuck)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float new_x = transform.position.x + (horizontalMovement * speed * Time.deltaTime);
            transform.position = new Vector3(new_x, transform.position.y, 0);

        }
        if (!IsStuck)
        {
            transform.position += current_velocity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 direction = Vector3.Reflect(current_velocity.normalized, collision.GetContact(0).normal);
        current_velocity = direction * current_velocity.magnitude;
        if (collision.gameObject.CompareTag("Bottom"))
        {
            --GameData.PlayerLives;
            GameData.OnLivesChange();
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            --GameData.NumBlocks;
            GameData.CheckLevelClear();
        }
    }
}
