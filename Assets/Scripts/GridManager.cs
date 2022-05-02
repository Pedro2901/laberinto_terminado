using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GameObject Inner;
    private List<Tile> _tiles = new List<Tile>();

    private int Player1Tiles = 0;
    private int Player2Tiles = 0;
    [SerializeField] private int _width, _heigh;
    [SerializeField] private Tile _tile;
    [SerializeField] private Transform _cam;

    void Start()
    {
        GenerateGrid(); 
    }
    void GenerateGrid() { 
    for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _heigh; y++)
            {
                var tile = Instantiate(_tile, new Vector3(x, y, 0), Quaternion.identity);
                _tiles.Add(tile);
                tile.name=$"Tile {x} {y}";
                if ((x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0))
                {
                    tile.SetColor(true);
                }
                else
                {
                    tile.SetColor(false);
                }  
                
            }
        }
        _cam.transform.position =new Vector3((float) _width/2 -0.5f, (float) _heigh/ 2 -0.5f,-10);
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }

    public void  ContColor()
    {
        foreach (var item in _tiles)
        {
            if (item.Inner.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                Player2Tiles++;
            }
            else if (item.Inner.GetComponent<SpriteRenderer>().color == Color.blue)
            {
                Player1Tiles++;
            }
            
        }
        
    }
    public int getP1()
    {
        return Player1Tiles;
    }
    public int getP2()
    {
        return Player2Tiles;
    }
}