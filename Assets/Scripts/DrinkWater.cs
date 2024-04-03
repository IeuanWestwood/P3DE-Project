using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{

    public Animator animator;
    public GameObject ui;
    public AudioClip waterSound;

    // Start is called before the first frame update
    void Start()
    {
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
            ShowUI();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideUI();

        }
    }

    public void Drink()
    {
        animator.SetTrigger("Clicked");
        gameObject.GetComponent<AudioSource>().PlayOneShot(waterSound);
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
        Drink();
    }

    public void PressNo()
    {
        HideUI();
    }

}
