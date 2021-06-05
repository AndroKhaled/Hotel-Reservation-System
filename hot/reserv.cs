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
    public partial class reserv : Form
    {
        int daysDiff = 0 ;
        String cmdroomchoose, cmdroomcostchoose, cmdroomdecrease, cmdroomcheck;
        
        int finalNoRooms =0;
        int noroomscost = 0;
        int totalcost = 0;
        int noroomsb4 = 0,totalrooms = 0;
        int freerooms = 0;

        int lastID = 0;

        String choosed;
        DateTime datefrom;
        DateTime dateto;
        
        

        public reserv()
        {
            InitializeComponent();
            

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reserv_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            
            
          //---------------------to get last id--------------------------------------


            try
            {
                lastID = 0;
                con.Open();
                SqlCommand cmdid = new SqlCommand();
                cmdid.Connection = con;
                cmdid.CommandText = "SELECT MAX(id) FROM guest ";
                cmdid.ExecuteNonQuery();
                SqlDataReader sdrid = cmdid.ExecuteReader();
                sdrid.Read();
                lastID = sdrid.GetInt32(0);
                con.Close();
            }
            catch (Exception i)
            {   
                //throw;
                MessageBox.Show(i.ToString());
            }
            


            //--------------insert bill data---------------------

            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "INSERT INTO billz (bill_guest_id,bill_room_type,numberofrooms,checkin,checkout,nday,extra,totalbill,paid,unpaid) VALUES ('" + lastID + "' , '" + choosed + "','" + finalNoRooms + "' ,'" + datefrom + "','" + dateto + "','" + daysDiff + "','" + 0 + "','" + totalcost + "','" + 0 + "','" + 0 + "');";
                //id - bill_guest_id - bill_room_type - numberofrooms - checkin - checkout - nday - extra - totalbill - paid - unpaid

                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.ToString());
                //throw;
            }


            //---------------insert room data------------------

            //---------decrease number of rooms ----------------
            int decreasedno = totalrooms - finalNoRooms;
           // iddd.Text = decreasedno.ToString();
            string cmddecrease = cmdroomdecrease + decreasedno + "' WHERE id_avail_room = 1";

            try
            {
                con.Open();
                SqlCommand cmddec = new SqlCommand();
                cmddec.Connection = con;
                cmddec.CommandText = cmddecrease;
                cmddec.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception n)
            {
                MessageBox.Show(n.ToString());
                //throw;
            }

        }

        private void dtfrom_ValueChanged(object sender, EventArgs e)
        {
            //--checkin---checkout---ndays----------
            datefrom = dtfrom.Value.Date;
            dateto = dtto.Value.Date;
            daysDiff = ((TimeSpan)(dateto - datefrom)).Days;
            textdayss.Text = daysDiff.ToString();
        }

        private void dtto_ValueChanged(object sender, EventArgs e)
        {
            //--checkin---checkout---ndays----------
            datefrom = dtfrom.Value.Date;
            dateto = dtto.Value.Date;
            daysDiff = ((TimeSpan)(dateto - datefrom)).Days;
            textdayss.Text = daysDiff.ToString();
        }

        private void cbroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            choosed = cbroomtype.SelectedItem.ToString().Trim();

            if (choosed == "Superior")
            {
                cmdroomchoose = "SELECT sup FROM avail_rooms ";
                cmdroomcostchoose = "SELECT cost FROM room_sup ";

                cmdroomdecrease = "UPDATE avail_rooms SET sup ='";
                cmdroomcheck = "SELECT COUNT(number) FROM room_sup WHERE ('" + datefrom + "' >= cout AND  '" + dateto + "' >= cout  ) OR ( '" + dateto + "' <= cin AND '" + datefrom + "' >= cin) OR ( '" + datefrom + "' < cout AND '" + dateto + "' <= cin) OR (avail = 'true')";


            }
            else if (choosed == "Suite")
            {
                cmdroomchoose = "SELECT suite FROM avail_rooms ";
                cmdroomcostchoose = "SELECT cost FROM room_suite ";

                cmdroomdecrease = "UPDATE avail_rooms SET suite ='";
                cmdroomcheck = "SELECT COUNT(number) FROM room_suite WHERE ('" + datefrom + "' >= cout AND  '" + dateto + "' >= cout  ) OR ( '" + dateto + "' <= cin AND '" + datefrom + "' >= cin) OR ( '" + datefrom + "' < cout AND '" + dateto + "' <= cin) OR (avail = 'true')";

            }
            else if (choosed == "Jr Suite")
            {
                cmdroomchoose = "SELECT jrsuite FROM avail_rooms ";
                cmdroomcostchoose = "SELECT cost FROM room_jr_suite ";

                cmdroomdecrease = "UPDATE avail_rooms SET jrsuite ='";
                cmdroomcheck = "SELECT COUNT(number) FROM room_jr_suite WHERE ('" + datefrom + "' >= cout AND  '" + dateto + "' >= cout  ) OR ( '" + dateto + "' <= cin AND '" + datefrom + "' >= cin) OR ( '" + datefrom + "' < cout AND '" + dateto + "' <= cin) OR (avail = 'true')";

            }
            else if (choosed == "Family Room")
            {
                cmdroomchoose = "SELECT family FROM avail_rooms ";
                cmdroomcostchoose = "SELECT cost FROM room_family ";

                cmdroomdecrease = "UPDATE avail_rooms SET family ='";
                cmdroomcheck = "SELECT COUNT(number) FROM room_family WHERE ('" + datefrom + "' >= cout AND  '" + dateto + "' >= cout  ) OR ( '" + dateto + "' <= cin AND '" + datefrom + "' >= cin) OR ( '" + datefrom + "' < cout AND '" + dateto + "' <= cin) OR (avail = 'true')";

            }
            else if (choosed == "Family Deluxe")
            {
                cmdroomchoose = "SELECT fam_del FROM avail_rooms ";
                cmdroomcostchoose = "SELECT cost FROM room_family_deluxe ";

                cmdroomdecrease = "UPDATE avail_rooms SET fam_del ='";
                cmdroomcheck = "SELECT COUNT(number) FROM room_family_deluxe WHERE ('" + datefrom + "' >= cout AND  '" + dateto + "' >= cout  ) OR ( '" + dateto + "' <= cin AND '" + datefrom + "' >= cin) OR ( '" + datefrom + "' < cout AND '" + dateto + "' <= cin) OR (avail = 'true')";

            }

            //--------------number of rooms------------


            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand cmdroom = new SqlCommand();
                cmdroom.Connection = con;
                cmdroom.CommandText = cmdroomchoose;
                cmdroom.ExecuteNonQuery();
                SqlDataReader sdrroom = cmdroom.ExecuteReader();
                sdrroom.Read();
                //double totaldouble = sdrroom.GetInt32(0);
                totalrooms = sdrroom.GetInt32(0);

                con.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.ToString());
                //throw;
            }
            //iddd.Text = totalrooms.ToString();
            

            //--------cost---------------------

            noroomscost = 0;
            try
            {
                con.Open();
                SqlCommand cmdroomcost = new SqlCommand();
                cmdroomcost.Connection = con;
                cmdroomcost.CommandText = cmdroomcostchoose;
                cmdroomcost.ExecuteNonQuery();
                SqlDataReader sdrroomcost = cmdroomcost.ExecuteReader();
                sdrroomcost.Read();
                String strcost = sdrroomcost.GetInt32(0).ToString();
                noroomscost = int.Parse(strcost);

                con.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
                //throw;
            }


            totalcost = noroomscost * daysDiff * finalNoRooms;
            textcost.Text = totalcost.ToString();


            //-------------------------------------------CHECK AVAIL---------------------------------
            if (choosed != null && cmdroomcheck != null)
            {
                cbnuroom.Items.Clear();

                //string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
                //SqlConnection con = new SqlConnection(conString);
                try
                {
                    con.Open();
                    SqlCommand cmdroomz = new SqlCommand();
                    cmdroomz.Connection = con;
                    cmdroomz.CommandText = "SELECT SUM(numberofrooms) FROM billz WHERE  (( checkin <= '" + datefrom + "' AND checkout > '" + datefrom + "') OR  ( checkin < '" + dateto + "' AND checkout >='" + dateto + "') OR ('" + datefrom + "' <= checkin AND '" + dateto + "' >= checkin)   OR ('" + datefrom + "' < checkin AND '" + dateto + "' > checkin)   ) AND (bill_room_type ='" + choosed + "')";
                    cmdroomz.ExecuteNonQuery();
                    object result = cmdroomz.ExecuteScalar();
                    con.Close();
                    noroomsb4 = int.Parse(result.ToString());

                    // l mash8ool = noroomsb4 .. l total -- totalrooms
                    freerooms = totalrooms - noroomsb4;
                    for (int i = 1; i <= freerooms; i++)
                    {
                        string[] numbers = { i.ToString() };
                        cbnuroom.Items.AddRange(numbers);
                    }
                  //  con.Open();
                  //  DataTable dt = new DataTable();
                  //  dt.Load(cmdroomz.ExecuteReader());
                  //  dgcheckbill.DataSource = dt;
                  //  con.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show("error here");
                    freerooms = totalrooms;
                    for (int i = 1; i <= freerooms; i++)
                    {
                        string[] numbers = { i.ToString() };
                        cbnuroom.Items.AddRange(numbers);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Room Type");
            }

        }

        private void cbnuroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalNoRooms = int.Parse(cbnuroom.SelectedItem.ToString());
            totalcost = noroomscost * daysDiff * finalNoRooms;
            textcost.Text = totalcost.ToString();
        
        }

        private void textdayss_TextChanged(object sender, EventArgs e)
        {
            dtto.Value = dtfrom.Value.AddDays(daysDiff);
            totalcost = noroomscost * daysDiff * finalNoRooms;
            textcost.Text = totalcost.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            if (choosed != null && cmdroomcheck!=null)
            {
                cbnuroom.Items.Clear();

                string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                try
                {
                    con.Open();
                    SqlCommand cmdroomz = new SqlCommand();
                    cmdroomz.Connection = con;
                    cmdroomz.CommandText = "SELECT SUM(numberofrooms) FROM billz WHERE  (( checkin <= '" + datefrom + "' AND checkout > '" + datefrom + "') OR  ( checkin < '" + dateto + "' AND checkout >='" + dateto + "') OR ('" + datefrom + "' <= checkin AND '" + dateto + "' >= checkin)   OR ('" + datefrom + "' < checkin AND '" + dateto + "' > checkin)   ) AND (bill_room_type ='" + choosed + "')";
                    cmdroomz.ExecuteNonQuery();
                    object result = cmdroomz.ExecuteScalar();
                    con.Close();
                    noroomsb4 = int.Parse(result.ToString());
                    
                    // l mash8ool = noroomsb4 .. l total -- totalrooms
                    freerooms = totalrooms - noroomsb4;
                    for (int i = 1; i <= freerooms; i++)
                    {
                        string[] numbers = { i.ToString() };
                        cbnuroom.Items.AddRange(numbers);
                    }

                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmdroomz.ExecuteReader());
                    dgcheckbill.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("error here");
                    freerooms = totalrooms;
                    for (int i = 1; i <= freerooms; i++)
                    {
                        string[] numbers = { i.ToString() };
                        cbnuroom.Items.AddRange(numbers);
                    }
                }
            }
            else {
                MessageBox.Show("Please Select Room Type");
            }
*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //-------insert guest data----------------

            String name = textname.Text;
            String fonenumber = textphonenumber.Text;
            String noadults = textnoadults.Text;
            String nochilds = textchilds.Text;

            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO guest (name,number,noadults,nochilds) VALUES ('" + name + "' , '" + fonenumber + "','" + noadults + "' ,'" + nochilds + "');";
                //id-name-number-adults-childs-    
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
               // throw;
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
