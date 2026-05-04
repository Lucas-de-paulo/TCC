using UnityEngine;

public class Rock : MonoBehaviour, ILookTarget
{
    [SerializeField] private float timeToDestroy = 3f;
    
    private float lookTimer;
    private bool broken = false;

    public void OnLookEnter()
    {
        lookTimer = 0f;
    }

    public void OnLookStay()
    {
        if (!broken)
        {
            lookTimer += Time.deltaTime;

            if (lookTimer >= timeToDestroy)
            {
                broken = true;
                Destroy(gameObject);
            }
        }
    }

    public void OnLookExit()
    {
        lookTimer = 0f;
    }
}
