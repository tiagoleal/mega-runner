using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject barreiraPrefab; //Objeto a ser spawnado
	public float rateSpawn;           // intervalo de spawn
	private float currentTime; 		  
	private int posicao;
	private float y;
	public float PosA;
	public float PosB;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime >= rateSpawn) {
			currentTime = 0;

			posicao = Random.Range(1,100);
			
			//direciona o obstaculo para cima e para baixo
			if(posicao > 50){
				//y = 0.95f; 
				y = PosA; 
			}else{
				//y = 0.38f;
				y = PosB;
			}	

			GameObject tempPrefab = Instantiate(barreiraPrefab) as GameObject;//chama objeto na tela
			tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z);

		}
	}
}
