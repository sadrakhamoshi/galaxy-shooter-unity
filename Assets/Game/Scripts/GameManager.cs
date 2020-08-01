using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public bool isGameOver = true;

    public UiManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameOver = false;
                Instantiate(player, Vector3.zero, Quaternion.identity);
                uiManager.HideStartMenu();
            }
        }
    }
}
