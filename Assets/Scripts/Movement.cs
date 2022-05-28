using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public GameObject coinSound;
    public GameObject x2Sound;
    public GameObject destroyerSound;
    private Vector3 move;
    public int speed;
    public float jumpForce;
    public float gravity = -20;
    public float growth = 1.4f;
    private int laneNumber = 1;
    public float laneDistance = 6;
    private Animator anim;
    private bool destroyer = false;
    private bool doubleCoins = false;
    public static int CoinsCounter;
    public static int ScoreCounter;
    public Text timerDestroy;
    public Text timerDouble;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        CoinsCounter=0;
        ScoreCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        

        //roll and jump animation
        if (!anim.GetBool("dead"))
        ScoreCounter+=1;
        move.z = speed;

        if (controller.isGrounded)
        {
            move.y = -1;

            if (Input.GetKeyDown(KeyCode.UpArrow) && anim.GetBool("roll") != true)
            {
                jump();
               
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && anim.GetBool("jump")!=true)

            {
                slide();
            }
           
        }
        else
        {
            move.y += gravity * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            laneNumber++;
            if (laneNumber == 3)
                laneNumber = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            laneNumber--;
            if (laneNumber == -1)
                laneNumber = 0;
        }


        Vector3 targetPostion = transform.position.z * Vector3.forward + transform.position.y * transform.up;

        if (laneNumber == 2)
            targetPostion += Vector3.right * laneDistance;
        else if (laneNumber == 0)
            targetPostion += Vector3.left * laneDistance;
       
        if (transform.position != targetPostion)
        {
           Vector3 diff = targetPostion - transform.position;
             controller.Move(diff*Time.deltaTime*speed);
        }
        controller.Move(move * Time.deltaTime);

    }
    private void slide()
    {
        anim.SetBool("roll", true);
        anim.SetBool("jump", false);
        controller.center = new Vector3(0,.45f,.5f);
        controller.height = .94f;
        controller.radius = .5f;
        StartCoroutine("delay");
    }
    private void jump()
    {
        move.y = jumpForce;
        anim.SetBool("jump", true);
        anim.SetBool("roll", false);
        controller.center = new Vector3(0f,1.5f,0f);
        controller.height = 1f;
        StartCoroutine("delay");
    }
   private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.transform.tag == "obstacle")
        { 
            if(destroyer==false)
            StartCoroutine(gameEnd());
            else
              Object.Destroy(other.gameObject);
        }
        else if (other.transform.tag == "Coins")
        {
            if (doubleCoins == true)
                CoinsCounter += 2;
            else
                CoinsCounter++;

            Destroy(other.gameObject);
            coinSound.GetComponent<AudioSource>().Play();
        }
        else if (other.transform.tag == "destroy")
        {
            StartCoroutine(powerUpDestroy());
            Object.Destroy(other.gameObject);
            destroyerSound.GetComponent<AudioSource>().Play();

        }
        else if (other.transform.tag == "2x")
        {
            StartCoroutine(powerUpDoubleCoins());
            Object.Destroy(other.gameObject);
            x2Sound.GetComponent<AudioSource>().Play();

        }

    }
    IEnumerator powerUpDoubleCoins()
    {
        doubleCoins = true;
        for(int i=10;i>=0;i--)
        {
            timerDouble.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        doubleCoins = false;
    }
    IEnumerator powerUpDestroy()
    {
        transform.localScale *= growth;
        destroyer = true;
        for (int i = 5; i >=0; i--)
        {
            timerDestroy.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        transform.localScale /= growth;
        destroyer = false;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(.8f);
        controller.center = new Vector3(0, .9f, 0);
        controller.height = 1.88f;
        controller.radius = 0.28f;
        anim.SetBool("jump", false);
        anim.SetBool("roll", false);
    }

    IEnumerator gameEnd()
    {
        anim.SetBool("dead", true);
        speed = 0;
        jumpForce = 0;
        yield return new WaitForSeconds(3);
        playerMangement.gameOver = true;
    }
}
