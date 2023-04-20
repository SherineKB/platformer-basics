using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life;
    public GameObject[] heart;

    [SerializeField] private AudioSource heartSound;
    

    void Start()
    {
        life = 3;
    }

  
    void Update()
    {
        if (life == 2)
        {
            Destroy(heart[0].gameObject);
        }

        if (life==1)
        {
            Destroy(heart[1].gameObject);
        }

        if (life==0)
        {
            Destroy(heart[2].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene when death           
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Damage")

        {
            life -=1;
            heartSound.Play();
        }            
    }
}
