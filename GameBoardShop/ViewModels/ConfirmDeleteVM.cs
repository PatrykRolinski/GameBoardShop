namespace GameBoardShop.ViewModels
{
    public class ConfirmDeleteVM
    {
        public Guid Id { get; set; }
        public string ControllerName { get; set; }
        public string ItemName { get; set; }

        public ConfirmDeleteVM(Guid id, string controllerName, string itemName)
        {
            this.Id = id;
            this.ControllerName=controllerName;
            this.ItemName=itemName;
        }
        
    }
}
