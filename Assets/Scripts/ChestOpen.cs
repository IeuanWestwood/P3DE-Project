using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{

    public Animator animator;
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
            animator.SetTrigger("Open");
            animator.ResetTrigger("Close");
            gameObject.GetComponent<AudioSource>().PlayOneShot(chestOpenSound);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");
        }
    }
}
