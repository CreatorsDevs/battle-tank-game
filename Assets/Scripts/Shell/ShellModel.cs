public class ShellModel
{
    public float Speed { get; private set; }
    public float Damage { get; set; }
    public float Life { get; private set; }
    public ShellTypes Type { get; private set; }

    public ShellModel(ShellScriptableObject shellScriptableObject, float damage = 0f)
    {
        Speed = shellScriptableObject.speed;
        Damage = damage == 0f ? shellScriptableObject.damage : damage;
        Life = shellScriptableObject.life;
        Type = shellScriptableObject.type;
    }

}
