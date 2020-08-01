using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    Vector3 player;
    Vector2 vel;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        float random = Random.Range(0f, 1f);
        if(random <= 0.5f)
        {
            player.y += 17;
        }
        else
        {
            player.y -= 17;
        }
        random = Random.Range(-1f, 1f);
        player.x += random * 27;
        print(player);
        transform.position = player;
        vel.x = Random.Range(-5, 5);
        vel.y = Random.Range(-5, 5);
        this.GetComponent<Rigidbody2D>().velocity = vel;
        this.transform.position = player;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {        
        Destroy(this.gameObject);
    }*/
}
