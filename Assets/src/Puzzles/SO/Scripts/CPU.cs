using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : Game
{
    Vector3 mousePos;

    public static string status;

    public static bool inProcess = false;

    new void Update(){
        if(transform.position.x >= 0.2f && transform.position.x < 2.3f)
            status = "ram";
        else if(transform.position.x > 5 && transform.position.x < 6.8f)
            status = "hd";
        else {
            status = "fora";
        }
    }

    void OnMouseDrag(){
		mousePos = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
		mousePos.z = -0.7f;
		transform.position = mousePos;
	}

    void OnTriggerEnter2D(Collider2D other){
        Process processScript = (Process) other.GetComponent(typeof(Process));
        if(other.name.Contains(SO.currentProcess) && processScript.status == "ram" ) inProcess = true;
    }

}
