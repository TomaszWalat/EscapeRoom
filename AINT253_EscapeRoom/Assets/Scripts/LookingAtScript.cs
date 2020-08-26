using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookingAtScript : MonoBehaviour
{
    private RaycastHitScript m_RaycastHitScript;
    private Camera m_Camera;
    private RaycastHit hitData;
    private GameObject objectObserved;

    public GameObject interactablePointerImageObject;
    public int interactableLayer;

    public Sprite defaultPointerImage;

    public Sprite inspectIcon;
    public Sprite interactIcon;

    public float interactionDistance;

    private IInteractionLogicScript m_InteractionLogicScript;


    // Start is called before the first frame update
    void Start()
    {
        m_RaycastHitScript = GetComponent<RaycastHitScript>();
        m_Camera = Camera.main;//GetComponentInChildren<Camera>();

        m_InteractionLogicScript = GetComponent<IInteractionLogicScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hitData = m_RaycastHitScript.FireRay(m_Camera.transform.position, m_Camera.transform.forward.normalized, interactionDistance);

        if (hitData.collider != null)
        {
            objectObserved = hitData.collider.gameObject;            
        }
        else
        {
            objectObserved = null;
        }

        if (objectObserved != null)
        {
            if (objectObserved.layer == interactableLayer)
            {
                //interactablePointerImageObject.GetComponent<Image>().sprite = objectObserved.GetComponent<InteractableObjectScript>().GetInteractableImage();
                //interactablePointerImageObject.GetComponent<Image>().color = Color.red;

                if (objectObserved.tag == "Ingredient" || objectObserved.tag == "Bowl" || objectObserved.tag == "ClayPot" || objectObserved.tag == "Torch" || objectObserved.tag == "TorchHolder" || objectObserved.tag == "Lighter")
                {
                    interactablePointerImageObject.GetComponent<Image>().sprite = interactIcon;
                    //interactablePointerImageObject.GetComponent<RectTransform>().

                }
                else if (objectObserved.tag == "Altar" || objectObserved.tag == "Info_puzzleClue" || objectObserved.tag == "Info_doorway_gorg")
                {
                    interactablePointerImageObject.GetComponent<Image>().sprite = inspectIcon;

                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log(objectObserved.ToString());
                    m_InteractionLogicScript.InteractionRequest(objectObserved);
                }
            }
            else
            {
                interactablePointerImageObject.GetComponent<Image>().sprite = defaultPointerImage;
                //interactablePointerImageObject.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            interactablePointerImageObject.GetComponent<Image>().sprite = defaultPointerImage;
            //interactablePointerImageObject.GetComponent<Image>().color = Color.white;
        }

        //Debug.DrawRay(transform.po)
    }
}
