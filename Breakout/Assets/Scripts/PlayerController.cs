using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary
{
    public float min;
    public float max;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalMovement;
    Boundary boundary = new Boundary();
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float playerHalfSize = spriteRenderer.bounds.size.x * 0.5f;
        Vector3 pos = Camera.main.transform.position;
        float halfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        boundary.min = pos.x - halfWidth + playerHalfSize;
        boundary.max = pos.x + halfWidth - playerHalfSize;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        float clamped_x = Mathf.Clamp(transform.position.x + (horizontalMovement * speed * Time.deltaTime)
            , boundary.min, boundary.max);
        transform.position = new Vector3(clamped_x, transform.position.y, 0);
    }
}
