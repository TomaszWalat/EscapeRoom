using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDistance(Vector3 originPoint, Vector3 targetPoint)
    {
        float distance;

        distance = GetDirection(originPoint, targetPoint, false).magnitude;

        return distance;
    }

    public Vector3 GetDirection(Vector3 originPoint, Vector3 targetPoint, bool isNormalized)
    {
        Vector3 direction;

        direction = (targetPoint - originPoint);

        if (isNormalized)
        {
            direction.Normalize();
        }

        return direction;
    }

    public RaycastHit FireRayAt(Vector3 originPoint, Vector3 targetPoint)
    {
        Vector3 direction;
        RaycastHit hitData;

        direction = GetDirection(originPoint, targetPoint, true);

        hitData = FireRay(originPoint, direction);

        return hitData;
    }

    public RaycastHit FireRay(Vector3 originPoint, Vector3 direction)
    {
        RaycastHit hitData;

        Physics.Raycast(originPoint, direction, out hitData);

        return hitData;
    }

    public RaycastHit FireRay(Vector3 originPoint, Vector3 direction, float distance)
    {
        RaycastHit hitData;

        Physics.Raycast(originPoint, direction, out hitData, distance);

        return hitData;
    }

    public RaycastHit FireRay(Vector3 originPoint, Vector3 direction, float distance, int searchLayer)
    {
        RaycastHit hitData;

        int layerMask = 1 << searchLayer;
        Physics.Raycast(originPoint, direction, out hitData, distance, layerMask);

        return hitData;
    }

    public RaycastHit FireRay(Vector3 originPoint, Vector3 direction, int ignoreLayer, float distance)
    {
        RaycastHit hitData;

        int layerMask = 1 << ignoreLayer;
        layerMask = ~layerMask;
        Physics.Raycast(originPoint, direction, out hitData, distance, layerMask);

        return hitData;
    }

    public RaycastHit[] FireSphere(Vector3 originPoint, float radius)
    {
        RaycastHit[] hitDataList;

        Vector3 noDirection = new Vector3(0, 0, 0);

        hitDataList = Physics.SphereCastAll(originPoint, radius, Vector3.zero);

        return hitDataList;
    }

    public RaycastHit[] FireSphere(Vector3 originPoint, float radius, Vector3 direction)
    {
        RaycastHit[] hitDataList;

        hitDataList = Physics.SphereCastAll(originPoint, radius, direction);

        return hitDataList;
    }

    public RaycastHit[] FireSphere(Vector3 originPoint, float radius, Vector3 direction, float distance)
    {
        RaycastHit[] hitDataList;

        hitDataList = Physics.SphereCastAll(originPoint, radius, direction, distance);

        return hitDataList;
    }

    public RaycastHit[] FireSphere(Vector3 originPoint, float radius, Vector3 direction, float distance, int searchLayer, bool invertLayerSearch)
    {
        RaycastHit[] hitDataList;

        int layerMask = 1 << searchLayer;
        if (invertLayerSearch)
        {
            layerMask = ~layerMask;            
        }
        hitDataList = Physics.SphereCastAll(originPoint, radius, direction, distance, layerMask);

        return hitDataList;
    }

    public Collider[] PulseSphere(Vector3 originPoint, float radius, int searchLayer, bool invertLayerSearch)
    {
        Collider[] collidersHit;

        int layerMask = 1 << searchLayer;
        if (invertLayerSearch)
        {
            layerMask = ~layerMask;
        }
        collidersHit = Physics.OverlapSphere(originPoint, radius, layerMask);

        return collidersHit;
    }

    //public RaycastHit[] FireSphere(Vector3 originPoint, float radius, Vector3 direction, int ignoreLayer, float distance)
    //{
    //    RaycastHit[] hitDataList;

    //    int layerMask = 1 << ignoreLayer;
    //    layerMask = ~layerMask;
    //    hitDataList = Physics.SphereCastAll(originPoint, radius, direction);

    //    return hitDataList;
    //}
}
