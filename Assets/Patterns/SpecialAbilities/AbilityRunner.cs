using UnityEngine;

public class AbilityRunner : MonoBehaviour
{

    [SerializeField] private BaseAbilitySO currentAbility =
    new DelayDecorator(new RageAbility());

    public void UseAbility()
    {

        currentAbility.Use(gameObject);
    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public abstract class BaseAbilitySO: ScriptableObject, IAbility
{
    public abstract void Use(GameObject currentGameObject);
}

public class DelayDecorator : BaseAbilitySO
{
    [SerializeField] BaseAbilitySO wrapperAbility;

    public DelayDecorator(BaseAbilitySO ability)
    {
        this.wrapperAbility = ability;
    }

    public override void Use(GameObject currentGameObject)
    {
        // TODO some delaying functionality
        wrapperAbility.Use(currentGameObject);

    }
}

public class RageAbility : BaseAbilitySO
{
    public override void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class HealAbility : BaseAbilitySO
{
    public override void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}

public class FireBallAbility : BaseAbilitySO
{
    public override void Use(GameObject currentGameObject)
    {
        Debug.Log("Casting FireBall!");
    }
}
