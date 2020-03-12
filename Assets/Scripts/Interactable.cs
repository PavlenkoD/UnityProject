using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionsTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // Виртуальный метод взаимодействия
        Debug.Log( "Interacting with" + transform.name );
    }

    private void Update()
    {
        if( isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance( player.position , interactionsTransform.position );
            if(distance <= radius)
            {
                Interact( );
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform )
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if( interactionsTransform == null )
            interactionsTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere( interactionsTransform.position , radius );
    }
}
