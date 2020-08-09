using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelfDestructScript
{
    float secondsDelay { get; set; }

    void SelfDestruct();
}
