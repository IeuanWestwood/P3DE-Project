using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoconut : MonoBehaviour
{
    // Ui element
    public GameObject ui;
    // Audio 
    public AudioClip eatingSound;
    // Bollean to ensure ui plays once + sound
    public bool eaten = false;
    // each fruit gameObject
    public GameObject fruit1;
    public GameObject fruit2;

    // Start is called before the first frame update
    void Start()
    {
        // When game starting hide the UI
        HideUI();
        // Set all fruit to render
        fruit1.GetComponent<MeshCollider>().enabled = true;
        fruit1.GetComponent<MeshRenderer>().enabled = true;
        fruit2.GetComponent<MeshCollider>().enabled = true;
        fruit2.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !eaten)
        {
            // If player has entered object collision box Show UI
            ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !eaten)
        {
            // exiting trigger with box collider Hide UI
            HideUI();
        }
    }

    public void Eat()
    {
        // Play Oneshot audio Clip
        gameObject.GetComponent<AudioSource>().PlayOneShot(eatingSound);
        // set all objects to render as false
        fruit1.GetComponent<MeshCollider>().enabled = false;
        fruit1.GetComponent<MeshRenderer>().enabled = false;
        fruit2.GetComponent<MeshCollider>().enabled = false;
        fruit2.GetComponent<MeshRenderer>().enabled = false;
        // eaten = true so The audio and UI will not play again
        eaten = true;
    }

    public void HideUI()
    {
        // Hide UI elements and cursor lock
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void ShowUI()
    {
        // Show UI elements and cursor unlock
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressYes()
    {
        // Hide Ui on confirm + Eat fruit called
        HideUI();
        Eat();
    }

    public void PressNo()
    {
        // Hide UI on decline pressed
        HideUI();
    }
}
