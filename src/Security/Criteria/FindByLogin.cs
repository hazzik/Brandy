namespace Brandy.Security.Criteria
{
    using Brandy.Core;

    public class FindByLogin : ICriterion
    {
        public string Login { get; set; }
    }
}
