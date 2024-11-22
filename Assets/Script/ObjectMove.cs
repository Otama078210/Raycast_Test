using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : Singleton<ObjectMove>
{ 
    public Vector3 pos;
    public Vector3 rot;

    float timeCount;
    int direction = 1;

    bool flagState = false;

    private void Update()
    {
        if (flagState)
        {
            Moving();
        }
    }

    void Moving()
    {
        transform.Translate(pos * Time.deltaTime * direction);
        timeCount += Time.deltaTime;

        if (timeCount > 1)
        {
            timeCount = 0;
            direction *= -1;
        }

        transform.Rotate(rot * Time.deltaTime);
    }
}