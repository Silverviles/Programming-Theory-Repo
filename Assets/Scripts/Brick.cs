using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Black - AOE damage, +100 health, points +5
 * Green - normal block, points +3
 * Red - collisions turn on and off every 3 seconds, points +5
 * White - Fragile block, 1 point
 * Yellow - Very hard block, points +10 */

public class Brick : MonoBehaviour
{
    float health = 100;
    [SerializeField] protected GameObject dot;

    public float Health
    {
        get { return health; } set { health = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health -= 25;
        }
        if (collision.gameObject.CompareTag("DOT"))
        {
            health -= 50;
        }
    }
}
