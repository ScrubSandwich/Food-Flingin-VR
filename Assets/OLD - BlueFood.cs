using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlueFood : MonoBehaviour
{
    private Rigidbody rb;
    private int blueCount;

    public int totalScore;

    public Image food1, food2, food3;

    Image[] blueIngredients = new Image[3];

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //counter for number of ingredients on list
        blueCount = 0;

        //counter for total overall score
        totalScore = 0;

        //display images for 1st round
        food1.enabled = true;
        food2.enabled = true;
        food3.enabled = true;

        blueIngredients[0] = food1;
        blueIngredients[1] = food2;
        blueIngredients[2] = food3;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision other)
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
}