using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreateFood : MonoBehaviour
{
    public int totalScore;
    private int count;

    public Image food1, food2, food3;

    Image[] ingredients = new Image[3];

    void Start()
    {
        //counter for number of ingredients on list
        count = 0;

        //counter for total overall score
        totalScore = 0;

        //display images for 1st round
        food1.enabled = true;
        food2.enabled = true;
        food3.enabled = true;

        ingredients[0] = food1;
        ingredients[1] = food2;
        ingredients[2] = food3;

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