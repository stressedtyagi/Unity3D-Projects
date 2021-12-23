using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text Exit;

    private Rigidbody rb;
    private int count;

    private void Start()
    {        
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        Exit.text = "X To Exit";
        setCountText(); 
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey("x"))
            Application.Quit();


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }        

        if(count == 13)
        {
            winText.text = "YOU WON";
        }
    }

    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}

