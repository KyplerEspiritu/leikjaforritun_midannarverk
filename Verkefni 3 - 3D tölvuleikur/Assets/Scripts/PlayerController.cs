using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public float distance = 5;
	public Text countText;
	public Text winText;
	public Texture2D crosshairImage;

	private Rigidbody rigidbody;
	private int treesCollected;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        treesCollected = 0;
        SetCountTex();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
 		var actualDirection = Camera.main.transform.TransformDirection(movement);
 		rigidbody.AddForce(actualDirection * speed);
    }
    void OnTriggerEnter(Collider other){
    	if (other.gameObject.CompareTag("Pick Up")){
    		other.gameObject.SetActive(false);
    		treesCollected++;
    		SetCountTex();
    	}
    	if (other.gameObject.CompareTag("trophy")){
    		other.gameObject.SetActive(false);
    		winText.text = "You escaped!";
    	}
    }
    void SetCountTex(){
    	countText.text = "Trees Collected: " + treesCollected.ToString();
    	if (treesCollected >= 5){
    		GameObject[] gos = GameObject.FindGameObjectsWithTag("purpleBox");
    		gos[0].SetActive(false);
    	}
    }
}
