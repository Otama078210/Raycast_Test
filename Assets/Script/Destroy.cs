using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDestroy : Singleton<MaskDestroy>
{
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
