using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace darba_algas_kalkulators
{
    public partial class darba_algas_kalkulators : Form
    {
        public darba_algas_kalkulators()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Sbar_eur_Scroll(object sender, ScrollEventArgs e)
        {
            lb_alga.Text = Sbar_eur.Value.ToString();
            txtbox_eur.Text = Sbar_eur.Value.ToString();
            UpdateListBox();
        }
        private void txtbox_eur_TextChanged(object sender, EventArgs e)
        {
            UpdateScrollBarAndLabel();
            UpdateListBox();
        }
        private void UpdateScrollBarAndLabel()
        {
            // Parse the text from the textbox to a number
            if (int.TryParse(txtbox_eur.Text, out int textBoxValue))
            {
                // Ensure the value is within the range of the scroll bar
                textBoxValue = Math.Max(Math.Min(textBoxValue, Sbar_eur.Maximum), Sbar_eur.Minimum);

                // Set the scroll bar value to the value entered in the text box
                Sbar_eur.Value = textBoxValue;

                // Update the label with the same value
                lb_alga.Text = textBoxValue.ToString();
            }
        }
        private void UpdateListBox()
        {
            // Clear the items in the ListBox
            listbox_alga2024.Items.Clear();
            listbox_alga2023.Items.Clear();

            // Retrieve the scroll bar value
            int scrollBarValue = Sbar_eur.Value;
            int textBoxValue = 0;
            if (!int.TryParse(txtbox_eur.Text, out textBoxValue))
            {
                // Handle invalid input
                // For example, set a default value or display an error message
                textBoxValue = 0; // Default value
            }

            // Calculate 89.5% of the scroll bar value
            double combinedValue1 = (scrollBarValue * 0.895);
            double combinedValue2 = (textBoxValue * 0.895);

            // Add the calculated value to the ListBox
            listbox_alga2024.Items.Add(combinedValue1.ToString());
            listbox_alga2023.Items.Add(combinedValue1.ToString());
        }

        private void cb_nodGram_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBoxWithComboBox();
        }
        private void UpdateListBoxWithComboBox()
        {
            // Parse the text from the textbox to a number
            if (double.TryParse(txtbox_eur.Text, out double textBoxValue))
            {
                // Calculate the index based on the textbox value multiplied by 89.5%
                int index1 = (int)(textBoxValue * 0.895);
                int index2 = (int)(textBoxValue * 0.696);

                // Ensure the index is within the range of the ComboBox
                index1 = Math.Max(Math.Min(index1, cb_nodGram.Items.Count - 1), 0);
                index2 = Math.Max(Math.Min(index1, cb_nodGram.Items.Count - 1), 0);

                // Set the selected index of the ComboBox
                cb_nodGram.SelectedIndex = index1;
                cb_nodGram.SelectedIndex = index2;
            }
        }
    }
}
      