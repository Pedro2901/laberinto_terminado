using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private GameObject Inner;
    private Grid grid;
    public bool isWalkable;
    public int x, y ;
    public int gCost, hCost, fCost;
    public Cell pastCell;
     private bool finishGrid = false;

    public void Init(Grid grid, int x, int y, bool isWalkable)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
        SetText(x + "," + y);
    }

    public Vector2 Position => transform.position;

    public void SetText(string text)
    {
        textMeshPro.text = text;
    }

    public void SetColor(Color color)
    {
        Inner.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnMouseDown()
    {
        
        if (Input.GetMouseButton(0))
        {
            grid.CellMouseClick(this);
        } 
    }

    internal void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    internal void SetWalkable(bool v)
    {
        isWalkable = v;
        SetColor(Color.black);
    }

    public override string ToString()
    {
        return "Cell "+x + "," + y;
    }
     
      public void MoveEnemy(Cell cell)
    {
        //cell.SetText("Click on cell "+cell.x+ " "+ cell.y);
        BoardManager.Instance.MoveEnemy(cell.x, cell.y);
    }
     public void OnColliderEnter2D(Collider2D collision)
    {
        grid.MoveEnemy(this);
    }
      public bool CasillaFinal()
    {
        return finishGrid;
    }
}
