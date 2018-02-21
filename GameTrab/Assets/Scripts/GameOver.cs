using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public UnityEngine.UI.Text pontos;
	public UnityEngine.UI.Text recorde;

	// Use this for initialization
	void Start () {

		pontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
		recorde.text = PlayerPrefs.GetInt("recorde").ToString();
	}

}
