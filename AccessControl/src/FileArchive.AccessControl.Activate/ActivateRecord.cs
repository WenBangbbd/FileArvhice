namespace FileArchive.AccessControl.Activate
{
    public class ActivateRecord
    {
        public int Id { get; set; }
        public bool Activated { get; set; }
        public string ActivateCode { get; internal set; }
        public string UserName { get; internal set; }
    }
}
