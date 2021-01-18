using ClashBusiness;
using ClashBusiness.Storage;
using System.Windows.Forms;

namespace ClashStats
{
    public class StartClashStatApplication
    {
        public Form StartApplication()
        {
            var storageManagement = AutofacFactory.Instance.GetInstance<IStorageManagement>();
            storageManagement.InitializeStorage();

            return new MainForm();
        }
    }
}
