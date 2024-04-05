using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    // Animation 
    public Animator animator;
    // Audio
    public AudioClip chestOpenSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // If player has entered trigger collider play sound and animation open
            animator.SetTrigger("Open");
            animator.ResetTrigger("Close");
            gameObject.GetComponent<AudioSource>().PlayOneShot(chestOpenSound);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            // If player has exited trigger collider play sound and animation close

            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");
        }
    }
}
