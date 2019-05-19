using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float stamina = 10f;
    public float maxStamina = 10f;
    public float speed = 200f;

    private float staminaRegenTimer = 0f;
    private const float staminaTimeToRegen = 3.0f;

    Vector2 direction = Vector2.zero;

    Rigidbody2D rb2d;

    void Start()
    {

        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        else { direction.y = 0; }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        else { direction.x = 0; }


        //Dash
        if (stamina > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speed = 500f;
                stamina = stamina - 5f;
                staminaRegenTimer = 0.0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 200f;
        }

        if (stamina < maxStamina)
        {
            if (staminaRegenTimer >= staminaTimeToRegen)
            {
                stamina = Mathf.Clamp(stamina + (1 * Time.deltaTime), 0.0f, maxStamina);


            }
            else
                staminaRegenTimer += Time.deltaTime;
        }

        if (stamina < 0)
        {
            speed = 100f;
        }

        if (stamina > 0)
        {
            speed = 200f;
                }



        //rb2d.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);

        //this.transform.position += (Vector3)direction * speed * Time.deltaTime;

        rb2d.velocity = direction * speed * Time.deltaTime;
    }
}
