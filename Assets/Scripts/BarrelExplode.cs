using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    // UI element
    public GameObject ui;
    // Sound
    public AudioClip explosionSound;
    // Explosion Effects
    public ParticleSystem smokeClouds;
    public ParticleSystem fireClouds;
    // Exploded Check
    public bool Exploded = false;


    // Start is called before the first frame update
    void Start()
    {
        //Hide UI on start game and render objects
        HideUI();
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // if not exploded and has been triggered by player Show UI
            if (!Exploded)
            {
                ShowUI();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // If not exploded and player has exited S
            if (!Exploded)
            {
                HideUI();
            }
        }
    }

    public void Shoot()
    {
        // Play explosion vfx and sfx
        gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        fireClouds.Play();
        smokeClouds.Play();
        // set render to false on barrel
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        // set Exploded to true for future 
        Exploded = true;
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
        // Show UI and unlock cursor
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressYes()
    {
        // When confirm UI pressed Hide UI and trigger explosion function
        HideUI();
        Shoot();
    }

    public void PressNo()
    {
        // Hide UI when decline buton pressed
        HideUI();
    }
}
