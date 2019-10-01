using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public float minY, maxY;
    
    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;
    
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }
    
    void MovePlayer(){
        //Change hardcoded values
        if(Input.GetAxisRaw("Vertical") > 0f){
            Vector3 tmp = transform.position;
            tmp.y += speed * Time.deltaTime;
            
            if(tmp.y > maxY)
                tmp.y = maxY;
            
            transform.position = tmp;
        }else if(Input.GetAxisRaw("Vertical") < 0f){
            Vector3 tmp = transform.position;
            tmp.y -= speed * Time.deltaTime;
            if(tmp.y < minY)
                tmp.y = minY;
            transform.position = tmp;
        }
    }
    
    
    //Control bullet amount
    void Attack(){
        attackTimer += Time.deltaTime;
        if(attackTimer > currentAttackTimer){
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.K)){
            if(canAttack){
                canAttack = false;
                attackTimer = 0f;
                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
            }
        }
        
    }
    /* Wrong way?
    void Attack(){
        if(Input.GetKeyDown(KeyCode.K)){
            Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
        }
    }
    */
}
