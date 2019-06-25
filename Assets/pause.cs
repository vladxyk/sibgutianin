using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{
    public float timer;
    public bool ispause;
    public bool guipause;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispause == false)
        {
            ispause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause == true)
        {
            ispause = false;
        }
        if (ispause == true)
        {
            timer = 0;
            guipause = true;

        }
        else if (ispause == false)
        {
            timer = 1f;
            guipause = false;

        }
    }
    public void OnGUI()
    {
        if (guipause == true)
        {
            
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "В Меню"))
            {
                ispause = false;
                timer = 0;
                Application.LoadLevel("menu"); 

            }
        }
    }
}