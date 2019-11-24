using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestaoProjetos : Game
{
    public static List<string> leftSide;
    public static List<string> rightSide;
    public static List<string> boat;

    public TextMeshPro txtCantMove;
    public GameObject instructions;

    new void Start()
    {
        leftSide = new List<string>();
        rightSide = new List<string>();
        boat = new List<string>();

        leftSide.Add("Gerente");
        leftSide.Add("Lider back");
        leftSide.Add("Membro back1");
        leftSide.Add("Membro back2");
        leftSide.Add("Lider front");
        leftSide.Add("Membro front1");
        leftSide.Add("Membro front2");
        leftSide.Add("Preguiçoso");
    }

    public void ShowInstructions(bool show){
        instructions.SetActive(show);
    }

    protected IEnumerator HandleVictory(){
        if(!gestaoProjetosCompleted){
            gestaoProjetosCompleted = true;
            SaveStatus("gestaoProjetosCompleted");
        }
        txtCantMove.text = "Boa :)";
        yield return new WaitForSeconds(4);
        LoadScene("Main");
    }
}
