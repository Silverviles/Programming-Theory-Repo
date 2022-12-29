using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DOT : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Black") || 
            collision.gameObject.CompareTag("Green") ||
            collision.gameObject.CompareTag("White") ||
            collision.gameObject.CompareTag("Red") ||
            collision.gameObject.CompareTag("Yellow"))
        {
            collision.gameObject.GetComponent<BrickBlack>().Health -= 25;
            Destroy(gameObject);
        }
    }
}