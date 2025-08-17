using UnityEngine;

public class AbilityRunner : MonoBehaviour
{

    [SerializeField] private IAbility currentAbility =
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

public class DelayDecorator : IAbility
{
    private IAbility wrapperAbility;

    public DelayDecorator(IAbility wrappedAbility)
    {
        this.wrapperAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        // TODO some delaying functionality
        wrapperAbility.Use(currentGameObject);

    }
}

public class RageAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class HealAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}

public class FireBallAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Casting FireBall!");
    }
}
