using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{

	public float speed;
	public float distance = 5;
	public Text countText;
	public Text winText;
	public Texture2D crosshairImage;

	private Rigidbody rb;
	private int treesCollected;
    // Start is called before the first frame update

    IEnumerator loadMainMenu() // Fall sem loadar main menu eftir 3 sek
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        treesCollected = 0;   
        SetCountTex();
        winText.text = "";
    }

    // Update is called once per frame
    void Update() // Fall fyrir hreyfingu kúlunnar
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
 		var actualDirection = Camera.main.transform.TransformDirection(movement);
 		rb.AddForce(actualDirection * speed);
    }
    void OnTriggerEnter(Collider other){
    	if (other.gameObject.CompareTag("Pick Up")){ // Þegar þú snertir object með tagið pick up
    		other.gameObject.SetActive(false);
    		treesCollected++;
    		SetCountTex();
    	}
    	if (other.gameObject.CompareTag("trophy")){ // Þegar þú nærð í trophy-ið
    		other.gameObject.SetActive(false);
    		winText.text = "You escaped!";
            StartCoroutine(loadMainMenu());
    	}
    }
    void SetCountTex(){ // Update-ar textan 
    	countText.text = "Keys Collected: " + treesCollected.ToString();
    	if (treesCollected >= 5){
    		GameObject[] gos = GameObject.FindGameObjectsWithTag("purpleBox");
    		gos[0].SetActive(false);
    	}
    }
}
