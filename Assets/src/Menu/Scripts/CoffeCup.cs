using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeCup : MonoBehaviour
{
    Rigidbody2D rigidbody;

    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if(Input.GetMouseButtonDown(0)){
            int direction = Random.Range(-1, 2);
            rigidbody.AddForce(new Vector2(100 * direction, 400));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "BoundBottom")
            GooglePlayGame.ReportAchievementProgress("CgkIkpePysQWEAIQBQ", 100.0f, success => {});
    }
}
