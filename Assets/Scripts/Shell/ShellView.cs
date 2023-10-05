using System.Collections;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    public ShellController ShellController { get; private set; }
    public void SetShellController(ShellController shellController)
    {
        ShellController = shellController;
    }

    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ShellController?.Shoot();
        if(ShellController != null)
            StartCoroutine(ReturnToBulletPool());
    }

    private void OnDisable()
    {
        ShellController?.ResetVelocity();
    }

    private IEnumerator ReturnToBulletPool()
    {
        // Wait for the life of shell and then return the shell to the pool.
        yield return new WaitForSeconds(ShellController.ShellModel.Life);
        BulletObjectPool.Instance.ReturnObject(gameObject);
        StopCoroutine(ReturnToBulletPool());
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable;
        if ((damagable = collision.gameObject.GetComponent<IDamagable>()) != null)
        {
            // Apply appropriate damage to the damagable.
            damagable.TakeDamage(ShellController.ShellModel.Damage);
        }

        // Return bullet to pool.
        BulletObjectPool.Instance.ReturnObject(gameObject);
    }
}
