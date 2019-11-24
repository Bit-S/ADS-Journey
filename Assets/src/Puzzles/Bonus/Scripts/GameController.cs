using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour{
	public Text textoPergunta;
	// public Text textoPontos;
	// public Text highScoreText;

	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject painelDePerguntas;
	public GameObject painelFimRodada;

	private DataController dataController;
	private RoundData rodadaAtual;
	private QuestionData[] questionPool;


	private bool rodadaAtiva;
	private int questionIndex;
	// private int playerScore;

	List<int> usedValues = new List<int>();
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	void Start(){
		dataController = FindObjectOfType<DataController>();
		rodadaAtual = dataController.GetCurrentRoundData();
		questionPool = rodadaAtual.perguntas;
		ShowQuestion();

		// playerScore = 0;
		questionIndex = 0;
		rodadaAtiva = true;
	}

	void Update(){
		// if (rodadaAtiva){
				
		// }
	}

	private void ShowQuestion(){
		RemoveAnswerButtons();

		int random = Random.Range(0, questionPool.Length);

		while (usedValues.Contains(random)){
			random = Random.Range(0, questionPool.Length);
		}

		QuestionData questionData = questionPool[random];
		usedValues.Add(random);
		textoPergunta.text = questionData.textoDaPergunta;

		for (int i = 0; i < questionData.respostas.Length; i++){
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
			answerButtonGameObject.transform.SetParent(answerButtonParent);
			answerButtonGameObjects.Add(answerButtonGameObject);

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup(questionData.respostas[i]);
		}
	}

	private void RemoveAnswerButtons(){

		while (answerButtonGameObjects.Count > 0){
			answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
	}

	public void AnswerButtonClicked(bool estaCorreto){
		// if(estaCorreto){
		// 	playerScore += 10;
		// 	textoPontos.text = "Score:" + playerScore.ToString();
		// }

		if (questionPool.Length > questionIndex + 1){
			questionIndex++;
			ShowQuestion();
		}
		else{
			EndRound();
		}
	}

	public void EndRound(){
		rodadaAtiva = false;
		painelDePerguntas.SetActive(false);
		painelFimRodada.SetActive(true);
	}

	public void ReturnToMenu(){
		SceneManager.LoadScene("Main");
	}
}
