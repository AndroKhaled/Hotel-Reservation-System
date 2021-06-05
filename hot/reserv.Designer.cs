namespace hot
{
    partial class reserv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblname = new System.Windows.Forms.Label();
            this.textname = new System.Windows.Forms.TextBox();
            this.textphonenumber = new System.Windows.Forms.TextBox();
            this.lblphonenumber = new System.Windows.Forms.Label();
            this.textnoadults = new System.Windows.Forms.TextBox();
            this.lblnoadults = new System.Windows.Forms.Label();
            this.textchilds = new System.Windows.Forms.TextBox();
            this.lblchilds = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lblto = new System.Windows.Forms.Label();
            this.textdayss = new System.Windows.Forms.TextBox();
            this.lbldays = new System.Windows.Forms.Label();
            this.lblroomtype = new System.Windows.Forms.Label();
            this.cbroomtype = new System.Windows.Forms.ComboBox();
            this.cbnuroom = new System.Windows.Forms.ComboBox();
            this.lblnuroom = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textcost = new System.Windows.Forms.TextBox();
            this.lblcost = new System.Windows.Forms.Label();
            this.btnaddguest = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblname.Location = new System.Drawing.Point(80, 25);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(124, 27);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Full Name :";
            // 
            // textname
            // 
            this.textname.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textname.Location = new System.Drawing.Point(212, 19);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(282, 33);
            this.textname.TabIndex = 1;
            // 
            // textphonenumber
            // 
            this.textphonenumber.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textphonenumber.Location = new System.Drawing.Point(212, 84);
            this.textphonenumber.Name = "textphonenumber";
            this.textphonenumber.Size = new System.Drawing.Size(282, 33);
            this.textphonenumber.TabIndex = 3;
            // 
            // lblphonenumber
            // 
            this.lblphonenumber.AutoSize = true;
            this.lblphonenumber.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblphonenumber.Location = new System.Drawing.Point(33, 89);
            this.lblphonenumber.Name = "lblphonenumber";
            this.lblphonenumber.Size = new System.Drawing.Size(171, 27);
            this.lblphonenumber.TabIndex = 2;
            this.lblphonenumber.Text = "Phone Number :";
            // 
            // textnoadults
            // 
            this.textnoadults.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textnoadults.Location = new System.Drawing.Point(212, 155);
            this.textnoadults.Name = "textnoadults";
            this.textnoadults.Size = new System.Drawing.Size(58, 33);
            this.textnoadults.TabIndex = 5;
            // 
            // lblnoadults
            // 
            this.lblnoadults.AutoSize = true;
            this.lblnoadults.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblnoadults.Location = new System.Drawing.Point(10, 156);
            this.lblnoadults.Name = "lblnoadults";
            this.lblnoadults.Size = new System.Drawing.Size(195, 27);
            this.lblnoadults.TabIndex = 4;
            this.lblnoadults.Text = "Number of adults :";
            // 
            // textchilds
            // 
            this.textchilds.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textchilds.Location = new System.Drawing.Point(210, 229);
            this.textchilds.Name = "textchilds";
            this.textchilds.Size = new System.Drawing.Size(60, 33);
            this.textchilds.TabIndex = 7;
            // 
            // lblchilds
            // 
            this.lblchilds.AutoSize = true;
            this.lblchilds.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblchilds.Location = new System.Drawing.Point(10, 229);
            this.lblchilds.Name = "lblchilds";
            this.lblchilds.Size = new System.Drawing.Size(194, 27);
            this.lblchilds.TabIndex = 6;
            this.lblchilds.Text = "Number of Childs :";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblfrom.Location = new System.Drawing.Point(576, 22);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(76, 27);
            this.lblfrom.TabIndex = 8;
            this.lblfrom.Text = "From :";
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Tahoma", 16F);
            this.dtfrom.Location = new System.Drawing.Point(673, 19);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(354, 33);
            this.dtfrom.TabIndex = 9;
            this.dtfrom.ValueChanged += new System.EventHandler(this.dtfrom_ValueChanged);
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Tahoma", 16F);
            this.dtto.Location = new System.Drawing.Point(673, 62);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(354, 33);
            this.dtto.TabIndex = 11;
            this.dtto.ValueChanged += new System.EventHandler(this.dtto_ValueChanged);
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblto.Location = new System.Drawing.Point(600, 68);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(52, 27);
            this.lblto.TabIndex = 10;
            this.lblto.Text = "To :";
            // 
            // textdayss
            // 
            this.textdayss.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textdayss.Location = new System.Drawing.Point(673, 114);
            this.textdayss.Name = "textdayss";
            this.textdayss.Size = new System.Drawing.Size(44, 33);
            this.textdayss.TabIndex = 13;
            this.textdayss.TextChanged += new System.EventHandler(this.textdayss_TextChanged);
            // 
            // lbldays
            // 
            this.lbldays.AutoSize = true;
            this.lbldays.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lbldays.Location = new System.Drawing.Point(578, 117);
            this.lbldays.Name = "lbldays";
            this.lbldays.Size = new System.Drawing.Size(75, 27);
            this.lbldays.TabIndex = 12;
            this.lbldays.Text = "Days :";
            // 
            // lblroomtype
            // 
            this.lblroomtype.AutoSize = true;
            this.lblroomtype.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblroomtype.Location = new System.Drawing.Point(739, 178);
            this.lblroomtype.Name = "lblroomtype";
            this.lblroomtype.Size = new System.Drawing.Size(138, 27);
            this.lblroomtype.TabIndex = 14;
            this.lblroomtype.Text = "Room Type :";
            // 
            // cbroomtype
            // 
            this.cbroomtype.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cbroomtype.FormattingEnabled = true;
            this.cbroomtype.Items.AddRange(new object[] {
            "Superior",
            "Suite",
            "Jr Suite",
            "Family Room",
            "Family Deluxe"});
            this.cbroomtype.Location = new System.Drawing.Point(879, 172);
            this.cbroomtype.Name = "cbroomtype";
            this.cbroomtype.Size = new System.Drawing.Size(148, 33);
            this.cbroomtype.TabIndex = 15;
            this.cbroomtype.SelectedIndexChanged += new System.EventHandler(this.cbroomtype_SelectedIndexChanged);
            // 
            // cbnuroom
            // 
            this.cbnuroom.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cbnuroom.FormattingEnabled = true;
            this.cbnuroom.Location = new System.Drawing.Point(879, 229);
            this.cbnuroom.Name = "cbnuroom";
            this.cbnuroom.Size = new System.Drawing.Size(148, 33);
            this.cbnuroom.TabIndex = 17;
            this.cbnuroom.SelectedIndexChanged += new System.EventHandler(this.cbnuroom_SelectedIndexChanged);
            // 
            // lblnuroom
            // 
            this.lblnuroom.AutoSize = true;
            this.lblnuroom.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblnuroom.Location = new System.Drawing.Point(668, 229);
            this.lblnuroom.Name = "lblnuroom";
            this.lblnuroom.Size = new System.Drawing.Size(207, 27);
            this.lblnuroom.TabIndex = 16;
            this.lblnuroom.Text = "Number Of Rooms :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button1.Location = new System.Drawing.Point(744, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 53);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textcost
            // 
            this.textcost.Font = new System.Drawing.Font("Tahoma", 16F);
            this.textcost.Location = new System.Drawing.Point(938, 117);
            this.textcost.Name = "textcost";
            this.textcost.Size = new System.Drawing.Size(89, 33);
            this.textcost.TabIndex = 21;
            // 
            // lblcost
            // 
            this.lblcost.AutoSize = true;
            this.lblcost.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblcost.Location = new System.Drawing.Point(843, 117);
            this.lblcost.Name = "lblcost";
            this.lblcost.Size = new System.Drawing.Size(69, 27);
            this.lblcost.TabIndex = 20;
            this.lblcost.Text = "Cost :";
            // 
            // btnaddguest
            // 
            this.btnaddguest.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnaddguest.Location = new System.Drawing.Point(212, 307);
            this.btnaddguest.Name = "btnaddguest";
            this.btnaddguest.Size = new System.Drawing.Size(212, 53);
            this.btnaddguest.TabIndex = 34;
            this.btnaddguest.Text = "Add Guest";
            this.btnaddguest.UseVisualStyleBackColor = true;
            this.btnaddguest.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnback
            // 
            this.btnback.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnback.Location = new System.Drawing.Point(940, 419);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(94, 59);
            this.btnback.TabIndex = 36;
            this.btnback.Text = "BACK";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnexit.Location = new System.Drawing.Point(829, 420);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(94, 58);
            this.btnexit.TabIndex = 37;
            this.btnexit.Text = "EXIT";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // reserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1046, 490);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnaddguest);
            this.Controls.Add(this.textcost);
            this.Controls.Add(this.lblcost);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbnuroom);
            this.Controls.Add(this.lblnuroom);
            this.Controls.Add(this.cbroomtype);
            this.Controls.Add(this.lblroomtype);
            this.Controls.Add(this.textdayss);
            this.Controls.Add(this.lbldays);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.lblto);
            this.Controls.Add(this.dtfrom);
            this.Controls.Add(this.lblfrom);
            this.Controls.Add(this.textchilds);
            this.Controls.Add(this.lblchilds);
            this.Controls.Add(this.textnoadults);
            this.Controls.Add(this.lblnoadults);
            this.Controls.Add(this.textphonenumber);
            this.Controls.Add(this.lblphonenumber);
            this.Controls.Add(this.textname);
            this.Controls.Add(this.lblname);
            this.Name = "reserv";
            this.Text = "Reservation";
            this.Load += new System.EventHandler(this.reserv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox textname;
        private System.Windows.Forms.TextBox textphonenumber;
        private System.Windows.Forms.Label lblphonenumber;
        private System.Windows.Forms.TextBox textnoadults;
        private System.Windows.Forms.Label lblnoadults;
        private System.Windows.Forms.TextBox textchilds;
        private System.Windows.Forms.Label lblchilds;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.TextBox textdayss;
        private System.Windows.Forms.Label lbldays;
        private System.Windows.Forms.Label lblroomtype;
        private System.Windows.Forms.ComboBox cbroomtype;
        private System.Windows.Forms.ComboBox cbnuroom;
        private System.Windows.Forms.Label lblnuroom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textcost;
        private System.Windows.Forms.Label lblcost;
        private System.Windows.Forms.Button btnaddguest;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnexit;
    }
}