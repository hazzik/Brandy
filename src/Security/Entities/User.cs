namespace Brandy.Security.Entities
{
    using Brandy.Core;

    public class User : IEntity
    {
        public virtual string Login { get; set; }

        public virtual string EMail { get; set; }

        public virtual Password Password { get; protected set; }

        public virtual bool IsAdmin { get; set; }

        public virtual int Id { get; set; }

        public virtual void SetPassword(string newPassword)
        {
            Password = new Password(newPassword);
        }
    }
}
