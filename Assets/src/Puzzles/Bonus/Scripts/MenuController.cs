using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{
    private DataController data;
    void Start(){
        data = FindObjectOfType<DataController>();
    }

    public void StartGame(int round){
        data.SetRoundData(round);
        SceneManager.LoadScene("BonusGame");
    }
}
