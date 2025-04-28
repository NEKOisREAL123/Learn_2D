using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Java的import

public class Player : MonoBehaviour
{
    [SerializeField]
    public GameObject Spawning;
    
    [SerializeField]
    public Text scoreUI;
    
    [SerializeField]
    public AudioSource Jump_sound;
    [SerializeField] 
    public AudioSource Death_sound;
    [SerializeField] 
    public AudioSource Walk_sound;


    [SerializeField] public GameObject SetActive;

    Rigidbody2D rig;
    Animator anim;
    //增加剛體與動畫的功能
    public float Jump;
    bool isJumping = false;
    bool GameStart = true;
    
    private static int score = 0;

    void Start()//游戲開始呼叫
    {
        score = 0;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Spawning.SetActive(true);
        //設定剛體與動畫的功能
        anim.SetBool("isRunning",true);//Animator設定動畫
        anim.SetBool("isJump",false);
        GameStart = true;
        SetActive.SetActive(false);
        
    }
    void Update()//游戲每一幀刷新
    {
        if (GameStart)
        {
            score += 1;
        }

        if(isJumping == false && GameStart == true){//只能跳一次
            if(Input.GetKeyDown(KeyCode.Space)){//取得空格鍵按下的指令
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump), ForceMode2D.Impulse);
                //物體重力，y軸增加
                //ForceMode2D = 利用2D剛體(Rigidbody2D)移動物件 (施力)
                //詳細資料 http://tomyangtw.blogspot.com/2016/09/unity-2d.html
                anim.SetBool("isJump",true);//Animator設定動畫
                anim.SetBool("isRunning",false);
                Jump_sound.Play();
                isJumping = true;
            } 
        }
        
        scoreUI.text = "Score:" + score;
    }
    private void OnCollisionEnter2D(Collision2D collision) //使用碰撞器
    {
        if(collision.gameObject.tag == "Ground"){
            anim.SetBool("isRunning",true);//Animator設定動畫
            anim.SetBool("isJump",false);
            isJumping = false;
            Walk_sound.Play();

        }

        if(collision.gameObject.tag == "Enemy"){
            anim.SetBool("isDeath",true);//Animator設定動畫
            GameStart = false;//結束游戲
            Spawning.SetActive(false);//結束生成
            SetActive.SetActive(true);
            Death_sound.Play();
        }
    }
}
