using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Tile[,] allTiles = new Tile[4, 4];
    private List<Tile> emptyTiles = new List<Tile>();

    private List<Tile[]> columns = new List<Tile[]>();
    private List<Tile[]> rows = new List<Tile[]>();

    private void Start()
    {
        Tile[] AllTilesOneDim = GameObject.FindObjectsOfType<Tile>();
        foreach (Tile t in AllTilesOneDim)
        {
            t.Number = 0;
            allTiles[t.indRow, t.indCol] = t;
            emptyTiles.Add(t);
        }
        for (int i = 0; i < 4; i++)
        {

            columns.Add(new Tile[] { allTiles[0, i], allTiles[1, i], allTiles[2, i], allTiles[3, i] });
            rows.Add(new Tile[] { allTiles[i, 0], allTiles[i, 1], allTiles[i, 2], allTiles[i, 3] });
        }
        Generate();
        Generate();
    }

    private bool MakeMoveDownIndex(Tile[] lineOfTiles)
    {
        for (int i = 0; i < lineOfTiles.Length - 1; i++)
        {
            if (lineOfTiles[i].Number == 0 && lineOfTiles[i + 1].Number != 0)
            {
                lineOfTiles[i].Number = lineOfTiles[i + 1].Number;
                lineOfTiles[i + 1].Number = 0;
                return true;
            }
            if (lineOfTiles[i].Number != 0 && lineOfTiles[i].Number == lineOfTiles[i + 1].Number && !lineOfTiles[i].mergeThisTurn && !lineOfTiles[i + 1].mergeThisTurn)
            {
                lineOfTiles[i].Number *= 2;
                StateManager.currentCount += lineOfTiles[i].Number;
                lineOfTiles[i + 1].Number = 0;
                lineOfTiles[i].mergeThisTurn = true;
                return true;
            }
        }
        return false;
    }
    private bool MakeMoveUpIndex(Tile[] lineOfTiles)
    {
        for (int i = lineOfTiles.Length - 1; i > 0; i--)
        {
            if (lineOfTiles[i].Number == 0 && lineOfTiles[i - 1].Number != 0)
            {
                lineOfTiles[i].Number = lineOfTiles[i - 1].Number;
                lineOfTiles[i - 1].Number = 0;
                return true;
            }
            if (lineOfTiles[i].Number != 0 && lineOfTiles[i].Number == lineOfTiles[i - 1].Number && !lineOfTiles[i].mergeThisTurn && !lineOfTiles[i - 1].mergeThisTurn)
            {
                lineOfTiles[i].Number *= 2;
                StateManager.currentCount += lineOfTiles[i].Number;
                lineOfTiles[i - 1].Number = 0;
                lineOfTiles[i].mergeThisTurn = true;
                return true;
            }
        }
        return false;
    }
    private void Generate()
    {
        if (emptyTiles.Count > 0)
        {
            int randomNum = Random.Range(0, 10);
            int indexForNewNumber = Random.Range(0, emptyTiles.Count);
            if (randomNum == 0)
            {

                emptyTiles[indexForNewNumber].Number = 4;
            }
            else
            {

                emptyTiles[indexForNewNumber].Number = 2;
            }
            emptyTiles.RemoveAt(indexForNewNumber);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Generate();
        }
    }
    private void ResetMerge()
    {
        foreach (Tile t in allTiles)
        {
            t.mergeThisTurn = false;
        }
    }
    private void UpdateEmptyTiles()
    {
        emptyTiles.Clear();
        foreach (Tile t in allTiles)
        {
            if (t.Number == 0)
            {
                emptyTiles.Add(t);
            }
        }
    }
    public void Move(MoveDirection moveDirection)
    {
        bool moveMade = false;
        ResetMerge();
        Debug.Log(moveDirection.ToString());

        for (int i = 0; i < rows.Count; i++)
        {
            switch (moveDirection)
            {
                case MoveDirection.Down:
                    while (MakeMoveUpIndex(columns[i]))
                    {
                        moveMade = true;
                    }
                    break;
                case MoveDirection.Left:
                    while (MakeMoveDownIndex(rows[i]))
                    {
                        moveMade = true;
                    }
                    break;
                case MoveDirection.Up:
                    while (MakeMoveDownIndex(columns[i]))
                    {
                        moveMade = true;
                    }
                    break;
                case MoveDirection.Right:
                    while (MakeMoveUpIndex(rows[i]))
                    {
                        moveMade = true;
                    }
                    break;
            }
        }
        if (moveMade)
        {
            UpdateEmptyTiles();
            Generate();
        }
    }
}
