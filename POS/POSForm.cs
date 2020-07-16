using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class POSForm : Form
    {

        Global obj = new Global();
        Users objEmp = new Users();

        public POSForm()
        {
            InitializeComponent();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            loadApiData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Calc objCalc = new Calc(this);
            objCalc.ShowDialog();
        }

        public void loadApiData()
        {


            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("/users/1", Method.GET);
            var queryResult = client.Execute<List<Users>>(request).Data;


            foreach (var dvar in queryResult)
            {

                objEmp.name = dvar.name.ToString();
                string[] row1 = new string[] { dvar.name.ToString(), "Male", "33", "01/01/2001" };
                dataGridView1.Rows.Add(row1);

            }


        }

    }
}
