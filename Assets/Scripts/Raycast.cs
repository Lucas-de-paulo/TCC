using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float distance = 2f;

    private ILookTarget currentLookTarget;
    
    void Update()
    {
        if (Physics.Raycast(new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.forward, out RaycastHit hit, distance))
        {
            Debug.DrawRay(new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.forward * hit.distance, Color.green);

            if(hit.collider.gameObject.tag == "Interactable")
            {
                Debug.Log(hit.collider.name);

                ILookTarget lookTarget = hit.collider.gameObject.GetComponent<ILookTarget>();
                if (lookTarget != null)
                {
                    if (currentLookTarget != lookTarget)
                    {
                        if (currentLookTarget != null)
                        {
                            currentLookTarget.OnLookExit();
                        }

                        currentLookTarget = lookTarget;
                        currentLookTarget.OnLookEnter();
                    }
                    else
                    {
                        currentLookTarget.OnLookStay();
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(new Vector3 (transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.forward * distance, Color.red);
        }
    }
}
