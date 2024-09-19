using BT1.Class;
using BT1.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT1
{
    public partial class Form1 : Form
    {
        AnimalHandler animalHandler;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            animalHandler = new AnimalHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {                        
            animalHandler.AddAnimal(new Cow());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = animalHandler.getGridData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            animalHandler.AddAnimal(new Sheep());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            animalHandler.AddAnimal(new Goat());
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
