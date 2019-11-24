using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour{
    public RoundData[] todasAsRodadas;
    private int rodadaIndex;
    // private int playerHighScore;

    void Start(){
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BonusIntro");
        GooglePlayGame.ReportAchievementProgress("CgkIkpePysQWEAIQBA", 100.0f, success => {});
    }

    public void SetRoundData(int round){
        rodadaIndex = round;
    }

    public RoundData GetCurrentRoundData(){
        return todasAsRodadas[rodadaIndex]; 
    }
}