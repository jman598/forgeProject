using UnityEngine;

public class pickup : MonoBehaviour
{

    bool isHolding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3;
    float distance;

    tempParent tp;
    Rigidbody rb;

    Vector3 objectPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tp = tempParent.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            Hold();
        }
    }

    private void OnMouseDown()
    {
        if (tp != null)
        {
            distance = Vector3.Distance(this.transform.position, tp.transform.position);

            if (distance <= maxDistance)
            {
                isHolding = true;
                rb.useGravity = false;
                rb.detectCollisions = true;

                this.transform.SetParent(tp.transform);
            }
        }
        else
        {
            Debug.Log("Temp parent item not found");
        }
    }

    private void OnMouseUp()
    {
        Drop();
    }

    private void OnMouseExit()
    {
        Drop();
    }

    private void Hold()
    {
        distance = Vector3.Distance(this.transform.position, tp.transform.position);

        if (distance >= maxDistance)
        {
            Drop();
        }

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Input.GetMouseButtonDown(1))
        {
            rb.AddForce(tp.transform.forward * throwForce);
            Drop();
        }
    }

    private void Drop()
    {
        if (isHolding)
        {
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
}
