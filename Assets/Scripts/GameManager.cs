using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables
    GameObject titleScreen;
    GameObject ball;
    private static bool gameStarted = false;
    private static bool gameFinished = true;
    private bool pool = true;
    [SerializeField] GameObject[] brick = new GameObject[5];
    GameObject[] bricks = new GameObject[60];
    Vector4 cameraBounds = new Vector4(-8.9f, +8.9f, -5f, 5f);//-x, +x, -y, +y
    Vector2 startPosition;
    [SerializeField] Vector2 xAndY;

    #endregion

    #region Properties
    public static bool GameStarted
    {
        get { return gameStarted; }
        set { gameStarted = value; }
    }

    public static bool GameFinished
    {
        get { return gameFinished; }
        set { gameFinished = value; }
    }
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        //get the x size of the brick
        xAndY.x = brick[0].GetComponent<BoxCollider2D>().size.x *
            brick[0].GetComponent<BoxCollider2D>().transform.localScale.x;

        //get the y size of the brick
        xAndY.y = brick[0].GetComponent<BoxCollider2D>().size.y *
            brick[0].GetComponent<BoxCollider2D>().transform.localScale.y;

        //set the starting position correctly
        startPosition = new Vector2(cameraBounds.x + xAndY.x / 2, cameraBounds.w - xAndY.y / 2);

        //get the relevant gameobjects and save them to track 
        titleScreen = GameObject.FindGameObjectWithTag("TitleScreen");
        ball = GameObject.FindGameObjectWithTag("Ball");

        //set the ball as inactive so it wont appear in the start menu
        ball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ObjectPooling();
    }

    /// <summary>
    /// create an array of objects in size 60(hardcoded)
    /// </summary>
    public void ObjectPooling()
    {
        if (gameStarted && pool)
        {
            //for every element in the bricks array, populate it with a random brick
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = Instantiate<GameObject>(randomBrick(), nextPosition(startPosition),
                    randomBrick().transform.rotation);
            }
            //stop the objectpooling function so it wont run with every update
            pool = false;
        }
    }

    /// <summary>
    /// Returns a random brick from the 5 bricks
    /// </summary>
    /// <returns></returns>
    public GameObject randomBrick()
    {
        int random = UnityEngine.Random.Range(0,5);
        return brick[random];
    }

    /// <summary>
    /// Returns the next free position for a brick in the format of vector2
    /// </summary>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public Vector2 nextPosition(Vector2 startPos)
    {
        Vector2 returnPos = startPos;
        if (startPosition.x < cameraBounds.y - xAndY.x / 2)
        {
            startPosition.x += xAndY.x;
        }
        else
        {
            startPosition.x = cameraBounds.x + xAndY.x / 2;
            startPosition.y -= xAndY.y;
        }
        return returnPos;
    }

    public void StartButton()
    {
        if (!ball.activeSelf)
        {
            ball.SetActive(true);
        }
        if (gameFinished)
        {
            gameStarted = true; gameFinished = false;
        }
        titleScreen.gameObject.SetActive(false);
    }

    public static void GameOver(bool isOver)
    {
        gameFinished = isOver;

    }

    #endregion

}
