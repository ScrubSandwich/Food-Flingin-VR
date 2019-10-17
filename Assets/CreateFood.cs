using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreateFood : MonoBehaviour
{
    private Rigidbody rb;
    private int blueCount, greenCount, yellowCount;

    private int totalScore;

    public Text totalText;

    public Image food1, food2, food3, food4, food5, food6, food7, food8, food9;

    Image[] blueIngredients = new Image[3];
    Image[] greenIngredients = new Image[3];
    Image[] yellowIngredients = new Image[3];

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //counter for number of ingredients on list
        blueCount = greenCount = yellowCount = 0;

        //counter for total overall score
        totalScore = 0;

        //TODO: Find place to display total score
        //SetTotalScoreText();

        //display images for 1st round
        food1.enabled = true;
        food2.enabled = true;
        food3.enabled = true;
        food4.enabled = true;
        food5.enabled = true;
        food6.enabled = true;
        food7.enabled = true;
        food8.enabled = true;
        food9.enabled = true;

        blueIngredients[0] = food1;
        blueIngredients[1] = food2;
        blueIngredients[2] = food3;

        greenIngredients[0] = food4;
        greenIngredients[1] = food5;
        greenIngredients[2] = food6;

        yellowIngredients[0] = food7;
        yellowIngredients[1] = food8;
        yellowIngredients[2] = food9;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        //TODO: create helper methods to reduce redundancy (still figuring out)
        if (gameObject.tag == "Blue Pot")
        {
            for (int i = 0; i < blueIngredients.Length; i++)
            {
                if (other.gameObject.tag == blueIngredients[i].GetComponent<Image>().sprite.name)
                {
                    blueCount++;
                    blueIngredients[i].enabled = false;

                    //TODO: destroy gameobject and reinstantiate back at table


                    //disappear temporarily:
                    other.gameObject.SetActive(false);
                }
            }

            if (blueCount == blueIngredients.Length)
            {
                //update total score:
                totalScore++;
                //SetTotalScoreText();

                blueCount = 0;

                //TODO: show checkmark for 2 seconds


                //then display new recipe:

                for (int i = 0; i < blueIngredients.Length; i++)
                {
                    //TODO: change pictures to new recipe:
                    //ingredients[i].sprite = Resources.Load("Mushroom.png") as Sprite;
                    blueIngredients[i].sprite = food1.sprite;

                    //show images again
                    blueIngredients[i].enabled = true;
                }
            }
        }

        if (gameObject.tag == "Green Pot")
        {
            for (int i = 0; i < greenIngredients.Length; i++)
            {
                if (other.gameObject.tag == greenIngredients[i].GetComponent<Image>().sprite.name)
                {
                    greenCount++;
                    greenIngredients[i].enabled = false;

                    //TODO: destroy gameobject and reinstantiate back at table


                    //disappear temporarily:
                    other.gameObject.SetActive(false);
                }
            }

            if (greenCount == greenIngredients.Length)
            {
                //update total score:
                totalScore++;
                //SetTotalScoreText();

                greenCount = 0;

                //TODO: show checkmark for 2 seconds


                //then display new recipe:

                for (int i = 0; i < greenIngredients.Length; i++)
                {
                    //TODO: change pictures to new recipe:
                    //ingredients[i].sprite = Resources.Load("Mushroom.png") as Sprite;
                    greenIngredients[i].sprite = food1.sprite;

                    //show images again
                    greenIngredients[i].enabled = true;
                }
            }
        }

        if (gameObject.tag == "Yellow Pot")
        {
            for (int i = 0; i < yellowIngredients.Length; i++)
            {
                if (other.gameObject.tag == yellowIngredients[i].GetComponent<Image>().sprite.name)
                {
                    yellowCount++;
                    yellowIngredients[i].enabled = false;

                    //TODO: destroy gameobject and reinstantiate back at table


                    //disappear temporarily:
                    other.gameObject.SetActive(false);
                }
            }

            if (yellowCount == yellowIngredients.Length)
            {
                //update total score:
                totalScore++;
                //SetTotalScoreText();

                yellowCount = 0;

                //TODO: show checkmark for 2 seconds


                //then display new recipe:

                for (int i = 0; i < yellowIngredients.Length; i++)
                {
                    //TODO: change pictures to new recipe:
                    //ingredients[i].sprite = Resources.Load("Mushroom.png") as Sprite;
                    yellowIngredients[i].sprite = food1.sprite;

                    //show images again
                    yellowIngredients[i].enabled = true;
                }
            }
        }

        //TODO: shorten this with helper functions later
        /*
        if (gameObject.tag == "Blue Pot")
        {
            checkPot(other.gameObject, blueIngredients, blueCount);
        }

        if (gameObject.tag == "Green Pot")
        {
            checkPot(other.gameObject, greenIngredients, greenCount);
        }

        if (gameObject.tag == "Yellow Pot")
        {
            checkPot(other.gameObject, yellowIngredients, yellowCount);
        }
        */

    }

    /*
    void checkPot(GameObject other, Image[] ingredients, int count)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (other.tag == ingredients[i].GetComponent<Image>().sprite.name)
            {
                count++;
                ingredients[i].enabled = false;

                //TODO: destroy gameobject and reinstantiate back at table


                //disappear temporarily:
                other.SetActive(false);
            }
        }

        if (count == ingredients.Length)
        {
            //update total score:
            totalScore++;
            //SetTotalScoreText();

            count = 0;

            //TODO: show checkmark for 2 seconds


            //then display new recipe:

            for (int i = 0; i < ingredients.Length; i++)
            {
                //TODO: change pictures to new recipe:
                //ingredients[i].sprite = Resources.Load("Mushroom.png") as Sprite;
                ingredients[i].sprite = food1.sprite;

                //show images again
                ingredients[i].enabled = true;
            }
        }
    }
    */

    void SetTotalScoreText()
    {
        totalText.text = "Score: " + totalScore.ToString();
    }
}