using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    //Store color list from parent to use as "Health" system
    List<Color> colorList;
    SpriteRenderer thisSpriteRenderer;

    private void Start()
    {
        //Get the color list from parent and cache own sprite renderer
        colorList = gameObject.transform.parent.GetComponent<SpawnBricks>().colorList;
        thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    //Change the color on collision until it runs out of health
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Check the index of the current color
        int index = colorList.IndexOf(thisSpriteRenderer.color);

        //If it's zero, destroy the object
        if (index != 0)
        {
            thisSpriteRenderer.color = colorList[index - 1];
        }
        //Otherwise decrease the index by one
        else
        {
            Destroy(gameObject);
        }
    }
}
