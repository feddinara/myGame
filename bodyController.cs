using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyController : MonoBehaviour
{
    Animator anim;
    float vertical; 

    float yRotate;
    public KeyCode shift;
    public KeyCode s;
    int hp = 5;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        anim.SetFloat("walk", vertical); 
        
        transform.rotation = Quaternion.Euler(0, yRotate, 0); //Изменение rotation- тела

        if (Input.GetKeyDown(shift)) {//если нажимаю на shift
            anim.SetBool("run",true);
        } 
        if (Input.GetKeyUp(shift)) //если отжимаю на shift
        {
            anim.SetBool("run",false);
        } 
        if (Input.GetKeyDown(s)) {//если нажимаю на shift
            anim.SetBool("back",true);
        }
        if (Input.GetKeyUp(s)) {//если нажимаю на shift
            anim.SetBool("back",false);
        }
    }
    
    public void SomeMethod(float val) 
    {
        yRotate = val;
    }
}
