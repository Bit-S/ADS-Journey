using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Redes : Game
{
    
    public static byte time;
    
    public static GameObject imgScreen;
    public static TextMeshPro txtLoading;
    public static TextMeshPro txtTime;


    new void Start()
    {
        time = 15;
        InvokeRepeating("HandleTime", 1, 1);
        imgScreen = GameObject.Find("imgScreen");
        txtLoading = GameObject.Find("txtLoading").GetComponent<TextMeshPro>();
        txtTime = GameObject.Find("txtTime").GetComponent<TextMeshPro>();
    }

    void HandleTime(){
        time--;
        txtTime.text = "" + time;
        if(time == 0){
            HandleDefeat();
        }
    }

    void HandleDefeat(){
        time = 15;
        CancelInvoke("HandleTime");
        LoadScene(GetCurrentSceneName());
    }

    public IEnumerator HandleVictory(){
        time = 15;
        imgScreen.transform.position += new Vector3(0, 0, 20);
        txtLoading.text = txtLoading.text.Replace("...", "") + "\nBoa :)";
        Destroy(GameObject.Find("PackResponse"));
        yield return new WaitForSeconds(3);

        if(GetCurrentSceneName() == "RedesGame1")
            LoadScene("RedesIntro2");
        else {
            if(!redesCompleted){
                redesCompleted = true;
                SaveStatus("redesCompleted");
            }
            LoadScene("Main");
        }
    }
}
