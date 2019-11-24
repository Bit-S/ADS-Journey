using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process : Game
{
    Vector3 mousePos;

    public string status;

    // Update is called once per frame
    new void Update()
    {
        if(transform.position.x > 0.8f && transform.position.x < 1.8f)
            status = "ram";
        else if(transform.position.x > 5.5f && transform.position.x < 6.3)
            status = "hd";
        else
            status = "fora";
        //Debug.Log(status);
    }

    void OnMouseDrag(){
		mousePos = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
		mousePos.z = 0;
		transform.position = mousePos;
	}
}
