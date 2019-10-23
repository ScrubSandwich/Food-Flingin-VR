using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreateFood : MonoBehaviour
{
    private Rigidbody rb;
    //private int blueCount, greenCount, yellowCount;

    public int totalScore;
    private int count;

    //public Text totalText;

    public Image food1, food2, food3;
        //food4, food5, food6, food7, food8, food9;

    //Image[] blueIngredients = new Image[3];
    //Image[] greenIngredients = new Image[3];
    //Image[] yellowIngredients = new Image[3];

    Image[] ingredients = new Image[3];

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //counter for number of ingredients on list
        //blueCount = greenCount = yellowCount = 0;
        count = 0;

        //counter for total overall score
        totalScore = 0;

        //display images for 1st round
        food1.enabled = true;
        food2.enabled = true;
        food3.enabled = true;

        /*
        food4.enabled = false;
        food5.enabled = false;
        food6.enabled = false;
        food7.enabled = false;
        food8.enabled = false;
        food9.enabled = false;
        */

        ingredients[0] = food1;
        ingredients[1] = food2;
        ingredients[2] = food3;

        /*
        ingredients[3] = food4;
        ingredients[4] = food5;
        ingredients[5] = food6;
        ingredients[6] = food7;
        ingredients[7] = food8;
        ingredients[8] = food9;
        */

        /*
        blueIngredients[0] = food1;
        blueIngredients[1] = food2;
        blueIngredients[2] = food3;

        greenIngredients[0] = food4;
        greenIngredients[1] = food5;
        greenIngredients[2] = food6;

        yellowIngredients[0] = food7;
        yellowIngredients[1] = food8;
        yellowIngredients[2] = food9;
        */
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (other.gameObject.tag == ingredients[i].GetComponent<Image>().sprite.name
                && ingredients[i].GetComponent<Image>().isActiveAndEnabled)
            {
                //increase count and make image disappear from clipboard
                count++;
                ingredients[i].enabled = false;
            }
        }

        //"destroy" gameobject
        other.gameObject.SetActive(false);

        // TODO: reinstantiate object back at table for extra use


        //if all ingredients thrown into pot correctly then update totalScore
        if (count == ingredients.Length)
        {
            totalScore++;
            count = 0;

            // OPTIONAL EXTRA FEATURE: show checkmark confirmation for 2 seconds


            // OPTIONAL EXTRA FEATURE: display new recipe 
            

        }

    }

}