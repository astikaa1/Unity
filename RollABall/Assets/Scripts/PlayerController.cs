using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public float speed = 0;
    private Rigidbody rb;
    private int count;
    private float MovementX;
    private float MovementY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        MovementX = movementVector.x;
        MovementY = movementVector.y;
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(MovementX,0.00f,MovementY);
        rb.AddForce(movement * speed);

    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    private void OnTriggerEnter(Collider other) //called when it touches a collider
    {   if(other.gameObject.CompareTag("PickUp")){
        other.gameObject.SetActive(false);
        count++;
        SetCountText();

        }                    

    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count>=12){
            winTextObject.SetActive(true);
        }
    }
}
