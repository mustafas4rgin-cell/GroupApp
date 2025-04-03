using GroupApp.Core.Validators;

namespace GroupApp.Core.Providers;
public class ValidatorAssemblyProvider
{
     public static Type[] GetValidatorAssemblies() 
    {
        return new[]
        {
            typeof(ProjectCommentValidator),
            typeof(RoleValidator),
            typeof(TaskValidator),
            typeof(ProjectRelValidator),
            typeof(UserValidator),
            typeof(ProjectValidator),
            typeof(ProjectRoleValidator),
            typeof(TaskCommentValidator),
        };
    }
}