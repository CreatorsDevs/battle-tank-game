using UnityEngine;

public class ShellController
{
    public ShellModel ShellModel { get; }
    public ShellView ShellView { get; }
    private Transform spawn;
    private readonly Rigidbody shellRb;

    public void SetSpawn(Transform spawn) => this.spawn = spawn;

    public ShellController(ShellModel shellModel, ShellView shellView, LayerMask shellLayer, Transform spawnTransform)
    {
        spawn = spawnTransform;
        ShellModel = shellModel;
        ShellView = GameObject.Instantiate<ShellView>(shellView, spawn.position + new Vector3(0f, 1.5f, 0f), spawn.rotation);
        ShellView.gameObject.layer = GetLayerFromMask(shellLayer);
        ShellView.SetShellController(this);
        shellRb = ShellView.GetRigidbody();
    }

    public ShellController(ShellModel shellModel, ShellView shellView)
    {
        ShellModel = shellModel;
        ShellView = GameObject.Instantiate<ShellView>(shellView, Vector3.zero, Quaternion.identity);
        ShellView.SetShellController(this);
        shellRb = ShellView.GetRigidbody();
    }

    public void Shoot()
    {
        if (!spawn || !shellRb) return;
        shellRb.velocity = spawn.forward * ShellModel.Speed;
    }

    public void ResetVelocity()
    {
        shellRb.velocity = Vector3.zero;
    }

    public int GetLayerFromMask(LayerMask mask)
    {
        int layerNumber = 0;
        int layer = mask.value;
        while (layer > 0)
        {
            layer >>= 1;
            layerNumber++;
        }

        return layerNumber - 1;
    }

}
