using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Vector2 Speed = new Vector2(50, 50);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(Speed.x * inputX, Speed.y * inputY, 0);
        Movement *= Time.deltaTime;
        transform.Translate(Movement);
    }
}
