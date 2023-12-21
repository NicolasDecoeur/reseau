using Mirror;
using TMPro;
using UnityEngine;

public class Pig : NetworkBehaviour, IDamageable
{
    [SerializeField]
    private TextMeshPro m_text;
    [SerializeField]
    [SyncVar(hook = nameof(RecivedDmgSync))]
    private int sync_pigHp = 10;


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject);
        LayerMask mask = LayerMask.NameToLayer("WeaponCharacter");
        if (collision.gameObject.layer == mask)
        {
            InflictDamageCommand(collision.relativeVelocity);
        }
    }

    [Command(requiresAuthority = false)]
    public void InflictDamageCommand(Vector3 collision)
    {
        //Normalement, on effectue ici un sanity check
        OnDamageReceivedRPC();
        sync_pigHp -= 1;
    }

    [ClientRpc]
    public void OnDamageReceivedRPC()
    {
        m_text.gameObject.SetActive(true);
    }

    public void RecivedDmgSync(int oldValue, int newValue)
    {
        sync_pigHp = newValue;
        Debug.Log("your pig had " + oldValue + "HP" + " now you have " + newValue + " HP");
    }
}