using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hot
{
    public partial class cleanin : Form
    {
        String selectedsup, selectedsuite, selectedjrsuite, selectedfam, selectedfamdel;

        public cleanin()
        {
            InitializeComponent();
        }

        private void cleanin_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;

            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            availroomscombo(con);
        }

        private void availroomscombo(SqlConnection con)
        {

            //-----------show avail rooms in combobox SUPERIOR------------
            try
            {
                con.Open();
                SqlCommand cmdavailsup = new SqlCommand();
                cmdavailsup.Connection = con;
                cmdavailsup.CommandText = "SELECT number FROM room_sup WHERE clean = '0' ";
                cmdavailsup.ExecuteNonQuery();


                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdavailsup;
                da.Fill(ds);
                cbsup.DisplayMember = "number";
                cbsup.ValueMember = "number";
                cbsup.DataSource = ds.Tables[0];

                con.Close();
            }
            catch (Exception u)
            {
                MessageBox.Show(u.ToString());
                //throw;
            }

            //-----------show avail rooms in combobox SUITE------------
            try
            {

                con.Open();

                SqlCommand cmdavailsuite = new SqlCommand();

                cmdavailsuite.Connection = con;
                cmdavailsuite.CommandText = "SELECT number FROM room_suite WHERE clean = '0' ";
                cmdavailsuite.ExecuteNonQuery();

                DataSet dssuite = new DataSet();
                SqlDataAdapter dasuite = new SqlDataAdapter();

                dasuite.SelectCommand = cmdavailsuite;
                dasuite.Fill(dssuite);

                cbsuite.DisplayMember = "number";
                cbsuite.ValueMember = "number";
                cbsuite.DataSource = dssuite.Tables[0];

                con.Close();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
                throw;
            }


            //-----------show avail rooms in combobox JR SUITE------------
            try
            {

                con.Open();

                SqlCommand cmdavailjrsuite = new SqlCommand();

                cmdavailjrsuite.Connection = con;
                cmdavailjrsuite.CommandText = "SELECT number FROM room_jr_suite WHERE clean = '0' ";
                cmdavailjrsuite.ExecuteNonQuery();

                DataSet dsjrsuite = new DataSet();
                SqlDataAdapter dajrsuite = new SqlDataAdapter();

                dajrsuite.SelectCommand = cmdavailjrsuite;
                dajrsuite.Fill(dsjrsuite);

                cbjrsuite.DisplayMember = "number";
                cbjrsuite.ValueMember = "number";
                cbjrsuite.DataSource = dsjrsuite.Tables[0];

                con.Close();
            }
            catch (Exception j)
            {
                MessageBox.Show(j.ToString());
                //throw;
            }


            //-----------show avail rooms in combobox FAMILY------------

            try
            {
                con.Open();

                SqlCommand cmdavailfam = new SqlCommand();

                cmdavailfam.Connection = con;
                cmdavailfam.CommandText = "SELECT number FROM room_family WHERE clean = '0' ";
                cmdavailfam.ExecuteNonQuery();

                DataSet dsfam = new DataSet();
                SqlDataAdapter dafam = new SqlDataAdapter();

                dafam.SelectCommand = cmdavailfam;
                dafam.Fill(dsfam);

                cbfam.DisplayMember = "number";
                cbfam.ValueMember = "number";
                cbfam.DataSource = dsfam.Tables[0];

                con.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
                //throw;
            }

            //-----------show avail rooms in combobox FAMILY DELUXE------------

            try
            {
                con.Open();

                SqlCommand cmdavailfamDEL = new SqlCommand();

                cmdavailfamDEL.Connection = con;
                cmdavailfamDEL.CommandText = "SELECT number FROM room_family_deluxe WHERE clean = '0' ";
                cmdavailfamDEL.ExecuteNonQuery();

                DataSet dsfamDEL = new DataSet();
                SqlDataAdapter dafamDEL = new SqlDataAdapter();

                dafamDEL.SelectCommand = cmdavailfamDEL;
                dafamDEL.Fill(dsfamDEL);

                cbfamdel.DisplayMember = "number";
                cbfamdel.ValueMember = "number";
                cbfamdel.DataSource = dsfamDEL.Tables[0];

                con.Close();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
                //throw;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbsup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedsup = this.cbsup.GetItemText(this.cbsup.SelectedItem);
        }

        private void cbsuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedsuite = this.cbsuite.GetItemText(this.cbsuite.SelectedItem);
        }

        private void cbjrsuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedjrsuite = this.cbjrsuite.GetItemText(this.cbjrsuite.SelectedItem);
        }

        private void cbfam_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedfam = this.cbfam.GetItemText(this.cbfam.SelectedItem);
        }

        private void cbfamdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedfamdel = this.cbfamdel.GetItemText(this.cbfamdel.SelectedItem);
        }

        private void btnclsup_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasup = new SqlCommand();
                cmdasup.Connection = con;
                cmdasup.CommandText = "UPDATE room_sup SET clean = '1' WHERE number = '" + selectedsup + "'  ";
                cmdasup.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception u)
            {
                MessageBox.Show(u.ToString());
                //throw;
            }

            cbsup.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclsuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasuite = new SqlCommand();
                cmdasuite.Connection = con;
                cmdasuite.CommandText = "UPDATE room_suite SET clean = '1' WHERE number = '" + selectedsuite + "'  ";
                cmdasuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception v)
            {
                MessageBox.Show(v.ToString());
              //  throw;
            }

            cbsuite.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btncljrsuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdajrsuite = new SqlCommand();
                cmdajrsuite.Connection = con;
                cmdajrsuite.CommandText = "UPDATE room_jr_suite SET clean = '1' WHERE number = '" + selectedjrsuite + "'  ";
                cmdajrsuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.ToString());
                throw;
            }

            cbjrsuite.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclfam_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafam = new SqlCommand();
                cmdafam.Connection = con;
                cmdafam.CommandText = "UPDATE room_family SET clean = '1' WHERE number = '" + selectedfam + "'  ";
                cmdafam.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
                //throw;
            }

            cbfam.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclfamdel_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafamdel = new SqlCommand();
                cmdafamdel.Connection = con;
                cmdafamdel.CommandText = "UPDATE room_family_deluxe SET clean = '1' WHERE number = '" + selectedfamdel + "'  ";
                cmdafamdel.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception vv)
            {
                MessageBox.Show(vv.ToString());
                //throw;
            }

            cbfamdel.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclasup_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasup = new SqlCommand();
                cmdasup.Connection = con;
                cmdasup.CommandText = "UPDATE room_sup SET clean = '1' WHERE clean = '0' AND avail = '1'  ";
                cmdasup.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
                //throw;
            }

            cbsup.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclasuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasuite = new SqlCommand();
                cmdasuite.Connection = con;
                cmdasuite.CommandText = "UPDATE room_suite SET clean = '1' WHERE clean = '0' AND avail = '1'  ";
                cmdasuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception asu)
            {
                MessageBox.Show(asu.ToString());
                //throw;
            }

            cbsuite.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclajrsuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdajrsuite = new SqlCommand();
                cmdajrsuite.Connection = con;
                cmdajrsuite.CommandText = "UPDATE room_jr_suite SET clean = '1' WHERE clean = '0' AND avail = '1' ";
                cmdajrsuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception aj)
            {
                MessageBox.Show(aj.ToString());
                //throw;
            }

            cbjrsuite.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclafam_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafam = new SqlCommand();
                cmdafam.Connection = con;
                cmdafam.CommandText = "UPDATE room_family SET clean = '1' WHERE clean = '0' AND avail = '1' ";
                cmdafam.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception af)
            {
                MessageBox.Show(af.ToString());
                //throw;
            }

            cbfam.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnclafamdel_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafamdel = new SqlCommand();
                cmdafamdel.Connection = con;
                cmdafamdel.CommandText = "UPDATE room_family_deluxe SET clean = '1' WHERE clean = '0' AND avail = '1' ";
                cmdafamdel.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ad)
            {
                MessageBox.Show(ad.ToString());
                //throw;
            }

            cbfamdel.Text = "";
            //check for avail rooms again
            availroomscombo(con);
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
