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
    public partial class FormSqlQuery : Form
    {
        public FormSqlQuery()
        {
            InitializeComponent();
        }



        private IJobProcessService jobProcessService = new SqlQueryJobProcessServiceImpl();




        private void btnExec_Click(object sender, EventArgs e)
        {

            Job job = new Job()
            {
                JobCommand = this.txtSql.Text,
                JobSetting = this.txtConnString.Text
            };


            var result = this.jobProcessService.ExecuteJob(job);

            this.txtResult.Text = result.ToString();


            this.txtResult.AppendText(result.ResultData.ToString());


            /*            
            DataTable dt = (DataTable)result.ResultData;
            foreach (DataRow r in dt.Rows)
            {
                StringBuilder buff = new StringBuilder();

                foreach (DataColumn c in dt.Columns)
                {
                    buff.Append(c.ColumnName);
                    buff.Append(" = ");
                    buff.Append(r[c.ColumnName]);
                    buff.Append(", ");
                }

                if (buff.Length > 2)
                {
                    buff.Length = buff.Length - 2;
                }
                string line = buff.ToString();

                this.txtResult.AppendText(line);
            }
            */



        }


    }
}
