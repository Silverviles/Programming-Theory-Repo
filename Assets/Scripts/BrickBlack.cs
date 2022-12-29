using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBlack : Brick
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        GameObject dotObject1 = base.dot;
        GameObject dotObject2 = base.dot;
        GameObject dotObject3 = base.dot;
        GameObject dotObject4 = base.dot;
        dotObject1.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        dotObject2.GetComponent<Rigidbody2D>().AddForce(Vector2.left);
        dotObject3.GetComponent<Rigidbody2D>().AddForce(Vector2.down);
        dotObject4.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        Instantiate<GameObject>(dotObject1, transform);
    }
}
