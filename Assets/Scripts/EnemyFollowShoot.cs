using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowShoot : MonoBehaviour
{
    public float speed;
    public float StoppingDistance;
    public float RetreatDistance;
    private float TimeBTWShots;
    public float StartTimeBTWShots;
   public Tile tile;
    public LayerMask casilla;
    Animator anim;
    Vector2 targetPosition;
    Direction direction;
    public LayerMask limiter;
    public GameObject player; 

   
    public GameObject projectile;
    public Transform player2;
    void Start()
    {
        player2=GameObject.FindGameObjectWithTag("Player").transform;
        TimeBTWShots = StartTimeBTWShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player2.position)>StoppingDistance){
            transform.position=Vector2.MoveTowards(transform.position,player2.position,speed*Time.deltaTime);
            if(!checkCollision){
                if(transform.position.x>player2.position.x){
                    direction = Direction.left;
                    player.GetComponent<SpriteRenderer>().flipX = true;
                }else{
                    direction = Direction.right;
                    player.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }else if(Vector2.Distance(transform.position,player2.position)<StoppingDistance && Vector2.Distance(transform.position,player2.position)>RetreatDistance){
            transform.position=this.transform.position;
    }else if(Vector2.Distance(transform.position,player2.position)<RetreatDistance){
            transform.position=Vector2.MoveTowards(transform.position,player2.position,-speed*Time.deltaTime);
        }
        if(TimeBTWShots<=0){
            Instantiate(projectile,transform.position,Quaternion.identity);
            TimeBTWShots=StartTimeBTWShots;
    }else{
            TimeBTWShots-=Time.deltaTime;
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