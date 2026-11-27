using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
public class plsplspls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 moves = new Vector3(0, -100, 0);
    public TextMeshProUGUI countText;
    Rigidbody rb;
    private int counter;
    public PhysicsMaterial material;
    public PhysicsMaterial deck;
    void Start()
    {
        countText.text = "Count: 0";
        counter = 0;
        rb = GetComponent<Rigidbody>();
        PhysicsMaterial material = new PhysicsMaterial("Bal");
        PhysicsMaterial deck = new PhysicsMaterial("Dek");
        material.bounciness = 1f;
        deck.bounciness = 1f;
    }
    public void AddScore(int n)
    {
        counter += n;
        countText.text = $"Score: {counter}";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            AddScore(1);
            Debug.Log("Hit the floor "+ counter);
            
    }
    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log(mouse.leftButton.wasPressedThisFrame + "Left");
            rb.AddForce(moves);
        }
        if (mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log(mouse.leftButton.wasPressedThisFrame + "Right");
            rb.position = new Vector3(0f, 8f, 0f);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            counter = 0;
            AddScore(0);
            
        }

    }
}
