using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int itemCount;
    public float JumpPower = 50;
    public GameManager manager;

    bool isJump;
    Rigidbody rigid;
    AudioSource itemAudio;
    //AudioSource jumpAudio;

    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        itemAudio = GetComponent<AudioSource>();
        //jumpAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            //jumpAudio.Play();
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");   // 좌우
        float v = Input.GetAxisRaw("Vertical");     // 전후
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isJump = false;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            itemAudio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                manager.stage++;
                SceneManager.LoadScene(manager.stage);
            }
            else
            {
                // Restart
                // SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
