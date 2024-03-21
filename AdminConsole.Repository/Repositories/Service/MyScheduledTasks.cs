using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminConsole.Repository.Repositories.Service
{
    public class MyScheduledTasks: IServiceManagement
    {

      
        private readonly IServiceManagement _IServiceManagement;
        public MyScheduledTasks(IServiceManagement IServiceManagement)
        {
            _IServiceManagement = IServiceManagement;
        }
        public void SendData()
        {

            // Your logic to send data here
            // Example: _dataService.SendData(data);
            // Replace _dataService.SendData(data) with your actual logic to send data
        }
        #region MyRegion
        //private readonly IDataService<String> _dataService;

        //public MyScheduledTasks(IDataService<String> dataService)
        //{
        //    _dataService = dataService;
        //}

        //public void SendData()
        //    {
        //        // Your logic to send data here
        //        // Example: _dataService.SendData(data);
        //        // Replace _dataService.SendData(data) with your actual logic to send data
        //    }
        #endregion


    }
}
