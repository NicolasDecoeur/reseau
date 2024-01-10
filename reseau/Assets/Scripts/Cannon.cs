using Mirror;
using UnityEngine;

public class Cannon : NetworkBehaviour
{
    [SerializeField]
    private GameObject m_cannonBall;
    [SerializeField]
    private float m_cooldown;
    [SerializeField]
    private float m_currentCooldown;


    private void Update()
    {
        if (!isServer) return;
       
        m_currentCooldown -= Time.deltaTime;
        if (m_currentCooldown < 0 )
        {
            m_currentCooldown += m_cooldown;
            fire();
        }
    }

    void fire()
    {
        Instantiate(m_cannonBall);
    }
}
