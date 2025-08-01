using UnityEngine;

public class DestroyAfterPlay : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void DestroyParentGameObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
