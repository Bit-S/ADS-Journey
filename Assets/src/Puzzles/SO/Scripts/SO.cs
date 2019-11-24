using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SO : Game
{
    public static string currentProcess;
    public static byte time = 5;
    string defeatExplanation = "";
    byte round = 0;

    string[] processes = new string[]{"skype", "steam", "chrome", "spotify", "paint", "chrome", "skype"};
    public List<string> activeProcesses = new List<string>();

    public TextMeshPro txtTime;
    public TextMeshPro txtAction;

    public GameObject instructions;

    new void Start()
    {
        CancelInvoke();
        time = 5;
        InvokeRepeating("HandleProcess", 0, 5.001f);
        InvokeRepeating("HandleTime", 1, 1);
    }

    void HandleTime(){
        time--;
        txtTime.text = "" + time;
        if(time == 0){
            if(CPU.inProcess && CPU.status == "ram") 
                time = 5;
            else
                HandleGameOver();           
            CPU.inProcess = false;
            if(round <  5)
                for(byte i = 0; i < activeProcesses.Count - 1; i++) {
                    Process processScript = GameObject.Find(activeProcesses[i] + "(Clone)").GetComponent<Process>();
                    if(processScript.status != "ram") {
                        defeatExplanation = "Programa fora da RAM inesperadamente";
                        HandleGameOver();
                        return;
                    }
                }
            if(round >= 5){
                Process processScript = GameObject.Find(activeProcesses[0] + "(Clone)").GetComponent<Process>();
                if(processScript.status != "hd" && round != 6){
                    defeatExplanation = "O programa que está há mais tempo na RAM deve ir pro HD";
                    HandleGameOver();
                    return;
                }
                if(round != 6) activeProcesses.RemoveAt(0);
            }
            
        }
    }

    void HandleProcess()
    {  
        if(round == 7) {
            txtAction.text = "Boa :)\nDesligando PC...";
            StartCoroutine(HandleVictory());
        }; 
        currentProcess = processes[round];
        txtAction.text = "Abrir " + currentProcess;
        if(!activeProcesses.Contains(currentProcess) && round < 6){
            activeProcesses.Add(currentProcess);
            Instantiate(GameObject.Find(currentProcess), new Vector3(-3, -2, 95), Quaternion.identity);
        }
        round++;
    }

    public void ShowInstructions(bool show){
         instructions.SetActive(show);
     }

    IEnumerator HandleVictory(){
        CancelInvoke("HandleTime");
        CancelInvoke("HandleProcess");
        GameObject[] processObjs = GameObject.FindGameObjectsWithTag("Process");
        foreach (GameObject processObj in processObjs) {
            Destroy(processObj);
            yield return new WaitForSeconds(0.6f);
        }
        if(!soCompleted){
            soCompleted = true;
            SaveStatus("soCompleted");
        }
        LoadScene("Main");
    }

    void HandleGameOver(){
        txtTime.text = "Você perdeu";
        CancelInvoke("HandleProcess");
        CancelInvoke("HandleTime");
        
        if(defeatExplanation == ""){
            if(CPU.status == "hd")
                defeatExplanation = "Processador não acessa diretamente o HD\n";
            else if(CPU.status == "fora")
                defeatExplanation = "CPU só trabalha com a memória RAM";
            else
                defeatExplanation = "CPU não está executando o programa solicitado\n";
        }
        
        txtAction.text = defeatExplanation;
    }
}
