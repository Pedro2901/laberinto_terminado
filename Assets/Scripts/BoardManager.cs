    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private EnemyMovement Player2;
    
    private Grid grid;
    private Player player;
    private Player player2;
    public Button button;

    public Canvas canvas;
    public Dropdown dropdown;
      public LayerMask mascara;
     private List<Player> enemys = new List<Player>();
   

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        

       
        
         button.onClick.AddListener(() =>
         
        {
            //Recibir el valor del dropdown
            int valor = dropdown.value;
            
            Destroy(dropdown.gameObject);
            
            Destroy(button.gameObject);

            canvas.gameObject.SetActive(false);

             grid = new Grid(12,12, 1, CellPrefab);
            //hacer aparecer el enemigo en el tablero   //
            
            player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);  
        });
    }

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

     public void MoveEnemy(int x, int y)
    {
        foreach (var enemy in enemys)
        {
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y, x, y);
            enemy.SetPath(path);
        }
        
    }

}
