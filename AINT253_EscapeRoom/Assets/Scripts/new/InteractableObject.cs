using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableObject
{
    void interactionRequest(GameObject interactionRequester);
}
