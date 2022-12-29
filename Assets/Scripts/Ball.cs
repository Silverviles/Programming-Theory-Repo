using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameStarted)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OutBounds"))
        {
            Destroy(gameObject);
            GameManager.GameOver(true);
        }
    }
}
