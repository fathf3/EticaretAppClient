namespace EticaretApp.Areas.Admin.Models
{
    public class Action
    {
        public string actionType { get; set; }
        public string httpType { get; set; }
        public string definition { get; set; }
        public string code { get; set; }
    }

    public class ActionRoot
    {
        public string name { get; set; }
        public List<Action> actions { get; set; }
    }
}
