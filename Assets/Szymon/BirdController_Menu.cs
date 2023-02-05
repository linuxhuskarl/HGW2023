using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController_Menu : AnimalController
{
    float posX = -12;
    float posY;

    void Update()
    {
        Vector2 target;

        if(posX > 13 && posY < 10)
        {
            posY = posY + 1;

        }
        else if (posX > 13 && posY >= 10)
        {
            posX = -13;
        }
        else if (posX <= -13 && posY >= 10)
        {
            posY = posY - 1;
        }
        else
        {
            posY = 3;
            posX = posX + 0.03f;
        }
        
        target = new Vector2(posX, posY);

        transform.position = Vector2.MoveTowards(transform.position, target, 1);
        
    }
}


