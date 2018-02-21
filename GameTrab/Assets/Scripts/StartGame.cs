using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//se aperta o botao direito do mouse entra no jogo

		if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel("jogar");
		}
	}
}
