using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playAgain : MonoBehaviour
{
    [SerializeField]
    private GameObject button_playAgain;
// Start is called before the first frame update
    void Start()
    {
        Button PAbtn = this.GetComponent<Button>();
        PAbtn.onClick.AddListener(LoadScence); 
    }
    
    void LoadScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
