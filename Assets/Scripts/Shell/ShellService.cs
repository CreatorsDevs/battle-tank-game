using UnityEngine;

public class ShellService : SingletonGeneric<ShellService>
{
    [SerializeField] private ShellScriptableObjectList shellScriptableObjectList;

    private void Start()
    {
        AssetManager.Instance.SetShellService(this);
    }

    public GameObject SpawnShell(Transform spawn, LayerMask shellLayer, float damage = 0f)
    {
        int randomNumber = (int)Random.Range(0f, shellScriptableObjectList.shells.Length);
        ShellScriptableObject shellObject = shellScriptableObjectList.shells[randomNumber];
        Debug.Log("Created shell of type: " + shellObject.name);
        ShellModel model = new(shellObject, damage);
        ShellController shellController = new(model, shellObject.shellView, shellLayer, spawn);

        // Return the shell view gameobject.
        return shellController.ShellView.gameObject;
    }

    public GameObject SpawnShell()
    {
        int randomNumber = (int)Random.Range(0f, shellScriptableObjectList.shells.Length);
        ShellScriptableObject shellObject = shellScriptableObjectList.shells[randomNumber];
        Debug.Log("Created shell of type: " + shellObject.name);
        ShellModel model = new(shellObject, shellObject.damage);
        ShellController shellController = new(model, shellObject.shellView);

        // Return the shell view gameobject.
        return shellController.ShellView.gameObject;
    }

    public void SetShellParameters(ShellView shell, Transform trans, LayerMask layer, float damage = 0f)
    {
        SetShellTransform(shell, trans, new Vector3(0.0f, 1.5f, 0.0f));
        SetShellLayer(shell, layer);
        SetShellDamage(shell, damage);
    }

    public void SetShellDamage(ShellView shell,  float damage) 
    {
        if (damage != 0)
            shell.ShellController.ShellModel.Damage = damage;
    }

    public void SetShellLayer(ShellView shell, LayerMask shellLayer)
    {
        shell.gameObject.layer = shell.ShellController.GetLayerFromMask(shellLayer);
    }

    public void SetShellTransform(ShellView shell, Transform trans, Vector3 offset)
    {
        shell.transform.SetPositionAndRotation(trans.position + offset, trans.rotation);
        shell.ShellController.SetSpawn(trans);
    }
}
