using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    enum Ability
    {
        FireBall,
        Rage,
        Heal
    }

    [SerializeField] private Ability currentAbility = Ability.FireBall;

    public void UseAbility()
    {
        switch (currentAbility)
        {
            case Ability.FireBall:
                Debug.Log("Casting FireBall!");
                break;
            case Ability.Rage:
                Debug.Log("I'm always angry");
                break;
            case Ability.Heal:
                Debug.Log("Here eat this!");
                break;
        }
    }
}
