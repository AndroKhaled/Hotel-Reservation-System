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
    public partial class checkin : Form
    {
        String name, number, id;
        String cmdguestquery;
        DateTime checkinz;

        String selectedsup, selectedsuite, selectedjrsuite, selectedfam, selectedfamdel;

        String cin,cout,dayzz,gid;


        public checkin()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            name = textname.Text.ToString();
            number = textnumber.Text.ToString();
            id = textid.Text.ToString();
            checkinz = dtcheckin.Value.Date;


            //---------get data from text and search ------------
            if (name != "") {
                if (number != "")
                {
                    //check with name and number
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "' AND name='" + name + "') ) AND ( checkin = '" + checkinz + "' ) )";
                    
                }
                else {
                    // check with name only
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( name='" + name + "') ) AND ( checkin = '" + checkinz + "' ) )";
                }
            }
            else if(number!=""){
                if (name != "")
                {
                    //check with name and number
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "' AND name='" + name + "') ) AND ( checkin = '" + checkinz + "' ) )";
                }
                else
                {
                    // check with number only
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "') ) AND ( checkin = '" + checkinz + "' ) )";
                }
            }
            else {
                MessageBox.Show("Plz Enter Name or Number :)");
            }

            //-------search with name or number : guest bill --------

            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand cmdguest = new SqlCommand();
                cmdguest.Connection = con;
                cmdguest.CommandText = cmdguestquery;
                cmdguest.ExecuteNonQuery();


                //---------get values from billz to add it to rooms----------------------------------------------------------
                SqlDataReader readallguest = cmdguest.ExecuteReader();
                while (readallguest.Read())
                {
                    cin = readallguest["checkin"].ToString();
                    cout = readallguest["checkout"].ToString();
                    dayzz = readallguest["nday"].ToString();
                    gid = readallguest["bill_guest_id"].ToString();
                }
                con.Close();
           

            
            //---data in table-----
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmdguest.ExecuteReader());
            dgbill.DataSource = dt;
            con.Close();
            
            }
            catch (Exception n)
            {
                MessageBox.Show(n.ToString());
                //throw;
            }

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
                cmdavailsup.CommandText = "SELECT number FROM room_sup WHERE avail = 'True' ";
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
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
                //throw;
            }

            //-----------show avail rooms in combobox SUITE------------

            try
            {
                con.Open();

                SqlCommand cmdavailsuite = new SqlCommand();

                cmdavailsuite.Connection = con;
                cmdavailsuite.CommandText = "SELECT number FROM room_suite WHERE avail = 'True' ";
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
            catch (Exception ss)
            {
                MessageBox.Show(ss.ToString());
                //throw;
            }

            //-----------show avail rooms in combobox JR SUITE------------

            try
            {
                con.Open();

                SqlCommand cmdavailjrsuite = new SqlCommand();

                cmdavailjrsuite.Connection = con;
                cmdavailjrsuite.CommandText = "SELECT number FROM room_jr_suite WHERE avail = 'True' ";
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
                cmdavailfam.CommandText = "SELECT number FROM room_family WHERE avail = 'True' ";
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
                cmdavailfamDEL.CommandText = "SELECT number FROM room_family_deluxe WHERE avail = 'True' ";
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
            catch (Exception fd)
            {
                MessageBox.Show(fd.ToString());
               // throw;
            }
        }

        private void checkin_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }

        private void cbsup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------when item clicked in combobox superior---

            selectedsup = this.cbsup.GetItemText(this.cbsup.SelectedItem);
          }

        private void cbsuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------when item clicked in combobox suite---

            selectedsuite = this.cbsuite.GetItemText(this.cbsuite.SelectedItem);
        }

        private void cbjrsuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------when item clicked in combobox jr suite---

            selectedjrsuite = this.cbjrsuite.GetItemText(this.cbjrsuite.SelectedItem);
        }

        private void cbfam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------when item clicked in combobox family ---

            selectedfam = this.cbfam.GetItemText(this.cbfam.SelectedItem);
        }

        private void cbfamdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-------------when item clicked in combobox family deluxe ---

            selectedfamdel = this.cbfamdel.GetItemText(this.cbfamdel.SelectedItem);
        }

        private void btnaddsup_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            
            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasup = new SqlCommand();
                cmdasup.Connection = con;
                cmdasup.CommandText = "UPDATE room_sup SET avail = 'False' , clean = 'False' , cin = '" + cin + "' , cout = '" + cout + "' , dayss ='" + dayzz + "' , guest_id ='" + gid + "' WHERE number = '" + selectedsup + "'  ";
                cmdasup.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception v)
            {
                MessageBox.Show(v.ToString());
               // throw;
            }


            //---show avail = false from table -----------

            try
            {
                con.Open();
                SqlCommand cmdasups = new SqlCommand();
                cmdasups.Connection = con;
                cmdasups.CommandText = "SELECT number FROM room_sup WHERE avail='FALSE' AND guest_id='" + gid + "' ";
                cmdasups.ExecuteNonQuery();
                con.Close();

                //---data in table-----

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdasups.ExecuteReader());
                dgsup.DataSource = dt;
                con.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
                throw;
            }

            //check for avail rooms again
            availroomscombo(con);

        }

        private void btnaddsuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdasuite = new SqlCommand();
                cmdasuite.Connection = con;
                cmdasuite.CommandText = "UPDATE room_suite SET avail = 'False' , clean = 'False' , cin = '" + cin + "' , cout = '" + cout + "' , dayss ='" + dayzz + "' , guest_id ='" + gid + "' WHERE number = '" + selectedsuite + "'  ";
                cmdasuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception sc)
            {
             MessageBox.Show(sc.ToString());   
               // throw;
            }


            //---show avail = false from table -----------

            try
            {
                con.Open();
                SqlCommand cmdasuites = new SqlCommand();
                cmdasuites.Connection = con;
                cmdasuites.CommandText = "SELECT number FROM room_suite WHERE avail='FALSE' AND guest_id='" + gid + "' ";
                cmdasuites.ExecuteNonQuery();
                con.Close();


                //---data in table-----

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdasuites.ExecuteReader());
                dgsuite.DataSource = dt;
                con.Close();
            }
            catch (Exception ds)
            {
                MessageBox.Show(ds.ToString());
              //  throw;
            }

            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnaddjrsuite_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdajrsuite = new SqlCommand();
                cmdajrsuite.Connection = con;
                cmdajrsuite.CommandText = "UPDATE room_jr_suite SET avail = 'False' , clean = 'False' , cin = '" + cin + "' , cout = '" + cout + "' , dayss ='" + dayzz + "' , guest_id ='" + gid + "' WHERE number = '" + selectedjrsuite + "'  ";
                cmdajrsuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
               // throw;
            }


            //---show avail = false from table -----------

            try
            {
                con.Open();
                SqlCommand cmdajrsuites = new SqlCommand();
                cmdajrsuites.Connection = con;
                cmdajrsuites.CommandText = "SELECT number FROM room_jr_suite WHERE avail='FALSE' AND guest_id='" + gid + "' ";
                cmdajrsuites.ExecuteNonQuery();
                con.Close();


                //---data in table-----

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdajrsuites.ExecuteReader());
                dgjrsuite.DataSource = dt;
                con.Close();
            }
            catch (Exception fss)
            {
                MessageBox.Show(fss.ToString());
              //  throw;
            }

            //check for avail rooms again
            availroomscombo(con);

        }

        private void btnaddfam_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafam = new SqlCommand();
                cmdafam.Connection = con;
                cmdafam.CommandText = "UPDATE room_family SET avail = 'False' , clean = 'False' , cin = '" + cin + "' , cout = '" + cout + "' , dayss ='" + dayzz + "' , guest_id ='" + gid + "' WHERE number = '" + selectedfam + "'  ";
                cmdafam.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception fvv)
            {
                MessageBox.Show(fvv.ToString());
               // throw;
            }

            //---show avail = false from table -----------

            try
            {
                con.Open();
                SqlCommand cmdafams = new SqlCommand();
                cmdafams.Connection = con;
                cmdafams.CommandText = "SELECT number FROM room_family WHERE avail='FALSE' AND guest_id='" + gid + "' ";
                cmdafams.ExecuteNonQuery();
                con.Close();


                //---data in table-----

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdafams.ExecuteReader());
                dgfam.DataSource = dt;
                con.Close();
            }
            catch (Exception dff)
            {
                MessageBox.Show(dff.ToString());
             //   throw;
            }

            //check for avail rooms again
            availroomscombo(con);

        }

        private void btnaddfamdel_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            //-----update values of rooms-----------------

            try
            {
                con.Open();
                SqlCommand cmdafamdel = new SqlCommand();
                cmdafamdel.Connection = con;
                cmdafamdel.CommandText = "UPDATE room_family_deluxe SET avail = 'False' , clean = 'False' , cin = '" + cin + "' , cout = '" + cout + "' , dayss ='" + dayzz + "' , guest_id ='" + gid + "' WHERE number = '" + selectedfamdel + "'  ";
                cmdafamdel.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception vff)
            {
                MessageBox.Show(vff.ToString());
                //throw;
            }


            //---show avail = false from table -----------

            try
            {
                con.Open();
                SqlCommand cmdafamdels = new SqlCommand();
                cmdafamdels.Connection = con;
                cmdafamdels.CommandText = "SELECT number FROM room_family_deluxe WHERE avail='FALSE' AND guest_id='" + gid + "' ";
                cmdafamdels.ExecuteNonQuery();
                con.Close();


                //---data in table-----

                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmdafamdels.ExecuteReader());
                dgfamde.DataSource = dt;
                con.Close();
            }
            catch (Exception va)
            {
                MessageBox.Show(va.ToString());
                //throw;
            }

            //check for avail rooms again
            availroomscombo(con);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
