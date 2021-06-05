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
    public partial class checkout : Form
    {
        String name, number, id;
        String cmdguestquery;
        DateTime checkoutz;
        String cin, cout, dayzz, gid;

        String supcountnumber = "", supsumcost = "", supsumdayss = "";
        String suitecountnumber = "", suitesumcost = "", suitesumdayss = "";
        String jrsuitecountnumber = "", jrsuitesumcost = "", jrsuitesumdayss = "";
        String famcountnumber = "", famsumcost = "", famsumdayss = "";
        String famdelcountnumber = "", famdelsumcost = "", famdelsumdayss = "";
        // total + avail = after
        int totalsup = 0, totalsuite = 0, totaljrsuite = 0, totalfam = 0, totalfamdel = 0, totalroomscost = 0;

        int usedsup = 0, usedsuite = 0, usedjrsuite = 0, usedfam = 0, usedfamdel = 0;
        int availsup = 0, availsuite = 0, availjrsuite = 0, availfam = 0, availfamdel = 0;
        int aftersup = 0, aftersuite = 0, afterjrsuite = 0, afterfam = 0, afterfamdel = 0;

        int extraz = 0,totalall=0;


        public checkout()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //---------get data from textbox ------------
            name = textname.Text.ToString();
            number = textnumber.Text.ToString();
            id = textid.Text.ToString();
            checkoutz = dtcheckout.Value.Date;

            //---------get data from text and search ------------
            if (name != "")
            {
                if (number != "")
                {
                    //check with name and number
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "' AND name='" + name + "') ) AND ( checkout = '" + checkoutz + "' ) )";

                }
                else
                {
                    // check with name only
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( name='" + name + "') ) AND ( checkout = '" + checkoutz + "' ) )";
                }
            }
            else if (number != "")
            {
                if (name != "")
                {
                    //check with name and number
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "' AND name='" + name + "') ) AND ( checkout = '" + checkoutz + "' ) )";
                }
                else
                {
                    // check with number only
                    cmdguestquery = "SELECT * FROM billz WHERE ( bill_guest_id IN ( SELECT id FROM guest WHERE ( number='" + number + "') ) AND ( checkout = '" + checkoutz + "' ) )";
                }
            }
            else
            {
                MessageBox.Show("Plz Enter Name or Number :)");
            }

            //-------search with name or number : guest bill -----------------------------------

            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand cmdguest = new SqlCommand();
                cmdguest.Connection = con;
                cmdguest.CommandText = cmdguestquery;
                cmdguest.ExecuteNonQuery();


                //---------get values from billz to search the guests room----------------------------------------------------------
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
            catch (Exception ge)
            {
                MessageBox.Show(ge.ToString());
                //throw;
            }

            
            //-----------------------------------------------SUPERIOR ROOM-------------------------------------

            //-----------count number of used sup rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsup = new SqlCommand();
                cmdavailsup.Connection = con;
                cmdavailsup.CommandText = "SELECT COUNT(number) FROM room_sup WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsup.ExecuteNonQuery();
                con.Close();

                con.Open();
                supcountnumber = cmdavailsup.ExecuteScalar().ToString();
                textsumcountsup.Text = supcountnumber;
                con.Close();
                usedsup = int.Parse(supcountnumber);
            }
            catch (Exception sr)
            {
                MessageBox.Show(sr.ToString());
                //throw;
            }


            //-----------sum cost of used sup rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsupc = new SqlCommand();
                cmdavailsupc.Connection = con;
                cmdavailsupc.CommandText = "SELECT SUM(cost) FROM room_sup WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsupc.ExecuteNonQuery();
                con.Close();

                con.Open();
                supsumcost = cmdavailsupc.ExecuteScalar().ToString();
                textsumcostsup.Text = supsumcost;
                con.Close();

            }
            catch (Exception srs)
            {
                MessageBox.Show(srs.ToString());
                //throw;
            }

            //-----------sum dayss of used sup rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsupd = new SqlCommand();
                cmdavailsupd.Connection = con;
                cmdavailsupd.CommandText = "SELECT SUM(dayss) FROM room_sup WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsupd.ExecuteNonQuery();
                con.Close();

                con.Open();
                supsumdayss = cmdavailsupd.ExecuteScalar().ToString();
                textsumdaysssup.Text = supsumdayss;
                con.Close();
            }
            catch (Exception srsd)
            {
                MessageBox.Show(srsd.ToString());
                //throw;
            }

            if (supcountnumber == "" || supsumcost == "" || supsumdayss == "")
            {
                totalsup = 0;
                texttotalsup.Text = "0";
            }
            else { 
            
            totalsup = int.Parse(supcountnumber) * int.Parse(supsumcost) * int.Parse(supsumdayss);
            texttotalsup.Text = totalsup.ToString();
            }
            
            //-----------------------------------------------SUITE ROOM-------------------------------------


            //-----------count number of used suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsuite = new SqlCommand();
                cmdavailsuite.Connection = con;
                cmdavailsuite.CommandText = "SELECT COUNT(number) FROM room_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsuite.ExecuteNonQuery();
                con.Close();

                con.Open();
                suitecountnumber = cmdavailsuite.ExecuteScalar().ToString();
                textsumcountsuite.Text = suitecountnumber;
                con.Close();
                usedsuite = int.Parse(suitecountnumber);
            }
            catch (Exception us)
            {
                MessageBox.Show(us.ToString());
                //throw;
            }


            //-----------sum cost of used suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsuitec = new SqlCommand();
                cmdavailsuitec.Connection = con;
                cmdavailsuitec.CommandText = "SELECT SUM(cost) FROM room_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsuitec.ExecuteNonQuery();
                con.Close();

                con.Open();
                suitesumcost = cmdavailsuitec.ExecuteScalar().ToString();
                textsumcostsuite.Text = suitesumcost;
                con.Close();
            }
            catch (Exception usr)
            {
                MessageBox.Show(usr.ToString());
                //throw;
            }


            //-----------sum dayss of used suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailsuited = new SqlCommand();
                cmdavailsuited.Connection = con;
                cmdavailsuited.CommandText = "SELECT SUM(dayss) FROM room_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailsuited.ExecuteNonQuery();
                con.Close();

                con.Open();
                suitesumdayss = cmdavailsuited.ExecuteScalar().ToString();
                textsumdaysssuite.Text = suitesumdayss;
                con.Close();
            }
            catch (Exception urs)
            {
                MessageBox.Show(urs.ToString());
                //throw;
            }

            if (suitecountnumber == "" || suitesumcost == "" || suitesumdayss == "")
            {
                totalsuite = 0;
                texttotalsuite.Text = "0";
            }
            else
            {
                totalsuite = int.Parse(suitecountnumber) * int.Parse(suitesumcost) * int.Parse(suitesumdayss);
                texttotalsuite.Text = totalsuite.ToString();
            }

            //----------------------------------------------- JR SUITE ROOM-------------------------------------


            //-----------count number of used jr suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailjrsuite = new SqlCommand();
                cmdavailjrsuite.Connection = con;
                cmdavailjrsuite.CommandText = "SELECT COUNT(number) FROM room_jr_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailjrsuite.ExecuteNonQuery();
                con.Close();

                con.Open();
                jrsuitecountnumber = cmdavailjrsuite.ExecuteScalar().ToString();
                textsumcountjrsuite.Text = jrsuitecountnumber;
                con.Close();
                usedjrsuite = int.Parse(jrsuitecountnumber);

            }
            catch (Exception js)
            {
                MessageBox.Show(js.ToString());
                //throw;
            }

            //-----------sum cost of used jr suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailjrsuitec = new SqlCommand();
                cmdavailjrsuitec.Connection = con;
                cmdavailjrsuitec.CommandText = "SELECT SUM(cost) FROM room_jr_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailjrsuitec.ExecuteNonQuery();
                con.Close();

                con.Open();
                jrsuitesumcost = cmdavailjrsuitec.ExecuteScalar().ToString();
                textsumcostjrsuite.Text = jrsuitesumcost;
                con.Close();
            }
            catch (Exception jrr)
            {
                MessageBox.Show(jrr.ToString());
                //throw;
            }


            //-----------sum dayss of used jr suite rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailjrsuited = new SqlCommand();
                cmdavailjrsuited.Connection = con;
                cmdavailjrsuited.CommandText = "SELECT SUM(dayss) FROM room_jr_suite WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailjrsuited.ExecuteNonQuery();
                con.Close();

                con.Open();
                jrsuitesumdayss = cmdavailjrsuited.ExecuteScalar().ToString();
                textsumdayssjrsuite.Text = jrsuitesumdayss;
                con.Close();
            }
            catch (Exception jrss)
            {
                MessageBox.Show(jrss.ToString());
                //throw;
            }

            if (jrsuitecountnumber == "" || jrsuitesumcost == "" || jrsuitesumdayss == "")
            {
                totaljrsuite = 0;
                texttotaljrsuite.Text = "0";
            }
            else
            {
                totaljrsuite = int.Parse(jrsuitecountnumber) * int.Parse(jrsuitesumcost) * int.Parse(jrsuitesumdayss);
                texttotaljrsuite.Text = totaljrsuite.ToString();
            }

            //----------------------------------------------- FAMILY ROOM-------------------------------------


            //-----------count number of used fam rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfam = new SqlCommand();
                cmdavailfam.Connection = con;
                cmdavailfam.CommandText = "SELECT COUNT(number) FROM room_family WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfam.ExecuteNonQuery();
                con.Close();

                con.Open();
                famcountnumber = cmdavailfam.ExecuteScalar().ToString();
                textsumcountfam.Text = famcountnumber;
                con.Close();
                usedfam = int.Parse(famcountnumber);
            }
            catch (Exception frr)
            {
                MessageBox.Show(frr.ToString());
                //throw;
            }


            //-----------sum cost of used fam rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfamc = new SqlCommand();
                cmdavailfamc.Connection = con;
                cmdavailfamc.CommandText = "SELECT SUM(cost) FROM room_family WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfamc.ExecuteNonQuery();
                con.Close();

                con.Open();
                famsumcost = cmdavailfamc.ExecuteScalar().ToString();
                textsumcostfam.Text = famsumcost;
                con.Close();
            }
            catch (Exception frss)
            {
                MessageBox.Show(frss.ToString());
                //throw;
            }


            //-----------sum dayss of used fam rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfamd = new SqlCommand();
                cmdavailfamd.Connection = con;
                cmdavailfamd.CommandText = "SELECT SUM(dayss) FROM room_family WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfamd.ExecuteNonQuery();
                con.Close();

                con.Open();
                famsumdayss = cmdavailfamd.ExecuteScalar().ToString();
                textsumdayssfam.Text = famsumdayss;
                con.Close();
            }
            catch (Exception fss)
            {
                MessageBox.Show(fss.ToString());
                //throw;
            }

            if (famcountnumber == "" || famsumcost == "" || famsumdayss == "")
            {
                totalfam = 0;
                texttotalfam.Text = "0";
            }
            else
            {
                totalfam = int.Parse(famcountnumber) * int.Parse(famsumcost) * int.Parse(famsumdayss);
                texttotalfam.Text = totalfam.ToString();
            }

            //----------------------------------------------- FAMILY DELUXE ROOM-------------------------------------


            //-----------count number of used fam del rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfamdel = new SqlCommand();
                cmdavailfamdel.Connection = con;
                cmdavailfamdel.CommandText = "SELECT COUNT(number) FROM room_family_deluxe WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfamdel.ExecuteNonQuery();
                con.Close();

                con.Open();
                famdelcountnumber = cmdavailfamdel.ExecuteScalar().ToString();
                textsumcountfamdel.Text = famdelcountnumber;
                con.Close();
                usedfamdel = int.Parse(famdelcountnumber);
            }
            catch (Exception fda)
            {
                MessageBox.Show(fda.ToString());
                //throw;
            }


            //-----------sum cost of used fam del rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfamdelc = new SqlCommand();
                cmdavailfamdelc.Connection = con;
                cmdavailfamdelc.CommandText = "SELECT SUM(cost) FROM room_family_deluxe WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfamdelc.ExecuteNonQuery();
                con.Close();

                con.Open();
                famdelsumcost = cmdavailfamdelc.ExecuteScalar().ToString();
                textsumcostfamdel.Text = famdelsumcost;
                con.Close();
            }
            catch (Exception fdaa)
            {
                MessageBox.Show(fdaa.ToString());
                //throw;
            }


            //-----------sum dayss of used fam del rooms------------
            try
            {
                con.Open();
                SqlCommand cmdavailfamdeld = new SqlCommand();
                cmdavailfamdeld.Connection = con;
                cmdavailfamdeld.CommandText = "SELECT SUM(dayss) FROM room_family_deluxe WHERE avail = 'False' AND cout = '" + cout + "' AND guest_id = '" + gid + "' ";
                cmdavailfamdeld.ExecuteNonQuery();
                con.Close();

                con.Open();
                famsumdayss = cmdavailfamdeld.ExecuteScalar().ToString();
                textsumdayssfamdel.Text = famdelsumdayss;
                con.Close();
            }
            catch (Exception fdrr)
            {
                MessageBox.Show(fdrr.ToString());
                //throw;
            }

            if (famdelcountnumber == "" || famdelsumcost == "" || famdelsumdayss == "")
            {
                totalfamdel = 0;
                texttotalfamdel.Text = "0";
            }
            else
            {
                totalfamdel = int.Parse(famdelcountnumber) * int.Parse(famdelsumcost) * int.Parse(famdelsumdayss);
                texttotalfamdel.Text = totalfamdel.ToString();
            }

            //----------------------------------------------------------------------------------
            //---------------------------------TOTAL SUM OF ROOMS-------------------------------
            //----------------------------------------------------------------------------------

            totalroomscost = totalsup + totalsuite + totaljrsuite + totalfam + totalfamdel;
            texttotalrooms.Text =totalroomscost.ToString();

            totalall = extraz + totalroomscost;
            texttotalall.Text = totalall.ToString();

        }

        private void textextra_TextChanged(object sender, EventArgs e)
        {
            //--------sum cost of rooms + extra-----------------
            if (textextra.Text == "")
            {
                extraz = 0;
                totalall = extraz + totalroomscost;
                texttotalall.Text = totalall.ToString();
            }
            else {
                extraz = int.Parse(textextra.Text);
                totalall = extraz + totalroomscost;
                texttotalall.Text = totalall.ToString();
            }
            
        }

        private void btncheckout_Click(object sender, EventArgs e)
        {   
            string conString = "Data Source=.;Initial Catalog=hdata;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            //--------------------------------------------------GET THE NUMBER OF ALL AVAILABLE ROOMS-------------------
            //--------------number avail sup------------
            try
            {
                con.Open();
                SqlCommand cmdroomnosub = new SqlCommand();
                cmdroomnosub.Connection = con;
                cmdroomnosub.CommandText = "SELECT sup FROM avail_rooms ";
                cmdroomnosub.ExecuteNonQuery();
                SqlDataReader sdrroomnosub = cmdroomnosub.ExecuteReader();
                sdrroomnosub.Read();
                availsup = sdrroomnosub.GetInt32(0);
                con.Close();
            }
            catch (Exception su)
            {
                MessageBox.Show(su.ToString());
               // throw;
            }

            //--------------number avail suite------------
            try
            {
                con.Open();
                SqlCommand cmdroomnosuite = new SqlCommand();
                cmdroomnosuite.Connection = con;
                cmdroomnosuite.CommandText = "SELECT suite FROM avail_rooms ";
                cmdroomnosuite.ExecuteNonQuery();
                SqlDataReader sdrroomnosuite = cmdroomnosuite.ExecuteReader();
                sdrroomnosuite.Read();
                availsuite = sdrroomnosuite.GetInt32(0);
                con.Close();
            }
            catch (Exception suu)
            {
                MessageBox.Show(suu.ToString());
                //throw;
            }

            //--------------number avail jr suite------------
            try
            {
                con.Open();
                SqlCommand cmdroomnojrsuite = new SqlCommand();
                cmdroomnojrsuite.Connection = con;
                cmdroomnojrsuite.CommandText = "SELECT jrsuite FROM avail_rooms ";
                cmdroomnojrsuite.ExecuteNonQuery();
                SqlDataReader sdrroomnojrsuite = cmdroomnojrsuite.ExecuteReader();
                sdrroomnojrsuite.Read();
                availjrsuite = sdrroomnojrsuite.GetInt32(0);
                con.Close();
            }
            catch (Exception jsa)
            {
                MessageBox.Show(jsa.ToString());
                //throw;
            }

            //--------------number avail family------------
            try
            {
                con.Open();
                SqlCommand cmdroomnofam = new SqlCommand();
                cmdroomnofam.Connection = con;
                cmdroomnofam.CommandText = "SELECT family FROM avail_rooms ";
                cmdroomnofam.ExecuteNonQuery();
                SqlDataReader sdrroomnofam = cmdroomnofam.ExecuteReader();
                sdrroomnofam.Read();
                availfam = sdrroomnofam.GetInt32(0);
                con.Close();
            }
            catch (Exception fa)
            {
                MessageBox.Show(fa.ToString());
                //throw;
            }

            //--------------number avail family deluxe------------
            try
            {
                con.Open();
                SqlCommand cmdroomnofamdel = new SqlCommand();
                cmdroomnofamdel.Connection = con;
                cmdroomnofamdel.CommandText = "SELECT fam_del FROM avail_rooms ";
                cmdroomnofamdel.ExecuteNonQuery();
                SqlDataReader sdrroomnofamdel = cmdroomnofamdel.ExecuteReader();
                sdrroomnofamdel.Read();
                availfamdel = sdrroomnofamdel.GetInt32(0);
                con.Close();
            }
            catch (Exception fdl)
            {
                MessageBox.Show(fdl.ToString());
                //throw;
            }


            //---------------------------------------------ADD THE NUMBER OF USED ROOMS------------------------
            
            //---------------UPDATE NUMBER OF AVAIL ROOMS-------------------
            aftersup = usedsup + availsup;
            aftersuite = usedsuite + availsuite;
            afterjrsuite = usedjrsuite + availjrsuite;
            afterfam = usedfam + availfam;
            afterfamdel = usedfamdel + availfamdel;


            try
            {
                con.Open();
                SqlCommand cmdup = new SqlCommand();
                cmdup.Connection = con;
                cmdup.CommandText = "UPDATE avail_rooms SET sup = '" + aftersup + "' , suite = '" + aftersuite + "' , jrsuite = '" + afterjrsuite + "' , family = '" + afterfam + "' , fam_del = '" + afterfamdel + "' WHERE id_avail_room = '1' ";
                cmdup.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ava)
            {
                MessageBox.Show(ava.ToString());
                //throw;
            }


            //---------------------------------------------MAKE THE ROOMS AVAILABLE------------------------
            //--------------SUPERIOR------------
            try
            {
                con.Open();
                SqlCommand cmdmsup = new SqlCommand();
                cmdmsup.Connection = con;
                cmdmsup.CommandText = "UPDATE room_sup SET avail = '1' ,cin = NULL , cout = NULL , dayss = NULL , guest_id = NULL WHERE guest_id = '" + gid + "' ";
                cmdmsup.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception sa)
            {
                MessageBox.Show(sa.ToString());
                //throw;
            }
            
            //--------------SUITE------------
            try
            {
                con.Open();
                SqlCommand cmdmsuite = new SqlCommand();
                cmdmsuite.Connection = con;
                cmdmsuite.CommandText = "UPDATE room_suite SET avail = '1' ,cin = NULL , cout = NULL , dayss = NULL , guest_id = NULL WHERE guest_id = '" + gid + "' ";
                cmdmsuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception saas)
            {
                MessageBox.Show(saas.ToString());
                //throw;
            }

            //--------------JR SUITE------------
            try
            {
                con.Open();
                SqlCommand cmdmjrsuite = new SqlCommand();
                cmdmjrsuite.Connection = con;
                cmdmjrsuite.CommandText = "UPDATE room_jr_suite SET avail = '1' ,cin = NULL , cout = NULL , dayss = NULL , guest_id = NULL WHERE guest_id = '" + gid + "' ";
                cmdmjrsuite.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception jsss)
            {
                MessageBox.Show(jsss.ToString());
                //throw;
            }

            //--------------FAMILY-----------
            try
            {
                con.Open();
                SqlCommand cmdmfam = new SqlCommand();
                cmdmfam.Connection = con;
                cmdmfam.CommandText = "UPDATE room_family SET avail = '1' ,cin = NULL , cout = NULL , dayss = NULL , guest_id = NULL WHERE guest_id = '" + gid + "' ";
                cmdmfam.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception fsss)
            {
                MessageBox.Show(fsss.ToString());
                //throw;
            }

            //--------------FAMILY DELUXE-----------
            try
            {
                con.Open();
                SqlCommand cmdmfamdel = new SqlCommand();
                cmdmfamdel.Connection = con;
                cmdmfamdel.CommandText = "UPDATE room_family_deluxe SET avail = '1' ,cin = NULL , cout = NULL , dayss = NULL , guest_id = NULL WHERE guest_id = '" + gid + "' ";
                cmdmfamdel.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception fdss)
            {
                MessageBox.Show(fdss.ToString());
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

        private void checkout_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textsumdaysssup_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
