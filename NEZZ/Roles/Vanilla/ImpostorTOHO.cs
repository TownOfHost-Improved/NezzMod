
namespace NEZZ.Roles.Vanilla;

internal class ImpostorNEZZ : RoleBase
{
    //===========================SETUP================================\\
    public override CustomRoles Role => CustomRoles.ImpostorNEZZ;
    private const int Id = 300;
    public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.ImpostorVanilla;
    //==================================================================\\

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.ImpostorNEZZ);
    }
}
