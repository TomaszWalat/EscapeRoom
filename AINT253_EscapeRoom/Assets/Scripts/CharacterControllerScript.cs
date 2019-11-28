using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{

    private CharacterController m_CharacterController;
    private Vector3 moveDirection;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveDirection *= movementSpeed;

        //m_CharacterController.
        m_CharacterController.Move(moveDirection * Time.deltaTime);
    }

    public void TurnToTarget(Vector3 mouseTarget)
    {
        Vector3 target = new Vector3(mouseTarget.x, 0.0f, mouseTarget.z);
        transform.LookAt(target);
    }
}
