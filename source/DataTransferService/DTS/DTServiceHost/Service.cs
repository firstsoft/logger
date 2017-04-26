using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Web;

namespace DTServiceHost
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/");
            this.astroHost = new WebServiceHost(typeof(DTService.Service), baseAddress);
            this.astroHost.Open();
        }

        protected override void OnStop()
        {
            this.astroHost.Close();
        }

        private WebServiceHost astroHost;
    }
}
