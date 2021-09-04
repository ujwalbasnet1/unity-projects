using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public int level = 1;

    public int GetNumberOfArrowShots()
    {
        return level;
    }

    
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _GetSpriteOf(level);
    }

    private Sprite _GetSpriteOf(int level)
    {
        switch (level)
        {
            case 2:
                return level2;
            case 3:
                return level3;
            default:
                return level1;
        }
    }

}
