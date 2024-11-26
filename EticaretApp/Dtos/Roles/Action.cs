namespace EticaretApp.Dtos.Roles
{
    public class Action
    {
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }
    }

    public class ActionRoot
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; }
    }
}
