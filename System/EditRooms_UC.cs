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
    public partial class EditRooms_UC : UserControl
    {
        private const string connection = "server=localhost;port=3306;database=managementsystem;user=root;password=";
        public EditRooms_UC()
        {
            InitializeComponent();

        }

        private void EditRooms_UC_Load(object sender, EventArgs e)
        {
            cmbBoxAmenities.Items.Add("Kitchen");
            cmbBoxAmenities.Items.Add("Bathroom");
            cmbBoxAmenities.Items.Add("Bedroom");
            cmbBoxAmenities.Items.Add("Balcony");
        }

        private void cmbBoxAmenities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxAmenities.SelectedIndex == 0)
            {
                kitchenAmenities.Visible = true;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = false;

            }
            else if (cmbBoxAmenities.SelectedIndex == 1)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = true;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = false;
            }
            else if (cmbBoxAmenities.SelectedIndex == 2)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = true;
                roomAmenities.Visible = false;
            }
            else if (cmbBoxAmenities.SelectedIndex == 3)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Rooms Checkbox
            cbKitchen.Checked = false;
            cbBathroom.Checked = false;
            cbBedroom.Checked = false;
            cbBalcony.Checked = false;

            //Kitchen Amenities Checkbox
            cbCoffeeMachine.Checked = false;
            cbToaster.Checked = false;
            cbBlender.Checked = false;
            cbPlates.Checked = false;
            cbUtensils.Checked = false;
            cbPans.Checked = false;

            //Bathroom Amenities Checkbox
            cbShampoo.Checked = false;
            cbBodySoap.Checked = false;
            cbBidet.Checked = false;
            cbShower.Checked = false;
            cbBathTowel.Checked = false;
            cbHairDryer.Checked = false;

            //Bedroom Amenities Checkbox
            cbExtraPillows.Checked = false;
            cbHangers.Checked = false;
            cbBedSheets.Checked = false;
            cbDrawer.Checked = false;
            cbWardrobe.Checked = false;

            //Room Amenities Checkbox
            cbWifi.Checked = false;
            cbAirConditioned.Checked = false;
            cbRoomService.Checked = false;
            cbFreeParking.Checked = false;
            cbWashingMachine.Checked = false;
            cbLuggageStorage.Checked = false;
        }
        private string roomInclusions()
        {
            string inclusions = "";
            if (cbKitchen.Checked)
                inclusions += "Kitchen, ";
            if (cbBathroom.Checked)
                inclusions += "Bathroom, ";
            if (cbBedroom.Checked)
                inclusions += "Bedroom, ";
            if (cbBalcony.Checked)
                inclusions += "Balcony, ";


            if (!string.IsNullOrEmpty(inclusions))
                inclusions = inclusions.TrimEnd(',', ' ');
            return inclusions;
        }

        private string roomAminities()
        {
            string Amenities = "";
            //Kitchen Amenities Checkbox
            if (cbCoffeeMachine.Checked)
                Amenities += "Coffee Machine, ";

            if (cbToaster.Checked)
                Amenities += "Toaster, ";

            if (cbBlender.Checked)
                Amenities += "Blender, ";

            if (cbPlates.Checked)
                Amenities += "Plates, ";

            if (cbUtensils.Checked)
                Amenities += "Utensils, ";

            if (cbPans.Checked)
                Amenities += "Pans, ";

            //Bathroom Amenities Checkbox
            if (cbShampoo.Checked)
                Amenities += "Shampoo, ";

            if (cbBodySoap.Checked)
                Amenities += "Body Soap, ";

            if (cbBidet.Checked)
                Amenities += "Bidet, ";

            if (cbShower.Checked)
                Amenities += "Shower, ";

            if (cbBathTowel.Checked)
                Amenities += "Bath Towel, ";

            if (cbHairDryer.Checked)
                Amenities += "Hair Dryer, ";

            //Bedroom Amenities Checkbox
            if (cbExtraPillows.Checked)
                Amenities += "Extra Pillows, ";

            if (cbHangers.Checked)
                Amenities += "Hangers, ";

            if (cbBedSheets.Checked)
                Amenities += "Bed Sheets, ";

            if (cbDrawer.Checked)
                Amenities += "Drawer, ";

            if (cbWardrobe.Checked)
                Amenities += "Wardrobe, ";

            //Room Amenities Checkbox
            if (cbWifi.Checked)
                Amenities += "Wifi, ";

            if (cbAirConditioned.Checked)
                Amenities += "Air Conditioned, ";

            if (cbRoomService.Checked)
                Amenities += "Room Service, ";

            if (cbFreeParking.Checked)
                Amenities += "Free Parking, ";

            if (cbWashingMachine.Checked)
                Amenities += "Washing Machine, ";

            if (cbLuggageStorage.Checked)
                Amenities += "Luggage Storage, ";

            if (!string.IsNullOrEmpty(Amenities))
                Amenities = Amenities.TrimEnd(',', ' ');

            return Amenities;
        }





        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
                MessageBox.Show("Please enter a room number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectQuery = "SELECT idRooms, room_capacity, rooms_included, roomAmenities, room_price FROM rooms WHERE idRooms = @idRoom";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
                {
                    cmd.Parameters.AddWithValue("@idRoom", txtRoomNumber.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label11.Text = reader["idRooms"].ToString();
                            label12.Text = reader["room_capacity"].ToString();
                            label3.Text = reader["rooms_included"].ToString();
                            string roomAmenities = reader["roomAmenities"].ToString();
                            string[] amenitiesArray = roomAmenities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            StringBuilder displayText = new StringBuilder();
                            int amenityCount = 0;
                            foreach (string amenity in amenitiesArray)
                            {
                                displayText.Append(amenity.Trim());
                                displayText.Append(" | ");
                                amenityCount++;

                                if (amenityCount % 4 == 0)
                                    displayText.AppendLine();
                            }

                            label13.Text = displayText.ToString();
                            label15.Text = reader["room_price"].ToString();

                            btnCancel.Enabled = false;
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Room not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label11.Text = label12.Text = label3.Text = label15.Text = label13.Text = "";
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE  SET roomCapacity = @roomCapacity, roomInclustions = @roomInclustions, roomAmenities = @roomAmenities, roomPrice = @roomPrice,roomAmenities = @roomAmenities WHERE idRoom = @idRoom";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                string inclusions = roomInclusions();
                string Aminities = roomAminities();
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@roomInclusions", txtRoomCapacity.Text);
                    cmd.Parameters.AddWithValue("@roomCapacity", inclusions);
                    cmd.Parameters.AddWithValue("@roomAmenities", Aminities);
                    cmd.Parameters.AddWithValue("@roomPrice", txtRoomPrice.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
