public class PlayerController : UserController
{
    public override void CastSpell()
    {
        base.CastSpell();
    }

    public override void OrderSpellCastToAllUnitsOfType()
    {
        base.OrderSpellCastToAllUnitsOfType();
    }

    public override void SwapAdjacentUnits()
    {
        base.SwapAdjacentUnits();
    }

    public override void OrderMovementToAllUnits()
    {
        gameObject.GetComponent<UnitManager>().OrderMovement();
    }
}
