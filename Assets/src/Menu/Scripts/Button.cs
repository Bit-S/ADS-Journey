using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    void OnMouseDown(){
        transform.localScale *= 0.9f;
    }

    void OnMouseUp(){
        transform.localScale /= 0.9f;
        Game game = new Game();
        if(gameObject.name == "btnPlay")
            game.LoadScene("Main");
        if(gameObject.name == "btnAbout")
            game.LoadScene("About");
        if(gameObject.name == "btnAchievements")
            GooglePlayGame.ShowAchievementsUI();
    }

    void Update(){
        if(gameObject.name == "btnPlay"){
            Animate();
        }
    }

    void Animate(){
        if(transform.localScale.y < 1.4f) {
            InvokeRepeating("Inflate", 0, 0.1f);
            CancelInvoke("Shrink");
        }
        if(transform.localScale.y > 1.5f) {
            InvokeRepeating("Shrink", 0, 0.1f);
            CancelInvoke("Inflate");
        } 
    }

    public void Inflate(){
        transform.localScale += new Vector3(0.01f, 0.01f, 0);
    }
    
    public void Shrink(){
        transform.localScale += new Vector3(-0.01f, -0.01f, 0);
    }
}
