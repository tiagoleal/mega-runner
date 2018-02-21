using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speed;
	private float offset;

	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer>().material;


	}
	
	// Update is called once per frame
	void Update () {
		offset += speed * Time.deltaTime; //tempo que passou de um frame a outro p/dispositivos diferentes

		currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offset, 0)); //aplica na textura movendo somente o x

	}
}
