using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator    Anime;
	public Rigidbody2D playerRigidBody;
	public int 		   forceJump;

	public bool        jump;
	public bool        slide;

	//verifica o chao
	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;


	//slide
	public float slideTemp;
	public float timeTemp;

	//colisor
	public Transform colisor;

	//Audio
	public AudioSource audio;
	public AudioClip soundJump;
	public AudioClip soundSlide;

	//PONTUACAO
	public UnityEngine.UI.Text txtPontos;
	public static int pontuacao;

	// Use this for initialization
	void Start () {
	
		pontuacao = 0;
		PlayerPrefs.SetInt("pontuacao", pontuacao);

	}
	
	// Update is called once per frame
	void Update () {

		//se o botao pulo foi apertado e tiver pisando no chao
		//if (Input.GetButtonDown("Jump")
		if (Input.GetMouseButtonDown(0) && grounded == true) {
			//Debug.Log("Pulo");
			playerRigidBody.AddForce(new Vector2(0,forceJump));

			audio.PlayOneShot(soundJump);
			audio.volume = 1f;

			//caso esteja no slide
			if(slide == true){
				colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
			}

			slide = false;

		}

		//se o botao de deslizar for apertado
		//Input.GetButtonDown ("Slide")
		if (Input.GetMouseButtonDown(1) && grounded == true && slide == false) {
			//Debug.Log("Slide");
			//desce o coliso para poder fazer o sprite deslisar e e nao bater no obstaculo
			colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);

			audio.PlayOneShot(soundSlide);
			audio.volume = 0.5f; //BAIXA O VOLUME PARA A METADE

			slide = true;
			timeTemp = 0;
		}

		txtPontos.text = pontuacao.ToString();

		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);

		if (slide == true) {

			timeTemp +=Time.deltaTime;

			if(timeTemp >= slideTemp){
				//desce o coliso para poder fazer o sprite deslisar e e nao bater no obstaculo
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;	
			}
		
		}

		Anime.SetBool("jump", !grounded);
		Anime.SetBool("slide", slide);

	}

	void OnTriggerEnter2D(){
		//Debug.Log("Bateu");
		//grava a pontuacao para mostrar no gameover
		PlayerPrefs.SetInt("pontuacao", pontuacao);
		if(pontuacao > PlayerPrefs.GetInt("recorde"))
		{
			PlayerPrefs.SetInt("recorde",pontuacao);
		}
		Application.LoadLevel ("gameover");

	} 


}
