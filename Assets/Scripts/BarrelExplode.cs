using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    public GameObject ui;
    public AudioClip explosionSound;
    public ParticleSystem smokeClouds;
    public ParticleSystem fireClouds;
    public bool Exploded = false;


    // Start is called before the first frame update
    void Start()
    {
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
            if (!Exploded)
            {
                HideUI();
            }
        }
    }

    public void Shoot()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        fireClouds.Play();
        smokeClouds.Play();
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Exploded = true;
    }

    public void HideUI()
    {
        ui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void ShowUI()
    {
        ui.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressYes()
    {
        HideUI();
        Shoot();
    }

    public void PressNo()
    {
        HideUI();
    }
}
