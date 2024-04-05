using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    // UI element
    public GameObject ui;
    // Cannon shot Audio
    public AudioClip cannonSound;
    // Particle effects for cannon fire
    public ParticleSystem smokeCloud;

    // Start is called before the first frame update
    void Start()
    {
        // Hide UI elements when game starts
        HideUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // If player enters trigger Display UI
            ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // If player exits trigger Hide UI

            HideUI();
        }
    }

    public void Shoot()
    {
        // Play smoke effect and Cannon audio
            gameObject.GetComponent<AudioSource>().PlayOneShot(cannonSound);
            smokeCloud.Play();
    }

    public void HideUI()
    {
        // Hide UI elements and lock cursor
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void ShowUI()
    {
        // Show UI elements and unlock cursor
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressYes()
    {
        // When confirm button is pressed hide UI and call Shoot cannon function
        HideUI();
        Shoot();
    }

    public void PressNo()
    {        
        // When decline button is pressed hide UI
        HideUI();
    }
}
