using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Eventually we'll want to change this into a scriptable item
 so this will be made into an abstract class  */
public class BasicFishScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4f;
    private Vector2 tmpPos;
    public float deactivateTimer = 4f;
    void Start()
    {
        Invoke("DeactivateGameObject", deactivateTimer);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move(){
        tmpPos = transform.position;
        tmpPos.x += speed * Time.deltaTime;
        transform.position = tmpPos;

    }

    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }
}
