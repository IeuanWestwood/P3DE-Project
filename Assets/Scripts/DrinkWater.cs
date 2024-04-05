using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{
    // Animation
    public Animator animator;
    // UI Element
    public GameObject ui;
    // Audio
    public AudioClip waterSound;

    // Start is called before the first frame update
    void Start()
    {
        // Hide UI elements on game start
        HideUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // If player has entered collider display UI elements
            ShowUI();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // If player has exited collider hide UI elements

            HideUI();

        }
    }

    public void Drink()
    {
        // Play drink animation and Audio
        animator.SetTrigger("Clicked");
        gameObject.GetComponent<AudioSource>().PlayOneShot(waterSound);
    }

    public void HideUI()
    {
        // Hide UI and lock cursor
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void ShowUI()
    {
        // show UI and unlock cursor
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressYes()
    {
        // When confirm button is pressed Hide UI and call drink function
        HideUI();
        Drink();
    }

    public void PressNo()
    {
        // When decline button is pressed Hide UI

        HideUI();
    }

}
