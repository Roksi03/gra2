using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplinghook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer Rope;

   

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;


    // Start is called before the first frame update
    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        Rope.enabled = false;



        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hit = Physics2D.Raycast(
            origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
            direction: Vector2.zero,
            distance: Mathf.Infinity,
            layerMask: grappleLayer
          );

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = grappleLength;
                Rope.SetPosition(0, grapplePoint);
                Rope.SetPosition(1, transform.position);
                Rope.enabled = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            joint.enabled = false;
            Rope.enabled = false;
        }
        if (Rope.enabled == true)
        {
            Rope.SetPosition(1, transform.position);
        }

    }
}
    
 


