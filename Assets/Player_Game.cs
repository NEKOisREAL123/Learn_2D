using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Game : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //使用碰撞器
    {
        if(collision.gameObject.tag == "Enemy"){
            anim.SetBool("isDeath",true);//Animator設定動畫
            Debug.Log("Death");
        }
    }
}
