using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    Left, Right, Up, Down
}

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeInput.swipedRight)
        {
            gameManager.Move(MoveDirection.Right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeInput.swipedLeft)
        {
            gameManager.Move(MoveDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeInput.swipedUp)
        {
            gameManager.Move(MoveDirection.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeInput.swipedDown)
        {
            gameManager.Move(MoveDirection.Down);
        }
    }
}
