using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int scoreBall = 0;
    public int scoreBone = 0;
    public int scoreCandy = 0;
    public int scoreItem = 0;
    public int scoreMaze = 0;
    public int scoreTreasure = 0;
    public int scoreCake = 0;
    public GameObject secretItem1;
    public GameObject secretItem2;
    public GameObject secretItem3;
    public GameObject secretItem4;
    public GameObject secretItem5;
    Ray ray;
    RaycastHit hitData;
    public float eyeDistance = 5.0f;
    public Text msg;
    public Text msg1;
    public Transform startingPoint; 
    public Vector3 respawnPosition;
    public float jumpBoostMultiplier = 25.0f;
    public string jumpFloorTag = "JumpingFloor";
    public DoorController door;
    public GameObject WinMenu;
    public GameObject Player;
    public GameObject Timer;
    public AudioSource ShotSound;
    public AudioSource DoorSound;
    public AudioSource ItemSound;
    public AudioSource YummySound;
    public AudioSource BooSound;
    public AudioSource HurtSound;
    public AudioSource JumpSound;

    void Start()
    {
        msg.transform.gameObject.SetActive(false);
        msg.text = "Message";

        WinMenu.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            scoreBall++;
            ItemSound.Play();

            if(scoreBall == 12)
            {
                secretItem1.SetActive(true);
            }

        }
        
        if(other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);
            scoreCandy++;
            YummySound.Play();

            if(scoreCandy == 10)
            {
                secretItem4.SetActive(true);
            }
        }
    }

    internal void Die()
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            HandlePlayerDeath();
            HurtSound.Play();
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            HandlePlayerDeath();
            HurtSound.Play();
        }
        if (collision.gameObject.tag == jumpFloorTag)
        {           
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpBoostMultiplier, ForceMode.Impulse);
            JumpSound.Play();
        }
        if (collision.gameObject.tag == "Big")
        {
            YummySound.PlayOneShot(YummySound.clip, 1.0F);
            GameWin();
            Timer.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    private void HandlePlayerDeath()
    {
        Invoke("RespawnPlayer", 0f);
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPosition;

        gameObject.SetActive(true);

    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);
        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "Sign0":
                    msg.text = "There are 5 Black Blocks like me find them to know your task";
                    msg.transform.gameObject.SetActive(true);
                    break;

                case "Sign1":
                    msg.text = "Go in to the forest and collect the 6 balls come back to get something";
                    msg.transform.gameObject.SetActive(true);
                    if(scoreBall == 6)
                    {
                        msg.text = "Clear";
                    }

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    break;

                case "Sign2":
                    msg.text = "Go find the way and get the treasure";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    break;

                case "Sign3":
                    msg.text = "Kill All Monsters Inside and you will get a BigBone!!";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    break;

                case "Sign4":
                    msg.text = "Go and Jump to collect small cake to get a Big Cake!!";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    break;

                case "Sign5":
                    msg.text = "If you find the right one you will hear the good sound";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    break;

                case "Bone":
                    msg.text = "Press E to collect smallbone";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        scoreBone++;
                        ItemSound.Play();
                        

                        if (scoreBone == 5)
                        {
                            secretItem3.SetActive(true);
                        }
                    }
                    break;

                

                case "Eat":
                    msg.text = "You're so good Eat this and Go Jump!!!!";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        scoreMaze++;
                        YummySound.Play();

                        if (scoreMaze == 1)
                        {
                            secretItem2.SetActive(true);
                        }
                    }
                    break;

                case "Treasure":
                    msg.text = "Press E";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        scoreTreasure++;
                        ItemSound.Play();

                        if (scoreTreasure == 1)
                        {
                            secretItem5.SetActive(true);
                        }
                    }
                    break;

                case "Die":
                    msg.text = "Press E";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        BooSound.Play();
                    }

                    break;

                case "Item":
                    msg.text = "Press E to collect Secret Item";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        scoreItem++;
                        ItemSound.Play();

                        if (scoreItem == 5)
                        {
                            door.control();
                            DoorSound.Play();
                        }
                    }
                    break;


            }
        }
        else
        {
            //hide text msg
            msg.transform.gameObject.SetActive(false);
        }

        if (scoreItem <= 5)
        {
            msg1.text = "Task " + scoreItem + "/5 Secret Items";
        }


        if (Input.GetButtonDown("Fire1"))
        {
            ShotSound.Play();
        }


    }

    public void GameWin()
    {
        WinMenu.gameObject.SetActive(true);
    }

}
