using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject particles;
    Transform player;
    Vector2 vel;
    Rigidbody2D missile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        missile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            return;
        }
        vel = (Vector2)(player.position - transform.position);
        vel = vel.normalized;
        if(vel.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 57.2957f * Mathf.Atan(vel.y / vel.x)));
        } else
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0,180 + 57.2957f * Mathf.Atan(vel.y / vel.x)));
        }
        
        missile.velocity = vel * 4f;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHit();
        Destroy(this.gameObject);
    }
    void PlayerHit()
    {
        GameObject g = Instantiate(particles);
        g.transform.position = transform.position;
        g.transform.rotation = transform.rotation;
        g.GetComponent<ParticleSystem>().startColor = Color.red;
    }
}
