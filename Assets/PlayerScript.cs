using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D player;
    Vector2 force;
    Vector3 scale;
    Camera cam;
    int targetPlanet = 1;
    int tries = 0;
    public GameObject Particles;
    float currCamSize = 15, vel = 2;
    bool isWon = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        force = new Vector2(10, 0);
        scale = transform.localScale;
        cam = Camera.main;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //cam.orthographicSize = currCamSize + Mathf.Min(8, player.velocity.magnitude) * 1;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            force.x = 10 * vel;
            force.y = 0;
            player.AddForce(force);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            force.x = -10 * vel;
            force.y = 0;
            player.AddForce(force);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            force.x = 0;
            force.y = 10 * vel;
            player.AddForce(force);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            force.x = 0;
            force.y = -10 * vel;
            player.AddForce(force);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Planet"))
        {
            int planet = int.Parse(collision.gameObject.transform.Find("Canvas").Find("planetno").GetComponent<TMPro.TextMeshProUGUI>().text);
            if (planet == targetPlanet)
            {
                collision.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                IncreaseSize();
                if (targetPlanet == 10)
                {
                    Won();
                }
                targetPlanet++;
                
            } else if(planet > targetPlanet)
            {
                collision.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Gameover();
            }            

        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Gameover();
        }
    }

    private void Won()
    {
        isWon = true;
        FindObjectOfType<SceneScript>().Won();
    }

    void IncreaseSize()
    {
        if (tries > 10)
        {
            return;
        }
        tries++;
        scale *= 1.35f;
        currCamSize += 5;
        cam.orthographicSize += 5f; 
        this.transform.localScale = scale;                
    }
    public void Gameover()
    {
        FindObjectOfType<SceneScript>().Gameover();
        Instantiate(Particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
