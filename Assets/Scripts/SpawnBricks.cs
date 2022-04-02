using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    //Reference to the prefab to instantiate
    [SerializeField] private Brick brickPrefab;

    //Colors to assign
    [SerializeField] public List<Color> colorList;

    // Start is called before the first frame update
    void Start()
    {
        Spawner(); //Call spawner on initialization
    }

    private void Spawner()
    {
        //After a lot of experimenting with placements, ideal values are as follows
        //y -> start: 0, end: 4, step: 1
        //x -> start: -8.75, end: 8.75, step: 2.5
        for(float i = 0f; i <= 5f; ++i)
        {
            for(float j = -8.75f; j <= 8.75f; j += 2.5f)
            {
                //Instantiate a new brick at the position
                Vector3 position = new Vector3(j, i, 0);
                Brick brickInstance = Instantiate(brickPrefab, position, Quaternion.identity);

                //Set its color at random from the color list and attach it as a child of the spawner
                brickInstance.GetComponent<SpriteRenderer>().color = colorList[Random.Range(0, colorList.Count)];
                brickInstance.transform.parent = gameObject.transform;
            }
        }
    }
}
