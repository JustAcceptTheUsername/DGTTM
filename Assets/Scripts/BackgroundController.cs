using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Variable providing access to the Unity sprite renderer
    public SpriteRenderer rend;
    // Variable used to change a sprite later on
    public Sprite secondBackground;
    // Integer for changing the background in BackgroundChanger()
    int switchCase;




    // Called at the first run of the script
    public void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        rend.GetComponent<SpriteRenderer>();
        secondBackground = Resources.Load<Sprite>("Sprites/stars_Sprite");
        switchCase = 0;

    }

    public void BackgroundChanger()
    {
        // Switch case used to change backgrounds upon meeting certain conditions
        switch (switchCase)
        {
            
            // First condition for changing
            case 0:
                if (GameObject.FindGameObjectWithTag("Background").transform.position.y < -200)
                {
                    //Increasing value so the next condition may be met later on
                    switchCase++;
                    GameObject.FindGameObjectWithTag("Background").transform.position = new Vector3(0, 200, 0);

                }
                // Break prevents further execution of the condition
                break;
            // Second condition
            case 1:
                if (GameObject.FindGameObjectWithTag("SecondBackground").transform.position.y < -200)
                {
                    GameObject.FindGameObjectWithTag("SecondBackground").transform.position = new Vector3(0, 200, 0);
                    switchCase--;
                }
                break;
        }
    }

    // Called when the script is first loaded
    private void Awake()
    {
        // Preparing the variable for the background changer
        switchCase = 1;
    }

    // Method called every frame
    private void Update()
    {

        // Changing the background during runtime
        BackgroundChanger();
    }



}
