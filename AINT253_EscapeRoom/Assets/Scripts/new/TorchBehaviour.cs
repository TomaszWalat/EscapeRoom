using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class TorchBehaviour : MonoBehaviour, InteractableObject
{
    [SerializeField]
    private bool isTorchLit;
    [SerializeField]
    private GameObject flameParticles;
    [SerializeField]
    private FireLight flameLight;
    [SerializeField]
    private GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        //isTorchLit = false;
        //flame.SetActive(false);
        //flameLight.Extinguish();
        //flameParticles.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //flame.SetActive(isTorchLit);
    }

    public void lightTorch()
    {
        isTorchLit = true;
        flame.SetActive(true);
        //flameLight.Extinguish();
        //flameParticles.SetActive(true);
    }

    public void extinguishTorch()
    {
        isTorchLit = false;
        flame.SetActive(false);
    }

    public void interactionRequest(GameObject interactionRequester)
    { 
        
    }
}
