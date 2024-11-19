namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private object comboBoxSortiranje;
        private object vozila;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            comboBoxSortiranje.Items.AddRange(new string[] { "Marka", "Model", "GodinaProizvodnje", "Kilometraza" });
            LoadData();
        }

        private void LoadData()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marka = txtMarka.Text;
            string model = txtModel.Text;
            int godinaProizvodnje;
            int kilometraza;


            if (!int.TryParse(txtGodinaProizvodnje.Text, out godinaProizvodnje) || godinaProizvodnje <= 0)
            {
                MessageBox.Show("Godina proizvodnje mora biti pozitivan broj.");
                return;
            }

            if (!int.TryParse(txtKilometraza.Text, out kilometraza) || kilometraza < 0)
            {
                MessageBox.Show("Kilometraža mora biti pozitivan broj.");
                return;
            }

            Vozila novoVozilo = new Vozila(marka, model, godinaProizvodnje, kilometraza);
            vozila.Add(novoVozilo);


            RefreshVozilaList();
            ClearInputFields();
        }

        private void txtMarka_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kriterij = comboBoxSortiranje.SelectedItem.ToString();
            bool uzlazno = radioButtonUzlazno.Checked;

            // Sortiranje prema odabranom kriteriju
            var sortiranaVozila = vozila.AsEnumerable();

            switch (kriterij)
            {
                case "Marka":
                    sortiranaVozila = uzlazno ? sortiranaVozila.OrderBy(v => v.Marka) : sortiranaVozila.OrderByDescending(v => v.Marka);
                    break;
                case "Model":
                    sortiranaVozila = uzlazno ? sortiranaVozila.OrderBy(v => v.Model) : sortiranaVozila.OrderByDescending(v => v.Model);
                    break;
                case "GodinaProizvodnje":
                    sortiranaVozila = uzlazno ? sortiranaVozila.OrderBy(v => v.GodinaProizvodnje) : sortiranaVozila.OrderByDescending(v => v.GodinaProizvodnje);
                    break;
                case "Kilometraza":
                    sortiranaVozila = uzlazno ? sortiranaVozila.OrderBy(v => v.Kilometraza) : sortiranaVozila.OrderByDescending(v => v.Kilometraza);
                    break;
            }

            // Prikaz sortirane liste u TextBox-u
            txtSortiranaVozila.Text = string.Join(Environment.NewLine, sortiranaVozila.Select(v => v.ToString()));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
