using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float speed;
    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * 100 * Time.deltaTime;
        player.velocity = new Vector2 (horizontal, 0);
    }
}
