using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool alreadyHit = false;
    public int multiplier = 1;
    
    public int getScore()
    {
        if (alreadyHit)
        {
            return 0;
        }

        alreadyHit = true;
        return 10 * multiplier;
    }
}
