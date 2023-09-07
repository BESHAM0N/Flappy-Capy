using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;

public class Fence : MonoBehaviour{
    
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
       
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    public void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; 

        if (transform.position.x < leftEdge)
            Destroy(gameObject);
    }
}
