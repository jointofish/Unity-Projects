using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
  
    
   public float h = 0f, v = 0f, r=0f;

    public  Animator ani;
 
    [SerializeField] string posX = "Horizontal";
    [SerializeField] string posY = "Vertical";
    [SerializeField] string Mouse_X = "Mouse X";
    [SerializeField] string fireBtn = "Fire1";
    [SerializeField] string reloadBtn = "Reload";
    

    public bool fire {  get; private set; }
    public bool reload { get; private set; }

    public bool sprint { get; private set; }

    void Start()
    {       
        
    }



    void Update()
    {
        if (Gamemanager.instance != null && Gamemanager.instance.isgameover)
        {
            h = 0f;
            v = 0f;
            reload = false;
            fire = false;
            sprint = false;


            return;
        }
          
        h = Input.GetAxis(posX);
        v = Input.GetAxis(posY);
        r = Input.GetAxis(Mouse_X);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
           sprint = true;
           
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = false;
           
        }
        reload = Input.GetButtonDown(reloadBtn);
        fire = Input.GetButtonDown(fireBtn);
    }
    
 

}

