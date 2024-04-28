using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace System
{
    public partial class Rooms_Admin_UC : UserControl
    {
        private const string connection = "server=localhost;port=3306;database=managementsystem;user=root;password=";
        List<int> matchedIndexes = new List<int>();

        private Guna2Panel[] rooms;
   

        public Rooms_Admin_UC()
        {
            InitializeComponent();
            configureRooms();

            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void pnlAvailUnit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Rooms_Admin_UC_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void configureRooms()
        {
            rooms = new Guna2Panel[] {
                room1, room2, room3 , room4 ,room5, room6, room7, room8, room9, room10, room11,
                room12, room13 , room14 ,room15, room16, room17, room18, room19, room20, room21,
                room22, room23 , room24 ,room25, room26, room27, room28, room29, room30, room31,
                room32, room33 , room34 ,room35, room36, room37, room38, room39, room40, room41,
                room42, room43 , room44 , room45, room46, room47, room48, room49, room50,
                room51, room52, room53 , room54 ,room55, room56, room57, room58, room59, room60,  room61,
                room62, room63 , room64 ,room65, room66, room67, room68, room69, room70, room71,
                room72, room73 , room74 ,room75, room76, room77, room78, room79, room80, room81,
                room82, room83 , room84 ,room85, room86, room87, room88, room89, room90, room91,
                room92, room93 , room94 , room95, room96, room97, room98, room99, room100};



            foreach (var room in rooms)
            {
                room.Click += Room_Click;
                room.MouseLeave += Room_MouseLeave;
            }

        }

        private void Room_Click(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = (Guna2Panel)sender;
            clickedPanel.BorderColor = Color.Red;
            Image backgroundImage = clickedPanel.BackgroundImage;
            int roomIndex = Array.IndexOf(rooms, clickedPanel) + 1;
            txtRoomNumber.Text = roomIndex.ToString();

            if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
                MessageBox.Show("Please enter a room number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectQuery = "SELECT idRooms, room_capacity, rooms_included, roomAmenities, room_price FROM rooms WHERE idRooms = @roomIndex";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
                {
                    cmd.Parameters.AddWithValue("@roomIndex", txtRoomNumber.Text); // Fixed parameter name

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtRoomNumber.Text = reader["idRooms"].ToString();
                            roomCapacity.Text = reader["room_capacity"].ToString();
                            roomInclusion.Text = reader["rooms_included"].ToString();
                            string roomamenities = reader["roomAmenities"].ToString();
                            string[] amenitiesArray = roomamenities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            StringBuilder displayText = new StringBuilder();
                            int amenityCount = 0;
                            foreach (string amenity in amenitiesArray)
                            {
                                displayText.Append(amenity.Trim());
                                displayText.Append(" | ");
                                amenityCount++;

                                if (amenityCount % 3 == 0)
                                    displayText.AppendLine();
                            }

                            roomAmenities.Text = displayText.ToString();
                            txtPrice.Text = reader["room_price"].ToString();

                           
                        }
                        else
                        {
                            MessageBox.Show("Room not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //label11.Text = label12.Text = label3.Text = label15.Text = label13.Text = "";
                        }
                    }
                }
            }
        }

        private void Room_MouseLeave(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = (Guna2Panel)sender;
            clickedPanel.BorderColor = Color.Black;
           

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
           /* lblCurrentFloor.Text = "GROUND FLOOR";*/

            grpBoxGround.Show();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            grpBoxGround.Hide();
            grpBoxFirst.Show();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Show();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Show();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxFourth.Show();
            grpBoxFifth.Hide();
            grpBoxThird.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxFifth.Show();
            grpBoxFourth.Hide();
            grpBoxThird.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Show();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Show();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnEightFloor_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Show();
            grpBoxNinth.Hide();
        }

        private void btnNinthFloor_Click(object sender, EventArgs e)
        {
            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Show();
        }

        private void timerSetTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timerSetTime.Start();
        }

        private void room96_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
