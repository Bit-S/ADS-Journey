using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static string OS;

    public static bool matDiscCompleted;
    public static bool aocCompleted;
    public static bool soCompleted;
    public static bool bancoDadosCompleted;
    public static bool redesCompleted;
    public static bool algoritmoCompleted;
    public static bool estDadosCompleted;
    public static bool engSoftwareCompleted;
    public static bool gestaoProjetosCompleted;

    public static int nPuzzlesCompleted;

    protected void Start(){
        if(GetCurrentSceneName() == "Menu"){
            Initialize();
        }
    }

    void Initialize(){
        OS = SystemInfo.operatingSystem;

        soCompleted = PlayerPrefs.HasKey("soCompleted");
        aocCompleted = PlayerPrefs.HasKey("aocCompleted");
        bancoDadosCompleted = PlayerPrefs.HasKey("bancoDadosCompleted");
        matDiscCompleted = PlayerPrefs.HasKey("matDiscCompleted");
        redesCompleted = PlayerPrefs.HasKey("redesCompleted");
        algoritmoCompleted = PlayerPrefs.HasKey("algoritmoCompleted");
        estDadosCompleted = PlayerPrefs.HasKey("estDadosCompleted");
        gestaoProjetosCompleted = PlayerPrefs.HasKey("gestaoProjetosCompleted");
        engSoftwareCompleted = PlayerPrefs.HasKey("engSoftwareCompleted");

        nPuzzlesCompleted = PlayerPrefs.GetInt("nPuzzlesCompleted", 0);

        if(!GooglePlayGame.hasTriedToLogin){
            GooglePlayGame.Init();
            GooglePlayGame.Login(success => {});
            GooglePlayGame.hasTriedToLogin = true;
        }

    }

    protected void SaveStatus(string completedPuzzle){
        PlayerPrefs.SetInt(completedPuzzle, 1);
        nPuzzlesCompleted += 1;
        PlayerPrefs.SetInt("nPuzzlesCompleted", nPuzzlesCompleted);
        CheckAchievement();
    }

    void CheckAchievement(){
        switch(nPuzzlesCompleted){
            case 3:
                GooglePlayGame.IncrementAchievement("CgkIkpePysQWEAIQAQ", 3, success => {});
                break;
            case 6:
                GooglePlayGame.IncrementAchievement("CgkIkpePysQWEAIQAg", 6, success => {});
                break;
            case 9:
                GooglePlayGame.IncrementAchievement("CgkIkpePysQWEAIQAw", 9, success => {});
                break;
            default:
                return;
        }
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public static string GetCurrentSceneName(){
        return SceneManager.GetActiveScene().name;
    }

    protected void CopyList(List<string> originalList, List<string> newList){
        foreach(var item in originalList){
            newList.Add(item);
        }
    }

    protected void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(GetCurrentSceneName() == "Main")
                LoadScene("Menu");
            else
                LoadScene("Main");
		}
	}
}
