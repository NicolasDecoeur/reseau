using UnityEngine;
using UnityEngine.AI;

public class NetworkCharacterControler : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_nameshagent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            int layermask = LayerMask.NameToLayer("Navmesh");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layermask))
            {
                //transform.position = hit.point;
                m_nameshagent.SetDestination(hit.point);
                Debug.Log("toucher le sol ");
            }
        }
    }
}