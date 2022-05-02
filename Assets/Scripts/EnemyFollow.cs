using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    private Transform target;    
    public Tile tile;
    public LayerMask casilla;
    Animator anim;
    Vector2 targetPosition;
    Direction direction;
    public LayerMask limiter;
    public GameObject player; 

    public int speed = 5;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        targetPosition = target.position;
        direction = Direction.down;
    }

    // Update is called once per frame
    void Update()
    {
    
    
    Vector2 axisDirection = new Vector2(Input.GetAxis("Horizontal2"),Input.GetAxis("Vertical2"));
        anim.SetInteger("direction", (int)direction);
        if(axisDirection != Vector2.zero && targetPosition == (Vector2)transform.position){
            Debug.Log("primer if");
            if  (Mathf.Abs(axisDirection.x) > Mathf.Abs(axisDirection.y)){
                if(axisDirection.x > 0){
                    direction = Direction.right;
                    player.GetComponent<SpriteRenderer>().flipX = false;
                    if(!checkCollision)
                    
                        targetPosition += Vector2.right;
                }else{
                    direction = Direction.left;
                    player.GetComponent<SpriteRenderer>().flipX = true;
                    if(!checkCollision)
                        targetPosition -= Vector2.right;
                }
            }else{
                if(axisDirection.y > 0){
                    direction = Direction.up;
                    if(!checkCollision)
                        targetPosition += Vector2.up;
                }else{
                    direction = Direction.down;
                    if(!checkCollision)
                        targetPosition -= Vector2.up;
                }

            }
        }
        
        if(Vector2.Distance(transform.position,target.position)>3){
              transform.position=Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime); //MoveTowards is a function that moves the object towards a target position

        }else{
            Debug.Log("Player is too close");
        }
        if (Physics2D.OverlapCircle(transform.position, 0.1f, casilla))
        {
            
            //Obtener la colision
            Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, casilla);
            
            tile=col.GetComponent<Tile>();
            
            
        }
        
    }
    bool checkCollision
    {
        get
        {
            RaycastHit2D rh;
        Debug.Log("Entro al checkCollision");
            Vector2 dir = Vector2.zero;

            if(direction == Direction.down){
                dir = Vector2.down;
            }else if(direction == Direction.up){
                dir = Vector2.up;
            }else if(direction == Direction.left){
                dir = Vector2.left;
            }else{
                dir = Vector2.right;
            }


            rh = Physics2D.Raycast(transform.position, dir,1, limiter);

            return rh.collider != null;
        }
    }
}
