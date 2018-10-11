using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyJob.Model;
using MyJob.ServiceImpl;


namespace MyJob.Service.Test.UI
{
    public partial class FormSqlUpdate : Form
    {
        public FormSqlUpdate()
        {
            InitializeComponent();
        }



        private IJobProcessService jobProcessService = new SqlUpdateJobProcessServiceImpl();



        private void btnExec_Click(object sender, EventArgs e)
        {
            Job job = new Job()
            {
                JobCommand = this.txtSql.Text,
                JobSetting = this.txtConnString.Text
            };


            var result = this.jobProcessService.ExecuteJob(job);

            this.txtResult.Text = result.ToString();

        }
    }
}
