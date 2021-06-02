using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class headController : MonoBehaviour
{
    float xRotate;
    float yRotate;
    Transform head_tr;
    public GameObject body;
    Transform body_tr;
    public GameObject panelE;
    public GameObject panelH;
    public GameObject letter;
    public GameObject hand; 
    public GameObject cube; 
    public GameObject letterPanel;
    public GameObject paper2;
    public GameObject minimap;
    public KeyCode esc;
    public KeyCode one;
    public KeyCode two;
    public GameObject home;
    public GameObject choice;
    public GameObject start;
    public KeyCode q;
    public GameObject slime;
    int hp = 50;
    int time = 40;
    public Text timerText;
    public Text hpText;
    public GameObject textt;
    public GameObject bad;
    public GameObject win;
    public GameObject no;
    void Timer(){
        time = time - 1;
        timerText.text = "Timer:" + time;
    }
    bool pressed2 = false;
    bool pressed1 = false;
    void Start()
    {
        head_tr = GetComponent<Transform>();
        body_tr = body.GetComponent<Transform>();
        panelE = GameObject.Find("PressE");
        panelE.SetActive(false);
        panelH.SetActive(false);
        letterPanel.SetActive(false);
        paper2.SetActive(false);
        minimap.SetActive(false);
        home.SetActive(false);
        choice.SetActive(false);
        start.SetActive(true);
        slime.SetActive(false);   
        textt.SetActive(false);
        bad.SetActive(false);
        win.SetActive(false);
        no.SetActive(false);
        //letter = GameObject.Find("letter");
       // hand = GameObject.Find("place");
    }


    void Update()
    {
        xRotate = xRotate - Input.GetAxis("Mouse Y") * 3;
        yRotate = yRotate + Input.GetAxis("Mouse X") * 3;
        xRotate = Mathf.Clamp(xRotate, -90, 90); //ограничения по Y
        
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);

        panelE.SetActive(false);
        Debug.DrawRay(head_tr.position, head_tr.forward * 3f, Color.red);

        RaycastHit touch;

        if (Physics.Raycast(head_tr.position, head_tr.forward, out touch, 3f)) //проверяет все обекты которые расположены перед ним
        {
            if (touch.collider.gameObject.tag == "news")
            {
                panelE.SetActive(true);
                
                if (Input.GetKeyDown("e"))
                {
                    letterPanel.SetActive(true);
                    letter.GetComponent<Transform>().position = hand.GetComponent<Transform>().position;
                    letter.GetComponent<Transform>().SetParent(hand.GetComponent<Transform>());
                }
                if (Input.GetKeyDown("r"))
                {
                    paper2.SetActive(true);
                }
                if (Input.GetKeyDown(esc))
                {
                    letterPanel.SetActive(false);
                    paper2.SetActive(false);
                    minimap.SetActive(true);
                    home.SetActive(true);
                    letter.GetComponent<Transform>().position = cube.GetComponent<Transform>().position;
                    letter.GetComponent<Transform>().SetParent(cube.GetComponent<Transform>());
                }
            }
            if(touch.collider.gameObject.tag == "home")
            {
                panelH.SetActive(true);
                if (Input.GetKeyDown("h"))
                {
                    choice.SetActive(true);
                    panelH.SetActive(false);
                }
            } 
            if(Input.GetKeyDown("1"))
            {
                pressed1 = true;
                choice.SetActive(false);
                panelH.SetActive(false);
                bad.SetActive(true);
                Invoke("oneAction", 3f);
            }
            if(Input.GetKeyDown("2"))
            {
                pressed2 = true;
                panelH.SetActive(false);
                slime.SetActive(true);
                choice.SetActive(false);
                InvokeRepeating("Timer", 1f, 1f); 
            }
        
        }
        if(pressed2 == true)
        {
            if(hp < 0 && time == 0)
            {
                InvokeRepeating("Timer", 1f, 1f); 
                no.SetActive(true);
            }
            if(hp > 0 && time == 0)
            {
                InvokeRepeating("Timer", 1f, 1f); 
                win.SetActive(true);
            }

        }
        
        if (Input.GetKeyDown("q"))
        {
            start.SetActive(false);
        }
        FindObjectOfType<bodyController>().SomeMethod(yRotate); //находим скрипт и отправляем туда переменную yRotate
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "enemy"){
            hp = hp - 10;
            hpText.text = "HP: " + hp;
        }
    }
    void oneAction(){
        panelH.SetActive(false);
        bad.SetActive(false);
        choice.SetActive(true);
        if(Input.GetKeyDown("2"))
        {
            pressed2 = true;
            panelH.SetActive(false);
            slime.SetActive(true);
            choice.SetActive(false);
            InvokeRepeating("Timer", 1f, 1f); 
        }
    }
    
}