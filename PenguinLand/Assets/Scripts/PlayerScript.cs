using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float maxX, maxY, minX, minY;
    private Vector2 tmpPos;
    private int dirX, dirY;

    //Fish shot will probably be moved to a Gun class
    [SerializeField]
    private GameObject fishShot;
    [SerializeField]
    private Transform shootPoint;

    public float shootTimer = 0.35f;
    private float currentTimer;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = shootTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shoot();
        Override();
    }

    void MovePlayer(){
        //change getaxisraw eventually to controller code or just better non-hardcoded code
        dirX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        tmpPos = transform.position;
        tmpPos.x += dirX * speed * Time.deltaTime;
        tmpPos.y += dirY * speed * Time.deltaTime;

        if(tmpPos.x > maxX)
            tmpPos.x = maxX;

        if(tmpPos.x < minX)
            tmpPos.x = minX;

        if(tmpPos.y > maxY)
            tmpPos.y = maxY;

        if(tmpPos.y < minY)
            tmpPos.y = minY;

        transform.position = tmpPos;
    }
    //We'll use this later probably for sprite rotations and firing direction
    void Rotate(){

    }

    //most of the logic here will probably moved to a Gun class
    void Shoot(){
        shootTimer += Time.deltaTime;
        if(shootTimer > currentTimer){
            canShoot = true;
        }

        if(Input.GetKeyDown(KeyCode.K)){
            if(canShoot){
                canShoot = false;
                shootTimer = 0f;
                Instantiate(fishShot, shootPoint.position, Quaternion.identity);
            }
            
        }
    }

    //This one will probably be placed in a Gun script
    void Override(){
        if(Input.GetKeyDown(KeyCode.J)){
            currentTimer = 0.15f;
        }
    }
}
