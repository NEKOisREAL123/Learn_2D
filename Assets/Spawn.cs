using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float maxtime = 3f;
    float timer;

    [SerializeField]
    public GameObject Cactus1;
    [SerializeField]
    public GameObject Cactus2;
    [SerializeField]
    public GameObject Cactus3;

    GameObject newcac;

    // Update is called once per frame
    void Update()
    {
        
        Vector2 random = new Vector2(Random.Range( 7f, 12f),-0.03f);//ramdom坐標
        timer += Time.deltaTime;//設定計時器

        if (timer > maxtime){
            int num = Random.Range(1, 4);
            switch (num)
            {
                case 1:
                    newcac = Instantiate(Cactus1, random, transform.rotation);//生成
                    break;
                case 2:
                    newcac = Instantiate(Cactus2, random, transform.rotation);//生成
                    break;
                case 3:
                    newcac = Instantiate(Cactus3, random, transform.rotation);//生成
                    break;
            }
            timer = 0;
            Destroy(newcac, 8f);//銷毀物件
        }

    }
}
